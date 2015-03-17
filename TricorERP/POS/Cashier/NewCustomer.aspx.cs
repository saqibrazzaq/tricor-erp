using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

namespace TricorERP.POS.Cashier
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        CustomerModel newcustomer;
        int customerid;

        public NewCustomer() {
            newcustomer = new CustomerModel();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            customerid = newcustomer.ID;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            CustomerModel customer = new CustomerModel();
            int customertyep = int.Parse(CustomerTyepDropDown.SelectedValue);
            customer.Name = FullNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Tyep = customertyep;
            newcustomer = addNewCustomer(customer);
            if (newcustomer != null)
                ErrorMessageLable.Text = "Data of new customer is save...";
            customerid = newcustomer.ID;
            
        }
        private CustomerModel addNewCustomer(CustomerModel newCustomer)
        {
            return Database.POS.Customer.CustomerDB.addNewCustomer(newCustomer);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customerid);
        }

    }
}