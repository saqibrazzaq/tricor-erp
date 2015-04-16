using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Reports
{
    public partial class StockReport : System.Web.UI.Page
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
            LoadStockListView();
        }

        private void LoadStockListView()
        {
            List<Models.POS.Stock.POSStockModel> stocklist = GetStockListFromBD();
            StockReportView.DataSource = stocklist;
            StockReportView.DataBind();
        }

        private List<Models.POS.Stock.POSStockModel> GetStockListFromBD()
        {
            return Database.POS.StockDB.getStockList("");
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
            // to be continue on that point and next work is related to the purchases....
        }

        protected void StockReportView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Models.POS.Stock.POSStockModel stock = (Models.POS.Stock.POSStockModel)e.Item.DataItem;
            if (stock.Quantity < 10)
            {
                // make the data row red
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("tr1");

                row.Attributes.Add("Class", "alert-warning");
            }
        }
    }
}