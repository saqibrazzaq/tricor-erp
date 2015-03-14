using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Login
{
    // Make this class public
    public class UserModel
    {
        public int ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public int RoleID { get; set; }
    }
}
