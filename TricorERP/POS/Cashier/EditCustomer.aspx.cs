using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.Customer;

namespace TricorERP.POS.Cashier
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents(Request.QueryString["Id"]);
            }
        }

        private void InitializePageContents(String Id)
        {
            SearchCustomers(Id);
        }
        private void SearchCustomers(String Id)
        {
            CustomerModel customer = null;
            List<Models.Customer.AddressModel> customers = null;

            customer = GetCustomerInFo(Id);
            customers = GetAddressesFromDB(Id);
            
            CustomerNameLab.Text = customer.Name;
            CNICpLab.Text = customer.CNIC;
            
            CustomerAddressesview.DataSource = customers;
            CustomerAddressesview.DataBind();
        }

        private CustomerModel GetCustomerInFo(String Id)
        {
            return Database.CustomerDatabase.CustomerDB.getCustomerInFo(Id);
        }

        private List<Models.Customer.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.Customer.AddressDB.getCustomerAddresses(Id);
        }
        //----------------------------------------------------------


        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/AddAddress.aspx");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}