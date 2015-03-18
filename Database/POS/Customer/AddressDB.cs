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
        private String customerID;
        public AddressDB() {
            customerID = null;
        }
        public void setCustomerID(String ID) {
            customerID = ID;
        }
        
        //get all address related to an customer from database.
        public static List<AddressModel> getCustomerAddresses(String ID)
        {
            List<AddressModel> customerAddresses = new List<AddressModel>();

            String sql = @"select Address.City City, Address.Location1 Location1, Address.PhoneNo Phoneno
                          from Customer
                          join CustomerAddress on Customer.Id = CustomerAddress.Customer_ID
                          join Address on CustomerAddress.Address_ID=Address.id
                          where Customer.Id='" + ID + "';";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.City = reader["City"].ToString();
                address.Location1 = reader["Location1"].ToString();
                address.Phonenumber = reader["Phoneno"].ToString();
                customerAddresses.Add(address);
            }
            return customerAddresses;
        }

        //set address within database and return id of inserted address.
        public static AddressModel addAddress(AddressModel newaddress, String customerID)
        {
            //AddressDB db = new AddressDB();
            //db.setCustomerID(customerID);

            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //trans. = System.Data.IsolationLevel.ReadUncommitted;

                String sql = @"insert into Address(City, Location1, PhoneNo, Email, Location2)
                         output inserted.ID 
                         values ('" + newaddress.City + "', '" + newaddress.Location1 + "', '" + newaddress.Phonenumber + "', '" + newaddress.Email + "', '" + newaddress.Location2 + "')";
                object id = DBUtility.SqlHelper.ExecuteScalar(trans, con, System.Data.CommandType.Text, sql, null);
                newaddress.ID = int.Parse(id.ToString());

                String sql2 = @"insert into CustomerAddress(Customer_ID, Address_ID)
                            values('" + customerID + "', '" + newaddress.ID + "')";
                DBUtility.SqlHelper.ExecuteScalar(trans, con, System.Data.CommandType.Text, sql2, null);

                trans.Commit();
            }
            catch(Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
            // End
            
            

            return newaddress;
        }

    }
}
