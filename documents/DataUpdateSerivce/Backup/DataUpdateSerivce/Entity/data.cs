using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class data
    {
        public List<dataItem> items { get; set; }
    }
}