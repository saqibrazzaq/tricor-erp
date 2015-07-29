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
        Database.POS.MainCatalog mainCatalogObject = new Database.POS.MainCatalog();
        List<Models.Common.CatalogModel> sda = null;
        string catId = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            catId = Request.QueryString["CatId"];
            catName.Text = Request.QueryString["CatName"];

            sda = Database.POS.MainCatalog.showCatalogProducts(catId);
            setListView();

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            if (searchProduct.Text != "")
            {
                sda = Database.POS.MainCatalog.searchCatalogProducts(searchProduct.Text);
                setListView();
            }
        }

        public void setListView()
        {

            mainCatalogListview.DataSource = sda;
            mainCatalogListview.DataBind();
        }
    }
}