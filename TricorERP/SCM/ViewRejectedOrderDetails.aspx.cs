using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewRejectedOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetOrderDetails();
        }
        protected void GetOrderDetails()
        {
            String OrderID = Request.QueryString["OrderID"];
            List<Models.SCM.SalesOrderItemModel> items = Database.SCM.SalesOrder.GetOrderItems(OrderID);
            OrderDetialsListview.DataSource = items;
            OrderDetialsListview.DataBind();
            Models.SCM.SalesOrderModel order = Database.SCM.SalesOrder.GetRejectionDetails(OrderID);
            rejectedby.Text = order.RejectedBy;
            rejectedon.Text = order.RejectedOn;
            rejectionreason.Text = order.RejectionReason;
        }
        protected void rejectedby_TextChanged(object sender, EventArgs e)
        {

        }
        protected void rejectionreason_TextChanged(object sender, EventArgs e)
        {

        }
        protected void rejectedon_TextChanged(object sender, EventArgs e)
        {

        }
        protected void OrderDetailsListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void OrderDetailsListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }
            if (e.CommandName == "viewdetails")
            {
                String OrderID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/ViewRejectedOrderDetails.aspx?OrderID=" + OrderID);
            }
        }
    }
}