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
        /*That function return the sale report that is based on date*/
        public static List<Models.POS.Report.ReportModel> getSaleReport(string searchbydate, String OrderComplete)
        {
            List<Models.POS.Report.ReportModel> salereport = new List<Models.POS.Report.ReportModel>();
            String sql = @"select [SalesOrder].OrderDate , SUM([SalesOrderItem].TotalQuantity) as TotalQuantity, 
                        SUM([SalesOrderItem].Price*[SalesOrderItem].TotalQuantity) 
		                as TotalSalePrice 
		                , sum([Product].SalePrice*[SalesOrderItem].TotalQuantity) as TotalPurchasePrice,
		                SUM(([SalesOrderItem].Price*[SalesOrderItem].TotalQuantity)-([Product].SalePrice*[SalesOrderItem].TotalQuantity)) as Profit
		                from [SalesOrder]
		                join [SalesOrderItem] on [SalesOrder].ID = [SalesOrderItem].OrderID
		                join [Product] on [SalesOrderItem].ProductID = [Product].Id
		                where [SalesOrder].OrderStatus='" + OrderComplete
                                                         +@"' and [SalesOrder].OrderDate like '%"+searchbydate
                        +"%'group by [SalesOrder].OrderDate";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.Report.ReportModel salesreportitems = new Models.POS.Report.ReportModel();

                salesreportitems.orderdates = reader["OrderDate"].ToString();
                salesreportitems.Quantity = int.Parse(reader["TotalQuantity"].ToString());
                salesreportitems.SalePrice = float.Parse(reader["TotalSalePrice"].ToString());
                salesreportitems.PurchasePrice = float.Parse(reader["TotalPurchasePrice"].ToString());
                salesreportitems.Profit = float.Parse(reader["Profit"].ToString());
                salereport.Add(salesreportitems);
            }
            return salereport;
        }

        public static List<Models.POS.Report.ReportModel> getPurchaseReport(string p)
        {
            List<Models.POS.Report.ReportModel> purchaereport = new List<Models.POS.Report.ReportModel>();
            String sql = @"SELECT [PurchaseOrder].OrderDate OrderDate, SUM([PurchaseOrderItems].Quantity) as TotalQuantity
		                FROM PurchaseOrder
		                JOIN [PurchaseOrderItems] on [PurchaseOrder].ID = [PurchaseOrderItems].POID
		                WHERE [PurchaseOrder].OrderStatus = '"+CommonDB.OrderApproved+"' and [PurchaseOrder].OrderDate LIKE '%" +p+@"%'
		                GROUP BY [PurchaseOrder].OrderDate";

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                Models.POS.Report.ReportModel purchasereportitems = new Models.POS.Report.ReportModel();
                purchasereportitems.orderdates = reader["OrderDate"].ToString();
                purchasereportitems.Quantity = int.Parse(reader["TotalQuantity"].ToString());
                
                purchaereport.Add(purchasereportitems);
            }
            return purchaereport;
        }
    }
}
