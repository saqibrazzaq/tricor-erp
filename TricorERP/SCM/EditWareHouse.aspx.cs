using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class EditWareHouse : System.Web.UI.Page
    {
        String WHID = "0";
        WareHouseModel WareHouseModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            WHID = Request.QueryString["WHID"];
            if (IsPostBack == false)
            {
                InitializePageContents(WHID);
            }
        }
        private void InitializePageContents(String Id)
        {
            WareHouseData(Id);
        }
        private void WareHouseData(String Id)
        {
            WareHouseModel  WHModel = null;
            List<Models.Global.AddressModel> wareHouseAddresses = null;
            WHModel = GetWareHouseInFo(Id);
            wareHouseAddresses = GetAddressesFromDB(Id);
            WHNameText.Text = WHModel.Name;
            WHDescriptionText.Text = WHModel.Description;
            //for access the WareHouse data on next page. 
            WareHouseModel = WHModel;
            WareHouseAddressesview.DataSource = wareHouseAddresses;
            WareHouseAddressesview.DataBind();
        }
        private WareHouseModel GetWareHouseInFo(String Id)
        {
            return Database.SCM.WareHouseDB.getWareHouseInFo(Id);
        }
        private List<Models.Global.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.SCM.AddressDB.getWareHouseAddresses(Id);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SCM/AddAddress.aspx?WHID=" + WHID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (WHID == "0")
                AddNewCustomer();
            else
                UpdateCustomer();
        }
        // method for add new customer
        private void AddNewCustomer()
        {
            CustomerModel customer = new CustomerModel();
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Type = int.Parse(CustomerTyepDropDown.SelectedValue);
            customer = Database.POS.Customer.CustomerDB.addNewCustomer(customer);
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customer.ID + "&AddressID=0");
        }

        // method for update customers
        private void UpdateCustomer()
        {
            CustomerModel customer = new CustomerModel();

            customer.ID = int.Parse(WHID.ToString());
            customer.Name = CustomerNameText.Text;
            customer.CNIC = CNICText.Text;
            customer.Gender = GenderDropDown.SelectedValue;
            customer.Type = int.Parse(CustomerTyepDropDown.SelectedValue);

            int check = Database.POS.Customer.CustomerDB.updateCustomer(customer);
            if (check == 1)
            {
                message.Text = "Data is Updated";
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customer.ID + "&AddressID=0");
            }
            else
            {
                message.Text = "Data is not Updated";
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + customer.ID + "&AddressID=0");
            }
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "AddAddress")
            {
                Response.Redirect("AddAddress.aspx?CustomerID=" + WHID + "&AddressID=" + AddressID);
            }
            else if (e.CommandName == "DeleteAddress")
            {
                deleteCustomerAddress(AddressID);
                Response.Redirect("~/POS/Cashier/EditCustomer.aspx?CustomerID=" + WHID);
            }
        }
        private void deleteCustomerAddress(String AddressID)
        {
            int check = Database.POS.Customer.CustomerDB.deleteAddress(WHID, AddressID);
            if (check == 1)
            {
                message.Text = "Address is Deleted";
            }
            else
            {
                message.Text = "Due to Some error Data is not Deleted";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/CustomerList.aspx");
        }
    }
}