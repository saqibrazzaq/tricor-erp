using Models.Global;
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
                        ([WHName],[WHDescription])
		                output inserted.ID 
                        VALUES ('" + whModel.Name + "','" + whModel.Description+ "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            whModel.ID = int.Parse(id.ToString());
            return whModel;
        }
           public static int updateWareHouse( WareHouseModel whModel)
        {
              String sql = @"Update [dbo].[WareHouse]
                         SET [WHName] = '" + whModel.Name + "' , [WHDescription]= '"+ whModel.Description
                         +"' where ID='" +whModel.ID+ "' ";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        
        public static List<WareHouseModel> getWareHouseList(String searchtext)
        {
            List<WareHouseModel> wareHouseList = new List<WareHouseModel>();
            String sql = @"select top 10 WareHouse.ID WHID , WareHouse.WHName WHName,  WareHouse.WHDescription WHDescription
                        from WareHouse
                        where 1=1
                        and 
	                    (WareHouse.WHName like '%" + searchtext + "%' or WareHouse.WHDescription like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                WareHouseModel whModel = new WareHouseModel();
                whModel.ID = int.Parse(reader["WHID"].ToString());
                whModel.Name = reader["WHName"].ToString();
                whModel.Description = reader["WHDescription"].ToString();
                wareHouseList.Add(whModel);
            }
            return wareHouseList;
        }
        public static WareHouseModel getWareHouseInFo(String ID)
        {
            WareHouseModel whModel= null;

            String sql = @"select  WareHouse.WHName WHName,  WareHouse.WHDescription WHDescription 
                           from WareHouse
                        where WareHouse.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                    whModel = new WareHouseModel();
                    whModel.Name = reader["WHName"].ToString();
                    whModel.Description = reader["WHDescription"].ToString();
            }
            return whModel;
        }
        public static int addAddress(AddressModel newaddress, String WHID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //Query1
                newaddress = Database.SCM.AddressDB.addAddress(newaddress,trans);
              
                if (newaddress.ID > 0)
                {
                    //Query 2
                    String sql = @"INSERT INTO [dbo].[WareHouseAddress] ([WHID] ,[AddressID])
                             output inserted.ID
                                 VALUES ('" + WHID + "', '" + newaddress.ID + "')";
                int check2 = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql, null);
                    trans.Commit();
                }
                else
                {
                    con.Close();
                    return 0;
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
        
        public static int deleteAddress(String WHID, String AddressID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //Query 1.
                String sql1 = @"DELETE FROM [dbo].[WareHouseAddress] WHERE [WareHouseAddress].WHID='" + WHID + "' and [WareHouseAddress].AddressID ='" + AddressID + "';";
                int check2 = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql1, null);
              
                if (check2 == 1)
                {
                    //Query 2
                    int check = Database.SCM.AddressDB.deleteAddress(AddressID, trans);   
                    trans.Commit();
                }
                else
                {
                    con.Close();
                    return 0;
                }
            }
            catch (Exception e)
            {
                trans.Rollback();
            }
            finally
            {
                con.Close();
            }
            return 1;
        }
    }
}
