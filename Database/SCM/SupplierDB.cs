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
            String sql = @"select Supplier.ID sID , Supplier.Name Name, Supplier.CNIC CNIC
                        from Supplier
                        where 1=1
                        and 
	                    (Supplier.Name like '%" + searchtext + "%' or Supplier.CNIC like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                SupplierModel sModel = new SupplierModel();
                sModel.ID = int.Parse(reader["sID"].ToString());
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
                        where Supplier.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                    sModel = new SupplierModel();
                    sModel.Name = reader["Name"].ToString();
                    sModel.CNIC = reader["CNIC"].ToString();
            }
            return sModel;
        }
        public static List<AddressModel> getSupplierAddresses(String ID)
        {
            List<AddressModel> SupplierAddresses = new List<AddressModel>();

            String sql = @"select top 10  Address.ID ID , Address.City City ,  Address.Location1 Location1,Address.Location2 Location2, Address.PhoneNo Phoneno , Address.Email Email
                          from Address
                          join SupplierAddress on Address.ID = SupplierAddress.AddressID
                          join Supplier on SupplierAddress.SID = Supplier.ID
                         where Supplier.ID='" + ID + "' ";

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
                SupplierAddresses.Add(address);
            }
            return SupplierAddresses;
        }
        public static int addSupplierAddress(AddressModel newaddress, String sID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //Query1
                newaddress = Database.SCM.AddressDB.addAddress(newaddress, trans);

                if (newaddress.ID > 0)
                {
                    //Query 2
                    String sql = @"INSERT INTO [dbo].[SupplierAddress] ([SID] ,[AddressID])
                             output inserted.ID
                                 VALUES ('" + sID + "', '" + newaddress.ID + "')";
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

        public static int deleteSupplierAddress(String sID, String AddressID)
        {
            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            con.Open();
            SqlTransaction trans = con.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted);
            try
            {
                //Query 1.
                String sql1 = @"DELETE FROM [dbo].[SupplierAddress] WHERE [SupplierAddress].SID='" + sID + "' and [SupplierAddress].AddressID ='" + AddressID + "';";
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
