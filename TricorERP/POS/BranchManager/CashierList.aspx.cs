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
            cashier = GetFromDatabase("");
        }

        private List<Models.POS.Cashier.CashierModel> GetFromDatabase(string p)
        {
            return Database.POS.CashierDB.
        }

        protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        {

        }
    }
}