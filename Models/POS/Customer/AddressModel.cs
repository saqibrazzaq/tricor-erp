using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.Customer
{
    public class AddressModel
    {
        public int ID { set; get; }
        public String Location1 { set; get; }
        public String Location2 { set; get; }
       
        public String Phonenumber { set; get; }
        public String City { set; get; }
        public String Email { set; get; }
    }
}
