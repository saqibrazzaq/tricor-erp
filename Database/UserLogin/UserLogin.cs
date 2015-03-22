using Models.Login;
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
        public static UserModel loginCheck(String username, String password)
        {
            UserModel userModel = null;
            try
            {
                String sql = "select * from Users where UserName = '" + username + "'and Password='" + password + "'";
                SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                if (reader.Read()) // Read() gets first record
                {
                    userModel = new UserModel()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        Username = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        RoleID = int.Parse(reader["RoleID"].ToString())
                    };
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return userModel;
        }

    }
}
