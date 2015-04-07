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
            SearchCashier("");
        }

        private void SearchCashier(string searchuser)
        {
            List<Models.POS.User.UserModel> cashier = null;
            if (searchuser == null)
                cashier = GetFromDatabase("");
            else if (searchuser != null)
                cashier = GetFromDatabase(searchuser);
            else
                Message.Text = "Your Required Customer is not in Database..";
            CashierListview.DataSource = cashier;
            CashierListview.DataBind();
        }

        private List<Models.POS.User.UserModel> GetFromDatabase(string p)
        {
            return Database.POS.UserDB.getCashierList(p);
        }

        protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        {
            SearchCashier(SearchCustomer.Text);
        }

        protected void CashierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String UserID = e.CommandArgument.ToString();
            // Edit customer command
            if (e.CommandName == "EditCashier")
            {
                String userID = e.CommandArgument.ToString();
                Response.Redirect("EditUser.aspx?UserID=" + userID);
            } else if (e.CommandName == "DeleteCashier") {
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