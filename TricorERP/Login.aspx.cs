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
            //String gender = "";
            //bool ischeck = BranchManagerRadio.Checked;
            //if (ischeck)
            //    gender = BranchManagerRadio.Text;
            //else
            //    gender = CashierRadio.Text;

            //Q. how can we use model class?
            //LoginModel user = new LoginModel();
            //user.userName = NameTextBox.Text;
            //user.password = PasswordTextBox.Text;
            //user.userType = gender; // set value in integer
            
            UserModel userModel = UserLogin.loginCheck(NameTextBox.Text, PasswordTextBox.Text); // static method

            if (userModel != null)
            {
               // loginMsg.Text = "<h4>You Choose Branch Manager OR Cashier </h4>";
                Session["Username"] = NameTextBox.Text;
                Session["RoleID"] = userModel.RoleID;
                Response.Redirect("~/Home.aspx");
            }
            else
                loginMsg.Text = "<h4>Invalid User/Name Password</h4>";
        }
    }
}