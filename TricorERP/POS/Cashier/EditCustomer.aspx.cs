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
        String customerID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            customerID = Request.QueryString["Id"];
            
            if (IsPostBack == false)
            {
                InitializePageContents(customerID);
            }
        }

        private void InitializePageContents(String Id)
        {
            SearchCustomers(Id);
        }
        private void SearchCustomers(String Id)
        {
            CustomerModel customer = null;
            List<Models.Customer.AddressModel> customerAddresses = null;

            customer = GetCustomerInFo(Id);
            customerAddresses = GetAddressesFromDB(Id);
            
            CustomerNameLab.Text = customer.Name;
            CNICpLab.Text = customer.CNIC;
            
            CustomerAddressesview.DataSource = customerAddresses;
            CustomerAddressesview.DataBind();
        }

        private CustomerModel GetCustomerInFo(String Id)
        {
            return Database.Customer.CustomerDB.getCustomerInFo(Id);
        }

        private List<Models.Customer.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.Customer.AddressDB.getCustomerAddresses(Id);
        }
        //----------------------------------------------------------


        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customerID);
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/CustomerList.aspx");
        }
    }
}