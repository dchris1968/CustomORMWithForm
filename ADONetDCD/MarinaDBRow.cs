using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetDCD
{
    class MarinaDBRow
    {
        public string id;
        public string name;
        public string address;
        public string city;
        public string state;
        public string zip;

        public MarinaDBRow(string id, string name, string address, string city, string state, string zip)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
        }

        public MarinaDBRow()
        {
        }
     }
}
