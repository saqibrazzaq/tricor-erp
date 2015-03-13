using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.UserLogin
{
    public class UserLogin
    {
        public static Boolean loginCheck(String username, String password, String user)
        {
            int success = 0;
            try
            {

                String sql;
                if (user == "Cashier")
                    sql = "select count(*) from CashierInfo where UserName = '" + username + "'and Password='" + password + "'";
                else if (user == "BranchManager")
                    sql = "select count(*) from BranchManager where bm_username = '" + username + "'and bm_password='" + password + "'";
                else
                    return false;

                SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                success = Convert.ToInt32(reader.ToString());
            }
            catch (Exception e)
            {
                e.ToString();
            }
            if (success == 1)
                return true;
            else
                return false;
        }

    }
}
