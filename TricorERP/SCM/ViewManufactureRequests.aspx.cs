using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewApprovedOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void SearchOrder(String text)
        {
            List<Models.SCM.SalesOrderModel> orders = Database.SCM.SalesOrder.GetApprovedOrders(text);
            ApprovedOrderListview.DataSource = orders;
            ApprovedOrderListview.DataBind();
        }
        protected void ApprovedOrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }
            if (e.CommandName == "viewdetails")
            {
               String OrderID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/ViewManufactureRequestDetails.aspx?OrderID=" + OrderID);
            }
            if(e.CommandName == "manufacture")
            {
                String OrderID = e.CommandArgument.ToString();
                Database.SCM.SalesOrder.SendToManufacture(OrderID);
                SearchOrder("");
            }
        }


        protected void SearchOrder(object sender, EventArgs e)
        {
            SearchOrder(SearchApprovedOrdersText.Text);
        }

        protected void ApprovedOrderListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void SearchApprovedOrdersText_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ViewDetails(String id)
        {
           
        }

    }
}