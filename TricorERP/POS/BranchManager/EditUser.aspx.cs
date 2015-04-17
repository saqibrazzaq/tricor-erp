﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.User;

namespace TricorERP.POS.BranchManager
{
    // what about the customer username and password  

    public partial class EditCashier : System.Web.UI.Page
    {
        String UserID = "0";
        string AddressID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Request.QueryString["UserID"];
            AddressID = Request.QueryString["AddressID"];

            if (UserID == "0") { 
                btnAddNewAddress.Enabled = false;
            }

            if (UserID != "0")
                Head.Text = "User Information";
            else if(UserID == "0")
                Head.Text = "New User";
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            UserData();
            LoadUserTyepDropDown();
        }

        private void LoadUserTyepDropDown()
        {
            List<Models.POS.RoleModel> roles = GetRoleListFromDB();
            UserTypeDropDownList.DataSource = roles;
            UserTypeDropDownList.DataTextField = "Name";
            UserTypeDropDownList.DataValueField = "ID";
            UserTypeDropDownList.DataBind();
        }

        private List<Models.POS.RoleModel> GetRoleListFromDB()
        {
            return Database.POS.UserDB.getRoleList();
        }

        private void UserData()
        {
            UserModel user = null;
            List<Models.POS.Customer.AddressModel> userAddresses = null;

            user = GetCahierInFo();
            userAddresses = GetAddressesFromDB();

            CashierNameText.Text = user.Name;
            CashierPasswordText.Text = user.Password;
            CNIC.Text = user.CNIC;
            UserTypeDropDownList.SelectedValue = user.Role;

            CashierAddressesview.DataSource = userAddresses;
            CashierAddressesview.DataBind();
        }

        private UserModel GetCahierInFo()
        {
            return Database.POS.UserDB.getUserInFo(UserID);
        }
        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB()
        {
            return Database.POS.UserDB.getUserAddresses(UserID);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/AddAddress.aspx?UserID=" + UserID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (UserID == "0")
                addNewUser();
            else
            {
                updateCashier();
            }
        }
        private void addNewUser()
        {
            UserModel newcasier = new UserModel();
            newcasier.Name = CashierNameText.Text;
            newcasier.Password = CashierPasswordText.Text;
            newcasier.CNIC = CNIC.Text;
            
            newcasier.Role = UserTypeDropDownList.SelectedValue;

            newcasier = Database.POS.UserDB.addNewUser(newcasier);

            if (newcasier != null)
                Response.Redirect("~/POS/BranchManager/AddAddress.aspx?UserID=" + newcasier.ID + "&AddressID=0");
            else
                message.Text = "UserName/CNIC is already exist.";
        }

        private void updateCashier()
        {
            UserModel updatecashier = new UserModel();
            updatecashier.ID = int.Parse(UserID.ToString());
            updatecashier.CNIC = CNIC.Text;
            updatecashier.Name = CashierNameText.Text;
            updatecashier.Password = CashierPasswordText.Text;

            updatecashier.Role = UserTypeDropDownList.SelectedValue; 


            int check = Database.POS.UserDB.updateUser(updatecashier);
            if (check == 1)
            {
                ErroMessage.Text = "Data is Updated";
                //Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + updatecashier.ID + "&AddressID=0");
            }
            //else
            //{
            //    message.Text = "Data is not Updated";
            //    //Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + updatecashier.ID + "&AddressID=0");
            //}
        }

        protected void CashierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "AddAddress")
            {
                Response.Redirect("AddAddress.aspx?UserID=" + UserID + "&AddressID=" + AddressID);
            }
       }

        protected void deleteCashierrAddress_onClick(object sender, EventArgs e)
        {
            int AddressID = int.Parse(txtAddressID.Text);
            deleteCashierAddress(AddressID.ToString());
            InitializePageContents();
        }

        private int deleteCashierAddress(String AddressID)
        {
            return Database.POS.UserDB.deleteAddress(UserID, AddressID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/UserList.aspx");
        }

        
    }
}