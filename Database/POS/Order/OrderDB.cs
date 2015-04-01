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
        public static SaleOrderModel assNewSaleOrder(SaleOrderModel newsaleorder)
        {
             String sql = @"INSERT INTO [dbo].[SalesOrder]
                        ([CustomerID] ,[OrderDate] ,[DeliveryDate])
		                output inserted.ID
                        VALUES ("+newsaleorder.CustomerID+" ,'"+newsaleorder.OrderDate+"','"+newsaleorder.DeliveryDate+"')";
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
            }
            return productitems;
        }

        //that function return the order list and return an list
        public static List<SaleOrderModel> getOrderList(String searchtext)
        {
            List<SaleOrderModel> sales = new List<SaleOrderModel>();
            String sql = @"select top 10 SalesOrder.ID SID, SalesOrder.CustomerID CID
                         ,Customer.Name CN, SalesOrder.OrderDate OD, SalesOrder.DeliveryDate DD
                         from Customer 
                         join  SalesOrder on SalesOrder.CustomerID = Customer.Id
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
                sales.Add(sale);
            }
            return sales;
        }

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
                saleorderitem.Price = int.Parse(reader["pri"].ToString());
                saleorderitem.ProductID = int.Parse(productID.ToString());
            }
            return saleorderitem;
        }

        // that function can update the data when user want to update it
        public static int updateSalesProduct(SaleOrderItemModel updatesaleproduct)
        {
            String sql = @"UPDATE [dbo].[SaleOrderItem] SET [OrderID] = "+updatesaleproduct.OrderID
                         +",[ProductID] = "+updatesaleproduct.ProductID
                         +",[Quantity] = "+updatesaleproduct.Quantity
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
    }
}
