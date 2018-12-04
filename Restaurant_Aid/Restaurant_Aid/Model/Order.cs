using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Aid.Model
{
    class Order
    {
        public int id { get; set; }
        public int mid { get; set; }
        public int rid { get; set; }
        public int pid { get; set; }
        public int oid { get; set; }
        public string status { get; set; }
        public string detail { get; set; }
    }
}
