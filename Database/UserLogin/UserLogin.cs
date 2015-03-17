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
            try
            {
                String sql;
                if (user == "Cashier")
                    sql = "select count(*) as count from CashierInfo where UserName = '" + username + "'and Password='" + password + "'";
                else if (user == "BranchManager")
                    sql = "select count(*) as count from BranchManager where bm_username = '" + username + "'and bm_password='" + password + "'";
                else
                    return false;

                SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                if (reader.Read()) // Read() gets first record
                {
                    int count = int.Parse(reader["count"].ToString());
                    if (count == 0)
                        return false; // 0 count means no user exists
                    else
                        return true; // means user is found in database
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return false;
        }
    }
}
