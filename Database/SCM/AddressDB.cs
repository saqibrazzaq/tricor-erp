using Models.Global;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{
    public class AddressDB
    {
        public static List<AddressModel> getWareHouseAddresses(String ID)
        {
            List<AddressModel> wareHouseAddresses = new List<AddressModel>();

            String sql = @"select Address.City City ,  Address.Location1 Location1,Address.Location2 Location2, Address.PhoneNo Phoneno , Address.Email Email
                          from WareHouse
                          join WareHouseAddress on WareHouse.Id = WareHouseAddress.AddressID
                          join Address on WareHouseAddress.AddressID = Address.id
                          where WareHouse.Id='" + ID + "' ";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                AddressModel address = new AddressModel();
                address.ID = int.Parse(reader["ID"].ToString());
                address.City = reader["City"].ToString();
                address.Location1 = reader["Location1"].ToString();
                address.Location2 = reader["Location2"].ToString();
                address.Phonenumber = reader["Phoneno"].ToString();
                address.Email = reader["Email"].ToString();
                wareHouseAddresses.Add(address);
            }
            return wareHouseAddresses;
        }

        //set address within database and return id of inserted address.
        public static AddressModel addAddress(AddressModel newaddress, String wareHouseID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {

                String sql = @"insert into Address(City, Location1, Location2 , PhoneNo, Email)
                         output inserted.ID 
                         values ('" + newaddress.City + "', '" + newaddress.Location1 + "', '" + newaddress.Location2 + "', '" + newaddress.Phonenumber + "', '" + newaddress.Email + "')";
               
                object id = DBUtility.SqlHelper.ExecuteScalar(trans, con, System.Data.CommandType.Text, sql, null);
                newaddress.ID = int.Parse(id.ToString());

                String sql2 = @"insert into WareHouseAddress(WHID, AddressID)
                            values('" + wareHouseID + "', '" + newaddress.ID + "')";
                DBUtility.SqlHelper.ExecuteScalar(trans, con, System.Data.CommandType.Text, sql2, null);

                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
            return newaddress;
        }

        //Get individual address base on address id  
        public static AddressModel getAddress(String id)
        {
            String sql = @"SELECT [Id] ID ,[City] City,[Location1] Location1,[PhoneNo] PhoneNo,[Email] Email,[Location2] Location2
                           FROM [dbo].[Address]
                           where Address.Id = '" + id + "'";
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

        //update address of an customer
        public static int updateAddress(AddressModel updateaddress)
        {
            String sql = @"UPDATE [dbo].[Address]
                         SET [City] = '" + updateaddress.City + "' ,[Location1] = '" + updateaddress.Location1 + "' ,[PhoneNo] = '"
                         + updateaddress.Phonenumber + "' ,[Email] = '" + updateaddress.Email + "' ,[Location2] = '"
                         + updateaddress.Location2 + "' WHERE Address.Id='" + updateaddress.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }


        //delete address of an customer from CustomerAddress table. 
        public static int deleteAddress(String WareHouseID, String AddressID, SqlTransaction tran)
        {
            String sql = @"DELETE FROM [WareHouseAddress] WHERE WHID='" + WareHouseID + "' and AddressID='" + AddressID + "';";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }


    }
}
