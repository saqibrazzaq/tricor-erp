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
                //stockItems.ID = 0;
                stockItems.ID = getExistingStockId(stockItems);
                int quantity = getQuantityFromStock(stockItems);
                stockItems.Quantity = stockItems.Quantity + quantity;
                updateStock(stockItems);
                return stockItems;
            }
            else
            {
                sql = @"INSERT INTO [dbo].[Stock]
                         ([WHID] ,[PID] ,[Quantity])
                         output inserted.ID
                         VALUES (" + stockItems.WHID + " ," + stockItems.ProductID + " ," + stockItems.Quantity + " )";
                object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
                stockItems.ID = int.Parse(id.ToString());
                return stockItems;
            }
        }

        //that function return the quantity of stock by using product id.
        private static int getQuantityFromStock(Models.POS.Stock.POSStockModel stockItems)
        {
            int stockquantity = 0;
            String sqlproductquantity = @"select [Stock].Quantity from [Stock] where [Stock].PID='" + stockItems.ProductID + "'";
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlproductquantity, null))
            {
                if (readerPrice.Read())
                {
                    stockquantity = int.Parse(readerPrice["Quantity"].ToString());
                }
            }
            return stockquantity;
        }
        
        //that function update the existence stock
        public static int updateStock(Models.POS.Stock.POSStockModel updatestockitems)
        {
            String sql = @"UPDATE [dbo].[Stock]
                         SET [PID] = " + updatestockitems.ProductID + ",[Quantity] = " + updatestockitems.Quantity
                         + "WHERE [Stock].ID =" + updatestockitems.ID;
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

                stockitem.ID = int.Parse(reader["ID"].ToString());
                stockitem.ProductName = reader["PN"].ToString();
                stockitem.Quantity = int.Parse(reader["Qant"].ToString());
                //stockitem.WHID
                stocklist.Add(stockitem);
            }
            return stocklist;
        }

        //that function delete the stock item that is exist in the stock.. 
        public static int deleteStockItem(int itemID)
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
        public static int getExistingStockId(Models.POS.Stock.POSStockModel soItemModel)
        {
            int stockid = 0;
            String sqlstockid = @"SELECT [ID]
                                FROM [dbo].[Stock] where [Stock].PID = '" + soItemModel.ProductID + "' and [Stock].WHID = '" + soItemModel.WHID + "'";
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlstockid, null))
            {
                if (readerPrice.Read())
                {
                    stockid = int.Parse(readerPrice["ID"].ToString());
                }
            }
            return stockid;
        }

        // that function update the quantity according to the WHID and productID...
        public static int updateStockQuantity(Models.POS.Stock.POSStockModel posstockmodel)
        {
            String sql = null;
            if (posstockmodel.ID != 0)
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

        /*that function can return 0 and 1 y using that function can update the stock and decrese and increse the stock according to the 
         requirement...*/
        public static int updateStockItems(Models.POS.Order.SaleOrderModel soModel)
        {
            if (soModel.OrderStatus == 6)
            {
                int updateorderstatus = Database.POS.Order.OrderDB.updateOrderStatus(soModel);
                if (updateorderstatus > 0)
                {
                    // these integer arrays contains the product ids and quantity...
                    int NumberOfProduct = soModel.items.Count;
                    int[] ProductId = new int[NumberOfProduct];
                    int[] Quantity = new int[NumberOfProduct];
                    int[] WHID = new int[NumberOfProduct];

                    for (int i = 0; i < NumberOfProduct; i++)
                    {
                        ProductId[i] = soModel.items[i].ProductID;
                        Quantity[i] = soModel.items[i].Quantity;
                        WHID[i] = soModel.items[i].WareHouseID;
                    }

                    int[] totalquantity = getTotalQuantityFromStock(ProductId, WHID, NumberOfProduct);

                    for (int i = 0; i < NumberOfProduct; i++)
                    {
                        int quant = totalquantity[i] - Quantity[i];
                        String sqlupdatestock = @"UPDATE [dbo].[Stock]
                                           SET [Quantity] = '" + quant + "'WHERE [Stock].PID='" + ProductId[i] + "' and [Stock].WHID='" + WHID[i] + "'";
                        int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sqlupdatestock, null);
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

        private static int[] getTotalQuantityFromStock(int[] ProductId, int[] WHID, int size)
        {
            int[] QuantityList = new int[size];
            for (int i = 0; i < size; i++)
            {
                String sqlproductquantity = @"select [Stock].Quantity from [Stock] where [Stock].PID='" + ProductId[i] + "' and [Stock].WHID='"+WHID[i]+"'";
                using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlproductquantity, null))
                {
                    if (readerPrice.Read())
                    {
                        QuantityList[i] = int.Parse(readerPrice["Quantity"].ToString());
                    }
                }
            }

            return QuantityList;
        }

    }
}
