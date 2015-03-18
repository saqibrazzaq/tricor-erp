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
        public static ProductModel addProduct(String Pname, String Pcode, float Pprice, String Pdescription)
        {
            ProductModel userModel = null;

            try
            {

            }
            catch (Exception e)
            {
                e.ToString();
            }
            return userModel;
        }
        public static List<ProductModel> ProductList(String searchtext)
        {

            List<ProductModel> productList = new List<ProductModel>();
            String sql = @"select top 10 Product.PId PID, Product.PName PName, Product.PCode Pcode, Product.PPrice PPrice
                        from Product
                        where 1=1
                        and 
	                    (Product.PName like '%" + searchtext + "%' or Product.PCode like '%" + searchtext + "%')";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while (reader.Read())
            {
                ProductModel product = new ProductModel();
                product.ProductID = int.Parse(reader["ID"].ToString());
                product.ProductName = reader["PName"].ToString();
                product.ProductCode = reader["PCode"].ToString();
                product.ProductPrice = float.Parse(reader["PPrice"].ToString());
                productList.Add(product);
            }
            return productList;
        }
    }
}

