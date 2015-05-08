using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class StockDB
    {
        /*that function can add the data of new stock in the database...*/
        public static Models.POS.Stock.POSStockModel addNewStock(Models.POS.Stock.POSStockModel stockItems)
        {

            String sql = @"select Stock.PID from Stock 
                          where Stock.PID = '" + stockItems.ProductID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                //set an check for checking on main page and update the data of stock in the database. 
                stockItems.check = -1;
                updateStock(stockItems);
                return stockItems;
            }
            else
            {
                sql = @"INSERT INTO [dbo].[Stock] ([WHID] ,[PID] ,[Quantity])
                      output inserted.ID VALUES('" + stockItems.WHID + "','" + stockItems.ProductID + "','" + stockItems.Quantity + "')";
                object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
                stockItems.ID = id.ToString();
                return stockItems;
            }
        }

        //that function return the quantity of stock by using product id.
        //private static int getQuantityFromStock(Models.POS.Stock.POSStockModel stockItems)
        //{
        //    int stockquantity = 0;
        //    String sqlproductquantity = @"select [Stock].Quantity from [Stock] where [Stock].PID='" + stockItems.ProductID + "'";
        //    using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlproductquantity, null))
        //    {
        //        if (readerPrice.Read())
        //        {
        //            stockquantity = int.Parse(readerPrice["Quantity"].ToString());
        //        }
        //    }
        //    return stockquantity;
        //}

        //that function update the existence stock
        public static int updateStock(Models.POS.Stock.POSStockModel updatestockitems)
        {
            String sql = @"UPDATE [dbo].[Stock]
                         SET [Quantity] = [Quantity] + '" + updatestockitems.Quantity
                         + "' WHERE [Stock].PID = '" + updatestockitems.ProductID +"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        //that function return the Stock list and binde that list with listview
        public static List<Models.POS.Stock.POSStockModel> getStockList(string productname)
        {
            List<Models.POS.Stock.POSStockModel> stocklist = new List<Models.POS.Stock.POSStockModel>();
            // changing
            String sql = @"select Stock.ID ID, Stock.Quantity Qant, Stock.WHID WHID, Product.PName PN
	                     from Stock 
	                     join Product on Stock.PID = Product.Id
	                     where 1=1
                         and (Product.PName like '%" + productname + "%') ";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.Stock.POSStockModel stockitem = new Models.POS.Stock.POSStockModel();

                stockitem.ID = reader["ID"].ToString();
                stockitem.ProductName = reader["PN"].ToString();
                stockitem.Quantity = int.Parse(reader["Qant"].ToString());
                //stockitem.WHID
                stocklist.Add(stockitem);
            }
            return stocklist;
        }

        //that function delete the stock item that is exist in the stock.. 
        public static int deleteStockItem(String itemID)
        {
            String sql = @"DELETE FROM [dbo].[Stock]
                         WHERE [Stock].ID = '" + itemID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        // that function can return the existent sales order id of a product...
        public static String getExistingStockId(Models.POS.Stock.POSStockModel soItemModel)
        {
            String stockid = null;
            String sqlstockid = @"SELECT [ID]
                                FROM [dbo].[Stock] where [Stock].PID = '" + soItemModel.ProductID + "' and [Stock].WHID = '" + soItemModel.WHID + "'";
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlstockid, null))
            {
                if (readerPrice.Read())
                {
                    stockid = readerPrice["ID"].ToString();
                }
            }
            return stockid;
        }

        // that function update the quantity according to the WHID and productID...
        public static int updateStockQuantity(Models.POS.Stock.POSStockModel posstockmodel)
        {
            String sql = null;
            if (posstockmodel.ID != CommonDB.NULL_ID)
                sql = @"UPDATE [dbo].[Stock]
                         SET [Quantity] = '" + posstockmodel.Quantity + "' WHERE [Stock].ID = '" + posstockmodel.ID + "' and [Stock].WHID='" + posstockmodel.WHID + "'";
            else
                sql = @"UPDATE [dbo].[Stock]
                      SET [Quantity] = '" + posstockmodel.Quantity + @"'
                      WHERE [Stock].PID = '" + posstockmodel.ProductID + "' and [Stock].WHID = '" + posstockmodel.WHID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        /*that function can return 0 and 1 y using that function can update the stock 
         * and decrese and increse the stock according to the requirement...*/
        public static int updateStockItems(Models.POS.Order.SaleOrderModel soModel)
        {
            if (soModel.OrderStatus == Database.CommonDB.OrderComplete)
            {
                int updateorderstatus = Database.POS.Order.OrderDB.updateOrderStatus(soModel);
                if (updateorderstatus > 0)
                {
                    foreach (Models.POS.Order.SaleOrderItemModel soItem in soModel.items)
                    {
                        String sqlupdatestock = @"UPDATE [dbo].[Stock]
                                           SET [Quantity] = [Quantity] - " + soItem.Quantity 
                                           + " WHERE [Stock].PID = '" + soItem.ProductID + "' and [Stock].WHID = '" 
                                           + soItem.WareHouseID + "'";
                        DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlupdatestock, null);
                    }
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        /*that function return the count of all products that have low stock*/
        public static int getStockStatus(String WHID)
        {
            String sql = @"SELECT COUNT(*)
                        FROM Stock s
                        INNER JOIN Product p ON s.PID = p.Id
                        WHERE S.WHID = '" + WHID + @"' 
                        AND s.Quantity <= P.PThreshHoldValue";
            object lowstock = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(lowstock.ToString());
        }

        /*that funcion get the data related to the threshhold value which is prasent in the 
         data base within product table*/
        public static int getThreshHoldValue(String stockid, String WHID) {

            String sql = @"SELECT p.PThreshHoldValue
                           FROM [Product] p INNER JOIN [Stock] s ON p.Id = s.PID
	                       WHERE s.WHID = '"+WHID+"' AND s.ID = '"+ stockid
                                            +"' AND s.Quantity <= p.PThreshHoldValue";
            
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            int threstholdvalue = 0;
            if (reader.Read())
            {
                threstholdvalue = int.Parse(reader["PThreshHoldValue"].ToString());
            }
            return threstholdvalue;
        }
    }
}
