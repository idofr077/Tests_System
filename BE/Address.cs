using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE  // a class to set adresses.
{
    public struct Address
    {
        public string street;
        public int num;
        public string city;
        
        public Address(string street, int num, string city) //C_Tor
        {
            this.street = street;
            this.num = num;
            this.city = city;
        }
        public override string ToString()
        {
            return street + " " + num + " " + city;
        }
    }
}
