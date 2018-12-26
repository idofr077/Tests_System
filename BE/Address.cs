using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct Address
    {
        string street;
        int num;
        string city;

        public Address(string street, int num, string city)
        {
            this.street = street;
            this.num = num;
            this.city = city;
        }
    }
}
