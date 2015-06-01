using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataUpdataSerivce.Entity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Threading;

namespace DataUpdataSerivce
{
    public static class SQLHelper
    {

        #region 查询
        public static int FindCount(string tableName)
        {
            string sql = string.Format("SELECT COUNT(1) FROM [{0}]", tableName);
            object obj = SQLHelper.ExecuteScalar(GetConnection(), CommandType.Text, sql);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public static List<field> FindTable(string tableName)
        {
            string sql = @"SELECT a.name AS N,b.name AS T,a.max_length AS L,a.[precision] as B,a.scale  as S FROM sys.columns AS a
LEFT JOIN sys.types AS b on a.system_type_id=b.system_type_id and a.user_type_id=b.user_type_id
WHERE object_id =(select top 1 object_id from sys.objects where type='U' and name=@tableName)";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@tableName",tableName)
            };
            DataSet ds = SQLHelper.ExecuteQuery(GetConnection(), CommandType.Text, sql, paras);

            List<field> result = new List<field>();
            if (ds.Tables.Count > 0)
            {
                DataTable table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dr = table.Rows[i];
                    field fieldItem = new field();
                    fieldItem.name = dr["N"].ToString();
                    fieldItem.type = dr["T"].ToString();
                    if ("decimal".Equals(dr["T"].ToString()))
                    {
                        fieldItem.length = string.Format("{0},{1}", dr["B"].ToString(), dr["S"].ToString());
                    }
                    else
                    {
                        fieldItem.length = dr["L"].ToString();
                    }
                    result.Add(fieldItem);
                }
            }

