using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Aid.Model
{
    public class Alert
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int rid { get; set; }
        public string status { get; set; }
        public string detail { get; set; }
    }
}
