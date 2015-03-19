using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

namespace TricorERP.POS.Cashier
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        String customerID = "0";
        String AddressID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["ID"];
            AddressID = Request.QueryString["AddressID"];

            if (IsPostBack == false)
            {
                InitializePageContents(customerID);
            }
        }

        private void InitializePageContents(String Id)
        {
            SearchCustomers(Id);
        }
        private void SearchCustomers(String Id)
        {
            CustomerModel customer = null;
            List<Models.POS.Customer.AddressModel> customerAddresses = null;

            customer = GetCustomerInFo(Id);
            customerAddresses = GetAddressesFromDB(Id);

            CustomerNameText.Text = customer.Name;
            CNICText.Text = customer.CNIC;
            GenderDropDown.SelectedValue = customer.Gender;

            CustomerAddressesview.DataSource = customerAddresses;
            CustomerAddressesview.DataBind();
        }

        private CustomerModel GetCustomerInFo(String Id)
        {
            return Database.POS.Customer.CustomerDB.getCustomerInFo(Id);
        }

        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.POS.Customer.AddressDB.getCustomerAddresses(Id);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customerID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (customerID == "0")
                AddNewCustomer();
            else
                UpdateCustomer();
        }
        // method for add new customer
        private void AddNewCustomer()
        {
            CustomerModel customer = new CustomerModel();
            int customertyep = int.Parse(CustomerTyepDropDown.SelectedValue);
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Tyep = customertyep;
            customer = Database.POS.Customer.CustomerDB.addNewCustomer(customer);
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customer.ID + "&AddressID=0");
        }

        // method for update customers
        private void UpdateCustomer()
        {
            CustomerModel customer = new CustomerModel();
            int customertyep = int.Parse(CustomerTyepDropDown.SelectedValue);
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Tyep = customertyep;
            int check = Database.POS.Customer.CustomerDB.updateCustomer(customer);
            if (check == 1)
            {
                message.Text = "Data is Updated";
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customer.ID + "&AddressID=0");
            }
            else
            {
                message.Text = "Data is not Updated";
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customer.ID + "&AddressID=0");
            }
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "AddAddress")
            {
                //String customerID = e.CommandArgument.ToString();
                Response.Redirect("AddAddress.aspx?CustomerID=" + customerID);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/CustomerList.aspx");
        }
    }
}