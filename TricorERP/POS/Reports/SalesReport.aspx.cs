using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Reports
{
    public partial class SalesReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            Models.POS.Order.SaleOrderModel salesreport = GetSalesRoport();
            //to be continue...
        }

        /*That function get the data of sales order of a day*/
        private Models.POS.Order.SaleOrderModel GetSalesRoport()
        {
            return Database.POS.ReportDB.getSaleReport();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}