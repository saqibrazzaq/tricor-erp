using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.Samples
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public partial class Test : System.Web.UI.Page
    {
        

        // Add the order item list as member
        List<OrderItem> orderItemList = new List<OrderItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        /// <summary>
        /// Initialize contents of this page, First time load only
        /// </summary>
        private void InitializePageContents()
        {
            LoadProductsListInDropdown();
        }

        private void LoadProductsListInDropdown()
        {
            // Get products list
            List<Product> products = GetProductsDummy();
            // Bind list to the dropdown
            ProductsList.DataSource = products;
            ProductsList.DataTextField = "Name";
            ProductsList.DataValueField = "ID";
            ProductsList.DataBind();
        }

        private List<Product> GetProductsDummy()
        {
            // Initialize new List
            List<Product> products = new List<Product>();

            // Create the products
            Product p1 = new Product() { ID = 1, Name = "Door", Price = 3000 };
            Product p2 = new Product() { ID = 2, Name = "Window", Price = 2000 };
            Product p3 = new Product() { ID = 3, Name = "Tile", Price = 100 };

            // Add the products to the list
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);

            // Return the list
            return products;
        }

        class Product
        {
            public int ID { get; set; }
            public String Name { get; set; }
            public float Price { get; set; }
        }

        /// <summary>
        /// Add product to the order
        /// </summary>
        private void AddProductToOrder()
        {
            // Get the product from dropdown, which we are going to add
            int productID = int.Parse(ProductsList.SelectedValue);
            
            // Create a new order item
            OrderItem orderItem = new OrderItem() { ID = 1, OrderID = 0, ProductID = productID, Price = 3000, Quantity = 1 };

            // Add this item to the list
            orderItemList.Add(orderItem);

            // Now bind with the listview
            OrderListview.DataSource = orderItemList;
            OrderListview.DataBind();
        }

        /// <summary>
        /// Get dummy list of customers, NOT from database
        /// </summary>
        /// <returns>List of customers</returns>
        private List<Models.Samples.CustomerModel> TryDummyData()
        {
            // Create new list
            List<Models.Samples.CustomerModel> customers = new List<Models.Samples.CustomerModel>();

            // Add first customer to the list
            Models.Samples.CustomerModel saqib = new Models.Samples.CustomerModel()
            {
                ID = 123123,
                FullName = "Saqib Razzaq",
                CustomerType = 1
            };
            customers.Add(saqib);

            // Add second customer
            Models.Samples.CustomerModel shaheer = new Models.Samples.CustomerModel()
            {
                ID = 123,
                FullName = "Muhammad Shaheer",
                CustomerType = 1
            };
            customers.Add(shaheer);

            // Return the list
            return customers;
        }

        /// <summary>
        /// Handle command events from the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            AddProductToOrder();
        }

        protected void btnShowJumbotron_Click(object sender, EventArgs e)
        {

        }

        protected void btnHideJumbotron_Click(object sender, EventArgs e)
        {

        }

        protected void CustomerListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}