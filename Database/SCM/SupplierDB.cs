using Models.SCM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{
    public class SupplierDB
    {
        public static SupplierModel addNewSupplier(SupplierModel supplierModel)
        {
                    String sql = @"INSERT INTO [dbo].[Supplier]
                        ([Name],[CNIC])
		                output inserted.ID 
                        VALUES ('" + supplierModel.Name + "','" + supplierModel.CNIC + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            supplierModel.ID = int.Parse(id.ToString());
            return supplierModel;
        }
           public static int updateSupplier( SupplierModel supplierModel)
        {
              String sql = @"Update [dbo].[Supplier]
                         SET [WHName] = '" + supplierModel.Name + "' , [CNIC]= '"+ supplierModel.CNIC
                         +"' where ID='" +supplierModel.ID+ "' ";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        
        public static List<SupplierModel> getSupplierList(String searchtext)
        {
            List<SupplierModel> supplierList = new List<SupplierModel>();
            String sql = @"select top 10 Supplier.ID sID , Supplier.Name Name, Supplier.CNIC CNIC
                        from Supplier
                        where 1=1
                        and 
	                    (Supplier.Name like '%" + searchtext + "%' or Supplier.CNIC like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                SupplierModel sModel = new SupplierModel();
                sModel.ID = int.Parse(reader["ID"].ToString());
                sModel.Name = reader["Name"].ToString();
                sModel.CNIC = reader["CNIC"].ToString();
                supplierList.Add(sModel);
            }
            return supplierList;
        }
        public static SupplierModel getSupplierInFo(String ID)
        {
            SupplierModel sModel= null;

            String sql = @"select Supplier.ID sID , Supplier.Name Name, Supplier.CNIC CNIC
                        from Supplier
                        where WareHouse.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                    sModel = new SupplierModel();
                    sModel.Name = reader["Name"].ToString();
                    sModel.CNIC = reader["CNIC"].ToString();
            }
            return sModel;
        }
        public static int deleteSupplierAddress(string sID, string AddressID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //Query 1.
                String sql2 = @"DELETE FROM Address WHERE Id ='" + AddressID + "';";
                int check1 = DBUtility.SqlHelper.ExecuteNonQuery(trans, System.Data.CommandType.Text, sql2, null);
                
                if (check1 == 1)
                {
                    //Query 2
                    int check2 = Database.SCM.AddressDB.deleteAddress(sID, AddressID, trans);
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
