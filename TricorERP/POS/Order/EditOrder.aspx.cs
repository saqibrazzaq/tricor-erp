using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

// for get the products
using Models.SCM;

namespace TricorERP.POS.Order
{
    public partial class EditOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            LoadProductList();
            LoadCustomerList();
        }

        private void LoadCustomerList()
        {
            List<CustomerModel> customer = GetCustomerFromDatabase();
            CustomerDropDown.DataTextField = "Name";
            CustomerDropDown.DataValueField = "ID";
            CustomerDropDown.DataSource = customer;
            CustomerDropDown.DataBind();
        }

        private List<CustomerModel> GetCustomerFromDatabase()
        {
            return Database.POS.Customer.CustomerDB.getCustomersList("");
        }

        private void LoadProductList()
        {
            List<ProductModel> products = GetProductsFromDatabase();
            ProductsDropDown.DataTextField = "ProductName";
            ProductsDropDown.DataValueField = "ProductID";
            ProductsDropDown.DataSource = products;
            ProductsDropDown.DataBind();
        }

        private List<ProductModel> GetProductsFromDatabase()
        {
            return Database.SCM.ProductDB.getProductList("");
        }

        protected void AddProducts_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
    }
}