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
            String sql = @"INSERT INTO [dbo].[ProductOrder] 
                        ([WHID],[SID],[OrderDate] ,[CreatedBy] ,[LastUpdatedBy],[OrderStatus])
		                output inserted.ID 
                        VALUES ('" + POModel.WHID + "','" + POModel.SID + "','" +
                                 POModel.OrderDate + "','" + POModel.CreatedBy + "','" + POModel.LastUpdatedBy 
                                 + "','" + POModel.OrderStatus + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POModel.ID = id.ToString();
            return POModel;
        }

        public static int deletePurchaseOrder(string ID)
        {
            String sql = @"DELETE FROM ProductOrder WHERE ID ='" + ID + "'";
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
            String sql = @"select * from ProductOrder 
                           JOIN [OrderStatus] ON [ProductOrder].OrderStatus = [OrderStatus].ID 
                           where ProductOrder.ID='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                poModel = new PurchaseOrderModel();
                poModel.ID = ID;
                poModel.WHID = reader["WHID"].ToString();
                poModel.SID = reader["SID"].ToString();
                poModel.OrderDate = reader["OrderDate"].ToString();

                poModel.CreatedBy = reader["CreatedBy"].ToString();
                poModel.LastUpdatedBy = reader["LastUpdatedBy"].ToString();
                poModel.OrderStatusName = reader["StatusName"].ToString();
                poModel.OrderStatus = reader["OrderStatus"].ToString();
                poModel.DeliveryDate = reader["DeliveryDate"].ToString();

            }
            return poModel;
        }

        public static List<PurchaseOrderModel> getPurchaseOrderList(String searchtext)
        {
            List<PurchaseOrderModel> POList = new List<PurchaseOrderModel>();
            String sql = @"SELECT [ProductOrder].ID ID, [ProductOrder].OrderDate OrderDate, [Warehouse].WHName WHName
                         , [OrderStatus].StatusName , [ProductOrder].OrderStatus ,[ProductOrder].DeliveryDate
							FROM [ProductOrder]
							JOIN [Warehouse] ON [Warehouse].ID = [ProductOrder].WHID
							JOIN [OrderStatus] ON [OrderStatus].ID = [ProductOrder].OrderStatus
							WHERE 1=1
                            AND (ProductOrder.OrderDate like '%" + searchtext + "%' or Warehouse.WHName like '%" + searchtext + "%') ORDER BY ID DESC  ";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                PurchaseOrderModel POMOdel = new PurchaseOrderModel();
                POMOdel.ID = reader["ID"].ToString();
                POMOdel.WHName = reader["WHName"].ToString();
                POMOdel.OrderDate = reader["OrderDate"].ToString();
                POMOdel.OrderStatusName = reader["StatusName"].ToString();
                POMOdel.OrderStatus = reader["OrderStatus"].ToString();
                POMOdel.DeliveryDate = reader["DeliveryDate"].ToString();
                POList.Add(POMOdel);
            }
            return POList;
        }

        public static int updatePurchaseOrder(PurchaseOrderModel poModel)
        {
            String sql = @"UPDATE [dbo].[ProductOrder]
                         SET [WHID] = '" + poModel.WHID + "' ,[SID] = '" + poModel.SID
                        + "', [OrderDate]='" + poModel.OrderDate + "', [OrderStatus] ='"+poModel.OrderStatus
                        + "' WHERE ProductOrder.ID = '" + poModel.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
