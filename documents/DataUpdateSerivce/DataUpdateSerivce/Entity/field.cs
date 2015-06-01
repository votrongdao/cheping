using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataUpdataSerivce.Entity
{
    [Serializable]
    public class field
    {
        public string name { get; set; }
        public string type { get; set; }
        public string length { get; set; }
    }
}