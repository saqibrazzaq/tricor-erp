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
            String gender = "";
            bool ischeck = BranchManagerRadio.Checked;
            if (ischeck)
                gender = BranchManagerRadio.Text;
            else
                gender = CashierRadio.Text;

            Login user = new Login();
            user.userName = NameTextBox.Text;
            user.password = PasswordTextBox.Text;
            user.userType = gender;
            


            UserLogin login = new UserLogin();
            Boolean check = login.loginCheck(NameTextBox.Text, PasswordTextBox.Text, gender);

            if (check && gender == "BranchManager")
            {
                Session["UserName"] = NameTextBox.Text;
                Response.Redirect("~/BranchManager/BranchManagerHome.aspx");
            }
            else if (check && gender == "Cashier")
            {
                Session["UserName"] = NameTextBox.Text;
                Response.Redirect("~/Cashier/CashierHome.aspx");
            }
            else if (ischeck == false)
                loginMsg.Text = "<h4>You Choose Branch Manager OR Cashier </h4>";
            else
                loginMsg.Text = "<h4>Invalid User/Name Password</h4>";
        }
    }
}