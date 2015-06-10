using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Catalog
{
    public partial class MainCatalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Database.POS.MainCatalog catalogObject = new Database.POS.MainCatalog();

            SqlDataAdapter sda = catalogObject.showCatalogData();

            DataTable dt = new DataTable();
            sda.Fill(dt);

            mainCatalogListview.DataSource = dt;
            mainCatalogListview.DataBind();
        }
    }
}