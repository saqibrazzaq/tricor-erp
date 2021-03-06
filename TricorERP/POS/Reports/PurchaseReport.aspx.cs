﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Reports
{
    public partial class PurchaseReport : System.Web.UI.Page
    {
        List<Models.POS.Report.ReportModel> purchasereport = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ErrorMessage.Text = "";
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

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadPurchaseOrderListView(SearchPurchaseOrder.Text);
            if (purchasereport.Count == 0)
            {
                ErrorMessage.Text = "Data is not found...";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void printPreview_Click(object sender, EventArgs e)
        {
            string url = "../PrintPreviews/PurchaseReportPrintPreview.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=1200,height=530,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }
    }
}