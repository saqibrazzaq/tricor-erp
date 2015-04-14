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
            LoadListView();

        }

        private void LoadListView()
        {
            List<Models.POS.Order.SaleOrderItemModel> salesreport = GetSalesRoport();
            SalesReportView.DataSource = salesreport;
            SalesReportView.DataBind();
        }

        private List<Models.POS.Order.SaleOrderItemModel> GetSalesRoport()
        {
            DateTime date = DateTime.Now;
            String shortdate = date.ToShortDateString();
            error.Text = shortdate;
            return Database.POS.ReportDB.getSaleReport(shortdate);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}