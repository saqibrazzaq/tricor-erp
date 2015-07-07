using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models.POS.Order;
using Models.POS.Customer;
using Models.POS;
using System.Web.UI.HtmlControls;

namespace TricorERP.POS.Order
{
    public partial class AddOrder : System.Web.UI.Page
    {
        SaleOrderModel soModel = new SaleOrderModel() { ID = Common.NULL_ID };
        //CustomerModel customerInFo;
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
            //ErroMessage.Text = soModel.CustomerID;

            //checks if our sale order id have some value then disable all the buttons.
            if (soModel.ID != Common.NULL_ID && NewSalesOrder.Text == "Save Sales Order")
            {
                int checkOrdestatus = GetOrderStatus(soModel);
                if (checkOrdestatus > 0)
                {
                    NewSalesOrder.Enabled = false;
                    OrderStatusList.Enabled = false;
                    CustomerList.Enabled = false;
                    ProductList.Enabled = false;
                    btnAddProduct.Enabled = false;
                    SaveSaleOrder.Enabled = false;
                    //DeleteItem.Enabled = false;
                    //btnAddInvoice.Enabled = false;
                    //btnAddInvoice.Text = "View Invoice";
                    //btnAddInvoice.Text = "Invoice";
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
                if (Common.CheckNullString(Request.QueryString["ID"]) != Common.NULL_ID)
                {
                    soModel.ID = Request.QueryString["ID"];
                    loadOrderModel();
                }
                else
                {
                    ProductList.Enabled = false;
                    btnAddProduct.Enabled = false;
                    OrderStatusList.Enabled = false;
                    btnAddInvoice.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                soModel.ID = Common.NULL_ID;
                throw ex;
            }
        }

        private void loadOrderModel()
        {
            soModel = Database.POS.Order.OrderDB.loadOrderModel(soModel);
        }

        private void InitializeSaveOrderButton()
        {
            if (soModel.ID == Common.NULL_ID)
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
            return Database.POS.Customer.CustomerDB.getCustomersList("");
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
            if (soModel.ID != Common.NULL_ID)
            {
                // Select the customer
                CustomerList.Items.FindByValue(soModel.CustomerID.ToString()).Selected = true;
                // Bind the items in list view

                if (Session["RoleID"].ToString() == Common.POSManager)
                    OrderStatusList.SelectedValue = soModel.OrderStatus.ToString();

                SalesOrderItemListview.DataSource = soModel.items;
                SalesOrderItemListview.DataBind();
            }
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            if (soModel.ID != Common.NULL_ID)
            {
                // Create the order item model
                SaleOrderItemModel soItemModel = new SaleOrderItemModel();
                // Set sales order id and product id of the selected product
                soItemModel.OrderID = soModel.ID;
                soItemModel.ProductID = ProductList.SelectedValue;
                // Set quantity to default 1
                soItemModel.Quantity = 1;
                soItemModel.WareHouseID = Common.WarehouseIDDefault;
                soItemModel = Database.POS.Order.OrderDB.setSaleOrderItems(soItemModel);
                if (soItemModel.Quantity <= 0 || soItemModel.QuantityCheck == -1)
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
            if (soModel.ID == Common.NULL_ID && NewSalesOrder.Text == "Create New Sales Order")
            {
                CreateNewSalesOrder();
            }
            else if (soModel.ID != Common.NULL_ID && NewSalesOrder.Text == "Save Sales Order" && OrderStatusList.SelectedItem.ToString() == "Approved")
            {
                UpdateStock();
            }
            else if (soModel.ID != Common.NULL_ID && NewSalesOrder.Text == "Save Sales Order" && OrderStatusList.SelectedItem.ToString() == "Cancel")
            {
                CancelSaleOrder();
            }
            else 
            {
                UpdateSalesOrder();
            }
        }

        private void CancelSaleOrder()
        {
            int check = Database.POS.Order.OrderDB.deleteSalesOrder(soModel);
            if (check > 0)
            {
                Response.Redirect("~/POS/Order/CancelOrder.aspx");
            }
        }

        private void UpdateStock()
        {
            soModel.OrderStatus = OrderStatusList.SelectedValue;
            int updatestockcheck = UpdateStock(soModel);
            if (updatestockcheck > 0)
            {
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
                //ProductList.Enabled = false;
                //btnAddProduct.Enabled = false;
                //OrderStatusList.Enabled = false;
                //CustomerList.Enabled = false;
                //NewSalesOrder.Enabled = false;
            }
        }

        private SaleOrderModel CreateSalesOrderModelFromUI()
        {
            // Create the Sales Order Model from UI
            SaleOrderModel so = new SaleOrderModel();
            so.ID = soModel.ID;

            so.CustomerID = CustomerList.SelectedValue;//customerInFo.ID;

            so.OrderDate = DateTime.Today.ToString();
            so.OrderStatus = OrderStatusList.SelectedValue;
            return so;
        }

        protected void deleteSalesOrderItem_onClick(object sender, EventArgs e)
        {
            String itemID = txtSalesOrderItemID.Text.Trim();
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
            // here  can set default warehouse WareHouseID = WaherHouseDropDownList.SelectedValue
            SaleOrderItemModel soItemModel = new SaleOrderItemModel()
            {
                ID = txtSalesOrderItemID.Text.Trim(),
                Quantity = int.Parse(txtQuantity.Text),
                Price = float.Parse(txtPrice.Text),
                WareHouseID = Common.WarehouseIDDefault,
                ProductID = txtSalesProductID.Text,
                ProductName = txtProductName.Text.Trim()
            };
            int check = Database.POS.Order.OrderDB.updateSalesItem(soItemModel);
            if (check > 0)
            {
                ErroMessage.Text = "Product is update";
                InitializePageContents();
            }
            else
                ErroMessage.Text = "Insufficient Stock...";
        }

        protected void SalesOrderItemListview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (soModel.OrderStatus == Common.OrderApproved)
            {
                Control myControl1 = e.Item.FindControl("ItemCommandtd");
                if (myControl1 != null)
                    myControl1.Visible = false;
            }
            if (OrderStatusList.SelectedValue != "Complete" && soModel.ID != Common.NULL_ID)
            {
                //SaleOrderModel stock = (SaleOrderModel)e.Item.DataItem;
                //if (1 < 1null)
                //{
                //    // make the data row red
                //    HtmlTableRow row = (HtmlTableRow)e.Item.FindControl("ItemRow");
                //    row.Attributes.Add("Class", "alert-warning");
                //}
                //to be continue on that point.....
            }
        }

        protected void btnAddInvoice_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            Response.Redirect("~/POS/Invoice/AddInvoice.aspx?ID=" + Request.QueryString["ID"].ToString() + "&CustomerID=" + CustomerList.SelectedValue); //customerInFo.ID);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/OrderList.aspx");
        }

        protected void btnviewInvoice_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            ErroMessage.Text = soModel.ID;
            Response.Redirect("~/POS/Invoice/ViewInvoice.aspx?ID="+soModel.ID);
        }

        protected void SearchByCNIC_Click(object sender, EventArgs e)
        {
            //String CNIC = txtSearchCNIC.Text;
            //customerInFo = Database.POS.Customer.CustomerDB.getCustomerInFo(CNIC);

            //check.Text = customerInFo.Name;

        }

      
    }
}