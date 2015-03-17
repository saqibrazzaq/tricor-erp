using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.POS.Customer;
using System.Data.SqlClient;

namespace Database.POS.Customer
{
    public class AddressDB
    {
        //get all address related to an customer from database.

        public static List<AddressModel> getCustomerAddresses(String ID)
        {
            List<AddressModel> customerAddresses = new List<AddressModel>();

            String sql = @"select Address.City City, Address.Location Location, Address.PhoneNo Phoneno
                          from Customer
                          join CustomerAddress on Customer.Id = CustomerAddress.Customer_ID
                          join Address on CustomerAddress.Address_ID=Address.id
                          where Customer.Id='" + ID + "';";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.City = reader["City"].ToString();
                address.Location = reader["Location"].ToString();
                address.Phonenumber = reader["Phoneno"].ToString();
                customerAddresses.Add(address);
            }
            return customerAddresses;
        }

        //set address within database
        public AddressModel addAddress()
        {

            return null;
        }

    }
}
