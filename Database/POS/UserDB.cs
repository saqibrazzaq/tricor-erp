using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.POS.User;
using System.Data.SqlClient;
using Models.POS.Customer;

namespace Database.POS
{
    public class UserDB
    {
        // addition of new customer in database and return an id of User 
        public static UserModel addNewUser(UserModel newuser)
        {
            String sql = null;
            UserModel user = new UserModel();
            Boolean namecheck = checkUserName(newuser.Name);
            Boolean cniccheck = checkUserCNIC(newuser.Name);
            if (namecheck && cniccheck)
            {
                sql = @"INSERT INTO [dbo].[User] ([Username] ,[Password] ,[RoleID] ,[CNIC])
                  output inserted.ID 
                  VALUES ('" + newuser.Name + "','" + newuser.Password + "','"+newuser.Role+"','" + newuser.CNIC + "')";
                object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
                newuser.ID = int.Parse(id.ToString());
                return newuser;
            }
            else
            {
                return null;
            }
        }
        public static Boolean checkUserName(String name)
        {
            String sql = @"SELECT [Username] Name FROM [dbo].[User]
                    where [User].Username = '" + name + "';";
            String UserName = null;
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
                UserName = reader["Name"].ToString();
            if (UserName == name)
                return false;
            return true;
        }
        public static Boolean checkUserCNIC(String name)
        {
            String sql = @"SELECT [CNIC] CNIC FROM [dbo].[User]
                         where [User].Username = '" + name + "';";
            String CNIC = null;
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
                CNIC = reader["CNIC"].ToString();
            if (CNIC == name)
                return false;
            return true;
        }
        // get cashier information and return an object of CashierModel
        public static UserModel getUserInFo(String UserID)
        {
            UserModel cashier = new UserModel();
            String sql = @"SELECT [ID],[Username] Name,[Password] Password,[RoleID],[CNIC] CNIC FROM [dbo].[User]
                           where ID = '" + UserID + "'";
            //SELECT [Username] Name ,[Password] Password FROM [dbo].[User], [CNIC] CNIC where ID = '" + CashierID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                cashier.Name = reader["Name"].ToString();
                cashier.Password = reader["Password"].ToString();
                cashier.CNIC = reader["CNIC"].ToString();
            }
            return cashier;
        }
        //get all data of cashier and return an list.
        public static List<UserModel> getUserList(String searchtext, String roleid)
        {
            List<UserModel> users = new List<UserModel>();
            String sql = @"select top 10 [User].ID ID, [User].Username Name, Address.PhoneNo PhoneNo
                           from [User] 
                           join UserAddress on [User].ID = UserAddress.UserID
                           join Address on Address.Id = UserAddress.AddressID
                           where [User].RoleID="+ roleid
                           +"and([User].Username like '%" + searchtext 
                           + "%' or Address.PhoneNo like '%" + searchtext + "%')";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                UserModel user = new UserModel();
                user.ID = int.Parse(reader["ID"].ToString());
                user.Name = reader["Name"].ToString();
                user.PhoneNo = reader["PhoneNo"].ToString();
                users.Add(user);
            }
            return users;
        }
        // update the cashier data 
        public static int updateUser(UserModel updateuser)
        {
            String sql = @"UPDATE [dbo].[User] SET [Username] = '" + updateuser.Name
                        + "',[Password] = '" + updateuser.Password + "',[CNIC] = '" + updateuser.CNIC + "',[RoleID] ='" + updateuser.Role
                        + "' WHERE [ID]=" + updateuser.ID;
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        // add address into useraddress table of cashier 
        public static int addAddress(string UserID, int CashierAddressID)
        {
            String sql = @"INSERT INTO [dbo].[UserAddress] ([UserID] ,[AddressID])
                             output inserted.ID
                                 VALUES ('" + UserID + "', '" + CashierAddressID + "')";

            Object check = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            if (int.Parse(check.ToString()) > 0)
                return 1;
            else
                return 0;
        }
        //get address of cashier from database and return an list of Cashiers.
        public static List<AddressModel> getUserAddresses(String ID)
        {
            List<AddressModel> useraddresses = new List<AddressModel>();

            String sql = @"select Address.City City, Address.Id ID, Address.Location1 Location1, Address.PhoneNo Phoneno, Address.Email, Address.PhoneNo
                          from [User]
                          join UserAddress on [User].ID = UserAddress.UserID
                          join Address on UserAddress.AddressID=Address.id
                          where [User].ID='" + ID + "';";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.ID = int.Parse(reader["ID"].ToString());
                address.City = reader["City"].ToString();
                address.Location1 = reader["Location1"].ToString();
                address.Phonenumber = reader["Phoneno"].ToString();
                address.ID = int.Parse(reader["ID"].ToString());
                useraddresses.Add(address);
            }
            return useraddresses;
        }
        public static int deleteAddress(String UserID, String AddressID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                String sql = null;
                if(AddressID != null)
                    sql = @"DELETE FROM [dbo].[UserAddress] WHERE [UserAddress].UserID='" + UserID + "' and [UserAddress].AddressID ='" + AddressID + "';";
                else
                    sql = @"DELETE FROM [dbo].[UserAddress] WHERE [UserAddress].UserID='" + UserID + "';";
                int check = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, null);
                if (check > 0)
                {
                    if (AddressID != null)
                        Database.Common.AddressDB.deleteAddress(AddressID, trans);
                    else
                        Database.UserLogin.UserLogin.deleteUser(UserID, trans);
                    
                    trans.Commit();
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        /*That function is return an list of Roles that is getting from database */
        public static List<Models.POS.RoleModel> getRoleList()
        {
            List<Models.POS.RoleModel> roles = new List<Models.POS.RoleModel>();
            String sql = @"select * from Role ";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.RoleModel role = new Models.POS.RoleModel();
                role.ID = int.Parse(reader["ID"].ToString());
                role.Name = reader["Name"].ToString();
                roles.Add(role);
            }
            return roles;
        }
    }
}
