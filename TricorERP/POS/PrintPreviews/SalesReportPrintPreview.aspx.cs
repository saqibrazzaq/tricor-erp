using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.PrintPreviews
{
    public partial class SalesReportPrintPreview : System.Web.UI.Page
    {
        List<Models.POS.Report.ReportModel> salesreport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            LoadSalesListView("");
            CurrentDatVariable.Text = "("+System.DateTime.Now.ToString()+")";
        }
        private void LoadSalesListView(String searchbydate)
        {
            if (searchbydate == null)
            {
                salesreport = GetSalesRoport("");
            }
            else
            {
                salesreport = GetSalesRoport(searchbydate);
            }
            SalesReportView.DataSource = salesreport;
            SalesReportView.DataBind();
        }
        private List<Models.POS.Report.ReportModel> GetSalesRoport(String searchbydate)
        {
            return Database.POS.ReportDB.getSaleReport(searchbydate, Common.OrderApproved);
        }
    }
}