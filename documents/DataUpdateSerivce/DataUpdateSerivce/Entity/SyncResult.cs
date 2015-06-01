using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class SyncResult
    {
        public int result { get; set; }
        public string message { get; set; }
        public int count { get; set; }
        public List<field> fields { get; set; }
        public List<data> datas { get; set; }

    }
}