using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models.POS.Order;
using Models.POS.Customer;
using Models.POS;

namespace TricorERP.POS.Order
{
    public partial class AddOrder : System.Web.UI.Page
    {
        SaleOrderModel soModel = new SaleOrderModel() { ID = 0 };

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            ErroMessage.Text = "";
            InitializeOrderModel();
            InitializeSaveOrderButton();
            LoadCustomerListInDropdown();
            LoadProductListInDropdown();
            UpdateSalesOrderUI();

            LoadOrderStatusListInDropdown();
            
            TotalPrice.Text = soModel.TotalPrice.ToString();
        }

        private void LoadOrderStatusListInDropdown()
        {
            List<OrderStatusModel> orderstatus = GetOrderStatusList();
            OrderStatusList.DataSource = orderstatus;
            OrderStatusList.DataTextField = "StatusName";
            OrderStatusList.DataValueField = "ID";
            OrderStatusList.DataBind();
        }

        private List<OrderStatusModel> GetOrderStatusList()
        {
            return Database.POS.Order.OrderDB.getOrderStatusList();
        }

        private void InitializeOrderModel()
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    soModel.ID = int.Parse(Request.QueryString["ID"]);
                    loadOrderModel();
                }
                else {
                    ProductList.Enabled = false;
                    btnAddProduct.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                soModel.ID = 0;
                throw ex;
            }
        }

        private void loadOrderModel()
        {
            soModel = Database.POS.Order.OrderDB.loadOrderModel(soModel);
        }

        private void InitializeSaveOrderButton()
        {
            if (soModel.ID == 0)
                NewSalesOrder.Text = "Create New Sales Order";
            else
                NewSalesOrder.Text = "Save Sales Order";
        }

        private void LoadCustomerListInDropdown()
        {
            List<CustomerModel> customers = GetCustomers();
            // Bind list to the dropdown
            CustomerList.DataSource = customers;
            CustomerList.DataTextField = "Name";
            CustomerList.DataValueField = "ID";
            CustomerList.DataBind();
        }

        private List<CustomerModel> GetCustomers()
        {
            return Database.POS.Customer.CustomerDB.getallCustomer();
        }

        private void LoadProductListInDropdown()
        {
            List<ProductModel> products = GetProducts();
            ProductList.DataSource = products;
            // Set text and value
            ProductList.DataTextField = "ProductName";
            ProductList.DataValueField = "ProductID";
            ProductList.DataBind();
        }

        private List<ProductModel> GetProducts()
        {
            return Database.POS.ProductDB.getProductList();
        }

        private void UpdateSalesOrderUI()
        {
            if (soModel.ID != 0)
            {
                // Select the customer
                CustomerList.Items.FindByValue(soModel.CustomerID.ToString()).Selected = true;
                // Bind the items in list view

                if (Session["RoleID"].ToString() == "1")
                    OrderStatusList.SelectedValue = soModel.OrderStatus.ToString();
            
                SalesOrderItemListview.DataSource = soModel.items;
                SalesOrderItemListview.DataBind();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            if (soModel.ID != 0)
            {
                // Create the order item model
                SaleOrderItemModel soItemModel = new SaleOrderItemModel();
                // Set sales order id and product id of the selected product
                soItemModel.OrderID = soModel.ID;
                soItemModel.ProductID = int.Parse(ProductList.SelectedValue);
                // Set quantity to default 1
                soItemModel.Quantity = 1;
                soItemModel = Database.POS.Order.OrderDB.setSaleOrderItems(soItemModel);

                

                InitializePageContents();
            }
        }

        protected void NewSalesOrder_Click(object sender, EventArgs e)
        {
            SaveSalesOrder();
        }

        private void SaveSalesOrder()
        {
            InitializeOrderModel();
            if (soModel.ID == 0)
                CreateNewSalesOrder();
            else
                UpdateSalesOrder();
        }

        private void CreateNewSalesOrder()
        {
            SaleOrderModel so = CreateSalesOrderModelFromUI();
            so = Database.POS.Order.OrderDB.addNewSaleOrder(so);
            Response.Redirect("~/POS/Order/AddOrder.aspx?ID=" + so.ID);
        }

        private void UpdateSalesOrder()
        {
            SaleOrderModel so = CreateSalesOrderModelFromUI();
            int check = Database.POS.Order.OrderDB.updateSaleOrder(so);
            if (check > 0)
            {
                ErroMessage.Text = "Customer is updated";
            }
        }

        private SaleOrderModel CreateSalesOrderModelFromUI()
        {
            // Create the Sales Order Model from UI
            SaleOrderModel so = new SaleOrderModel();
            so.ID = soModel.ID;
            so.CustomerID = int.Parse(CustomerList.SelectedValue);
            so.OrderDate = DateTime.Now.ToString();
            return so;
        }

        

        protected void deleteSalesOrderItem_onClick(object sender, EventArgs e)
        {
            int itemID = int.Parse(txtSalesOrderItemID.Text);
            int check = Database.POS.Order.OrderDB.deleteSaleOrderItem(itemID);
            InitializePageContents();
        }

        protected void SaveSalesOrderItem_onClick(object sender, EventArgs e)
        {
            SaleOrderItemModel soItemModel = new SaleOrderItemModel()
            {
                ID = int.Parse(txtSalesOrderItemID.Text),
                Quantity = int.Parse(txtQuantity.Text),
                Price = float.Parse(txtPrice.Text)
            };
            int check = Database.POS.Order.OrderDB.updateSalesItem(soItemModel);
            if (check > 0)
                ErroMessage.Text = "Product is update";
            InitializePageContents();
        }

        protected void OrderApproved_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            soModel.OrderStatus = int.Parse(OrderStatusList.SelectedValue);
            int check = Database.POS.Order.OrderDB.updateOrderStatus(soModel);
            if (check > 0)
                ErroMessage.Text = "UPDATED...";
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/OrderList.aspx");
        }

    }
}