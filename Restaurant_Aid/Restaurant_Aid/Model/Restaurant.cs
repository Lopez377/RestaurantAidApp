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
    [Serializable]
    public class Restaurant
    {
        public string username { get; set; }
        public string phone { get; set; }
        public string passhash { get; set; }
        public string address { get; set; }
        public int id { get; set; }
        public string loc { get; set; }
        public string name { get; set; }
    }
}


//[{"username": "ABC", "phone": "3434", "passhash": "hash", "address": "123 a", "id": 1, "gps_location": "loc", "name": "name"