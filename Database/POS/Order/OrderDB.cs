﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Models.POS.Order;
using System.Data.SqlClient;
using Models.POS;

namespace Database.POS.Order
{
    public class OrderDB
    {
        //that function save the data of new saleorder into saleorder table and return an object
        public static SaleOrderModel addNewSaleOrder(SaleOrderModel newsaleorder)
        {
            String sql = @"INSERT INTO [dbo].[SalesOrder]
                        ([CustomerID] ,[OrderDate] ,[DeliveryDate] ,[OrderStatus])
		                output inserted.ID
                        VALUES ('" + newsaleorder.CustomerID + "','" + newsaleorder.OrderDate + "','" + newsaleorder.DeliveryDate + "','1');";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newsaleorder.ID = int.Parse(id.ToString());
            return newsaleorder;
        }

        //that function can return an object of saleorder information for view peruse
        public static SaleOrderModel SaleOrderInFo(String SaleOrderID)
        {
            String sql = @"SELECT [CustomerID] CID
                          ,[OrderDate] OrderDate
                          ,[DeliveryDate] DeliveryDate
                          FROM [dbo].[SalesOrder] 
                          where [SalesOrder].ID = '" + SaleOrderID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            SaleOrderModel saleorder = new SaleOrderModel();
            if (reader.Read())
            {
                saleorder.ID = int.Parse(SaleOrderID.ToString());
                saleorder.CustomerID = int.Parse(reader["CID"].ToString());
                saleorder.OrderDate = reader["Orderdate"].ToString();
                saleorder.DeliveryDate = reader["DeliveryDate"].ToString();
            }
            return saleorder;
        }

        //that function return the order list and return an list
        public static List<SaleOrderModel> getOrderList(String searchtext)
        {
            List<SaleOrderModel> sales = new List<SaleOrderModel>();
            String sql = @"select SalesOrder.ID SID, SalesOrder.CustomerID CID, Customer.Name CN
                         , OrderStatus.StatusName SN
	                     ,SalesOrder.OrderDate OD, SalesOrder.DeliveryDate DD
                         from Customer 
                         join  SalesOrder on SalesOrder.CustomerID = Customer.Id
	                     join OrderStatus on SalesOrder.OrderStatus = OrderStatus.ID
                         where 1=1
                         and Customer.Name like '%" + searchtext + "%' or SalesOrder.OrderDate like '%" + searchtext + "%'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                SaleOrderModel sale = new SaleOrderModel();
                sale.ID = int.Parse(reader["SID"].ToString());
                sale.CustomerID = int.Parse(reader["CID"].ToString());
                sale.OrderDate = reader["OD"].ToString();
                sale.DeliveryDate = reader["DD"].ToString();
                sale.CustomerName = reader["CN"].ToString();
                sale.OrderStatusName = reader["SN"].ToString();
                sales.Add(sale);
            }
            return sales;
        }

