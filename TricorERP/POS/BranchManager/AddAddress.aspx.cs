﻿using Models.POS.User;
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
        String AddressID = "null";
        String UserID = "null";
        protected void Page_Load(object sender, EventArgs e)
        {
            AddressID = Common.CheckNullString(Request.QueryString["AddressID"]);
            UserID = Common.CheckNullString(Request.QueryString["UserID"]);
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
            customeraddress = Database.Common.AddressDB.getAddress(AddressID);
            Location1Text.Text = customeraddress.Location1;
            Location2Text.Text = customeraddress.Location2;
            email.Text = customeraddress.Email;
            PhoneNumberText.Text = customeraddress.Phonenumber;
            CityNameText.Text = customeraddress.City;

            // set cashier information of customer. 
            UserModel cashier = new UserModel();
            cashier = Database.POS.UserDB.getUserInFo(UserID);
            cashierName.Text = cashier.Name;
            cashierCNIC.Text = cashier.CNIC;

        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (AddressID == Common.NULL_ID)
                saveNewAddress();
            else if (UserID != Common.NULL_ID)
                updateAddress();

        }

        //for saving new address in database
        private void saveNewAddress()
        {
            AddressModel newaddress = new AddressModel();
            newaddress.ID = UserID.ToString();
            newaddress.City = CityNameText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = email.Text;

            newaddress = Database.Common.AddressDB.addAddress(newaddress);// customerID, CashierID);
            int check = Database.POS.UserDB.addAddress(UserID, newaddress.ID);

            if (check == 1)
            {
                if (newaddress != null)
                    Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + UserID + "& AddressID=" + newaddress.ID);
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
            updateaddress.ID = AddressID.ToString();
            updateaddress.City = CityNameText.Text;
            updateaddress.Location1 = Location1Text.Text;
            updateaddress.Location2 = Location2Text.Text;
            updateaddress.Phonenumber = PhoneNumberText.Text;
            updateaddress.Email = email.Text;
            int check = Database.Common.AddressDB.updateAddress(updateaddress);
            if (check == 1)
            {
                Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + UserID + "&AddressID=" + AddressID);
                message.Text = "Data is Updated";
            }
            else if (check != 1)
            {
                message.Text = "Data is not Updated";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + UserID + "& AddressID=null");
        }
    }
}