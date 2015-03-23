using Models.POS.Cashier;
using Models.POS.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.BranchManager
{
    public partial class AddAddress : System.Web.UI.Page
    {
        String AddressID = "0";
        String CashierID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            AddressID = Request.QueryString["AddressID"];
            CashierID = Request.QueryString["CashierID"];
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            CustomersAddress();
        }

        private void CustomersAddress()
        {
            //set address of an customer.
            AddressModel customeraddress = new AddressModel();
            customeraddress = Database.POS.Customer.AddressDB.getAddress(AddressID);
            Location1Text.Text = customeraddress.Location1;
            Location2Text.Text = customeraddress.Location2;
            email.Text = customeraddress.Email;
            PhoneNumberText.Text = customeraddress.Phonenumber;
            CityNameText.Text = customeraddress.City;

            // set cashier information of customer. 
            CashierModel cashier = new CashierModel();
            cashier = Database.POS.CashierDB.getCashierInFo(CashierID);
            cashierName.Text = cashier.Name;
            cashierCNIC.Text = cashier.CNIC;

        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (AddressID == "0")
                saveNewAddress();
            else if (CashierID != "0")
                updateAddress();

        }

        //for saving new address in database
        private void saveNewAddress()
        {
            AddressModel newaddress = new AddressModel();
            newaddress.ID = int.Parse(CashierID.ToString());
            newaddress.City = CityNameText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = email.Text;

            newaddress = Database.POS.Customer.AddressDB.addAddress(newaddress);// customerID, CashierID);
            int check = Database.POS.CashierDB.addAddress(CashierID, newaddress.ID);

            if (check == 1)
            {
                if (newaddress != null)
                    Response.Redirect("~/POS/BranchManager/EditCashier.aspx?CashierID=" + CashierID + "& AddressID=" + newaddress.ID);
            }
            else
            {
                message.Text = "Due to some problem data is not save..";
            }
        }

        //for update the address 
        private void updateAddress()
        {
            AddressModel updateaddress = new AddressModel();
            updateaddress.ID = int.Parse(AddressID.ToString());
            updateaddress.City = CityNameText.Text;
            updateaddress.Location1 = Location1Text.Text;
            updateaddress.Location2 = Location2Text.Text;
            updateaddress.Phonenumber = PhoneNumberText.Text;
            updateaddress.Email = email.Text;
            int check = Database.POS.Customer.AddressDB.updateAddress(updateaddress);
            if (check == 1)
            {
                Response.Redirect("~/POS/BranchManager/EditCashier.aspx?CashierID=" + CashierID + "&AddressID=" + AddressID);
                message.Text = "Data is Updated";
            }
            else if (check != 1)
            {
                message.Text = "Data is not Updated";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/EditCustomer.aspx?CashierID=" + CashierID + "& AddressID=0");
        }
    }
}