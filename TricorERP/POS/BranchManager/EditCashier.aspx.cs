using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.BranchManager
{
    public partial class EditCashier : System.Web.UI.Page
    {
        String CashierID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            CashierID = Request.QueryString["CashierID"];
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            CashierData();
        }

        private void CashierData()
        {
            //throw new NotImplementedException();
        }

        protected void CashierAddressesview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {

        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (CashierID == "0")
                addNewCashier();
        }

        private void addNewCashier()
        {
            //throw new NotImplementedException();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}