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
                stockItems.ID = 0;
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
        //*****************************************************************


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

        public static List<Models.POS.Stock.POSStockModel> getStockList(string productname)
        {
            List<Models.POS.Stock.POSStockModel> stocklist = new List<Models.POS.Stock.POSStockModel>();
            // changing
            String sql = @"select Stock.ID ID, Stock.Quantity Qant, Stock.WHID WHID, Product.PName PN
	                     from Stock 
	                     join Product on Stock.PID = Product.Id
	                     where 1=1
                         and (Product.PName like '%"+productname+"%') ";
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

        public static int deleteStockItem(int itemID)
        {
            String sql = @"DELETE FROM [dbo].[Stock]
                         WHERE [Stock].ID = '"+itemID+"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }


        // that function can return the quantity of a product...
        public static int getQuantityFromStock(Models.POS.Order.SaleOrderItemModel soItemModel)
        {
            int stockquantity = 0;
            String sqlproductquantity = @"select [Stock].Quantity from [Stock] where [Stock].PID='" + soItemModel.ProductID + "'";
            using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlproductquantity, null))
            {
                if (readerPrice.Read())
                {
                    stockquantity = int.Parse(readerPrice["Quantity"].ToString());
                }
            }
            return stockquantity;
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
    }
}
