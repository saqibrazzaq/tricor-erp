using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.BranchManager
{
    public partial class CashierList : System.Web.UI.Page
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
            LoadUserTyepDropDown();
            SearchUser("",UserTypeDropDownList.SelectedValue);
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

        private void SearchUser(string searchuser, String roleid)
        {
            List<Models.POS.User.UserModel> user = null;
            if (searchuser == "")
                user = GetFromDatabase("", UserTypeDropDownList.SelectedValue);
            else if (searchuser != "")
                user = GetFromDatabase(searchuser, UserTypeDropDownList.SelectedValue);
            else
                Message.Text = "Your Required Customer is not in Database..";
            CashierListview.DataSource = user;
            CashierListview.DataBind();
        }

        private List<Models.POS.User.UserModel> GetFromDatabase(string searchtext, string roleid)
        {
            return Database.POS.UserDB.getUserList(searchtext, roleid);
        }

        protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        {
            SearchUser(SearchCustomer.Text, UserTypeDropDownList.SelectedValue);
        }

        protected void CashierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String UserID = e.CommandArgument.ToString();
            // Edit customer command
            if (e.CommandName == "EditCashier")
            {
                //String userID = e.CommandArgument.ToString();
                Response.Redirect("EditUser.aspx?UserID=" + UserID);
            }
            else if (e.CommandName == "DeleteCashier")
            {
                deleteCashierAddress(UserID);
                Response.Redirect("UserList.aspx");
            }
        }
        private int deleteCashierAddress(String UserID)
        {
            // set the value of parameter as null because it can be delete the data from database according to the user id.
            return Database.POS.UserDB.deleteAddress(UserID, null);
        }

        protected void deleteCashier_onClick(object sender, EventArgs e)
        {
            int AddressID = int.Parse(txtAddressID.Text);
            deleteCashierAddress(AddressID.ToString());
            InitializePageContents();
        }

    }
}