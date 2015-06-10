using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace TricorERP.POS.PrintPreviews
{
    public partial class StockReportPrintPreview : System.Web.UI.Page
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

        protected void StockReportView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Models.POS.Stock.POSStockModel stock = (Models.POS.Stock.POSStockModel)e.Item.DataItem;
            if (stock.Quantity <= Database.POS.StockDB.getThreshHoldValue(stock.ID, Common.WarehouseIDDefault))
            {
                HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("tr1");
                row.Attributes.Add("Class", "alert-danger");
            }
            else
            {
                Label lab = (Label)e.Item.FindControl("StockLowMessage");
                lab.Attributes.Add("Class", "hidden");
            }
        }
    }
}