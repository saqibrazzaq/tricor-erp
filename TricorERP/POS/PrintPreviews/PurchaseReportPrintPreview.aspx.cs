using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.PrintPreviews
{
    public partial class PurchaseReportPrintPreview : System.Web.UI.Page
    {
        List<Models.POS.Report.ReportModel> purchasereport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            LoadPurchaseOrderListView("");
        }

        private void LoadPurchaseOrderListView(string searchbydate)
        {
            if (searchbydate == null)
            {
                purchasereport = GetPurchaseRoport("");
            }
            else
            {
                purchasereport = GetPurchaseRoport(searchbydate);
            }
            PurchaseReportView.DataSource = purchasereport;
            PurchaseReportView.DataBind();
        }

        private List<Models.POS.Report.ReportModel> GetPurchaseRoport(string p)
        {
            return Database.POS.ReportDB.getPurchaseReport(p);
        }
    }
}