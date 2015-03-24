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

        private void SearchCashier(string searchcashier)
        {
            List<Models.POS.Cashier.CashierModel> cashier = null;
            if (searchcashier == null)
                cashier = GetFromDatabase("");
            else if (searchcashier != null)
                cashier = GetFromDatabase(searchcashier);
            else
                Message.Text = "Your Required Customer is not in Database..";
            CashierListview.DataSource = cashier;
            CashierListview.DataBind();
        }

        private List<Models.POS.Cashier.CashierModel> GetFromDatabase(string p)
        {
            return Database.POS.CashierDB.getCashierList(p);
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
                // Customer ID is in argument
                String cashierID = e.CommandArgument.ToString();
                // Open the edit customer page
                Response.Redirect("EditCashier.aspx?cashierID=" + cashierID);
            }
            else if (e.CommandName == "DeleteCashier") {
                deleteCashierAddress(UserID);
                Response.Redirect("CashierList.aspx");
            }
        }
        private void deleteCashierAddress(String UserID)
        {
            // set the value of parameter as null because it can be delete the data from database according to the user id.
            int check = Database.POS.CashierDB.deleteAddress(UserID, null);
            if (check == 1)
            {
                Message.Text = "Address is Deleted";
            }
            else
            {
                Message.Text = "Due to Some error Data is not Deleted";
            }
        }

    }
}