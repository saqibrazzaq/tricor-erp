using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Customer;
using System.Data.SqlClient;

namespace Database.CustomerDatabase
{
    public class Customer
    {
        public static List<CustomerModel> getCustomersList(String searchtext)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            String sql = @"select Customer.Id ID, Address.PhoneNo Phoneno, Customer.Name Name
                         from Customer, Address
                         where 1=1;";
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
