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
        Models.POS.ProductModel product = new Models.POS.ProductModel() { 
            ProductID = 0
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
            InitializeProductModel();
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

        private void InitializeProductModel()
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    product.ProductID = int.Parse(Request.QueryString["ID"]);
                }
            }
            catch (Exception ex)
            {
                product.ProductID = 0;
                throw ex;
            }
        }

        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            SaveProductInStock();
        }

        private void SaveProductInStock()
        {
            InitializeProductModel();
            if (product.ProductID == null)
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
            
        }
        private void UpdateStock()
        {

        }
        private Models.POS.Stock.POSStockModel CreateStockItemFromUI()
        {
            Models.POS.Stock.POSStockModel productstock = new Models.POS.Stock.POSStockModel();
            

            return null;
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}