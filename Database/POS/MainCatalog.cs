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
        public SqlDataAdapter showCatalogData()
        {

            SqlConnection con = new SqlConnection(DBUtility.SqlHelper.connectionString);
            string sqlQuery = "SELECT Product.PName, MainCatalog.ImagePath, Product.PDescription, Product.SalePrice FROM Product INNER JOIN MainCatalog ON Product.Id=MainCatalog.PId";

            SqlDataAdapter sda = new SqlDataAdapter(sqlQuery, con);
            return sda;
        }
    }
}
