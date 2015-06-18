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
        //set address within database and return id of inserted address.
        public static AddressModel addAddress(AddressModel newaddress, SqlTransaction trans)
        {
            String sql = @"insert into [dbo].[Address] 
                            ([City], [Location1] , [Location2] , [PhoneNo] , [Email] )
                         output inserted.ID 
                         values ('" + newaddress.City + "', '" + newaddress.Location1 + "', '" + newaddress.Location2 + "', '" + newaddress.Phonenumber + "', '" + newaddress.Email + "')";
            Object check = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newaddress.ID = int.Parse(check.ToString());
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
        public static int deleteAddress( String AddressID, SqlTransaction trans)
        {
            String sql = @"DELETE FROM Address WHERE Id ='" + AddressID + "'";
              int check = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, null);
                if (check > 0)
                {
                return 1;
               }
                return 0;
        }


    }
}
