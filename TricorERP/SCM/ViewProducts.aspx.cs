using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewProducts : System.Web.UI.Page
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
            return Database.SCM.ProductDB.getProductList(SearchProduct);
        }
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditProduct")
            {
                String ProductID = e.CommandArgument.ToString();
                // not really need to save in session...
                Session["ProductID"] = ProductID;
                Response.Redirect("~/SCM/AddNewProduct.aspx?ProductID=" + ProductID + "&update=1");
            }
        }

        protected void SearchProduct(object sender, EventArgs e)
        {
            SearchProduct(SearchProductText.Text);
        }

    }
}