using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Customer
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Phonenumber { get; set; }
        public String CNIC { get; set; }
        public String Gender { get; set; }
        public int Type { get; set; }
    }
}
