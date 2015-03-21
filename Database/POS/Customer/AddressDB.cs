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

            String sql = @"select Address.City City, Address.Id ID, Address.Location1 Location1, Address.PhoneNo Phoneno
                          from Customer
                          join CustomerAddress on Customer.Id = CustomerAddress.Customer_ID
                          join Address on CustomerAddress.Address_ID=Address.id
                          where Customer.Id='" + ID + "';";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.ID = int.Parse(reader["ID"].ToString());
                address.City = reader["City"].ToString();
                address.Location1 = reader["Location1"].ToString();
                address.Phonenumber = reader["Phoneno"].ToString();
                address.ID = int.Parse(reader["ID"].ToString());
                customerAddresses.Add(address);
            }
            return customerAddresses;
        }

        //set address within database and return id of inserted address.
        public static AddressModel addAddress(AddressModel newaddress, String customerID)
        {
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
            return newaddress;
        }

        //Get individually address base on address id  
        public static AddressModel getAddress(String id) {
            String sql = @"SELECT [Id] ID ,[City] City,[Location1] Location1,[PhoneNo] PhoneNo,[Email] Email,[Location2] Location2
                           FROM [dbo].[Address]
                           where Address.Id = '" +id+"'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            AddressModel address = new AddressModel();
            if (reader.Read())
            {
                address.ID = int.Parse(reader["ID"].ToString());
                address.City = reader["City"].ToString();
                address.Location1 = reader["Location1"].ToString();
                address.Phonenumber = reader["PhoneNo"].ToString();
                address.Email = reader["Email"].ToString();
                address.Location2 = reader["Location2"].ToString();
            }
            return address;
        }

        public static int updateAddress(AddressModel updateaddress)
        {
            String sql = @"UPDATE [dbo].[Address]
                         SET [City] = '"+updateaddress.City+"' ,[Location1] = '"+updateaddress.Location1+"' ,[PhoneNo] = '"
                         +updateaddress.Phonenumber+"' ,[Email] = '"+updateaddress.Email+"' ,[Location2] = '"
                         +updateaddress.Location2+"' WHERE Address.Id='"+updateaddress.ID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }


        //delete address of an customer from CustomerAddress table. 
        public static int deleteAddress(String CustomerID, String AddressID, SqlTransaction tran)
        {   
            String sql = @"DELETE FROM [CustomerAddress] WHERE Customer_ID='"+CustomerID+"' and Address_ID='"+AddressID+"';";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
