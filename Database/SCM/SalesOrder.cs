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
        public static List<Models.SCM.SalesOrderModel> GetAllOrders(String searchtext)
        {
            String sql;
            if (searchtext == "")
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, ProductOrder.RejectedOn RejectedOn,
                            ProductOrder.RejectedBy RejectedBy, ProductOrder.RejectionReason RejectionReason,
                            OrderStatus.StatusName, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID 
                            where OrderStatus.ID>1";
            else
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, ProductOrder.RejectedOn RejectedOn,
                            ProductOrder.RejectedBy RejectedBy, ProductOrder.RejectionReason RejectionReason,
                            OrderStatus.StatusName, Warehouse.WHName  from ProductOrder 
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID  
                            join Warehouse on ProductOrder.WHID = Warehouse.ID 
                            where OrderStatus.ID>1 AND ProductOrder.ID='" + searchtext + "' ";
 
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
                order.RejectedBy = reader["RejectedBy"].ToString();
                order.RejectedOn = reader["RejectedOn"].ToString();
                order.RejectionReason = reader["RejectionReason"].ToString();
                order.WarehouseName = reader["WHName"].ToString();
                orders.Add(order);
            }
            return orders;
        }
        public static List<Models.SCM.SalesOrderModel> GetApprovedOrders(String searchtext)
        {
            String sql;
            if (searchtext == "")
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            OrderStatus.StatusName, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID 
                            where OrderStatus=2";
            else
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            OrderStatus.StatusName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID 
                            where OrderStatus=2 AND ProductOrder.ID='" + searchtext + "' ";
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
                order.WarehouseName = reader["WHName"].ToString();
                orders.Add(order);
            }
            return orders;
        }

        public static List<Models.SCM.SalesOrderModel> GetRejectedOrders(String searchtext)
        {
            String sql;
            if (searchtext == "")
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            OrderStatus.StatusName, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID 
                            where OrderStatus=7";
            else
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            OrderStatus.StatusName from ProductOrder, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID
                            where OrderStatus=7 AND ProductOrder.ID='" + searchtext + "' ";
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
                order.WarehouseName = reader["WHName"].ToString();
                orders.Add(order);
            }
            return orders;
        }

        public static List<Models.SCM.SalesOrderItemModel> GetOrderItems(String id)
        {
            String sql;
            sql = @"select * from ProductOrderItem where OrderID='" + id + "' ";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            List<Models.SCM.SalesOrderItemModel> Item = new List<SalesOrderItemModel>();
            while (reader.Read())
            {
                SalesOrderItemModel detail = new SalesOrderItemModel();
                detail.ID = int.Parse(reader["ID"].ToString());
                detail.OrderID = int.Parse(reader["OrderID"].ToString());
                detail.ProductID = int.Parse(reader["ProductID"].ToString());
                detail.TotalQuantity = int.Parse(reader["TotalQuantity"].ToString());
                detail.ManufacturedQuantity = int.Parse(reader["ManufacturedQuantity"].ToString());
                detail.ProductStatus = reader["ProductStatus"].ToString();
                Item.Add(detail);
            }
            return Item;
        }
        public static void SendToManufacture(String id)
        {
            int orderstatus = 3;
            String sql = @"select WHID from ProductOrder where ID='" + id + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            reader.Read();
            if (!reader["WHID"].ToString().Equals("1"))
            {
                sql = @"select * from ProductOrderItem where OrderID='" + id + "'";
                reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                int stockquantity, totalquantity, manufacturedquantity, productid;
                String salesorderitemID;
                while (reader.Read())
                {
                    manufacturedquantity = int.Parse(reader["ManufacturedQuantity"].ToString());
                    totalquantity = int.Parse(reader["TotalQuantity"].ToString());
                    productid = int.Parse(reader["ProductID"].ToString());
                    salesorderitemID = reader["ID"].ToString();
                    sql = @"select Quantity from Stock where PID='" + productid + "' and WHID=1";
                    reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                    reader.Read();
                    stockquantity = int.Parse(reader["Quantity"].ToString());
                    if ((stockquantity - totalquantity) < 0)
                    {
                        manufacturedquantity = stockquantity;
                        stockquantity = 0;
                    }
                    else
                    {
                        manufacturedquantity = totalquantity;
                        stockquantity = stockquantity - totalquantity;
                    }
                    sql = @"Update [dbo].[ProductOrderItem] set [ManufacturedQuantity]=" + manufacturedquantity + " where [ProductOrderItem].[ID]=" + salesorderitemID + "";
                    DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                    sql = @"update [dbo].[Stock] set [Quantity]='" + stockquantity + "' where PID='" + productid + "' and WHID=1";
                    DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                    if (manufacturedquantity == totalquantity)
                    {
                        UpdateItemStatus(salesorderitemID);
                        orderstatus = CheckOrUpdateSalesOrderStatus(id);
                    }
                }
            }

            sql = @"select * from LastSalesOrderDeliveryDate";
            reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            DateTime datetime = new DateTime();
            while (reader.Read())
            {
                datetime = DateTime.Parse(reader["Date"].ToString());
                int days = CalculateDaysRequiredForManufacturing(id);
                datetime = datetime.Date.AddDays(days);
            }

            sql = @"Update [dbo].[ProductOrder] set [OrderStatus]='" + orderstatus + "', [DeliveryDate]='" + datetime.Date + "' where [ProductOrder].ID=" + id + "";
            DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);

            sql = @"update [dbo].[LastSalesOrderDeliveryDate] set [Date]='" + datetime.Date + "'";
            DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
        }
        public static void UpdateItemStatus(String id)
        {
            String sql = @"Update [dbo].[ProductOrderItem] set [ProductStatus]='4' where [ProductOrderItem].[ID]=" + id + "";
            DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
        }
        public static int CalculateDaysRequiredForManufacturing(String orderid)
        {
            String sql = @"select * from ProductOrderItem where OrderID='" + orderid + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            int days = 0;
            List<Models.SCM.SalesOrderItemModel> orderitems = new List<SalesOrderItemModel>();

            while (reader.Read())
            {
                Models.SCM.SalesOrderItemModel item = new SalesOrderItemModel();
                item.TotalQuantity = int.Parse(reader["TotalQuantity"].ToString()) - int.Parse(reader["ManufacturedQuantity"].ToString());
                item.ProductID = int.Parse(reader["ProductID"].ToString());
                orderitems.Add(item);
            }
            foreach (var item in orderitems)
            {
                sql = @"select ManufactureTime from Product where Product.id='" + item.ProductID + "'";
                reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                if (reader.Read())
                    days = days + (int.Parse(reader["ManufactureTime"].ToString()) * item.TotalQuantity);
            }
            return days;
        }
        public static List<Models.SCM.SalesOrderModel> ViewQueuedOrders(String id)
        {
            String sql;
            if (id.Equals(""))
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            ProductOrder.OrderStatus Status, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID
                            where OrderStatus=3";
            else
                sql = @"select ProductOrder.ID ID, ProductOrder.WHID CID, ProductOrder.OrderDate ADate, ProductOrder.DeliveryDate DDate, 
                            ProductOrder.OrderStatus Status, Warehouse.WHName from ProductOrder
                            join  OrderStatus on ProductOrder.OrderStatus = OrderStatus.ID
                            join Warehouse on ProductOrder.WHID = Warehouse.ID
                            where OrderStatus=3 AND ProductOrder.ID='" + id + "'";

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
                order.WarehouseName = reader["WHName"].ToString();
                orders.Add(order);
            }
            return orders;
        }
        public static void UpdateManufacturedQuantityByOne(String id)
        {
            String sql = @"select ProductOrderItem.TotalQuantity, ProductOrderItem.ManufacturedQuantity, ProductOrderItem.ProductID, ProductOrderItem.OrderID from ProductOrderItem where ProductOrderItem.ID='" + id + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            reader.Read();
            int totalquantity = int.Parse(reader["TotalQuantity"].ToString());
            int manufacturedquantity = int.Parse(reader["ManufacturedQuantity"].ToString());
            String productid = reader["ProductID"].ToString();
            String orderid = reader["OrderID"].ToString();

            if (manufacturedquantity < totalquantity)
            {
                manufacturedquantity++;
                if (manufacturedquantity == totalquantity)
                {
                    sql = @"Update [dbo].[ProductOrderItem] set [ManufacturedQuantity]=" + manufacturedquantity + ",[ProductStatus]='4' where [ProductOrderItem].[ID]=" + id + "";
                }
                else
                {
                    sql = @"Update [dbo].[ProductOrderItem] set [ManufacturedQuantity]=" + manufacturedquantity + " where [ProductOrderItem].[ID]=" + id + "";
                }

                DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                CheckOrUpdateSalesOrderStatus(orderid);

                sql = @"select WHID from ProductOrder where ID='" + orderid + "'";
                reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                reader.Read();
                String customerid = reader["WHID"].ToString();
                if (customerid.Equals("1"))
                {
                    sql = @"select Quantity from Stock where PID='" + productid + "' and WHID=1";
                    reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
                    reader.Read();
                    int quantity = int.Parse(reader["Quantity"].ToString());
                    quantity++;
                    sql = @"update [dbo].[Stock] set [Quantity]='" + quantity + "' where PID='" + productid + "' and WHID=1";
                    DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                }

            }
        }
        public static int CheckOrUpdateSalesOrderStatus(String orderid)
        {
            String sql = @"select ProductStatus from ProductOrderItem where OrderID='" + orderid + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            Boolean isCompleted = true;
            while (reader.Read())
            {
                if (!reader["ProductStatus"].ToString().Equals("4"))
                    isCompleted = false;
            }
            if (isCompleted)
            {
                sql = @"Update [dbo].[ProductOrder] set [OrderStatus]=4 where ID='" + orderid + "'";
                DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
                return 4;
            }
            return 3;
        }
        public static int RejectOrder(String id, String reason, String rejectedby)
        {

            String sql = @"Update [dbo].[ProductOrder] set [OrderStatus]=7, [RejectionReason]='" + reason + "', [RejectedOn]='" + DateTime.Today.Date + "',[RejectedBy]='" + rejectedby + "' where [ProductOrder].[ID]='" + id + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            return check;
        }
        public static Models.SCM.SalesOrderModel GetRejectionDetails(String id)
        {
            String sql = @"select RejectedBy, RejectedOn, RejectionReason from ProductOrder where ID='" + id + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            SalesOrderModel order = new SalesOrderModel();
            while (reader.Read())
            {

                order.RejectedBy = reader["RejectedBy"].ToString();
                order.RejectedOn = reader["RejectedOn"].ToString();
                order.RejectionReason = reader["RejectionReason"].ToString();
            }
            return order;
        }
        public static SalesOrderModel addNewSaleOrder(SalesOrderModel newsaleorder)
        {
            String sql = @"INSERT INTO [dbo].[ProductOrder]
                        ([WHID] ,[OrderDate] ,[OrderStatus])
		                output inserted.ID
                        VALUES ('" + newsaleorder.CustomerID + "','" + newsaleorder.OrderDate + "','" + newsaleorder.OrderStatus + "');";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newsaleorder.ID = int.Parse(id.ToString());
            return newsaleorder;
        }
        public static SalesOrderItemModel addSaleOrderItems(SalesOrderItemModel soItemModel)
        {

            string sqlPrice = "SELECT PurchasePrice,PReOrderValue FROM Product WHERE ID = " + soItemModel.ProductID;
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlPrice, null))
            {
                if (readerPrice.Read())
                {
                    soItemModel.Price = int.Parse(readerPrice["PurchasePrice"].ToString());
                    soItemModel.TotalQuantity = int.Parse(readerPrice["PReOrderValue"].ToString());
                }
            }
            String sqlInsert = @"INSERT INTO [dbo].[ProductOrderItem]
                        ([OrderID] , [ProductID] , [TotalQuantity]
                        ,[Price] ,[ProductStatus])
                        OUTPUT INSERTED.ID
                        VALUES('" + soItemModel.OrderID + "','" + soItemModel.ProductID + "','" + soItemModel.TotalQuantity
                                + "','" + soItemModel.Price + "','" + soItemModel.ProductStatus
                                + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sqlInsert, null);
            soItemModel.ID = int.Parse(id.ToString());
            return soItemModel;
        }
        public static int getProgressSalesOrderCount()
        {
            String sql = @"SELECT COUNT (*) as Pending
                         FROM ProductOrder
                         where [ProductOrder].OrderStatus = '2'";
            object PendingOrder = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(PendingOrder.ToString());
        }
    }
}
