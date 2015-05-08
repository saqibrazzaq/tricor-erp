using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.POS.User
{
    public class UserModel
    {
        public String ID { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public String CNIC { get; set; }
        public String PhoneNo { get; set; }
        public String WHID { set; get; }
    }

}
