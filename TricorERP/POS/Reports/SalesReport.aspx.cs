﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Reports
{
    public partial class SalesReport : System.Web.UI.Page
    {
        List<Models.POS.Report.ReportModel> salesreport = null;
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
            LoadSalesListView("");
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

        protected void Search_Click(object sender, EventArgs e)
        {
            LoadSalesListView(SearchSales.Text);
            if (salesreport.Count == 0)
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
            string url = "../PrintPreviews/SalesReportPrintPreview.aspx";
            string s = "window.open('" + url + "', 'popup_window', 'width=1200,height=530,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
        }

    }
}