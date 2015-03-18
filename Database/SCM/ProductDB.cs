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
        //public static ProductModel addProduct(String Pname, String Pcode, float Pprice, String Pdescription)
        public static ProductModel addProduct( ProductModel productModel)
        {
              String sql = @"INSERT INTO [dbo].[Product]
                        ([PName],[PCode],[PPrice],[PDescription])
		                output inserted.ID 
                        VALUES ('" + productModel.ProductName + "','" + productModel.ProductCode + "','" + productModel.ProductPrice + "','" + productModel.ProductDescription + "')";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            productModel.ProductID = int.Parse(id.ToString());
            return productModel;
        }
        
        public static List<ProductModel> ProductList(String searchtext)
        {
            List<ProductModel> productList = new List<ProductModel>();
            String sql = @"select top 10 Product.PId PID, Product.PName PName, Product.PCode PCode, Product.PPrice PPrice
                        from Product
                        where 1=1
                        and 
	                    (Product.PName like '%" + searchtext + "%' or Product.PCode like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = int.Parse(reader["PID"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.ProductPrice = float.Parse(reader["PPrice"].ToString());
                productList.Add(product);
            }
            return productList;
        }
        public static ProductModel getProductInFo(String ID)
        {
            ProductModel product = new ProductModel();
            String sql = @"select Product.PName Name, Product.PCode PCode from Product where Product.id='" + ID + "'";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            if (reader.Read())
            {
                product.ProductName = reader["Name"].ToString();
                product.ProductCode = reader["PCode"].ToString();
            }
            return product;
        }

    }
}

