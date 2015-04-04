using System;
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
                        VALUES ('" + newsaleorder.CustomerID+"','"+newsaleorder.OrderDate+"','"+newsaleorder.DeliveryDate+"','1');";
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
                          where [SalesOrder].ID = '"+SaleOrderID+"'";
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

        //function is used for add sales product into database and return an object.
        public static SaleOrderItemModel addSalesProduct(SaleOrderItemModel newsaleproduct)
        {
            String sql = @"INSERT INTO [dbo].[SaleOrderItem]
                         ([OrderID] ,[ProductID] ,[Quantity] ,[Price])
                         output inserted.ID
                         VALUES("+newsaleproduct.OrderID+","+newsaleproduct.ProductID+","
                                 +newsaleproduct.Quantity+","+newsaleproduct.Price+")";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            newsaleproduct.ID = int.Parse(id.ToString());
            return newsaleproduct;
        }


        // function that can return the all sales order item list and show that list in the list view. 
        public static List<ProductModel> getSaleOrderItemList(String SaleOrderID)
        {
            // it will be SaleOrderItemModel? 
            // some points these are discuss with teacher?
            List<ProductModel> productitems = new List<ProductModel>();
            String sql = @"select SalesOrder.ID ID, SaleOrderItem.ProductID PID, 
                         Product.PName PN, Product.SalePrice SP , SaleOrderItem.Quantity Qat
                         from SalesOrder
                         join SaleOrderItem on SalesOrder.ID = SaleOrderItem.OrderID
                         join Product on Product.ID = SaleOrderItem.ProductID
                         where SalesOrder.ID = '" + SaleOrderID+"'";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel item = new ProductModel();
                item.ProductID = int.Parse(reader["PID"].ToString());
                item.ProductName = reader["PN"].ToString();
                item.SalesPrice = int.Parse(reader["SP"].ToString());
                item.Quantity = int.Parse(reader["Qat"].ToString());
                productitems.Add(item);
                //perform addition of products and price on that end or not.
            }
            return productitems;
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
                sale.CName = reader["CN"].ToString();
                sale.OrderStatusName = reader["SN"].ToString();
                sales.Add(sale);
            }
            return sales;
        }

        //not correct 
        /* that function is work on the bases of orderid and productid and get the data according to 
           these ids get data from database and return an object of a product*/
        public static SaleOrderItemModel getSaleOrderItem(int orderID, String productID) {
            String sql = @"select [SaleOrderItem].ID id, [SaleOrderItem].Quantity Qa, [SaleOrderItem].Price pri
                         from [SaleOrderItem]
                         where [SaleOrderItem].OrderID = "+orderID+" and [SaleOrderItem].ProductID = "+ productID;
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            SaleOrderItemModel saleorderitem = new SaleOrderItemModel();
            if (reader.Read())
            {
                saleorderitem.ID = int.Parse(reader["id"].ToString());
                saleorderitem.OrderID = orderID;
                saleorderitem.Quantity = int.Parse(reader["Qa"].ToString());
                saleorderitem.Price = float.Parse(reader["pri"].ToString());
                saleorderitem.ProductID = int.Parse(productID.ToString());
            }
            return saleorderitem;
        }



        // that function can update the data when user want to update it
        public static int updateSalesItem(SaleOrderItemModel updatesaleproduct)
        {
            String sql = @"UPDATE [dbo].[SaleOrderItem] SET [Quantity]="+updatesaleproduct.Quantity
                         +",[Price] = "+updatesaleproduct.Price
                         + "WHERE [SaleOrderItem].ID="+updatesaleproduct.ID+";";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }


        // by using saleorderitem id that function can delete an tuple in the table and return an integer value 
        public static int deleteSaleOrderItem(int p)
        {
            String sql = @"DELETE FROM [dbo].[SaleOrderItem]
                         WHERE [SaleOrderItem].ID = '"+p+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        /*Method that is used for update the customers if we want to change the customer*/
        public static int updateSaleOrder(SaleOrderModel so)
        {
            String sql = @"UPDATE [dbo].[SalesOrder] SET [CustomerID] = "+so.CustomerID
                         +"WHERE ID="+so.ID;
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

            // Load the items
            string sqlItems = @"SELECT item.*, Product.Name AS ProductName
                    FROM SaleOrderItem item
                    INNER JOIN Product ON item.ProductID = Product.ID
                    WHERE item.OrderID = " + soModel.ID;
            // Empty the list of items before loading from DB
            soModel.items.Clear();
            using (SqlDataReader readerItems = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlItems, null))
            {
                while (readerItems.Read())
                {
                    SaleOrderItemModel soItemModel = new SaleOrderItemModel(){
                        ID = int.Parse(readerItems["ID"].ToString()),
                        OrderID = int.Parse(readerItems["OrderID"].ToString()),
                        ProductID = int.Parse(readerItems["ProductID"].ToString()),
                        Quantity = int.Parse(readerItems["Quantity"].ToString()),
                        Price = float.Parse(readerItems["Price"].ToString()),
                        ProductName = readerItems["ProductName"].ToString()
                    };

                    soModel.items.Add(soItemModel);
                }
            }
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
            // Add the item to sales order
            String sqlInsert = @"INSERT INTO SaleOrderItem ([OrderID]
                               ,[ProductID] ,[Quantity] ,[Price]) 
                               OUTPUT INSERTED.ID VALUES (" + soItemModel.OrderID + " , " +
                soItemModel.ProductID + " , " + soItemModel.Quantity + " , '" + soItemModel.Price + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sqlInsert, null);
            soItemModel.ID = int.Parse(id.ToString());
            
            return soItemModel;
        }



        public static int updateOrderStatus(SaleOrderModel soModel)
        {
            String sql = @"UPDATE [dbo].[SalesOrder]
                          SET [OrderStatus] = "+soModel.OrderStatus
                          +"WHERE [SalesOrder].ID ="+ soModel.ID;
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
