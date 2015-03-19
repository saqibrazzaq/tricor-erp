using Models.SCM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{
    public class StockDB
    {
        public static StockModel addNewStockItem(StockModel sModel)
        {
            String sql = @"INSERT INTO [dbo].[Stock]
                        ([WHID],[PID],[Quantity])
		                output inserted.ID 
                        VALUES ('" + sModel.WareHouseID + "','" + sModel.ProductID + "','" +sModel.Quantity + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            sModel.ID = int.Parse(id.ToString());
            return sModel;
        }

        public static List<StockModel> geStockItemList(String searchtext)
        {
            List<StockModel> stockItemList = new List<StockModel>();
            String sql = @"select top 10 Stock.ID SID , Stock.WHID WHID ,  Stock.PID PID , Stock.Quantity Quantity  
                        from Stock
                        where 1=1
                        and 
	                    (Stock.ID like '%" + searchtext + "%' or Stock.WHID like '%" + searchtext + "%' or Stock.PID like '%" + searchtext + "%' or Stock.Quantity like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                StockModel sModel = new StockModel();
                sModel.ID = int.Parse(reader["ID"].ToString());
                sModel.WareHouseID = int.Parse(reader["WHID"].ToString());
                sModel.ProductID = int.Parse(reader["PID"].ToString());
                sModel.Quantity = float.Parse(reader["Quantity"].ToString());
                stockItemList.Add(sModel);
            }
            return stockItemList;
        }
        public static StockModel getStockInFo(String ID)
        {
            StockModel sModel = null;

            String sql = @"select  Stock.ID SID , Stock.WHID WHID ,  Stock.PID PID , Stock.Quantity Quantity  
                        from Stock where Stock.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                sModel = new StockModel();
                sModel.ID = int.Parse(reader["ID"].ToString());
                sModel.WareHouseID = int.Parse(reader["WHID"].ToString());
                sModel.ProductID = int.Parse(reader["PID"].ToString());
                sModel.Quantity = float.Parse(reader["Quantity"].ToString());
            }
            return sModel;
        }

    }
}
