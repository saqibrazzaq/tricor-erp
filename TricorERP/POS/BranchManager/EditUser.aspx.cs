using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.User;

namespace TricorERP.POS.BranchManager
{
    public partial class EditCashier : System.Web.UI.Page
    {
        String UserID = "0";
        string AddressID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Request.QueryString["UserID"];
            AddressID = Request.QueryString["AddressID"];

            if (UserID == "0") { 
                btnAddNewAddress.Enabled = false;
            }

            if (UserID != "0")
                Head.Text = "User Information";
            else if(UserID == "0")
                Head.Text = "New User";
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            UserData();
        }

        private void UserData()
        {
            UserModel cashier = null;
            List<Models.POS.Customer.AddressModel> userAddresses = null;

            cashier = GetCahierInFo();
            userAddresses = GetAddressesFromDB();

            CashierNameText.Text = cashier.Name;
            CashierPasswordText.Text = cashier.Password;
            CNIC.Text = cashier.CNIC;

            CashierAddressesview.DataSource = userAddresses;
            CashierAddressesview.DataBind();
        }

        private UserModel GetCahierInFo()
        {
            return Database.POS.UserDB.getCashierInFo(UserID);
        }
        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB()
        {
            return Database.POS.UserDB.getCashierAddresses(UserID);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/AddAddress.aspx?UserID=" + UserID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (UserID == "0")
                addNewCashier();
            else
                updateCashier();
        }
        private void addNewCashier()
        {
            UserModel newcasier = new UserModel();
            newcasier.Name = CashierNameText.Text;
            newcasier.Password = CashierPasswordText.Text;
            newcasier.CNIC = CNIC.Text;
            newcasier = Database.POS.UserDB.addNewCashier(newcasier);

            if (newcasier != null)
                Response.Redirect("~/POS/BranchManager/AddAddress.aspx?UserID=" + newcasier.ID + "&AddressID=0");
            else
                message.Text = "UserName/CNIC is already exist.";
        }

        private void updateCashier()
        {
            UserModel updatecashier = new UserModel();
            updatecashier.ID = int.Parse(UserID.ToString());
            updatecashier.CNIC = CNIC.Text;
            updatecashier.Name = CashierNameText.Text;
            updatecashier.Password = CashierPasswordText.Text;

            int check = Database.POS.UserDB.updateCashier(updatecashier);
            if (check == 1)
            {
                message.Text = "Data is Updated";
                Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + updatecashier.ID + "&AddressID=0");
            }
            else
            {
                message.Text = "Data is not Updated";
                Response.Redirect("~/POS/BranchManager/EditUser.aspx?UserID=" + updatecashier.ID + "&AddressID=0");
            }
        }

        protected void CashierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "AddAddress")
            {
                Response.Redirect("AddAddress.aspx?UserID=" + UserID + "&AddressID=" + AddressID);
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
            return Database.POS.UserDB.deleteAddress(UserID, AddressID);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/BranchManager/UserList.aspx");
        }

        
    }
}