using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Order;

// for get the products
using Models.POS;



namespace TricorERP.POS.Order
{
    public partial class EditOrder : System.Web.UI.Page
    {
        List<SaleOrderItemModel> orderitemlist = new List<SaleOrderItemModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }


        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit customer command
            if (e.CommandName == "EditCustomer")
            {
                // Customer ID is in argument
                String customerID = e.CommandArgument.ToString();
                // Open the edit customer page
                Response.Redirect("EditCustomer.aspx?ID=" + customerID);
            }
        }


        private void InitializePageContents()
        {
            LoadProductsListInDropdown();
        }

        // load all the data of products in the drop down list and that list is get from database 
        private void LoadProductsListInDropdown()
        {
            List<ProductModel> productlist = GetProductsList();
            ProductsDropDown.DataTextField = "Name";
            ProductsDropDown.DataValueField = "ID";
            ProductsDropDown.DataBind();
        }
        // return all the product list that is save in the database
        private List<ProductModel> GetProductsList()
        {
            return Database.SCM.ProductDB.getProductList("");
        }

        protected void AddProducts_Click(object sender, EventArgs e)
        {
            AddProductToOrder();
        }

        // addition of products in Product list.
        private void AddProductToOrder()
        {
            int productID = int.Parse(ProductsDropDown.SelectedValue);
            SaleOrderItemModel orderItem = new SaleOrderItemModel();

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }


    }
}