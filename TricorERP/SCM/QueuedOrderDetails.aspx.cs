using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class QueuedOrderDetails : System.Web.UI.Page
    {
        String QueryID;
        protected void Page_Load(object sender, EventArgs e)
        {
            QueryID = Request.QueryString["OrderID"];
            GetOrderDetails();
        }

        protected void OrderDetailsListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "none")
            {
                String ID = e.CommandArgument.ToString();
            }
            if(e.CommandName == "one-more-completion")
            {
                String ID = e.CommandArgument.ToString();
                Database.SCM.SalesOrder.UpdateManufacturedQuantityByOne(ID);

                GetOrderDetails();
            }
            
        }
        
        protected void GetOrderDetails()
        {
            String OrderID = QueryID;
            List<Models.SCM.SalesOrderItemModel> items = Database.SCM.SalesOrder.GetOrderItems(OrderID);
            OrderDetialsListview.DataSource = items;
            OrderDetialsListview.DataBind();
        }
        protected void OrderDetailsListview_SelectedIndexChanged(object sender, EventArgs e)
        {
                     
        }
    }
}