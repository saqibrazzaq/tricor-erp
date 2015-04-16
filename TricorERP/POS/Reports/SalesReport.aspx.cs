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
            float[] totalsaleprice = new float[salesreport.Count];
            float[] totalpurchasePrice = new float[salesreport.Count];

            for (int i = 0; i < salesreport.Count; i++) {
                totalsaleprice[i] = salesreport[i].Price;
                totalpurchasePrice[i] = salesreport[i].PurchasePrice;
            }
            float totalsp = 0;
            float totalpp = 0;
            for (int i = 0; i < salesreport.Count; i++) {
                totalsp = totalsp + totalsaleprice[i];
                totalpp = totalpp + totalpurchasePrice[i];
            }

            TotalSalePrice.Text = "Total Sales Price :" + totalsp;
            TotalPurchasePrice.Text = "Total Purchase Price :" + totalpp;
            Profit.Text = "Profit is :" + (totalsp - totalpp); 
        }

        private List<Models.POS.Order.SaleOrderItemModel> GetSalesRoport()
        {
            return Database.POS.ReportDB.getSaleReport();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

    }
}