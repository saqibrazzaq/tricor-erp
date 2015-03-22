using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.POS.Cashier;
using System.Data.SqlClient;

namespace Database.POS
{
    public class CashierDB
    {
        // addition of new customer in database and return an id of User 
        public static CashierModel addNewCashier(CashierModel newcustomer)
        {
            String sql = @"INSERT INTO [dbo].[User]
           ([Username] ,[Password] ,[RoleID] ,[CNIC])
            output inserted.ID 
            VALUES ('"+newcustomer.Name+"','"+newcustomer.Password+"','2','"+newcustomer.CNIC+"')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newcustomer.ID = int.Parse(id.ToString());
            return newcustomer;
        }
        public static CashierModel getCashierInFo(String CashierID)
        {
            CashierModel cashier = new CashierModel();
            String sql = @"SELECT [ID],[Username] Name,[Password] Password,[RoleID],[CNIC] CNIC FROM [dbo].[User]
                           where ID = '" +CashierID+"'";
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
        public static List<CashierModel> getCustomersList(String searchtext)
        {
            List<CashierModel> cashiers = new List<CashierModel>();
            String sql = @"select top 10 Customer.Id ID, Customer.Name Name, Address.PhoneNo Phoneno
                        from Customer
                        join CustomerAddress on Customer.Id=CustomerAddress.Customer_ID
                        join Address on Address.Id=CustomerAddress.Address_ID
                        where 1=1
                        and 
	                    (Customer.Name like '%" + searchtext + "%' or Address.PhoneNo like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                CashierModel cashier = new CashierModel();
                cashier.ID = int.Parse(reader["ID"].ToString());
                cashier.Name = reader["Name"].ToString();
                //cashier.Phonenumber = reader["Phoneno"].ToString();
                cashiers.Add(cashier);
            }
            return cashiers;
        }


    }
}
