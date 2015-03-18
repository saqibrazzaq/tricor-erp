using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database.UserLogin;
using Models.Login;

namespace TricorERP.POS
{
    public partial class POS_Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            UserModel userModel = UserLogin.loginCheck(NameTextBox.Text, PasswordTextBox.Text); // static method
            if (userModel != null)
            {
                Session["Username"] = NameTextBox.Text;
                Session["RoleID"] = userModel.RoleID;
                Session["CustomerID"] = userModel.ID;
                Response.Redirect("~/Home.aspx");
            }
            else
                loginMsg.Text = "<h4>Invalid User/Name Password</h4>";
        }
    }
}