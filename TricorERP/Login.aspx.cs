﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database.UserLogin;
using Models.POS.User;

namespace TricorERP.POS
{
    public partial class POS_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
                
            }
        }

        private void InitializePageContents()
        {
            //if (Session["RoleID"].ToString() == "")
            //{
            //    loginMsg.Text = Session["logOutMsg"].ToString();
            //}
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserLogin.loginCheck(NameTextBox.Text, PasswordTextBox.Text); // static method
            if (userModel != null)
            {
                Session["Username"] = NameTextBox.Text;
                Session["RoleID"] = userModel.Role;
                //Session["CustomerID"] = userModel.ID;
                Session["UserID"] = userModel.ID;
                Session["WHID"] = userModel.WHID;
                Response.Redirect("~/Home.aspx");
            }
            else
                loginMsg.Text = "<h4>Invalid UserName/Password</h4>";
        }
    }
}