        // that function can update the data when user want to update it
        public static int updateSalesItem(SaleOrderItemModel updatesaleproduct)
        {
            String sql = @"UPDATE [dbo].[SalesOrderItem] SET [TotalQuantity]=" + updatesaleproduct.Quantity
                         + ",[Price] = " + updatesaleproduct.Price + ",[WareHouseID] =" + updatesaleproduct.WareHouseID
                         + "WHERE [SalesOrderItem].ID=" + updatesaleproduct.ID + ";";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        // by using saleorderitem id that function can delete an tuple in the table and return an integer value 
        public static int deleteSaleOrderItem(int itemID)
        {
            String sql = @"DELETE FROM [dbo].[SalesOrderItem]
                         WHERE [SalesOrderItem].ID = '" + itemID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        private static SaleOrderItemModel getOrderItem(int itemID)
        {
            String sql = @"SELECT [OrderID]
                      ,[ProductID]
                      ,[TotalQuantity]
                      ,[WareHouseID]
                      FROM [dbo].[SalesOrderItem]
                      where [SalesOrderItem].ID = '" + itemID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            SaleOrderItemModel saleorderitem = new SaleOrderItemModel();
            if (reader.Read())
            {
                saleorderitem.ID = itemID;
                saleorderitem.OrderID = int.Parse(reader["OrderID"].ToString());
                saleorderitem.Quantity = int.Parse(reader["TotalQuantity"].ToString());
                //saleorderitem.Price = float.Parse(reader["pri"].ToString());
                saleorderitem.WareHouseID = int.Parse(reader["WareHouseID"].ToString());
                saleorderitem.ProductID = int.Parse(reader["ProductID"].ToString());
            }
            return saleorderitem;
        }

        /*Method that is used for update the customers if we want to change the customer*/
        public static int updateSaleOrder(SaleOrderModel so)
        {
            String sql = @"UPDATE [dbo].[SalesOrder] SET [CustomerID] = " + so.CustomerID
                         + "WHERE ID=" + so.ID;
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        public static SaleOrderModel loadOrderModel(SaleOrderModel soModel)
        {
            string sql = "SELECT * FROM SalesOrder WHERE ID = " + soModel.ID;
            using (SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null))
            {
                if (reader.Read())
                {
                    // Load the order
                    soModel.ID = soModel.ID;
                    soModel.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    soModel.OrderDate = reader["OrderDate"].ToString();
                    soModel.OrderStatus = int.Parse(reader["OrderStatus"].ToString());
                }
            }

            //for total price 
            float totalprice = 0;
            // Load the items
            string sqlItems = @"SELECT item.*, Product.PName AS ProductName
                              FROM SalesOrderItem item
                              INNER JOIN Product ON item.ProductID = Product.ID
					          INNER join Warehouse on item.WareHouseID = Warehouse.ID
                              WHERE item.OrderID =" + soModel.ID;

            // Empty the list of items before loading from DB
            soModel.items.Clear();
            using (SqlDataReader readerItems = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlItems, null))
            {
                while (readerItems.Read())
                {
                    SaleOrderItemModel soItemModel = new SaleOrderItemModel();
                    soItemModel.ID = int.Parse(readerItems["ID"].ToString());
                    soItemModel.OrderID = int.Parse(readerItems["OrderID"].ToString());
                    soItemModel.ProductID = int.Parse(readerItems["ProductID"].ToString());
                    soItemModel.Quantity = int.Parse(readerItems["TotalQuantity"].ToString());
                    soItemModel.Price = float.Parse(readerItems["Price"].ToString());
                    soItemModel.ProductName = readerItems["ProductName"].ToString();
                    soItemModel.WareHouseID = int.Parse(readerItems["WareHouseID"].ToString());
                    //total Price according to the product quantity 
                    totalprice = totalprice + (soItemModel.Price * soItemModel.Quantity);
                    soModel.items.Add(soItemModel);
                }
            }
            soModel.TotalPrice = totalprice;
            return soModel;
        }
        public static SaleOrderItemModel setSaleOrderItems(SaleOrderItemModel soItemModel)
        {
            string sqlPrice = "SELECT SalePrice FROM Product WHERE ID = " + soItemModel.ProductID;
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlPrice, null))
            {
                if (readerPrice.Read())
                {
                    soItemModel.Price = int.Parse(readerPrice["SalePrice"].ToString());
                }
            }
            String sqlInsert = @"INSERT INTO [dbo].[SalesOrderItem]
                        ([OrderID] ,[ProductID] ,[TotalQuantity]
                        ,[Price] ,[ManufacturedQuantity] ,[ProductStatus] ,[WareHouseID])
                        OUTPUT INSERTED.ID
                        VALUES('" + soItemModel.OrderID + "','" + soItemModel.ProductID + "','" + soItemModel.Quantity
                                + "','" + soItemModel.Price + "','" + soItemModel.ManufacturedQuantity + "','" + soItemModel.ProductStatus
                                + "','" + soItemModel.WareHouseID + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sqlInsert, null);
            soItemModel.ID = int.Parse(id.ToString());
            return soItemModel;
        }

        public static int updateOrderStatus(SaleOrderModel soModel)
        {
            String sql = @"UPDATE [dbo].[SalesOrder]
                          SET [OrderStatus] = " + soModel.OrderStatus
                          + "WHERE [SalesOrder].ID =" + soModel.ID;
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        public static List<OrderStatusModel> getOrderStatusList()
        {
            List<OrderStatusModel> orderstatus = new List<OrderStatusModel>();
            String sql = @"SELECT [ID] ID,[StatusName] SN
                         FROM [dbo].[OrderStatus]";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                OrderStatusModel status = new OrderStatusModel();
                status.ID = int.Parse(reader["ID"].ToString());
                status.StatusName = reader["SN"].ToString();

                orderstatus.Add(status);
            }
            return orderstatus;
        }

        // that function can return the list of warehouse list for viewing on the panal
        public static List<Models.SCM.WareHouseModel> getWareHouseList()
        {
            List<Models.SCM.WareHouseModel> WHlists = new List<Models.SCM.WareHouseModel>();
            String sql = @"SELECT [ID] ID,[WHName] WHN ,[WHDescription] WHD
                         FROM [dbo].[Warehouse]";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.SCM.WareHouseModel WHList = new Models.SCM.WareHouseModel();
                WHList.ID = int.Parse(reader["ID"].ToString());
                WHList.Name = reader["WHN"].ToString();
                WHList.Description = reader["WHD"].ToString();
                WHlists.Add(WHList);
            }
            return WHlists;
        }

        /*That function can return the count of pending sales order for home page*/
        public static int getPendingSalesOrderCount()
        {
            String sql = @"SELECT COUNT (*) as Pending
                         FROM [TRICOR].[dbo].[SalesOrder]
                         where [SalesOrder].OrderStatus = '1'";
            object PendingOrder = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(PendingOrder.ToString());
        }

        public static int getProgressSalesOrderCount()
        {
            String sql = @"SELECT COUNT (*) as Pending
                         FROM [TRICOR].[dbo].[SalesOrder]
                         where [SalesOrder].OrderStatus = '3'";
            object inprogressOrders = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(inprogressOrders.ToString());
        }

        public static int orderStatus(SaleOrderModel soModel)
        {
            String sql = @"select [SalesOrder].OrderStatus from [SalesOrder] 
                         where [SalesOrder].ID = '"+soModel.ID+"'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            int orderstatus = 0;
            if (reader.Read())
            {
                orderstatus = int.Parse(reader["OrderStatus"].ToString());
            }
            if(orderstatus==6)
                return 1;
            return 0;
        }
    }
}
