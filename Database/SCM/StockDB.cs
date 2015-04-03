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
                sModel.Quantity = float.Parse(reader["Quantity"].ToString());
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
                sModel.Quantity = float.Parse(reader["Quantity"].ToString());
                stockItemList.Add(sModel);
            }
            return stockItemList;
        }
    }
}
