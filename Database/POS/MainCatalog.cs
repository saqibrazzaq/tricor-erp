using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.POS
{
    public class MainCatalog
    {
        SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
        string sqlQuery = null;
        string productTypeId = null;

        public SqlDataAdapter showCatalogProducts(string pTypeId) // show main catalog products
        {
            productTypeId = pTypeId;

            if (productTypeId == "AllProducts") // show all products of all catagories
            {
                sqlQuery = "SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId";
            }

            else  // show specific catagory products
            {
                sqlQuery = "SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId where Product.ProductTypeID=" + productTypeId;
            }

            SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, con);
            return sda;
        }

        public SqlDataAdapter searchCatalogProducts(string searchText) // show all searched products
        {
            sqlQuery = "SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId where Product.PName LIKE '" + searchText + "%' OR Product.SalePrice Like '" + searchText + "%'";

            SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, con);
            return sda;
        }
    }
}
