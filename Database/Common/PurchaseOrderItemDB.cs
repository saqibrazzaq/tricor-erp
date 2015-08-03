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
            PurchaseOrderItemsModel checkproductid = checkProductInfoiInPurchaseOrderItems(POIModel);

            if (checkproductid.checkProduct)
            {
                String sql = @"UPDATE [ProductOrderItem]
                        SET [TotalQuantity] = [TotalQuantity] +'" + POIModel.Quantity
                        + "'WHERE ProductOrderItem.OrderID = '" + POIModel.PurchaseOrderID
                        + "' AND ProductOrderItem.ProductID = '" + POIModel.ProductID + "'";
                DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            }
            else
            {
                String sql = @"INSERT INTO [dbo].[ProductOrderItem]
                        ([OrderID],[ProductID] ,[TotalQuantity] ,[CreatedBy] ,[LastUpdatedBy])
                           output inserted.ID
                           VALUES
                           ('" + POIModel.PurchaseOrderID + "','" + POIModel.ProductID + "','" + POIModel.Quantity + "','" 
                               + POIModel.CreatedBy + "','" + POIModel.LastUpdatedBy + "')";

                object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
                POIModel.ID = id.ToString();
            }
            return POIModel;
        }
        public static PurchaseOrderItemsModel checkProductInfoiInPurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"SELECT ProductOrderItem.* from ProductOrderItem
	                     WHERE ProductOrderItem.OrderID = '" + POIModel.PurchaseOrderID
                         + "' AND ProductOrderItem.ProductID = '" + POIModel.ProductID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            String Productid = null;
            if (reader.Read())
            {
                Productid = reader["ProductID"].ToString();
                POIModel.ID = reader["ID"].ToString();
                POIModel.PurchaseOrderID = reader["OrderID"].ToString();
                POIModel.ProductID = reader["ProductID"].ToString();
            }

            if (Productid == POIModel.ProductID)
            {
                POIModel.checkProduct = true;
                return POIModel;
            }
            else
            {
                return POIModel;
            }
        }
        public static int updatePurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            String sql = @"UPDATE [ProductOrderItem]
                        SET [TotalQuantity] = '" + POIModel.Quantity + "' ,[LastUpdatedBy] = '" + POIModel.LastUpdatedBy
                        + "'WHERE [ProductOrderItem].ID = '" + POIModel.ID + "'";
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
