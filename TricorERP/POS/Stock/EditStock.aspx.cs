using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Stock
{
    public partial class EditStock : System.Web.UI.Page
    {
        Models.POS.Stock.POSStockModel stckModel = new Models.POS.Stock.POSStockModel()
        {
            ID = 0
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            InitializeStockModel();
            LoadProductDropDownList();
        }

        private void LoadProductDropDownList()
        {
            List<Models.POS.ProductModel> productlist = GetProductList();
            ProductDropDownList.DataSource = productlist;
            ProductDropDownList.DataTextField = "ProductName";
            ProductDropDownList.DataValueField = "ProductID";
            ProductDropDownList.DataBind();
        }

        private List<Models.POS.ProductModel> GetProductList()
        {
            return Database.POS.ProductDB.getProductList();
        }

        private void InitializeStockModel()
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    stckModel.ID = int.Parse(Request.QueryString["ID"]);
                }
            }
            catch (Exception ex)
            {
                stckModel.ID = 0;
                throw ex;
            }
        }

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            SaveProductInStock();
        }

        private void SaveProductInStock()
        {
            InitializeStockModel();
            if (stckModel.ID == 0)
            {
                NewStock();
            }
            else
            {
                UpdateStock();
            }
        }


        private void NewStock()
        {
            if (Quantity.Text == "")
                MessageLable.Text = "Enter Quantity...";
            else
            {
                Models.POS.Stock.POSStockModel stockItems = CreateStockItemFromUI();
                stockItems = Database.POS.StockDB.addNewStock(stockItems);
                stckModel.ID = stockItems.ID;
                MessageLable.Text = "Data of stock is saved...";
            }
        }
        private void UpdateStock()
        {
            Models.POS.Stock.POSStockModel updatestockitems = CreateStockItemFromUI();
            int check = Database.POS.StockDB.updateStock(updatestockitems);
            if (check > 0)
                MessageLable.Text = "Data is Updated....";
        }
        private Models.POS.Stock.POSStockModel CreateStockItemFromUI()
        {
            Models.POS.Stock.POSStockModel productstock = new Models.POS.Stock.POSStockModel();
            productstock.ProductID = int.Parse(ProductDropDownList.SelectedValue);
            productstock.Quantity = int.Parse(Quantity.Text);

            // how to set WHID in stock
            productstock.WHID = 1;
            return productstock;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}