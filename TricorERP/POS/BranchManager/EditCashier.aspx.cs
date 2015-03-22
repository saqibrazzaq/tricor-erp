using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Cashier;

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
            else
                updateCashier();
        }
        private void addNewCashier()
        {
            CashierModel newcasier = new CashierModel();
            newcasier.Name = CashierNameText.Text;
            newcasier.Password = CashierPasswordText.Text;
            newcasier.CNIC = CNIC.Text;
            newcasier = Database.POS.CashierDB.addNewCashier(newcasier);
            if (newcasier != null)
                Response.Redirect("~/POS/Cashier/AddAddress.aspx?CashierID="+newcasier.ID+"&AddressID=0");
        }

        private void updateCashier()
        {
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}