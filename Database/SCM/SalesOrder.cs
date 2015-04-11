using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SCM;
namespace Database.SCM
{
    public class SalesOrder
    {
        public static List<Models.SCM.SalesOrderModel> GetApprovedOrders(String searchtext)
        {
            String sql;
            if (searchtext == "")
                sql = @"select SalesOrder.ID ID, SalesOrder.CustomerID CID, SalesOrder.OrderDate ADate, SalesOrder.DeliveryDate DDate, 
                            StatusType.StatusName from SalesOrder join  StatusType on SalesOrder.OrderStatus = StatusType.StatusID  where OrderStatus=2";
            else
                sql = @"select SalesOrder.ID ID, SalesOrder.CustomerID CID, SalesOrder.OrderDate ADate, SalesOrder.DeliveryDate DDate, 
                            StatusType.StatusName from SalesOrder join  StatusType on SalesOrder.OrderStatus = StatusType.StatusID where OrderStatus=2 AND ID='" + searchtext + "' ";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            List<Models.SCM.SalesOrderModel> orders = new List<Models.SCM.SalesOrderModel>();
            while (reader.Read())
            {
                SalesOrderModel order = new SalesOrderModel();
                order.ID = int.Parse(reader["ID"].ToString());
                order.CustomerID = int.Parse(reader["CID"].ToString());
                order.OrderDate = reader["ADate"].ToString();
                order.DeliveryDate = reader["DDate"].ToString();
                order.OrderStatusName = reader["StatusName"].ToString();
                orders.Add(order);
            }
            return orders;
        }
        public static List<Models.SCM.SalesOrderItemModel> GetOrderItems(String id)
        {
            String sql;
            sql = @"select * from SalesOrderItems where OrderID='" + id + "' ";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            List<Models.SCM.SalesOrderItemModel> items = new List<SalesOrderItemModel>();
            while (reader.Read())
            {
                SalesOrderItemModel detail = new SalesOrderItemModel();
                detail.ID = int.Parse(reader["ID"].ToString());
                detail.OrderID = int.Parse(reader["OrderID"].ToString());
                detail.ProductID = int.Parse(reader["ProductID"].ToString());
                detail.TotalQuantity = int.Parse(reader["TotalQuantity"].ToString());
                detail.ManufacturedQuantity = int.Parse(reader["ManufacturedQuantity"].ToString());
                detail.Price = float.Parse(reader["Price"].ToString());
                detail.ProductStatus = reader["ProductStatus"].ToString();
                items.Add(detail);
            }
            return items;
        }
        public static void SendToManufacture(String id)
        {
            String sql = @"Update [dbo].[SalesOrder] set [OrderStatus]=" + 3 + " where [SalesOrder].ID=" + id + "";
            DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
        }
        public static List<Models.SCM.SalesOrderModel> ViewQueuedOrders()
        {
            String sql;

            sql = @"select SalesOrder.ID ID, SalesOrder.CustomerID CID, SalesOrder.OrderDate ADate, SalesOrder.DeliveryDate DDate, 
                            SalesOrder.OrderStatus Status from SalesOrder where OrderStatus=3";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            List<Models.SCM.SalesOrderModel> orders = new List<Models.SCM.SalesOrderModel>();
            while (reader.Read())
            {
                SalesOrderModel order = new SalesOrderModel();
                order.ID = int.Parse(reader["ID"].ToString());
                order.CustomerID = int.Parse(reader["CID"].ToString());
                order.OrderDate = reader["ADate"].ToString();
                order.DeliveryDate = reader["DDate"].ToString();
                order.OrderStatus = int.Parse(reader["Status"].ToString());
                orders.Add(order);
            }
            return orders;
        }
        public static void UpdateManufacturedQuantityByOne(String id)
        {
            String sql = @"select SalesOrderItems.TotalQuantity, SalesOrderItems.ManufacturedQuantity, SalesOrderItems.OrderID from SalesOrderItems where SalesOrderItems.ID='" + id + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            reader.Read();
            int totalquantity = int.Parse(reader["TotalQuantity"].ToString());
            int manufacturedquantity = int.Parse(reader["ManufacturedQuantity"].ToString());
            String orderid = reader["OrderID"].ToString();
            if(manufacturedquantity < totalquantity)
            {
                manufacturedquantity++;
                if (manufacturedquantity == totalquantity)
                {
                    sql = @"Update [dbo].[SalesOrderItems] set [ManufacturedQuantity]=" + manufacturedquantity + ",[ProductStatus]='Completed' where [SalesOrderItems].[ID]=" + id + "";
                                   
                }
                else
                {
                    sql = @"Update [dbo].[SalesOrderItems] set [ManufacturedQuantity]=" + manufacturedquantity + " where [SalesOrderItems].[ID]=" + id + "";                
                }
                    DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                    CheckOrUpdateSalesOrderStatus(orderid); 
            }
        }
        public static void CheckOrUpdateSalesOrderStatus(String orderid)
        {
            String sql = @"select ProductStatus from SalesOrderItems where OrderID='" + orderid + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            Boolean isCompleted=true;
            while(reader.Read())
            {
                if (!reader["ProductStatus"].ToString().Equals("Completed"))
                    isCompleted = false;
                
            }
            if(isCompleted)
            {
               sql = @"Update [dbo].[SalesOrder] set [OrderStatus]=4 where ID='"+orderid+"'";
               DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            }
        }
    }
}
