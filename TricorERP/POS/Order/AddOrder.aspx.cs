using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models.POS.Order;
using Models.POS.Customer;
using Models.POS;
using Models.SCM;
using System.Web.UI.HtmlControls;

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
            LoadWaherHouseDropDownList();
            TotalPrice.Text = soModel.TotalPrice.ToString();
            
            //checks if ou sale order id have some value then disable all the buttons.
            if (soModel.ID != 0 && NewSalesOrder.Text=="Save Sales Order") {
                int checkOrdestatus = GetOrderStatus(soModel);
                if (checkOrdestatus > 0) {
                    NewSalesOrder.Enabled = false;
                    OrderStatusList.Enabled = false;
                    CustomerList.Enabled = false;
                    ProductList.Enabled = false;
                    btnAddProduct.Enabled = false;
                    SaveSaleOrder.Enabled = false;
                    //DeleteItem.Enabled = false;
                }
            }
        }

        // that function can return the orderstatus according to the sale order
        private int GetOrderStatus(SaleOrderModel soModel)
        {
            return Database.POS.Order.OrderDB.orderStatus(soModel);
        }

        private void LoadWaherHouseDropDownList()
        {
            List<WareHouseModel> WHModel = GetWareHouseList();
            WaherHouseDropDownList.DataSource = WHModel;
            WaherHouseDropDownList.DataTextField = "Name";
            WaherHouseDropDownList.DataValueField = "ID";
            WaherHouseDropDownList.DataBind();
        }

        private List<WareHouseModel> GetWareHouseList()
        {
            return Database.POS.Order.OrderDB.getWareHouseList();
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
                else
                {
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
            List<Models.POS.ProductModel> products = GetProducts();
            ProductList.DataSource = products;
            // Set text and value
            ProductList.DataTextField = "ProductName";
            ProductList.DataValueField = "ProductID";
            ProductList.DataBind();
        }

        private List<Models.POS.ProductModel> GetProducts()
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
                soItemModel.Quantity = Common.WarehouseIDDefault;
                soItemModel.WareHouseID = int.Parse(WaherHouseDropDownList.SelectedValue);
                soItemModel = Database.POS.Order.OrderDB.setSaleOrderItems(soItemModel);
                if (soItemModel.ID == 0)
                    ErroMessage.Text = "Quantity of Selected Product is not Prasent in your Stock...";
                else
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
            if (soModel.ID == 0 && NewSalesOrder.Text == "Create New Sales Order")
            {
                CreateNewSalesOrder();
            }
            else if (soModel.ID != 0 && NewSalesOrder.Text == "Save Sales Order" && OrderStatusList.SelectedItem.ToString()=="Complete")
            {
                //that condition is false....
                UpdateStock();
            }
            else
            {
                UpdateSalesOrder();
            }
        }

        private void UpdateStock()
        {
            soModel.OrderStatus = int.Parse(OrderStatusList.SelectedValue);
            int updatestockcheck = UpdateStock( soModel );
            if (updatestockcheck > 0) {
                ErroMessage.Text = "Your request is procede...";
                InitializePageContents();
            }
        }

        private int UpdateStock(SaleOrderModel soModel)
        {
            return Database.POS.StockDB.updateStockItems(soModel);
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
            so.OrderDate = DateTime.Today.ToString();
            return so;
        }
        
        protected void deleteSalesOrderItem_onClick(object sender, EventArgs e)
        {
            int itemID = int.Parse(txtSalesOrderItemID.Text);
            int check = Database.POS.Order.OrderDB.deleteSaleOrderItem(itemID);
            if (check > 0)
                InitializePageContents();
            else
                ErroMessage.Text = "data is not deleted";
        }

        protected void SaveSalesOrderItem_onClick(object sender, EventArgs e)
        {
            // on that point set the warehouse id 
            //on that point our product is not save in the productname 
            
            SaleOrderItemModel soItemModel = new SaleOrderItemModel()
            {
                ID = int.Parse(txtSalesOrderItemID.Text),
                Quantity = int.Parse(txtQuantity.Text),
                Price = float.Parse(txtPrice.Text),
                WareHouseID = int.Parse(WaherHouseDropDownList.SelectedValue),
                ProductID = int.Parse(ProductList.SelectedValue),
                ProductName = txtProductName.Text
            };
            int check = Database.POS.Order.OrderDB.updateSalesItem(soItemModel);
            if (check > 0)
            {
                ErroMessage.Text = "Product is update";
                InitializePageContents();
            }
            else
                ErroMessage.Text = "Quantity of Selected Product is not Prasent in your Stock...";

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/OrderList.aspx");
        }

        protected void SalesOrderItemListview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (OrderStatusList.SelectedValue != "Complete" && soModel.ID != 0) {
                //SaleOrderModel stock = (SaleOrderModel)e.Item.DataItem;
                //if (1 < 10)
                //{
                //    // make the data row red
                //    HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("ItemRow");
                //    row.Attributes.Add("Class", "alert-warning");
                //}
                //to be continue on that point.....
            }
        }
    }
}