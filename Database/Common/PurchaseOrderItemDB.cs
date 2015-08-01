using Models.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Common
{
    public class PurchaseOrderItemDB
    {
        public static List<PurchaseOrderItemsModel> getPurchaseOrderItemsList(String ID)
        {
            List<PurchaseOrderItemsModel> purchaseorderitems = new List<PurchaseOrderItemsModel>();

            String sql = @"SELECT [Product].PName PName, [ProductOrderItem].TotalQuantity Quantity, [ProductOrderItem].ID ID, [ProductOrderItem].ProductID
						, [ProductOrderItem].CreatedBy CreatedBy, [ProductOrderItem].LastUpdatedBy LastUpdatedBy
						, [ProductOrder].WHID
                        from [Product]
                        join [ProductOrderItem] ON [ProductOrderItem].ProductID=[Product].Id
						JOIN [ProductOrder] ON [ProductOrder].ID = [ProductOrderItem].OrderID
						WHERE [ProductOrderItem].OrderID =  '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.Common.PurchaseOrderItemsModel item = new Models.Common.PurchaseOrderItemsModel();
                item.ID = reader["ID"].ToString();
                item.Quantity = int.Parse(reader["Quantity"].ToString());
                item.ProductName = reader["PName"].ToString();
                item.ProductID = reader["ProductID"].ToString();
                item.LastUpdatedBy = reader["LastUpdatedBy"].ToString();
                item.CreatedBy = reader["CreatedBy"].ToString();
                item.WHID = reader["WHID"].ToString();
                purchaseorderitems.Add(item);
            }
            return purchaseorderitems;
        }

        public static PurchaseOrderItemsModel addPurchaseProductItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"INSERT INTO [dbo].[ProductOrderItem]
                        ([OrderID],[ProductID] ,[TotalQuantity] ,[ProductStatus] ,[CreatedBy] ,[LastUpdatedBy])
           output inserted.ID
           VALUES
           ('" + POIModel.PurchaseOrderID + "','" + POIModel.ProductID + "','" + POIModel.Quantity + "','"
               + POIModel.PurchasePrice + "','" + POIModel.CreatedBy + "','" + POIModel.LastUpdatedBy + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            POIModel.ID = id.ToString();
            return POIModel;
        }


        public static int updatePurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"UPDATE [ProductOrderItem]
                        SET [TotalQuantity] = '"+POIModel.Quantity+"' ,[LastUpdatedBy] = '"+POIModel.LastUpdatedBy
                        +"'WHERE [ProductOrderItem].ID = '"+POIModel.ID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        public static int deletePurchaseOrderItems(String ID)
        {
            String sql = @"DELETE FROM ProductOrderItem WHERE ID ='" + ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
