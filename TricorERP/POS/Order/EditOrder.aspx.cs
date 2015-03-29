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
        String SaleOrderID = "0";
        List<CustomerModel> customerlist = null;
        DateTime dt = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            DateText.Text = dt.ToShortDateString().ToString();
            SaleOrderID = Request.QueryString["SaleOrderID"];

            if (SaleOrderID != "0") {
                AddProductsButten.Enabled = false;
            }
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            LoadCustomerListInDropdown();
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
            if (SaleOrderID != "0")
            {
                CustomerDropDown.Items.FindByValue(SaleOrderID).Selected = true;
                CustomerDropDown.Enabled = false;
            }
            else
            {
                //CustomerDropDown.Items.FindByValue(SaleOrderID).Selected = true;
                CustomerDropDown.Enabled = true;
            }
        }

        private List<CustomerModel> GetCustomerList()
        {
            return Database.POS.Customer.CustomerDB.getCustomersList("");
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit customer command
            if (e.CommandName == "DeleteOrderItem")
            {
            }
            else if (e.CommandName == "EditOrderItem")
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

        protected void AddProductsButten_Click(object sender, EventArgs e)
        {
            Message.Text = CustomerDropDown.SelectedValue;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (SaleOrderID == "0")
            {
                newSaleOrder();
            }
            else
            {
                updateSaleOrder();
            }
        }

        // function for save the new sale order into database.
        private void newSaleOrder()
        {
            SaleOrderModel newsaleorder = new SaleOrderModel();
            
            newsaleorder.OrderDate = dt.ToShortDateString();
            newsaleorder.CustomerID = int.Parse(CustomerDropDown.SelectedValue);
            newsaleorder = Database.POS.Order.OrderDB.assNewSaleOrder(newsaleorder);
            
            // redirect the customer id for checking the customer information.
            if (newsaleorder != null)
                Response.Redirect("~/POS/Order/EditOrderItem.aspx?SaleOrderID=" + newsaleorder.ID + "&CustomerID="+newsaleorder.CustomerID);
        }
        private void updateSaleOrder()
        {

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }



    }
}