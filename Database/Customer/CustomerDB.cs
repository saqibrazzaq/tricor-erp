using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Customer;
using System.Data.SqlClient;

namespace Database.CustomerDatabase
{
    public class CustomerDB
    {
        public static List<CustomerModel> getCustomersList(String searchtext)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
//            String sql = @"select Customer.Id ID, Address.PhoneNo Phoneno, Customer.Name Name
//                         from Customer, Address
//                         where 1=1;";
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

    }
}
