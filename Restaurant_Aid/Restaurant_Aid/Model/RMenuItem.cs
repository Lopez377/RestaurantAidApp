using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System;
using System.ComponentModel;
using System.Collections.Specialized;

namespace Restaurant_Aid.Model
{
   public class RMenuItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public int rid { get; set; }
    }
}
