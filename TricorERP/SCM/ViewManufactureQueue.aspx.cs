using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewManufactureQueue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Models.SCM.SalesOrderModel> orders = Database.SCM.SalesOrder.ViewQueuedOrders();
            MQListview.DataSource = orders;
            MQListview.DataBind();
        }

        protected void MQListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }
            if (e.CommandName == "viewdetails")
            {
                String OrderID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/QueuedOrderDetails.aspx?OrderID=" + OrderID);
            }
            
        }
        protected void MQListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}