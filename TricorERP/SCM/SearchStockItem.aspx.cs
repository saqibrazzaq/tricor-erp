using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchStockItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            SearchProduct("");
        }
        private void SearchProduct(String SearchProduct)
        {
            // Declare list
            List<Models.SCM.ProductModel> product = null;
            if (SearchProduct == "")
            {
                product = GetFromDatabase(null);
            }
            else if (SearchProduct != null)
            {
                product = GetFromDatabase(SearchProduct);
            }
            ProductListview.DataSource = product;
            ProductListview.DataBind();
        }

        private List<Models.SCM.ProductModel> GetFromDatabase(String SearchProduct)
        {
            return Database.SCM.StockDB.geStockItemList(SearchProduct);
        }
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                String ProductID = e.CommandArgument.ToString();
                Session["ProductID"] = ProductID;
                Response.Redirect("~/SCM/EditProduct.aspx?ID=" + ProductID);
            }
        }

        protected void SearchWareHouse(object sender, EventArgs e)
        {
            SearchProduct(SearchStockItemText.Text);
        }

    }
}