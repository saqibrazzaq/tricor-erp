using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

namespace TricorERP.POS.Cashier
{
    public partial class AddAddress : System.Web.UI.Page
    {
        string customerID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["CustomerID"];
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            AddressModel newaddress = new AddressModel();
            newaddress.ID = int.Parse(customerID.ToString());
            newaddress.City = CityNameText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = email.Text;
            saveNewAddress(newaddress);
            Response.Redirect("~/POS/Cashier/EditCustomer.aspx?ID=" + customerID);
        }

        private AddressModel saveNewAddress(AddressModel newaddress) {
            return Database.POS.Customer.AddressDB.addAddress(newaddress, customerID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //how to set previous page without effecting the values of previous page?
            Response.Redirect("~/POS/Cashier/EditCustomer.aspx?ID=" + customerID);
        }
    }
}