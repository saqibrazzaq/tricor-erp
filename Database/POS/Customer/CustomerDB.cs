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
                CustomerModel customer = new CustomerModel();
                customer.ID = int.Parse(reader["ID"].ToString());
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
            String sql = @"select Customer.Name Name, Customer.CNIC CNIC, Customer.Gender Gender from Customer where Customer.Id='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                customer.Name = reader["Name"].ToString();
                customer.CNIC = reader["CNIC"].ToString();
                customer.Gender = reader["Gender"].ToString();
            }
            return customer;
        }

        // save data of new customer in DB
        public static CustomerModel addNewCustomer(CustomerModel newcustomer)
        {
            String sql = @"INSERT INTO [dbo].[Customer]
                        ([Name],[CNIC],[Gender])
		                output inserted.ID 
                        VALUES ('" + newcustomer.Name + "','" + newcustomer.CNIC + "','" + newcustomer.Gender + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newcustomer.ID = int.Parse(id.ToString());
            return newcustomer;
        }

        //update customer data
        public static int updateCustomer(CustomerModel updatecustomer) {
            String sql = @"UPDATE [dbo].[Customer]
                         SET [Name] = '"+updatecustomer.Name+"' ,[CNIC] = '"+updatecustomer.CNIC+"',[Gender] = '"+updatecustomer.Gender
                         +"' WHERE Customer.Id = '"+updatecustomer.ID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1) {
                return 1;
            }
            return 0;
        }
    }
}
