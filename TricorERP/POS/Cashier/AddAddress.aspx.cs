using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Cashier
{
    public partial class AddAddress : System.Web.UI.Page
    {
        string customerID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["CustomerID"];
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //how to set previous page without effecting the values of previous page?
            Response.Redirect("~/POS/Cashier/EditCustomer.aspx?ID=" + customerID);
        }
    }
}