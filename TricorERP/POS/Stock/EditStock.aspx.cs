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
            ID = Common.NULL_ID
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
                if (Common.CheckNullString(Request.QueryString["ID"]) != Common.NULL_ID)
                {
                    stckModel.ID = Request.QueryString["ID"];
                }
            }
            catch (Exception ex)
            {
                stckModel.ID = null;
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
            if (stckModel.ID == Common.NULL_ID)
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
                Models.POS.Stock.POSStockModel stockItems = CreateStockItemFromUI();
                stockItems = Database.POS.StockDB.addNewStock(stockItems);
                if (stockItems.ID == Common.NULL_ID)
                {
                    //If already existing product is inserted it will show error message
                    MessageLable.Text = @"This product is already exist in stock...";
                }
                else
                {
                    stckModel.ID = stockItems.ID;
                    if(stockItems.check == -1)
                        MessageLable.Text = @"Quantity of New stock is 
                                              Added in previous one...";
                    else
                        MessageLable.Text = "New Data of stock is saved...";
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
            productstock.ProductID = ProductDropDownList.SelectedValue;
            productstock.Quantity = int.Parse(Quantity.Text);

            // how to set WHID in stock
            productstock.WHID = Session["WHID"].ToString();
            return productstock;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void UploadStock_Click(object sender, EventArgs e)
        {
            //to be continue on that point...
        }
    }
}