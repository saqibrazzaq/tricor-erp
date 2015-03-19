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
        String customerID = "0";
        String AddressID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["CustomerID"];
            AddressID = Request.QueryString["AddressID"];
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (AddressID == "0")
                saveNewAddress();
            else //if (customerID != "0")
                updateAddress();
            
        }

        //for saving new address in database
        private void saveNewAddress() {
            AddressModel newaddress = new AddressModel();
            newaddress.ID = int.Parse(customerID.ToString());
            newaddress.City = CityNameText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = email.Text;
            newaddress = Database.POS.Customer.AddressDB.addAddress(newaddress, customerID);
            Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customerID + "& AddressID=" + newaddress.ID);
        }

        //for update the address 
        private void updateAddress() {
            AddressModel updateaddress = new AddressModel();

            updateaddress = Database.POS.Customer.AddressDB.updateAddress("");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //how to set previous page without effecting the values of previous page?
            Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customerID + "& AddressID=0");
        }
    }
}