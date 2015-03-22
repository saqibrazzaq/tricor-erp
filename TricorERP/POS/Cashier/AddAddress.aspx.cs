using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Cashier;

namespace TricorERP.POS.Cashier
{
    public partial class AddAddress : System.Web.UI.Page
    {
        String customerID = "0";
        String AddressID = "0";
        String CashierID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["CustomerID"];
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
            //set address of an customer
            AddressModel customeraddress = new AddressModel();
            customeraddress = Database.POS.Customer.AddressDB.getAddress(AddressID);
            Location1Text.Text = customeraddress.Location1;
            Location2Text.Text = customeraddress.Location2;
            email.Text = customeraddress.Email;
            PhoneNumberText.Text = customeraddress.Phonenumber;
            CityNameText.Text = customeraddress.City;

            if (customerID != null)
            {
                //set customer personal information.
                CustomerModel customer = new CustomerModel();
                customer = Database.POS.Customer.CustomerDB.getCustomerInFo(customerID);
                customerName.Text = customer.Name;
                CustomerCNIC.Text = customer.CNIC;
            }
            else if (CashierID != null)
            {
                CashierModel cashier = new CashierModel();
                cashier = Database.POS.CashierDB.getCashierInFo(CashierID);
                customerName.Text = cashier.Name;
                CustomerCNIC.Text = cashier.CNIC;
            }
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (AddressID == "0" || CashierID == "0")
                saveNewAddress();
            else if (customerID != "0" || CashierID != "0")
                updateAddress();

        }

        //for saving new address in database
        private void saveNewAddress()
        {
            AddressModel newaddress = new AddressModel();
            if (customerID != null)
            {
                newaddress.ID = int.Parse(customerID.ToString());
            }
            else if (CashierID != null) { 
                newaddress.ID = int.Parse(CashierID.ToString());
            }
            newaddress.City = CityNameText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = email.Text;
            newaddress = Database.POS.Customer.AddressDB.addAddress(newaddress, customerID, CashierID);

                if (newaddress != null)
                {
                    if (customerID != "0")
                    {
                        Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customerID + "& AddressID=" + newaddress.ID);
                    }
                    else if (CashierID != "0")
                    {
                        Response.Redirect("~/POS/BranchManager/EditCashier.aspx?CashierID=" + CashierID + "& AddressID=" + newaddress.ID);
                    }
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
                if (customerID != null) 
                    Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customerID + "&AddressID=" + AddressID);
                else if (CashierID != null)
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
            if (customerID != null)
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customerID + "& AddressID=0");
            else if (CashierID != null)
                Response.Redirect("~/POS/BranchManager/EditCustomer.aspx?CashierID=" + CashierID + "& AddressID=0");
        }
    }
}