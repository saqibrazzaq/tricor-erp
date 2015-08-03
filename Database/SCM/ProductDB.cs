using Models.SCM;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.SCM
{

    public class ProductDB
    {
        public static ProductModel addProduct( ProductModel productModel)
        {
              String sql = @"INSERT INTO [dbo].[Product]
                        ([PName],[PCode],[SalePrice],[PDescription],[PThreshHoldValue],[PReOrderValue],[PurchasePrice],
                        [UnitTypeID],[ProductTypeID],[CreatedBy],[LastUpdatedBy],[ManufactureTime])
		                output inserted.ID 
                        VALUES ('" + productModel.ProductName + "','" + productModel.ProductCode + "','" +
                                   productModel.SalesPrice + "','" + productModel.ProductDescription   +
                                   "','" + productModel.ProductThresholdValue + "','" + productModel.ProductReOderValue + "','" +
                                   productModel.PurchasePrice + "','" + productModel.UnitTypeID + "','" + productModel.ProductTypeID +
                                   "','" + productModel.CreatedBy + "','" + productModel.LastUpdatedBy + "','" + productModel.ManufactureTime + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            productModel.ProductID = int.Parse(id.ToString());
            return productModel;
        }
        // this function is for getting Rawmaterial list
        public static List<ProductModel> getProductListOfType(String ID)
        {
            List<ProductModel> productList = new List<ProductModel>();
            String sql = @"select Product.Id PID, Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID,Product.ManufactureTime ManufactureTime
                        from Product
                        where Product.ProductTypeID='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = int.Parse(reader["PID"].ToString());
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = int.Parse(reader["productTypeID"].ToString());
                product.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                product.ManufactureTime = int.Parse(reader["ManufactureTime"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                productList.Add(product);
            }
            return productList;
        }
        // this function is Same as above but it gives all products list
        public static List<ProductModel> getProductList(String searchtext)
        {
            List<ProductModel> productList = new List<ProductModel>();
            String sql = @"select Product.Id PID, Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID, Product.ManufactureTime
                        from Product
                        where 1=1
                        and 
	                    (Product.PName like '%" + searchtext + "%' or Product.PCode like '%" + searchtext + "%')";
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
                product.ManufactureTime = int.Parse(reader["ManufactureTime"].ToString());
                productList.Add(product);
            }
            return productList;
        }
        public static ProductModel getProductInFo(String ID)
        {
            ProductModel product =null;
            String sql = @"select Product.PName PName, Product.PCode PCode, Product.SalePrice SalePrice ,Product.PDescription PDescription ,
                        Product.PThreshHoldValue PthreshHold,Product.PReOrderValue pReOrder,Product.PurchasePrice purchasePrice,
                        Product.UnitTypeID UnitTypeID,Product.ProductTypeID productTypeID, Product.ManufactureTime
                        from Product where Product.id='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                product = new ProductModel();
                product.ProductThresholdValue = int.Parse(reader["PthreshHold"].ToString());
                product.ProductReOderValue = int.Parse(reader["pReOrder"].ToString());
                product.ProductTypeID = int.Parse(reader["productTypeID"].ToString());
                product.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.ProductDescription = reader["PDescription"].ToString();
                product.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                product.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                product.ManufactureTime = int.Parse(reader["ManufactureTime"].ToString());
            }
            return product;
        }

        public static int updateProduct(ProductModel pModel)
        {
            String sql = @"UPDATE [dbo].[Product]
                         SET [PName] = '" + pModel.ProductName + "' ,[pCode] = '" + pModel.ProductCode 
                        +"', [SalePrice]='" + pModel.SalesPrice+ "' , [PDescription] = '" + pModel.ProductDescription 
                        + "' , [PThreshHoldValue] = '" + pModel.ProductThresholdValue 
                        + "',[PReOrderValue] = '" +pModel.ProductReOderValue + "' , [PurchasePrice] = '" + pModel.PurchasePrice 
                        + "' , [UnitTypeID] = '" +pModel.UnitTypeID + "' , [ProductTypeID] = '" + pModel.ProductTypeID
                        + "' , [LastUpdatedBy] = '" + pModel.LastUpdatedBy + "' , [ManufactureTime] = '" + pModel.ManufactureTime
                        + "' WHERE Product.id = '" + pModel.ProductID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }

        public static int DeleteProduct(string PID)
        {
            String sql = @"DELETE FROM Product WHERE Id ='" + PID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery( System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }

        //  Product Coposition data

        public static ProductCompositionModel addProductCompositionItem(ProductCompositionModel PCModel)
        {
            String sql = @"INSERT INTO [dbo].[ProductComposition]
                        ([PID],[RMID],[Quantity],[CreatedBy],[LastUpdatedBy] )
		                output inserted.ID 
                        VALUES ('" + PCModel.ProductID + "','" + PCModel.RawMaterialID + "','" +
                                    PCModel.Quantity + "','" +  PCModel.CreatedBy + "','" + PCModel.LastUpdatedBy + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            PCModel.ID = int.Parse(id.ToString());
            return PCModel;
        }

        public static List<ProductCompositionModel> getProductCompositionList(String PID)
        {
            List<ProductCompositionModel> productCompositionList = new List<ProductCompositionModel>();
            String sql = @"select ProductComposition.id ID, ProductComposition.RMID RMID, ProductComposition.Quantity Quantity
                        from ProductComposition
                        where ProductComposition.PID='" + PID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductCompositionModel productComposition = new ProductCompositionModel();
                productComposition.ID = int.Parse(reader["ID"].ToString());
                productComposition.RawMaterialID = int.Parse(reader["RMID"].ToString());
                productComposition.Quantity = int.Parse(reader["Quantity"].ToString());
                productCompositionList.Add(productComposition);
            }
            return productCompositionList;
        }
        public static int DeleteProductCompositionItem(string PID)
        {
            String sql = @"DELETE FROM ProductComposition WHERE Id ='" + PID + "'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check > 0)
            {
                return 1;
            }
            return 0;
        }
        public static int updateProductCompositionItem(ProductCompositionModel PCModel)
        {
            String sql = @"UPDATE [dbo].[ProductComposition] SET [Quantity] = '" + PCModel.Quantity 
                + "' , [LastUpdatedBy] = '" + PCModel.LastUpdatedBy +"'";
            int check = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            if (check == 1)
            {
                return 1;
            }
            return 0;
        }
    }
}

