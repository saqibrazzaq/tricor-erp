using Models.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Common
{
    public class PurchaseOrderDB
    {
        public static PurchaseOrderModel addPurchaseOrder(PurchaseOrderModel POModel)
        {
            String sql = @"INSERT INTO [dbo].[PurchaseOrder]
                        ([WHID],[SID],[OrderDate],[OrderType] ,[CreatedBy] ,[LastUpdatedBy],[OrderStatus])
		                output inserted.ID 
                        VALUES ('" + POModel.WHID + "','" + POModel.SID + "','" +
                                 POModel.OrderDate + "','" + POModel.OrderType + "','"
                                 +POModel.CreatedBy+"','"+POModel.LastUpdatedBy+"','"+POModel.OrderStatus+"')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POModel.ID = id.ToString();
            return POModel;
        }

        public static int deletePurchaseOrder(string ID)
        {
            String sql = @"DELETE FROM PurchaseOrder WHERE ID ='" + ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                //Database.Common.PurchaseOrderItemDB.deletePurchaseOrderItems(ID.ToString());
                return 1;
            }
            return 0;
        }

        public static PurchaseOrderModel getPurchaseOrderInFol(String ID)
        {
            PurchaseOrderModel poModel = null;
            String sql = @"select * from PurchaseOrder 
                           JOIN [OrderStatus] ON [PurchaseOrder].OrderStatus = [OrderStatus].ID 
                           where PurchaseOrder.ID='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                poModel = new PurchaseOrderModel();
                poModel.ID = ID;
                poModel.WHID = reader["WHID"].ToString();
                poModel.SID = reader["sID"].ToString();
                poModel.OrderDate = reader["OrderDate"].ToString();
                poModel.OrderType = reader["OrderType"].ToString();
                poModel.CreatedBy = reader["CreatedBy"].ToString();
                poModel.LastUpdatedBy = reader["LastUpdatedBy"].ToString();
                poModel.OrderStatus = reader["StatusName"].ToString();

            }
            return poModel;
        }

        public static List<PurchaseOrderModel> getPurchaseOrderList(String searchtext)
        {
            List<PurchaseOrderModel> POList = new List<PurchaseOrderModel>();
            String sql = @"SELECT [PurchaseOrder].ID ID, [PurchaseOrder].OrderDate OrderDate, [Warehouse].WHName WHName, [OrderStatus].StatusName
							FROM [PurchaseOrder]
							JOIN [Warehouse] ON [Warehouse].ID = [PurchaseOrder].WHID
							JOIN [OrderStatus] ON [OrderStatus].ID = [PurchaseOrder].OrderStatus
							WHERE 1=1
                            AND (PurchaseOrder.OrderDate like '%" +searchtext+"%' or Warehouse.WHName like '%"+searchtext+"%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                PurchaseOrderModel POMOdel = new PurchaseOrderModel();
                POMOdel.ID = reader["ID"].ToString();
                POMOdel.WHName = reader["WHName"].ToString();
                POMOdel.OrderDate = reader["OrderDate"].ToString();
                POMOdel.OrderStatus = reader["StatusName"].ToString();
                POList.Add(POMOdel);
            }
            return POList;
        }

        public static int updatePurchaseOrder(PurchaseOrderModel poModel)
        {
            String sql = @"UPDATE [dbo].[PurchaseOrder]
                         SET [WHID] = '" + poModel.WHID + "' ,[SID] = '" + poModel.SID
                        + "', [OrderDate]='" + poModel.OrderDate + "', [OrderType]='" + poModel.OrderType
                        + "' WHERE PurchaseOrder.ID = '" + poModel.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

       


    }
}
