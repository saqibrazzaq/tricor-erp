using Models.SCM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{
    public class WareHouseDB
    {
         public static WareHouseModel addNewWareHouse( WareHouseModel whModel)
        {
              String sql = @"INSERT INTO [dbo].[WareHouse]
                        ([WHName],[WHPhoneNumber],[WHCity],[WHEmail],[WHLocation1],[WHLocation2])
		                output inserted.ID 
                        VALUES ('" + whModel.Name + "','" + whModel.PhoneNumber + "','" + whModel.City + "','" + whModel.Email+"','" + whModel.Location1 + "','" + whModel.Location2 + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            whModel.ID = int.Parse(id.ToString());
            return whModel;
        }
        
        public static List<WareHouseModel> getWareHouseList(String searchtext)
        {
            List<WareHouseModel> wareHouseList = new List<WareHouseModel>();
            String sql = @"select top 10 WareHouse.ID WHID , WareHouse.WHName WHName,  WareHouse.WHPhoneNumber WHPhoneNumber ,WareHouse.WHCity WHCity , 
                                         WareHouse.WHEmail WHEmail , WareHouse.WHLocation1 WHLocation1 , WareHouse.WHLocation2 WHLocation2 
                        from WareHouse
                        where 1=1
                        and 
	                    (WareHouse.WHName like '%" + searchtext + "%' or WareHouse.WHPhoneNumber like '%" + searchtext + "%' or WareHouse.WHEmail like '%" + searchtext + "%' or WareHouse.WHCity like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                WareHouseModel whModel = new WareHouseModel();
                whModel.ID = int.Parse(reader["WHID"].ToString());
                whModel.Name = reader["WHName"].ToString();
                whModel.City = reader["WHCity"].ToString();
                whModel.Email = reader["WHEmail"].ToString();
                whModel.PhoneNumber = reader["WHPhoneNumber"].ToString();
                whModel.Location1 = reader["WHLocation1"].ToString();
                whModel.Location2 = reader["WHLocation2"].ToString();
                wareHouseList.Add(whModel);
            }
            return wareHouseList;
        }
        public static WareHouseModel getWareHouseInFo(String ID)
        {
            WareHouseModel whModel= null;
                  
           String sql = @"select  WareHouse.WHName WHName,  WareHouse.WHPhoneNumber WHPhoneNumber ,WareHouse.City WHCity , 
                                         WareHouse.WHEmail WHEmail , WareHouse.WHLocation1 WHLocation1 , WareHouse.WHLocation2 WHLocation2 from Product where WareHouse.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                    whModel = new WareHouseModel();
                    whModel.Name = reader["WHName"].ToString();
                    whModel.City = reader["WHCity"].ToString();
                    whModel.Email = reader["WHEmail"].ToString();
                    whModel.PhoneNumber = reader["WHPhoneNumber"].ToString();
                    whModel.Location1 = reader["WHLocation1"].ToString();
                    whModel.Location2 = reader["WHLocation2"].ToString();
                }
            return whModel;
        }


    }
}
