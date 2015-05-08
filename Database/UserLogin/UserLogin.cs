using Models.POS.User;
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
                String sql = "select * from [User] where UserName = '" + username + "' and Password='" + password + "'";
                SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                if (reader.Read()) // Read() gets first record
                {
                    userModel = new UserModel()
                    {
                        ID = reader["ID"].ToString(),
                        Name = reader["Username"].ToString(),
                        Password = reader["Password"].ToString(),
                        Role = reader["RoleID"].ToString(),
                        WHID = reader["WarehouseID"].ToString()
                    };
                }
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return userModel;
        }


        public static int deleteUser(string UserID, SqlTransaction trans)
        {
            String sql = @"DELETE FROM [dbo].[User]
                         WHERE [User].ID='" + UserID + "';";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

    }
}
