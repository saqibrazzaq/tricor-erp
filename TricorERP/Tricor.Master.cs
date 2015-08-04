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
            if (Session["UserID"] == null) 
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        protected void LogoffLinkButton(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            //Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Redirect("~/Login.aspx");
        }
    }
}