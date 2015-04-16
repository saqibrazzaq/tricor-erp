using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class ReportDB
    {
        /*That function return the sale tht is based on daly bases*/
        public static List<Models.POS.Order.SaleOrderItemModel> getSaleReport()
        {
            List<Models.POS.Order.SaleOrderItemModel> salereport = new List<Models.POS.Order.SaleOrderItemModel>();
            String sql = @"select [Product].PName, sum([SalesOrderItem].TotalQuantity) as  TotalQuantity
		                , sum([Product].SalePrice) as SalePrice, sum([Product].PurchasePrice) as PurchasePrice
		                from [SalesOrder] 
		                join [SalesOrderItem] on [SalesOrder].ID=[SalesOrderItem].OrderID
		                join [Product] on [SalesOrderItem].ProductID=[Product].Id
		                where [SalesOrder].OrderStatus='6'
		                group by [Product].PName  ";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.Order.SaleOrderItemModel salesreportitems = new Models.POS.Order.SaleOrderItemModel();
                salesreportitems.ProductName = reader["PName"].ToString();
                salesreportitems.Quantity = int.Parse(reader["TotalQuantity"].ToString());
                salesreportitems.Price = float.Parse(reader["SalePrice"].ToString());
                salesreportitems.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());

                salereport.Add(salesreportitems);
            }
            return salereport;
        }
        


    }
}