            return result;



        }

        public static List<data> FindData(FindDataEntity entity)
        {
            List<data> result = new List<data>();
            string sql = string.Format("SELECT TOP 10 * FROM [{0}] ", entity.TableName);
            List<SqlParameter> parasList = new List<SqlParameter>();
            if (entity.FilterItems != null && entity.FilterItems.Count > 0)
            {
                string whereStr = string.Empty;
                for (int i = 0; i < entity.FilterItems.Count; i++)
                {
                    if (i == 0)
                    {
                        whereStr += string.Format(" [{0}] =@{0}", entity.FilterItems[i].Name);
                    }
                    else
                    {
                        whereStr += string.Format(" AND [{0}] = @{0}", entity.FilterItems[i].Name);
                    }
                    parasList.Add(new SqlParameter("@" + entity.FilterItems[i].Name, entity.FilterItems[i].Value));

                }


                sql += " WHERE " + whereStr;
            }

            DataSet ds = SQLHelper.ExecuteQuery(GetConnection(), CommandType.Text, sql, parasList.ToArray());
            if (ds.Tables.Count > 0)
            {
                DataTable table = ds.Tables[0];
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    DataRow dr = table.Rows[i];
                    data dataItem = new data();
                    List<dataItem> items = new List<dataItem>();
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        dataItem item = new dataItem();
                        item.name = table.Columns[j].ColumnName;
                        item.value = dr[j].ToString();
                        items.Add(item);
                    }
                    dataItem.items = items;
                    result.Add(dataItem);
                }
            }


            return result;
        }

        #endregion
        #region 操作
        /// <summary>
        /// C/U/D操作
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool ExecuteSqlByUpdateDataDate(UpdateDataData date)
        {
            if (date.Operate == 1 || date.Operate == 2)
            {

                string sql = string.Empty;


                string sourceDataStr = string.Empty;
                string primaryKeyStr = string.Empty;
                string paraStr = string.Empty;
                string updateStr = string.Empty;
                string insertStrCol = string.Empty;
                string insertStrVal = string.Empty;
                SqlParameter[] paras = new SqlParameter[date.Record.Count];
                for (int i = 0; i < date.Record.Count; i++)
                {
                    RecordItem item = date.Record[i];
                    //构建Update和Insert语句
                    if (!item.IsNotBeInsertOrUpdate)
                    {
                        updateStr += string.Format("T.[{0}]=S.[{0}],", item.Name);
                        insertStrCol += string.Format("[{0}],", item.Name);
                        insertStrVal += string.Format("S.[{0}],", item.Name);

                    }

                    //构建主键条件列
                    if (item.IsPrimaryKey)
                    {
                        if (string.Empty.Equals(primaryKeyStr))
                        {
                            primaryKeyStr += string.Format(" T.[{0}] = S.[{0}]", item.Name);
                        }
                        else
                        {
                            primaryKeyStr += string.Format(" and T.[{0}] = S.[{0}]", item.Name);
                        }
                    }

                    sourceDataStr += string.Format(" @{0} AS [{0}],", item.Name);
                    paras[i] = GetParameter(item.Name, item.Type, item.Length);
                    paras[i].Value = GetParameterValue(item.Type, item.Value);
                }
                #region sql
                sql = string.Format(@"MERGE INTO [{0}] AS T
USING
 ( SELECT  {1} ) as S
ON {2}
WHEN MATCHED
THEN UPDATE SET {3}
WHEN NOT MATCHED
THEN INSERT({4}) VALUES({5});", date.TableName, sourceDataStr.TrimEnd(','), primaryKeyStr, updateStr.TrimEnd(','), insertStrCol.TrimEnd(','), insertStrVal.TrimEnd(','));

                #endregion
                int rowCount = ExecuteNonQuery(GetConnection(), CommandType.Text, sql, paras);
                return rowCount > 0;

            }
            else
            {
                string primaryKeyStr = string.Empty;
                List<SqlParameter> paras = new List<SqlParameter>();
                for (int i = 0; i < date.Record.Count; i++)
                {
                    RecordItem item = date.Record[i];
                    //构建主键条件列
                    if (item.IsPrimaryKey)
                    {
                        if (string.Empty.Equals(primaryKeyStr))
                        {
                            primaryKeyStr += string.Format("[{0}]=@{0}", item.Name);
                        }
                        else
                        {
                            primaryKeyStr += string.Format(" and [{0}]=@{0}", item.Name, item.Name);
                        }
                    }
                    paras.Add(GetParameter(item.Name, item.Type, item.Length));
                    paras[i].Value = GetParameterValue(item.Type, item.Value); ;
                }
                string sql = string.Format("DELETE FROM [{0}] WHERE {1}", date.TableName, primaryKeyStr);
                SQLHelper.ExecuteNonQuery(GetConnection(), CommandType.Text, sql, paras.ToArray());
                return true;
            }

        }

        /// <summary>
        /// 添加或修改列的方法
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static bool ExecuteSqlByAddField(AddFieldEntity field)
        {

            string coulmnExistsSql = "SELECT top 1 object_id FROM sys.columns WHERE  name=@columnName and object_id =(SELECT object_id FROM sys.objects WHERE TYPE='U' and name=@tableName)";
            SqlParameter[] paras = new SqlParameter[]{
            new SqlParameter("@columnName",field.FieldName),
            new SqlParameter("@tableName",field.TableName)
            };
            bool isExits = SQLHelper.ExecuteScalar(GetConnection(), CommandType.Text, coulmnExistsSql, paras) != null;

            string sql = string.Empty;
            if (isExits)
            {
                if (SqlDbType.Decimal.ToString().ToLower().Equals(field.FieldType.ToLower()))
                {
                    int length = int.Parse(field.FieldLength.Split(',')[0]);
                    int length1 = int.Parse(field.FieldLength.Split(',')[1]);
                    sql = string.Format("ALTER TABLE [{0}] {1}", field.TableName, GetALTERColumnStr(field.FieldName, field.FieldType, length, length1));
                }
                else
                {
                    sql = string.Format("ALTER TABLE [{0}] {1}", field.TableName, GetALTERColumnStr(field.FieldName, field.FieldType, int.Parse(field.FieldLength), 0));
                }
            }
            else
            {
                if (SqlDbType.Decimal.ToString().ToLower().Equals(field.FieldType.ToLower()))
                {
                    int length = int.Parse(field.FieldLength.Split(',')[0]);
                    int length1 = int.Parse(field.FieldLength.Split(',')[1]);
                    sql = string.Format("ALTER TABLE [{0}] {1}", field.TableName, GetAddColumnStr(field.FieldName, field.FieldType, length, length1));
                }
                else
                {
                    sql = string.Format("ALTER TABLE [{0}] {1}", field.TableName, GetAddColumnStr(field.FieldName, field.FieldType, int.Parse(field.FieldLength), 0));
                }
            }
            int n = ExecuteNonQuery(GetConnection(), CommandType.Text, sql, null);
            if (n == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool ExecuteSqlByAddTable(AddTableEntity table)
        {
            string baseSQL = @"CREATE TABLE [{0}](
	{1}
";
            string indexName = string.Format("PK_{0}", table.TableName);
            string columnStr = string.Empty;
            string pkStr = @" CONSTRAINT [{2}] PRIMARY KEY CLUSTERED 
(
	{3}
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]";
            string pkCol = string.Empty;
            bool isExitsPK = false;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                ColumnItem item = table.Columns[i];
                if (item.IsPrimaryKey)
                {
                    isExitsPK = true;
                    columnStr += string.Format("{0} NOT NULL,", GetColumnTypeStr(item.Name, item.Type, item.GetLegth(), item.GetLegth1()));
                    pkCol += string.Format(" [{0}],", item.Name);
                }
                else
                {
                    columnStr += string.Format(" {0} ,", GetColumnTypeStr(item.Name, item.Type, item.GetLegth(), item.GetLegth1()));
                }
            }
            string sql = string.Empty;
            if (isExitsPK)
            {
                sql = string.Format(baseSQL + pkStr, table.TableName, columnStr.TrimEnd(','), indexName, pkCol.TrimEnd(','));

            }
            else
            {
                sql = string.Format(baseSQL + ")", table.TableName, columnStr.TrimEnd(','));
            }
            int result = SQLHelper.ExecuteNonQuery(GetConnection(), CommandType.Text, sql, null);
            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region 辅助
        private static string GetParameterValue(string typeStr, string value)
        {

            switch (typeStr.ToLower())
            {
                case "bigint":
                case "binary":
                case "bit":
                case "datetime":
                case "decimal":
                case "float":
                case "image":
                case "int":
                case "money":
                case "real":
                case "uniqueidentifier":
                case "smalldatetime":
                case "smallint":
                case "smallmoney":
                case "timestamp":
                case "tinyint":
                case "varbinary":
                case "variant":
                case "xml":
                case "udt":
                case "structured":
                case "date":
                case "time":
                case "datetime2":
                case "datetimeoffset":
                    if (string.IsNullOrEmpty(value))
                    {
                        return null;
                    }
                    else
                    {
                        return value;
                    }
                case "char":
                case "nchar":
                case "ntext":
                case "nvarchar":
                case "text":
                case "varchar":
                    return value;
                default:
                    throw new Exception("类型不存在");
            }
        }
        /// <summary>
        /// 根据所传递的参数生成sqlParameter
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="typeStr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private static SqlParameter GetParameter(string paraName, string typeStr, string length1)
        {
            int length = 0;
            if (!"decimal".Equals(typeStr.ToLower()))
            {
                length = int.Parse(length1);
            }
            string parameterName = "@" + paraName;
            switch (typeStr.ToLower())
            {
                case "bigint":
                    return new SqlParameter(parameterName, SqlDbType.BigInt, length);
                case "binary":
                    return new SqlParameter(parameterName, SqlDbType.Binary, length);
                case "bit":
                    return new SqlParameter(parameterName, SqlDbType.Bit);
                case "char":
                    return new SqlParameter(parameterName, SqlDbType.Char, length);
                case "datetime":
                    return new SqlParameter(parameterName, SqlDbType.DateTime);
                case "decimal":
                    return new SqlParameter(parameterName, SqlDbType.Decimal);
                case "float":
                    return new SqlParameter(parameterName, SqlDbType.Float, length);
                case "image":
                    return new SqlParameter(parameterName, SqlDbType.Image);
                case "int":
                    return new SqlParameter(parameterName, SqlDbType.Int, length);
                case "money":
                    return new SqlParameter(parameterName, SqlDbType.Money);
                case "nchar":
                    return new SqlParameter(parameterName, SqlDbType.NChar, length);
                case "ntext":
                    return new SqlParameter(parameterName, SqlDbType.NText);
                case "nvarchar":
                    return new SqlParameter(parameterName, SqlDbType.NVarChar, length);
                case "real":
                    return new SqlParameter(parameterName, SqlDbType.Real);
                case "uniqueidentifier":
                    return new SqlParameter(parameterName, SqlDbType.UniqueIdentifier);
                case "smalldatetime":
                    return new SqlParameter(parameterName, SqlDbType.SmallDateTime);
                case "smallint":
                    return new SqlParameter(parameterName, SqlDbType.SmallInt);
                case "smallmoney":
                    return new SqlParameter(parameterName, SqlDbType.SmallMoney);
                case "text":
                    return new SqlParameter(parameterName, SqlDbType.Text);
                case "timestamp":
                    return new SqlParameter(parameterName, SqlDbType.Timestamp);
                case "tinyint":
                    return new SqlParameter(parameterName, SqlDbType.TinyInt);
                case "varbinary":
                    return new SqlParameter(parameterName, SqlDbType.VarBinary, length);
                case "varchar":
                    return new SqlParameter(parameterName, SqlDbType.VarChar, length);
                case "variant":
                    return new SqlParameter(parameterName, SqlDbType.Variant);
                case "xml":
                    return new SqlParameter(parameterName, SqlDbType.Xml);
                case "udt":
                    return new SqlParameter(parameterName, SqlDbType.Udt);
                case "structured":
                    return new SqlParameter(parameterName, SqlDbType.Structured);
                case "date":
                    return new SqlParameter(parameterName, SqlDbType.Date);
                case "time":
                    return new SqlParameter(parameterName, SqlDbType.Time, length);
                case "datetime2":
                    return new SqlParameter(parameterName, SqlDbType.DateTime2, length);
                case "datetimeoffset":
                    return new SqlParameter(parameterName, SqlDbType.DateTimeOffset, length);
                default:
                    throw new Exception("类型不存在");
            }
        }
        /// <summary>
        /// 获取添加列的SQL后半部分
        /// </summary>
        /// <param name="columnStr"></param>
        /// <param name="typeStr"></param>
        /// <param name="length"></param>
        /// <param name="length1"></param>
        /// <returns></returns>
        private static string GetAddColumnStr(string columnStr, string typeStr, int length, int length1)
        {
            string result = string.Empty;

            switch (typeStr.ToLower())
            {
                case "bigint":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "bigint");
                    break;
                case "binary":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "binary", length);
                    break;
                case "bit":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "bit");
                    break;
                case "char":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "char", length);
                    break;
                case "datetime":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "datetime");
                    break;
                case "decimal":
                    result = string.Format(" ADD [{0}] {1}({2},{3})", columnStr, "decimal", length, length1);
                    break;
                case "float":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "float", length);
                    break;
                case "image":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "image");
                    break;
                case "int":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "int");
                    break;
                case "money":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "money");
                    break;
                case "nchar":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "nchar", length);
                    break;
                case "ntext":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "ntext");
                    break;
                case "nvarchar":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "nvarchar", length);
                    break;
                case "real":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "real");
                    break;
                case "uniqueidentifier":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "uniqueidentifier");
                    break;
                case "smalldatetime":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "smalldatetime");
                    break;
                case "smallint":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "smallint");
                    break;
                case "smallmoney":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "smallmoney");
                    break;
                case "text":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "text");
                    break;
                case "timestamp":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "timestamp");
                    break;
                case "tinyint":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "tinyint");
                    break;
                case "varbinary":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "varbinary", length);
                    break;
                case "varchar":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "varchar", length);
                    break;
                case "variant":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "sql_variant");
                    break;
                case "xml":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "xml");
                    break;
                case "date":
                    result = string.Format(" ADD [{0}] {1}", columnStr, "date");
                    break;
                case "time":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "time", length);
                    break;
                case "datetime2":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "datetime2", length);
                    break;
                case "datetimeoffset":
                    result = string.Format(" ADD [{0}] {1}({2})", columnStr, "datetimeoffset", length);
                    break;
                default:
                    throw new Exception("未知的数据类型");
            }
            return result;
        }

        /// <summary>
        /// 获取修改列的SQL后半部分
        /// </summary>
        /// <param name="columnStr"></param>
        /// <param name="typeStr"></param>
        /// <param name="length"></param>
        /// <param name="length1"></param>
        /// <returns></returns>
        private static string GetALTERColumnStr(string columnStr, string typeStr, int length, int length1)
        {
            string result = string.Empty;

            switch (typeStr.ToLower())
            {
                case "bigint":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "bigint");
                    break;
                case "binary":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "binary", length);
                    break;
                case "bit":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "bit");
                    break;
                case "char":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "char", length);
                    break;
                case "datetime":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "datetime");
                    break;
                case "decimal":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2},{3})", columnStr, "decimal", length, length1);
                    break;
                case "float":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "float", length);
                    break;
                case "image":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "image");
                    break;
                case "int":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "int");
                    break;
                case "money":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "money");
                    break;
                case "nchar":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "nchar", length);
                    break;
                case "ntext":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "ntext");
                    break;
                case "nvarchar":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "nvarchar", length);
                    break;
                case "real":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "real");
                    break;
                case "uniqueidentifier":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "uniqueidentifier");
                    break;
                case "smalldatetime":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "smalldatetime");
                    break;
                case "smallint":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "smallint");
                    break;
                case "smallmoney":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "smallmoney");
                    break;
                case "text":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "text");
                    break;
                case "timestamp":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "timestamp");
                    break;
                case "tinyint":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "tinyint");
                    break;
                case "varbinary":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "varbinary", length);
                    break;
                case "varchar":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "varchar", length);
                    break;
                case "variant":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "sql_variant");
                    break;
                case "xml":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "xml");
                    break;
                case "date":
                    result = string.Format(" ALTER COLUMN [{0}] {1}", columnStr, "date");
                    break;
                case "time":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "time", length);
                    break;
                case "datetime2":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "datetime2", length);
                    break;
                case "datetimeoffset":
                    result = string.Format(" ALTER COLUMN [{0}] {1}({2})", columnStr, "datetimeoffset", length);
                    break;
                default:
                    throw new Exception("未知的数据类型");
            }
            return result;
        }

        /// <summary>
        /// 获取字段类型
        /// </summary>
        /// <param name="columnStr"></param>
        /// <param name="typeStr"></param>
        /// <param name="length"></param>
        /// <param name="length1"></param>
        /// <returns></returns>
        private static string GetColumnTypeStr(string columnStr, string typeStr, int length, int length1)
        {
            string result = string.Empty;

            switch (typeStr.ToLower())
            {
                case "bigint":
                    result = string.Format("[{0}] {1}", columnStr, "bigint");
                    break;
                case "binary":
                    result = string.Format("[{0}] {1}({2})", columnStr, "binary", length);
                    break;
                case "bit":
                    result = string.Format("[{0}] {1}", columnStr, "bit");
                    break;
                case "char":
                    result = string.Format("[{0}] {1}({2})", columnStr, "char", length);
                    break;
                case "datetime":
                    result = string.Format("[{0}] {1}", columnStr, "datetime");
                    break;
                case "decimal":
                    result = string.Format("[{0}] {1}({2},{3})", columnStr, "decimal", length, length1);
                    break;
                case "float":
                    result = string.Format("[{0}] {1}({2})", columnStr, "float", length);
                    break;
                case "image":
                    result = string.Format("[{0}] {1}", columnStr, "image");
                    break;
                case "int":
                    result = string.Format("[{0}] {1}", columnStr, "int");
                    break;
                case "money":
                    result = string.Format("[{0}] {1}", columnStr, "money");
                    break;
                case "nchar":
                    result = string.Format("[{0}] {1}({2})", columnStr, "nchar", length);
                    break;
                case "ntext":
                    result = string.Format("[{0}] {1}", columnStr, "ntext");
                    break;
                case "nvarchar":
                    result = string.Format("[{0}] {1}({2})", columnStr, "nvarchar", length);
                    break;
                case "real":
                    result = string.Format("[{0}] {1}", columnStr, "real");
                    break;
                case "uniqueidentifier":
                    result = string.Format("[{0}] {1}", columnStr, "uniqueidentifier");
                    break;
                case "smalldatetime":
                    result = string.Format("[{0}] {1}", columnStr, "smalldatetime");
                    break;
                case "smallint":
                    result = string.Format("[{0}] {1}", columnStr, "smallint");
                    break;
                case "smallmoney":
                    result = string.Format("[{0}] {1}", columnStr, "smallmoney");
                    break;
                case "text":
                    result = string.Format("[{0}] {1}", columnStr, "text");
                    break;
                case "timestamp":
                    result = string.Format("[{0}] {1}", columnStr, "timestamp");
                    break;
                case "tinyint":
                    result = string.Format("[{0}] {1}", columnStr, "tinyint");
                    break;
                case "varbinary":
                    result = string.Format("[{0}] {1}({2})", columnStr, "varbinary", length);
                    break;
                case "varchar":
                    result = string.Format("[{0}] {1}({2})", columnStr, "varchar", length);
                    break;
                case "variant":
                    result = string.Format("[{0}] {1}", columnStr, "sql_variant");
                    break;
                case "xml":
                    result = string.Format("[{0}] {1}", columnStr, "xml");
                    break;
                case "date":
                    result = string.Format("[{0}] {1}", columnStr, "date");
                    break;
                case "time":
                    result = string.Format("[{0}] {1}({2})", columnStr, "time", length);
                    break;
                case "datetime2":
                    result = string.Format("[{0}] {1}({2})", columnStr, "datetime2", length);
                    break;
                case "datetimeoffset":
                    result = string.Format("[{0}] {1}({2})", columnStr, "datetimeoffset", length);
                    break;
                default:
                    throw new Exception("未知的数据类型");
            }
            return result;
        }

        #endregion
        #region 数据库操作
        public static int ExecuteNonQuery(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                return ExecuteNonQuery(connection, commandType, commandText, commandParameters);

            }
        }



        public static int ExecuteNonQuery(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");
            int retval = 0;
            // 创建SqlCommand命令,并进行预处理 
            SqlCommand cmd = new SqlCommand();
            bool mustCloseConnection = false;
            try
            {
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // Finally, execute the command 
                retval = cmd.ExecuteNonQuery();

                // 清除参数,以便再次使用. 
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();
            }
            return retval;
        }
        #region
        private static void PrepareCommand(SqlCommand command, SqlConnection connection, SqlTransaction transaction, CommandType commandType, string commandText, SqlParameter[] commandParameters, out bool mustCloseConnection)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandText == null || commandText.Length == 0) throw new ArgumentNullException("commandText");

            // If the provided connection is not open, we will open it 
            if (connection.State != ConnectionState.Open)
            {
                mustCloseConnection = true;
                connection.Open();
            }
            else
            {
                mustCloseConnection = false;
            }

            // 给命令分配一个数据库连接. 
            command.Connection = connection;

            // 设置命令文本(存储过程名或SQL语句) 
            command.CommandText = commandText;

            // 分配事务 
            if (transaction != null)
            {
                if (transaction.Connection == null) throw new ArgumentException("The transaction was rollbacked or commited, please provide an open transaction.", "transaction");
                command.Transaction = transaction;
            }

            // 设置命令类型. 
            command.CommandType = commandType;

            // 分配命令参数 
            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }
            return;
        }

        #endregion 私有构造函数和方法结束

        #region 数据库连接
        /// <summary> 
        /// 一个有效的数据库连接字符串 
        /// </summary> 
        /// <returns></returns> 
        public static string GetConnSting()
        {
            return ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        }
        /// <summary> 
        /// 一个有效的数据库连接对象 
        /// </summary> 
        /// <returns></returns> 
        public static SqlConnection GetConnection()
        {
            SqlConnection Connection = new SqlConnection(GetConnSting());
            return Connection;
        }
        #endregion

        private static void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (commandParameters != null)
            {
                foreach (SqlParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value. 
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) &&
                            (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法 
            return ExecuteScalar(connectionString, commandType, commandText, (SqlParameter[])null);
        }
        public static object ExecuteScalar(string connectionString, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connectionString == null || connectionString.Length == 0) throw new ArgumentNullException("connectionString");
            // 创建并打开数据库连接对象,操作完成释放对象. 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // 调用指定数据库连接字符串重载方法. 
                return ExecuteScalar(connection, commandType, commandText, commandParameters);
            }
        }

        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText)
        {
            // 执行参数为空的方法 
            return ExecuteScalar(connection, commandType, commandText, (SqlParameter[])null);
        }
        public static object ExecuteScalar(SqlConnection connection, CommandType commandType, string commandText, params SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // 创建SqlCommand命令,并进行预处理 
            SqlCommand cmd = new SqlCommand();

            bool mustCloseConnection = false;
            object retval = null;
            try
            {
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // 执行SqlCommand命令,并返回结果. 
                retval = cmd.ExecuteScalar();

                // 清除参数,以便再次使用. 
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                if (mustCloseConnection)
                    connection.Close();
            }



            return retval;
        }


        private static DataSet ExecuteQuery(SqlConnection connection, CommandType commandType, string commandText, SqlParameter[] commandParameters)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            // 创建SqlCommand命令,并进行预处理 
            SqlCommand cmd = new SqlCommand();

            bool mustCloseConnection = false;
            DataSet ds = new DataSet();
            try
            {
                PrepareCommand(cmd, connection, (SqlTransaction)null, commandType, commandText, commandParameters, out mustCloseConnection);

                // 执行SqlCommand命令,并返回结果. 
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (mustCloseConnection)
                    connection.Close();

            }
            // 清除参数,以便再次使用. 
            cmd.Parameters.Clear();


            return ds;
        }
        public static void ExpandLog()
        {
            ExpandLog(0);

        }
        public static void ExpandLog(int times)
        {
            if (GetLogSize() > 100 && times < 5)
            {
                SQLHelper.ExecuteNonQuery(GetConnection(), CommandType.Text, string.Format("DBCC SHRINKDATABASE([{0}]) ", ConfigurationManager.AppSettings.Get("DataBaseName")), null);
                Thread.Sleep(30000);
                ExpandLog(times + 1);
            }
        }
        private static int GetLogSize()
        {
            DataSet ds = SQLHelper.ExecuteQuery(GetConnection(), CommandType.Text, "dbcc sqlperf(logspace) ", null);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr[0].ToString().ToLower().Equals(ConfigurationManager.AppSettings.Get("DataBaseName").ToLower()))
                {
                    return (int)decimal.Parse(dr[1].ToString());
                }
            }
            return 0;
        }
        #endregion







        internal static bool ImportData(string tableName, string fileName)
        {
            string sql = string.Format(@"  
BEGIN TRAN
TRUNCATE TABLE [{0}]
BULK INSERT [{0}]
FROM '{1}'
 WITH 
 (
  FIELDTERMINATOR = '	',
  ROWTERMINATOR = '\n' 
  
  ) 
  
IF(@@ERROR>0)
ROLLBACK TRAN
ELSE
COMMIT TRAN
  ", tableName, fileName);
            int count = SQLHelper.ExecuteNonQuery(GetConnection(), CommandType.Text, sql, null);
            if (count > 0)
            {
                Thread thread = new Thread(ExpandLog);
                thread.Start();
                FileHelper.DeleteFile(new string[] { fileName });
                return true;
            }
            else
            {
                return false;
            }


        }
    }
}