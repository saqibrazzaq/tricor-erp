using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Customer;

namespace Database.Customer
{
    public class AddressDB
    {
        //get all address related to an customer from database.

        public static List<AddressModel> getCustomerAddresses(String ID)
        {
            List<AddressModel> customers = new List<AddressModel>();

            String sql = @"select Address.City City, Address.Location Location, Address.PhoneNo Phoneno
                          from Customer
                          join CustomerAddress on Customer.Id = CustomerAddress.Customer_ID
                          join Address on CustomerAddress.Address_ID=Address.id
                          where Customer.Id='" + ID + "';";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel customer = new AddressModel();
                customer.City = reader["City"].ToString();
                customer.Location = reader["Location"].ToString();
                customer.Phonenumber = reader["Phoneno"].ToString();
                customers.Add(customer);
            }
            return customers;
        }

        //set address within database
        public Boolean addAddress() {
            
            return true;
        }

    }
}
