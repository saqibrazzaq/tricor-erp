using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class RjectOrderReason : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitreason(object sender, EventArgs e)
        {
            String id = Request.QueryString["OrderID"];
            String res = reason.Text;
            Database.SCM.SalesOrder.RejectOrder(id, res); 
            Response.Redirect("~/SCM/ViewManufactureRequests.aspx");
        }
    }
}