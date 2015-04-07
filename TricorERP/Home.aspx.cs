using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String User = Session["Username"].ToString();
            //if (User == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //else
            //{
                if (IsPostBack == false)
                {
                    InitializePageContents();
                }
            //}
        }

        private void InitializePageContents()
        {
            UpdateDatabasePanels();
        }

        private void UpdateDatabasePanels()
        {
            //String RoleID = Session["RoleID"].ToString();
            if (Session["RoleID"].ToString() == "1" || Session["RoleID"].ToString() == "2")
            {
                UpdatePOSPanels();
            }
        }

        private void UpdatePOSPanels()
        {
            GetPendingSalesOrder();
            GetInProgressSalesOrder();
        }

        private void GetPendingSalesOrder()
        {
            int pendingsaleorder = Database.POS.Order.OrderDB.getPendingSalesOrder();

        }

        private void GetInProgressSalesOrder()
        {
            
        }

    }
}