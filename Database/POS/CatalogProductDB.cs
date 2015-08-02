using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class CatalogProductDB
    {
        public static string sql;
        public static int AddProduct(Models.POS.Product.ProductModel productModel)
        {
            sql = @"INSERT INTO [dbo].[Product]
                        ([PName],[PCode],[SalePrice],[PDescription],[PThreshHoldValue],[PReOrderValue],[PurchasePrice],
                        [UnitTypeID],[ProductTypeID], [CreatedBy], [LastUpdatedBy])
		                output inserted.ID 
                        VALUES ('" + productModel.ProductName + "','" + productModel.ProductCode + "','" +
                                 productModel.SalesPrice + "','" + productModel.ProductDescription +
                                 "','" + productModel.ProductThresholdValue + "','" + productModel.ProductCatagory + "','" +
                                 productModel.PurchasePrice + "','" + productModel.UnitTypeID + "','" + productModel.ProductTypeID + "'," + productModel.CreatedBy + "," + productModel.LastUpdatedBy + ")";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return Convert.ToInt32(id);
        }

        public static int uploadImage(int pID, string imgPath)
        {
            sql = @"INSERT INTO [dbo].[MainCatalog]
                        ([PId],[ImagePath])
		                output inserted.CId
                        VALUES (" + pID + ",'" + imgPath + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            int imgId = Convert.ToInt32(id);

            return imgId;
        }

        public static int deleteProduct(int productId)
        {
            sql = @"DELETE FROM [dbo].[MainCatalog] WHERE PId=" + productId;
            DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);

            sql = @"DELETE FROM [dbo].[Product] WHERE Id=" + productId;
            object temp = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            return Convert.ToInt32(temp);
        }

        public static Models.POS.Product.ProductModel showProduct(int productId, Models.POS.Product.ProductModel productModel)
        {
            sql = @"SELECT * FROM Product where Id=" + productId;

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                productModel.ProductID = int.Parse(reader["Id"].ToString());
                productModel.ProductName = reader["PName"].ToString();
                productModel.ProductCode = reader["PCode"].ToString();
                productModel.SalesPrice = float.Parse(reader["SalePrice"].ToString());
                productModel.ProductDescription = reader["PDescription"].ToString();
                productModel.ProductThresholdValue = int.Parse(reader["PThreshHoldValue"].ToString());
                productModel.ProductCatagory = int.Parse(reader["PReOrderValue"].ToString());
                productModel.PurchasePrice = float.Parse(reader["PurchasePrice"].ToString());
                productModel.UnitTypeID = int.Parse(reader["UnitTypeID"].ToString());
                productModel.ProductTypeID = int.Parse(reader["ProductTypeID"].ToString());
                productModel.CreatedBy = int.Parse(reader["CreatedBy"].ToString());
                productModel.LastUpdatedBy = int.Parse(reader["LastUpdatedBy"].ToString());
            }

            return productModel;
        }

        public static string showProductImage(int productId)
        {
            string imgPath = "";
            sql = @"select * from [dbo].[Product] WHERE PId=" + productId;

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                imgPath = reader["ImagePath"].ToString();
            }

            return imgPath;
        }

        public static int updateProduct(int productId, string imgPath, Models.POS.Product.ProductModel productModel)
        {
            String sql = @"UPDATE [dbo].[Product]
                         SET [PName] = '" + productModel.ProductName + "',[PCode] = '" + productModel.ProductCode + "', [SalePrice] = " + productModel.SalesPrice + ", [PDescription] = '" + productModel.ProductDescription + "', [PThreshHoldValue] = " + productModel.ProductThresholdValue + ",[PReOrderValue] = " + productModel.ProductCatagory + ",[PurchasePrice] = " + productModel.PurchasePrice + ", [UnitTypeID] = " + productModel.UnitTypeID + ",[ProductTypeID] = " + productModel.ProductTypeID + ", [CreatedBy] = " + productModel.CreatedBy + ", [LastUpdatedBy] = " + productModel.LastUpdatedBy + " where Id=" + productId;

            DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);

            sql = @"UPDATE [dbo].[MainCatalog]
                         SET [ImagePath] = '" + imgPath + "' where PId=" + productId;

            int result = DBUtility.SqlHelper.ExecuteNonQuery(System.Data.CommandType.Text, sql, null);
            return result;
        }

        public static string getCatalogImgPath(int pId)
        {
            string imgPath = "";
            sql = @"select  [ImagePath] from [dbo].[MainCatalog] where PId=" + pId;

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
           if (reader.Read())
            {
                imgPath = reader["ImagePath"].ToString();
            }

            return imgPath;
        }

    }
}
