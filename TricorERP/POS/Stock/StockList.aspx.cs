using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Stock
{
    public partial class StockList : System.Web.UI.Page
    {
        List<Models.POS.Stock.POSStockModel> stocklist = null;
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
            SearchStockProducts("");
        }

        private void SearchStockProducts(string productname)
        {
            
            if (productname == null)
            {
                stocklist = GetStockListFromBD(null);
            }
            else
            {
                stocklist = GetStockListFromBD(productname);
            }
            OrderListview.DataSource = stocklist;
            OrderListview.DataBind();
        }

        private List<Models.POS.Stock.POSStockModel> GetStockListFromBD(string productname)
        {
            return Database.POS.StockDB.getStockList(productname);
        }

        protected void SearchStockItems_Click(object sender, EventArgs e)
        {
            SearchStockProducts(SearchStockData.Text);
            if (stocklist.Count == 0)
                ErrorMessage.Text = @"Data is not found..... ";
        }

        protected void StockListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit Sales order 
            if (e.CommandName == "EditstockItems")
            {
                
            }
        }

        protected void deleteStockItem_onClick(object sender, EventArgs e)
        {
            int itemID = int.Parse(txtStockItemID.Text);
            int check = Database.POS.StockDB.deleteStockItem(itemID);
            InitializePageContents();
        }

        protected void SaveStockItem_onClick(object sender, EventArgs e)
        {
            Models.POS.Stock.POSStockModel posstockmodel = new Models.POS.Stock.POSStockModel()
            {
                ID = int.Parse(txtStockItemID.Text),
                Quantity = int.Parse(txtQuantity.Text),
                WHID = 1
            };
            int check = Database.POS.StockDB.updateStockQuantity(posstockmodel);
            if (check > 0)
                InitializePageContents();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }


    }
}