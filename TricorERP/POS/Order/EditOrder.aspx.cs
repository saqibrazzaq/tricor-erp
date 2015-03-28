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
        List<ProductModel> productlist=null;
        List<CustomerModel> customerlist = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            LoadProductsListInDropdown();
            LoadCustomerListInDropdown();
        }

       
        // load all the data of products in the drop down list and that list is get from database 
        private void LoadProductsListInDropdown()
        {
            // product list is an list type reference that contain the list of products.
            productlist = GetProductsList();
            ProductsDropDown.DataSource = productlist;
            ProductsDropDown.DataTextField = "ProductName";
            ProductsDropDown.DataValueField = "ProductID";
            ProductsDropDown.DataBind();
        }
        // return all the product list that is save in the database
        private List<ProductModel> GetProductsList()
        {
            return Database.POS.ProductDB.getProductList("");
        }

        // load all the customer these are singe an proper agreement of create customer. 
        private void LoadCustomerListInDropdown()
        {
            //customerlist is an list type object that can save all the customer list
            customerlist = GetCustomerList();
            CustomerDropDown.DataSource = customerlist;
            CustomerDropDown.DataTextField = "Name";
            CustomerDropDown.DataValueField = "ID";
            CustomerDropDown.DataBind();

            if (Request.QueryString["CustomerID"] != null)
                CustomerDropDown.Items.FindByValue(Request.QueryString["CustomerID"]).Selected = true;
        }

        private List<CustomerModel> GetCustomerList()
        {
            return Database.POS.Customer.CustomerDB.getCustomersList("");
        }

        // Method for set different products in an list view.
        protected void AddProducts_Click(object sender, EventArgs e)
        {
            AddProductToOrder();
        }

        // addition of products in Product list.

        
        private void AddProductToOrder()
        {
            int productID = int.Parse(ProductsDropDown.SelectedValue);
            SaleOrderItemModel orderItem = new SaleOrderItemModel();
            
            orderItem.ID = 1;
            orderItem.OrderID = 0;
            orderItem.Price = 3000;
            orderItem.Quantity = 1;
            orderItem.ProductID = productID;
            


            orderitemlist.Add(orderItem);
            OrderListview.DataSource = orderitemlist;
            // Now bind with the list view
            OrderListview.DataBind();
        
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

        protected void CustomerListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {

        }


    }
}