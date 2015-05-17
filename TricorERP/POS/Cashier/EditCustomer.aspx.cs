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
        String customerID = Guid.Empty.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Common.CheckNullString(Request.QueryString["CustomerID"]);
            if (customerID == Common.NULL_ID)
            {
                btnAddNewAddress.Enabled = false;
                HeadingOfCuatomer.Text = "New Customer";
                Savebtn.Text = "Save";
            }
            else
            {
                Savebtn.Text = "Update";
                HeadingOfCuatomer.Text = "Customer Data";
            }
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            CustomersData(customerID);
        }
        private void CustomersData(String Id)
        {
            CustomerModel customer = null;
            List<Models.POS.Customer.AddressModel> customerAddresses = null;
            //if (customerID != "0")
            //{
                customer = GetCustomerInFo(Id);
                customerAddresses = GetAddressesFromDB(Id);

                CustomerNameText.Text = customer.Name;
                CNICText.Text = customer.CNIC;
                GenderDropDown.SelectedValue = customer.Gender;
                CustomerTyepDropDown.SelectedValue = customer.Type.ToString();

                CustomerAddressesview.DataSource = customerAddresses;
                CustomerAddressesview.DataBind();
            //}
        }

        private CustomerModel GetCustomerInFo(String Id)
        {
            return Database.POS.Customer.CustomerDB.getCustomerInFo(Id);
        }

        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.Common.AddressDB.getCustomerAddresses(Id);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/EditAddress.aspx?CustomerID=" + customerID + "&AddressID=");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (customerID == Common.NULL_ID)
                AddNewCustomer();
            else
                UpdateCustomer();
        }
        // method for add new customer
        private void AddNewCustomer()
        {
            CustomerModel customer = new CustomerModel();
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Type = int.Parse(CustomerTyepDropDown.SelectedValue);
            customer = Database.POS.Customer.CustomerDB.addNewCustomer(customer);
            if (customer != null)
                Response.Redirect("~/POS/Cashier/EditAddress.aspx?CustomerID=" + customer.ID + "&AddressID=");
        }

        // method for update customers
        private void UpdateCustomer()
        {
            CustomerModel customer = new CustomerModel();

            customer.ID = customerID.ToString();
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Type = int.Parse(CustomerTyepDropDown.SelectedValue);

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
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "AddAddress")
            {
                Response.Redirect("EditAddress.aspx?CustomerID=" + customerID + "&AddressID=" + AddressID);
            }
        }

        protected void deleteCustomerAddress_onClick(object sender, EventArgs e)
        {
            String AddressID = txtAddressID.Text.Trim();
            deleteCustomerAddress(AddressID.ToString());
            InitializePageContents();
        }

        private int deleteCustomerAddress(String AddressID)
        {
            return Database.POS.Customer.CustomerDB.deleteAddress(customerID, AddressID);
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked == true)
                Savebtn.Enabled = true;
            else
                Savebtn.Enabled = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}