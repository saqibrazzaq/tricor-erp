using System;
using System.Collections.Generic;
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
            String sql = @"INSERT INTO [dbo].[Stock]
                         ([WHID] ,[PID] ,[Quantity])
                         output inserted.ID
                         VALUES (" + stockItems.WHID+" ,"+stockItems.ProductID+" ,"+stockItems.Quantity+" )";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            stockItems.ID = int.Parse(id.ToString());
            return stockItems;
        }
        //*****************************************************************


        //that function update the existence stock
      
        public static int updateStock(Models.POS.Stock.POSStockModel updatestockitems)
        {
            String sql = @"UPDATE [dbo].[Stock]
                         SET [PID] = "+updatestockitems.ProductID+",[Quantity] = "+updatestockitems.Quantity
                         +"WHERE [Stock].ID ="+updatestockitems.ID;
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}
