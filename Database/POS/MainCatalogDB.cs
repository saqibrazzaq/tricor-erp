using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class MainCatalogDB
    {
        SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
        
        
        String productTypeId = null;

        public static List<Models.Common.CatalogModel> showCatalogProducts(string pTypeId)
        {
            List<Models.Common.CatalogModel> catalogs = new List<Models.Common.CatalogModel>();
            String sqlQuery = null;
            if (pTypeId == "AllProducts") // show all products of all catagories
            {
                sqlQuery = @"SELECT Product.Id,Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice 
                                       FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId";
            }
            else  // show specific catagory products
            {
                sqlQuery = @"SELECT Product.Id, Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice 
                                        FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId 
                                        where Product.ProductTypeID=" + pTypeId;
            }
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlQuery, null);
            while (reader.Read())
            {
                Models.Common.CatalogModel catalog = new Models.Common.CatalogModel();
                catalog.ID = reader["ID"].ToString();
                catalog.ImagePath = reader["ImagePath"].ToString();
                catalog.PDescription = reader["PDescription"].ToString();
                catalog.PName = reader["PName"].ToString();
                catalog.SalePrice = int.Parse(reader["SalePrice"].ToString());

                catalogs.Add(catalog);
            }
            return catalogs;
        }

//        public SqlDataAdapter showCatalogProducts(string pTypeId) // show main catalog products
//        {
//            productTypeId = pTypeId;

//            if (productTypeId == "AllProducts") // show all products of all catagories
//            {
//                sqlQuery = @"SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice 
//                           FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId";
//            }

//            else  // show specific catagory products
//            {
//                sqlQuery = @"SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice 
//                            FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId 
//                            where Product.ProductTypeID=" + productTypeId;
//            }

//            SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, con);
//            return sda;
//        }

//        public SqlDataAdapter searchCatalogProducts(string searchText) // show all searched products
//        {
//            String sqlQuery = @"SELECT Product.Id, Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product 
//                        INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId 
//                        where Product.PName LIKE '" + searchText + "%' OR Product.SalePrice Like '" + searchText + "%'";

//            SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, con);
//            return sda;
//        }

        public static List<Models.Common.CatalogModel> searchCatalogProducts(string searchText) // show all searched products
        {
            String sqlQuery = @"SELECT Product.Id, Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product 
                        INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId 
                        where Product.PName LIKE '" + searchText + "%' OR Product.SalePrice Like '" + searchText + "%'";

            List<Models.Common.CatalogModel> catalogs = new List<Models.Common.CatalogModel>();

            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlQuery, null);
            while (reader.Read())
            {
                Models.Common.CatalogModel catalog = new Models.Common.CatalogModel();
                catalog.ID = reader["ID"].ToString();
                catalog.ImagePath = reader["ImagePath"].ToString();
                catalog.PDescription = reader["PDescription"].ToString();
                catalog.PName = reader["PName"].ToString();
                catalog.SalePrice = int.Parse(reader["SalePrice"].ToString());

                catalogs.Add(catalog);
            }
            return catalogs;
        }

    }
}
