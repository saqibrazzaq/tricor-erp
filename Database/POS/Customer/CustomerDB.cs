using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.POS.Customer;
using System.Data.SqlClient;

namespace Database.POS.Customer
{
    public class CustomerDB
    {
        //get all the data of customer from database. 
        public static List<CustomerModel> getCustomersList(String searchtext)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            String sql = @"select Customer.Id ID, Customer.Name Name, Address.PhoneNo Phoneno
                        from Customer
                        join CustomerAddress on Customer.Id=CustomerAddress.Customer_ID
                        join Address on Address.Id=CustomerAddress.Address_ID
                        where 1=1
                        and 
	                    (Customer.Name like '%" + searchtext + "%' or Address.PhoneNo like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                CustomerModel customer = new CustomerModel();
                customer.ID = reader["ID"].ToString();
                customer.Name = reader["Name"].ToString();
                customer.Phonenumber = reader["Phoneno"].ToString();
                customers.Add(customer);
            }
            return customers;
        }

        //get all basic information related to the an customer
        public static CustomerModel getCustomerInFo(String ID)
        {
            CustomerModel customer = new CustomerModel();
            String sql;
            int value;
            if (int.TryParse(ID, out value))
            {
                 sql = @"SELECT [Id] ID ,[Name] Name ,[CNIC] CNIC ,[Gender] Gender ,[Type] Type FROM [dbo].[Customer] where Id = '" + ID + "'";
            }
            else 
            {
                 sql = @"SELECT [Id] ID ,[Name] Name ,[CNIC] CNIC ,[Gender] Gender ,[Type] Type FROM [dbo].[Customer] where [CNIC]='" + ID + "'";
            }

            
            //String sql = @"select Customer.Name Name, Customer.CNIC CNIC, Customer.Gender Gender from Customer where Customer.Id='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                customer.ID = reader["ID"].ToString();
                customer.Name = reader["Name"].ToString();
                customer.CNIC = reader["CNIC"].ToString();
                customer.Gender = reader["Gender"].ToString();
                customer.Type = int.Parse(reader["Type"].ToString());
            }
            return customer;
        }

        // save data of new customer in DB
        public static CustomerModel addNewCustomer(CustomerModel newcustomer)
        {
            String sql = @"INSERT INTO [dbo].[Customer] ([Name],[CNIC],[Gender],[Type])
            output inserted.ID 
            VALUES('" + newcustomer.Name + "','" + newcustomer.CNIC + "','" + newcustomer.Gender + "','" + newcustomer.Type + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newcustomer.ID = id.ToString();
            return newcustomer;
        }

        //update customer data
        public static int updateCustomer(CustomerModel updatecustomer)
        {
            String sql = @"UPDATE [dbo].[Customer]
                         SET [Name] = '" + updatecustomer.Name + "' ,[CNIC] = '" + updatecustomer.CNIC + "',[Gender] = '" + updatecustomer.Gender
                         + "',[Type] = '"+updatecustomer.Type+"' WHERE Customer.Id = '" + updatecustomer.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        // get all data of customer and return a list of customer. 
        //public static List<CustomerModel> getallCustomer()
        //{
        //    List<CustomerModel> customers = new List<CustomerModel>();
        //    String sql = @"SELECT * FROM Customer";
        //    SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
        //    while (reader.Read())
        //    {
        //        CustomerModel customer = new CustomerModel();
        //        customer.ID = reader["ID"].ToString();
        //        customer.Name = reader["Name"].ToString();
        //        customers.Add(customer);
        //    }
        //    return customers;
        //}

        // add new address in Customer Address and return an integer value for it
        public static int addAddress(string customerID, String CustomerAddressID)
        {
            String sql = @"insert into CustomerAddress(Customer_ID, Address_ID)
                            output inserted.ID 
                                        values('" + customerID + "', '" + CustomerAddressID + "')";

            Object check = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            if ((check.ToString()) != null)
                return 1;
            else
                return 0;
        }

        public static int deleteAddress(String CustomerID, String AddressID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                String sql = @"DELETE FROM [CustomerAddress] WHERE Customer_ID='" + CustomerID + "' and Address_ID='" + AddressID + "';";
                int check = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, null);
                if (check == 1)
                {
                    int check2 = Database.Common.AddressDB.deleteAddress(AddressID, trans);

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
                e.ToString();
            }
            finally
            {
                con.Close();
            }
            return 1;
        }


        public static int getCustomerCount()
        {
            String sql = @"SELECT COUNT (*) as Customer FROM [dbo].Customer";
            object customercount = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(customercount.ToString());
        }
    }
}
