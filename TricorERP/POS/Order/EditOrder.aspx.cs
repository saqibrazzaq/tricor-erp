using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Order;

// for get the products
using Models.SCM;



namespace TricorERP.POS.Order
{
    public partial class EditOrder : System.Web.UI.Page
    {
        String CustomerID = "0";
        String productID = "0";
        String OrderDate = "0";
        List<ProductModel> products;
        List<CustomerModel> customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            CustomerID = Request.QueryString["CustomerID"];
            
            // current date when we create an order then we can use it.
            DateTime dt = DateTime.Now;
            OrderDate = dt.ToShortDateString();
            DateLab.Text = OrderDate.ToString();

            if (IsPostBack == false)
            {
                InitializePageContents();
            }

        }

        private void InitializePageContents()
        {
            loadDropDownLists();
        }

        private void loadDropDownLists()
        {
            LoadCustomerList();
            LoadProductList();
        }

        private void LoadCustomerList()
        {
            customer = GetCustomerFromDatabase();
            
            CustomerDropDown.DataTextField = "Name";
            CustomerDropDown.DataValueField = "ID";
            
            CustomerDropDown.DataSource = customer;
            
            CustomerDropDown.DataBind();

            //Response.Redirect("~/POS/Order/EditOrder.aspx?CustomerID=");//" + CustomerID + "&ProductID=" + productID);
            
        }

        private List<CustomerModel> GetCustomerFromDatabase()
        {
            return Database.POS.Customer.CustomerDB.getCustomersList("");
        }

        private void LoadProductList()
        {
            products = GetProductsFromDatabase();

            ProductsDropDown.DataTextField = "ProductName";
            ProductsDropDown.DataValueField = "ProductID";
            ProductsDropDown.DataSource = products;
            

            for (int i = 0; i < products.Count; i++)
            {
                productID = products[i].ProductID.ToString();
            }

            ProductsDropDown.DataBind();

            //Response.Redirect("~/POS/Order/EditOrder.aspx?CustomerID=");// + CustomerID + "&ProductID=" + productID);
        }

        private List<ProductModel> GetProductsFromDatabase()
        {
            return Database.SCM.ProductDB.getProductList("");
        }

        protected void AddProducts_Click(object sender, EventArgs e)
        {

            // 1. OrderItemModel item = new OrderItemModel()
            // item.productiD = dropdown.id
            // item.saleOrderID = orderID (querystring)
            // OrderItemDB.Add(item)

            // 2. Bind list view
            // List<OrderItem> orderItems = OrderDB.GetOrderItems(orderID)
            
            Message.Text = ProductsDropDown.SelectedItem.ToString();
            OrderModel order = new OrderModel();
            order.ProductName = ProductsDropDown.SelectedItem.ToString();
            //OrderListview.DataSource = order;
            //OrderListview.DataBind();

            
        }

        protected void CustomerListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // for get the id og specific customer.
            for (int i = 0; i < customer.Count; i++)
            {
                CustomerID = customer[i].ID.ToString();
            }



            if (CustomerID != "0")
            {
                updateCustomerOrder();
            }
            else
            {
                newCustomerOrder();
            }
        }

        private void newCustomerOrder()
        {
            SaleOrderModel newsale = new SaleOrderModel();

        }

        private void updateCustomerOrder()
        {
            //throw new NotImplementedException();
        }

        protected void OrderListview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}