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
        string AddressID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            CashierID = Request.QueryString["CashierID"];
            AddressID = Request.QueryString["AddressID"];

            if (CashierID == "0") { 
                btnAddNewAddress.Enabled = false;
            }

            if (CashierID != "0")
                Head.Text = "Cashier Information.";
            else if(CashierID == "0")
                Head.Text = "New Cashier";
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
            CashierModel cashier = null;
            List<Models.POS.Customer.AddressModel> cashierAddresses = null;

            cashier = GetCahierInFo();
            cashierAddresses = GetAddressesFromDB();

            CashierNameText.Text = cashier.Name;
            CashierPasswordText.Text = cashier.Password;
            CNIC.Text = cashier.CNIC;

            CashierAddressesview.DataSource = cashierAddresses;
            CashierAddressesview.DataBind();
        }

        private CashierModel GetCahierInFo()
        {
            return Database.POS.CashierDB.getCashierInFo(CashierID);
        }
        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB()
        {
            return Database.POS.CashierDB.getCashierAddresses(CashierID);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/AddAddress.aspx?CashierID=" + CashierID + "&AddressID=0");
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
                Response.Redirect("~/POS/BranchManager/AddAddress.aspx?CashierID=" + newcasier.ID + "&AddressID=0");
            else
                message.Text = "UserName/CNIC is already exist.";
        }

        private void updateCashier()
        {
            CashierModel updatecashier = new CashierModel();
            updatecashier.ID = int.Parse(CashierID.ToString());
            updatecashier.CNIC = CNIC.Text;
            updatecashier.Name = CashierNameText.Text;
            updatecashier.Password = CashierPasswordText.Text;

            int check = Database.POS.CashierDB.updateCashier(updatecashier);
            if (check == 1)
            {
                message.Text = "Data is Updated";
                Response.Redirect("~/POS/BranchManager/EditCashier.aspx?CashierID=" + updatecashier.ID + "&AddressID=0");
            }
            else
            {
                message.Text = "Data is not Updated";
                Response.Redirect("~/POS/BranchManager/EditCashier.aspx?CashierID=" + updatecashier.ID + "&AddressID=0");
            }
        }

        protected void CashierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "AddAddress")
            {
                Response.Redirect("AddAddress.aspx?CashierID=" + CashierID + "&AddressID=" + AddressID);
            }
       }

        protected void deleteCashierrAddress_onClick(object sender, EventArgs e)
        {
            int AddressID = int.Parse(txtAddressID.Text);
            deleteCashierAddress(AddressID.ToString());
            InitializePageContents();
        }

        private int deleteCashierAddress(String AddressID)
        {
            return Database.POS.CashierDB.deleteAddress(CashierID, AddressID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/CashierList.aspx");
        }

        
    }
}