using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant_Aid.Model
{
    class Profile
    {
        public int id { get; set; }
        public string username { get; set; }
        public string passhash { get; set; }
        public string email { get; set; }
        public string dob { get; set; }
    }
}
