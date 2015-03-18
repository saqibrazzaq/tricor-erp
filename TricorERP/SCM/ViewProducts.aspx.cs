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

        }
        protected void SearchProduct(Object sender, EventArgs e)
        {
            String searchProduct = SearchProductText.Text;
            List<Models.SCM.ProductModel> products = null;
            if (searchProduct == null)
            {
                //products = GetFromDatabase(null);
            }
            else if (searchProduct != null)
            {
                //products = GetFromDatabase(searchProduct);
            }
            CustomerListview.DataSource = products;
            CustomerListview.DataBind();
        }

        //private List<Models.SCM.ProductModel> GetFromDatabase(String x)
        //{
        //    //what is CustomerDatabase?
        //    return Database.SCM.CustomerDB.getCustomersList(x);
        //}

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit customer command
            if (e.CommandName == "EditCustomer")
            {
                // Customer ID is in argument
                String customerID = e.CommandArgument.ToString();
                // Open the edit customer page
                Response.Redirect("EditCustomer.aspx?ID=" + customerID);
                Session["CustomerID"] = customerID;
            }
        }

        //protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        //{
        //    SearchCustomers(SearchCustomer.Text);
        //}

    }
}