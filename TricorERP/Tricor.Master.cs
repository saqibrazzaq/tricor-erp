using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP
{
    public partial class Tricor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void LogoffLinkButton(object sender, EventArgs e)
        {
            Session["logOutMsg"] = "You logout successfully";
            Session["UserName"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}