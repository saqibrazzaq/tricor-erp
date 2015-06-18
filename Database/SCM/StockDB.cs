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

            String sql2 = @"select  Stock.ID sID , Stock.Quantity Quantity  
                        from Stock where Stock.PID = '" + sModel.ProductID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql2, null);
            if (reader.Read())
            {
                sModel.check = 1;
                sModel.ID = int.Parse(reader["sID"].ToString());
                sModel.Quantity = sModel.Quantity + int.Parse(reader["quantity"].ToString());
                updateStockItem(sModel);
                //return stockItems;
            }
            else
            {
                sModel.check = 0;
                InsertNewStockItem(sModel);
            }
            return sModel;
        }
        public static StockModel InsertNewStockItem(StockModel sModel)
        {
            String sql = @"INSERT INTO [dbo].[Stock]
                        ([WHID],[PID],[Quantity])
		                output inserted.ID 
                        VALUES ('" + sModel.WareHouseID + "','" + sModel.ProductID + "','" + sModel.Quantity + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            sModel.ID = int.Parse(id.ToString());
            return sModel;
        }
        public static List<ProductModel> geStockItemList(String WHID ,String searchtext) 
        {
            List<ProductModel> stockItemList = new List<ProductModel>();
            String sql = @"select Product.ID PID, Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,
                        Product.PThreshHoldValue PthreshHold , Product.PReOrderValue pReOrder , Product.PurchasePrice purchasePrice , 
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID
                        from product
                        join Stock on Product.id = Stock.PID
                        join WareHouse on WareHouse.id = Stock.WHID
                        where WareHouse.id ='" + WHID + "' and (Stock.ID like '%" + searchtext + "%' or Stock.WHID like '%" + searchtext + "%' or Stock.PID like '%" + searchtext + "%' or Stock.Quantity like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = int.Parse(reader["PID"].ToString());
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = int.Parse(reader["productTypeID"].ToString());
                product.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                stockItemList.Add(product);
            }
            return stockItemList;
        }
        public static StockModel getStockInFo(String ID)
        {
            StockModel sModel = null;

            String sql = @"select  Stock.WHID WHID ,  Stock.PID PID , Stock.Quantity Quantity  
                        from Stock where Stock.ID = '" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                sModel = new StockModel();
                sModel.ID = int.Parse(reader["ID"].ToString());
                sModel.WareHouseID = int.Parse(reader["WHID"].ToString());
                sModel.ProductID = int.Parse(reader["PID"].ToString());
                sModel.Quantity = int.Parse(reader["Quantity"].ToString());
            }
            return sModel;
        }
        public static List<StockModel> getStockItems(String WHID,String SearchText)
        {
            StockModel sModel = null;
            List<StockModel> stockItemList = new List<StockModel>();
            String sql = @"select  Stock.ID ID ,  Stock.PID PID , Stock.Quantity Quantity  
                        from Stock where Stock.WHID= '" + WHID + "' and ( Stock.PID like '%" + SearchText + "%' or Stock.Quantity like '%" + SearchText + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while(reader.Read())
            {
                sModel = new StockModel();
                sModel.ID = int.Parse(reader["ID"].ToString());
                sModel.ProductID = int.Parse(reader["PID"].ToString());
                sModel.Quantity = int.Parse(reader["Quantity"].ToString());
                stockItemList.Add(sModel);
            }
            return stockItemList;
        }
        public static int DeleteStockItem(string ID)
        {
            String sql = @"DELETE FROM Stock WHERE Id ='" + ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        public static int updateStockItem(StockModel SMODEL)
        {
            String sql = @"UPDATE [dbo].[Stock]
                         SET [Quantity] = '" + SMODEL.Quantity + "' WHERE Stock.id = '" + SMODEL.ID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
        public static int getStockStatus()
        {
            int WHID = 1005;
            String sql = @"  SELECT COUNT(*)
                        FROM Stock s
                        INNER JOIN Product p ON s.PID = p.Id
                        WHERE S.WHID = '" + WHID + @"' 
                        AND s.Quantity <= P.PThreshHoldValue";
          
            object lowstock = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return int.Parse(lowstock.ToString());
        }
    }
}
