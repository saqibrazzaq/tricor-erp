using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewAcceptedOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchOrder(SearchOrdersText.Text);
        }
        private void SearchOrder(String text)
        {
            List<Models.SCM.SalesOrderModel> orders = Database.SCM.SalesOrder.ViewAcceptedOrders(text,4);
            OrderListview.DataSource = orders;
            OrderListview.DataBind();
        }
        protected void OrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }
            if (e.CommandName == "viewdetails")
            {
                String OrderID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/ViewSalesOrderDetails.aspx?OrderID=" + OrderID);
            }
        }
        protected void SearchOrdersText_TextChanged(object sender, EventArgs e)
        {

        }
        protected void SearchOrder(object sender, EventArgs e)
        {
            SearchOrder(SearchOrdersText.Text);
        }
        protected void OrderListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}