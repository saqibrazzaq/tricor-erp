using Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.Samples
{
    

    public partial class Test : System.Web.UI.Page
    {
        // Initialize with 0 order id
        // This page will load and save whatever is in this model
        SalesOrderModel soModel = new SalesOrderModel() { ID = 0 };

        
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
            InitializeOrderModel();
            InitializeSaveOrderButton();
            LoadCustomerListInDropdown();
            LoadProductListInDropdown();

            UpdateSalesOrderUI();
        }

        class ProductModel
        {
            public int ID { get; set; }
            public String Name { get; set; }
            public String Description { get; set; }
            public float CostPrice { get; set; }
            public float SalesPrice { get; set; }
        }

        private void LoadProductListInDropdown()
        {
            // Load the list from database
            List<ProductModel> products = new List<ProductModel>();
            string sql = "SELECT * FROM Product ";
            using (SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null))
            {
                while(reader.Read())
                {
                    // Create new product model
                    ProductModel product = new ProductModel();
                    product.ID = int.Parse(reader["ID"].ToString());
                    product.Name = reader["Name"].ToString();
                    product.Description = reader["Description"].ToString();
                    product.CostPrice = float.Parse(reader["CostPrice"].ToString());
                    product.SalesPrice = float.Parse(reader["SalesPrice"].ToString());
                    // Add to the lsit
                    products.Add(product);
                }
            }

            ProductList.DataSource = products;
            // Set text and value
            ProductList.DataTextField = "Name";
            ProductList.DataValueField = "ID";
            ProductList.DataBind();
        }

        private void UpdateSalesOrderUI()
        {
            if (soModel.ID != 0)
            {
                // Select the customer
                CustomerList.Items.FindByValue(soModel.CustomerID.ToString()).Selected = true;
                // Bind the items in list view
                SalesOrderItemListview.DataSource = soModel.items;
                SalesOrderItemListview.DataBind();
            }
        }

        private void InitializeSaveOrderButton()
        {
            if (soModel.ID == 0)
                btnSaveSalesOrder.Text = "Create New Sales Order";
            else
                btnSaveSalesOrder.Text = "Save Sales Order";
        }

        private void InitializeOrderModel()
        {
            // If no order id in query string, set it 0
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    soModel.ID = int.Parse(Request.QueryString["ID"]);
                    loadOrderModel();
                }
                    
            }
            catch(Exception ex)
            {
                soModel.ID = 0;
                throw ex;
            }
        }

        private void loadOrderModel()
        {
            // Load the order information from database
            string sql = "SELECT * FROM SalesOrder WHERE ID = " + soModel.ID;
            using (SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null))
            {
                if (reader.Read())
                {
                    // Load the order
                    soModel.CustomerID = int.Parse(reader["CustomerID"].ToString());
                    soModel.OrderDate = DateTime.Parse(reader["OrderDate"].ToString());


                }
            }

            // Load the items
            string sqlItems = @"SELECT item.*, Product.Name AS ProductName
                    FROM SalesOrderItem item
                    INNER JOIN Product ON item.ProductID = Product.ID
                    WHERE item.SalesOrderID = " + soModel.ID;
            // Empty the list of items before loading from DB
            soModel.items.Clear();
            using (SqlDataReader readerItems = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlItems, null))
            {
                while(readerItems.Read())
                {
                    SalesOrderItemModel soItemModel = new SalesOrderItemModel()
                    {
                        ID = int.Parse(readerItems["ID"].ToString()),
                        SalesOrderID = int.Parse(readerItems["SalesOrderID"].ToString()),
                        ProductID = int.Parse(readerItems["ProductID"].ToString()),
                        quantity = int.Parse(readerItems["Quantity"].ToString()),
                        price = float.Parse(readerItems["Price"].ToString()),
                        ProductName = readerItems["ProductName"].ToString(),
                        
                    };
                    soModel.items.Add(soItemModel);
                }
            }
        }

        protected void SaveSalesOrderItem_onClick(object sender, EventArgs e)
        {
            // Prepare the Item model from UI
            SalesOrderItemModel soItemModel = new SalesOrderItemModel()
                {
                    ID = int.Parse(txtSalesOrderItemID.Text),
                    quantity = int.Parse(txtQuantity.Text),
                    price = float.Parse(txtPrice.Text)
                };
            // Update the order item
            string sql = @"UPDATE SalesOrderItem
                SET Quantity = " + soItemModel.quantity +
                ", Price = '" + soItemModel.price + "' " +
                "WHERE ID = " + soItemModel.ID;
            DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);

            // Update the page
            InitializePageContents();
            
            Console.WriteLine("save method is called");
        }

        private void LoadCustomerListInDropdown()
        {
            // Get products list
            List<CustomerModel> customers = GetCustomers();
            // Bind list to the dropdown
            CustomerList.DataSource = customers;
            CustomerList.DataTextField = "FullName";
            CustomerList.DataValueField = "ID";
            CustomerList.DataBind();
        }

        private List<CustomerModel> GetCustomers()
        {
            // Initialize new List
            List<CustomerModel> customers = new List<CustomerModel>();

            String sql = "SELECT * FROM Customer";
            SqlDataReader reader = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sql, null);
            while(reader.Read())
            {
                CustomerModel customer = new CustomerModel()
                {
                    ID = int.Parse(reader["ID"].ToString()),
                    FullName = reader["FullName"].ToString()
                };
                customers.Add(customer);
            }


            // Return the list
            return customers;
        }

        class CustomerModel
        {
            public int ID { get; set; }
            public String FullName { get; set; }
        }

        class SalesOrderModel
        {
            public int ID { get; set; }
            public int CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
            public List<SalesOrderItemModel> items = new List<SalesOrderItemModel>();
        }

        class SalesOrderItemModel
        {
            // Table members
            public int ID { get; set; }
            public int SalesOrderID { get; set; }
            public int ProductID { get; set; }
            public int quantity { get; set; }
            public float price { get; set; }

            // Other members for display
            public String ProductName { get; set; }
        }

        /// <summary>
        /// Save the Sales Order
        /// </summary>
        private void SaveSalesOrder()
        {
            InitializeOrderModel();

            if (soModel.ID == 0)
                CreateNewSalesOrder();
            else
                UpdateSalesOrder();
        }

        private void UpdateSalesOrder()
        {
            // Create Model from UI
            SalesOrderModel so = CreateSalesOrderModelFromUI();

            string sql = @"UPDATE SalesOrder
                SET CustomerID = " + so.CustomerID +
                "WHERE ID = " + soModel.ID;
            DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
        }

        private void CreateNewSalesOrder()
        {
            SalesOrderModel so = CreateSalesOrderModelFromUI();

            // Insert new order
            string sql = @"INSERT INTO SalesOrder (CustomerID, OrderDate)
                OUTPUT INSERTED.ID
                VALUES ( " + so.CustomerID + " , '" + so.OrderDate + "' )";
            object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);
            so.ID = int.Parse(id.ToString());

            // Load the page with the order id
            Response.Redirect("Test.aspx?ID=" + so.ID);
        }

        private SalesOrderModel CreateSalesOrderModelFromUI()
        {
            // Create the Sales Order Model from UI
            SalesOrderModel so = new SalesOrderModel();
            so.ID = soModel.ID;
            so.CustomerID = int.Parse(CustomerList.SelectedValue);
            so.OrderDate = DateTime.Now;
            return so;
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
        protected void SalesOrderItemListview_ItemCommand(object sender, ListViewCommandEventArgs e)
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
            SaveSalesOrder();
        }

        protected void deleteSalesOrderItem_onClick(object sender, EventArgs e)
        {
            int itemID = int.Parse(txtSalesOrderItemID.Text);
            string sql = "DELETE FROM SalesOrderItem WHERE ID = " + itemID;
            DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sql, null);

            // Reload the page
            InitializePageContents();
        }

        protected void btnShowJumbotron_Click(object sender, EventArgs e)
        {

        }

        protected void btnHideJumbotron_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            InitializeOrderModel();
            if (soModel.ID != 0)
            {
                // Create the order item model
                SalesOrderItemModel soItemModel = new SalesOrderItemModel();
                // Set sales order id and product id of the selected product
                soItemModel.SalesOrderID = soModel.ID;
                soItemModel.ProductID = int.Parse(ProductList.SelectedValue);
                // Set quantity to default 1
                soItemModel.quantity = 1;
                // Get the price of this proeuct from database
                string sqlPrice = "SELECT SalesPrice FROM Product WHERE ID = " + soItemModel.ProductID;
                using (SqlDataReader readerPrice = DBUtility.SqlHelper.ExecuteReader(System.Data.CommandType.Text, sqlPrice, null))
                {
                    if (readerPrice.Read())
                    {
                        soItemModel.price = float.Parse(readerPrice["SalesPrice"].ToString());
                    }
                }
                // Add the item to sales order
                string sqlInsert = @"INSERT INTO SalesOrderItem (SalesOrderID, ProductID, Quantity, Price) OUTPUT INSERTED.ID VALUES (" + soItemModel.SalesOrderID + " , " +  
                    soItemModel.ProductID + " , " + soItemModel.quantity + " , '" + soItemModel.price + "')";
                object id = DBUtility.SqlHelper.ExecuteScalar(System.Data.CommandType.Text, sqlInsert, null);
                soItemModel.ID = int.Parse(id.ToString());

                // Initialize the page
                InitializePageContents();
            }
        }
    }
}