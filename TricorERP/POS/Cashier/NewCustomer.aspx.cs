using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.Customer;

namespace TricorERP.POS.Cashier
{
    public partial class NewCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            int customertyep = int.Parse( CustomerTyepDropDown.SelectedValue);
            CustomerModel newcustomer = new CustomerModel();
            newcustomer.Name = FullNameText.Text;
            newcustomer.CNIC = CNICText.Text;
            newcustomer.Gender = GenderDropDown.SelectedValue;
            newcustomer.Tyep = customertyep;
            addNewCustomer(newcustomer);
        }
        private CustomerModel addNewCustomer( CustomerModel newCustomer )
        {
            return Database.Customer.CustomerDB.addNewCustomer(newCustomer); 
        }
    }
}