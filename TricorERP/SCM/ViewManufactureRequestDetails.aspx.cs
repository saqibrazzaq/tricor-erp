using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class ViewOrderDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetOrderDetails();
        }
        
        protected void OrderDetailsListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }            
        }
        protected void GetOrderDetails()
        {
            String OrderID = Request.QueryString["OrderID"];
            List<Models.SCM.SalesOrderItemModel> items = Database.SCM.SalesOrder.GetOrderItems(OrderID);
            OrderDetialsListview.DataSource = items;
            OrderDetialsListview.DataBind();
        }
        protected void OrderDetailsListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        
    }
}