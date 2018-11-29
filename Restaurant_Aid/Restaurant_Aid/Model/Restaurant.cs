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
        private string _Name;
        [XmlIgnore]
        public string Name
        {
            [DebuggerStepThrough]
            get { return _Name; }

            [DebuggerStepThrough]
            set
            {
                if (_Name == value) return;
                _Name = value;
            }
        }
    }
}
