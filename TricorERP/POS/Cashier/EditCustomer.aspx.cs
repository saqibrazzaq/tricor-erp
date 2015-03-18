using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

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
            List<Models.POS.Customer.AddressModel> customerAddresses = null;

            customer = GetCustomerInFo(Id);
            customerAddresses = GetAddressesFromDB(Id);
            
            CustomerNameLab.Text = customer.Name;
            CNICpLab.Text = customer.CNIC;
            
            CustomerAddressesview.DataSource = customerAddresses;
            CustomerAddressesview.DataBind();
        }

        private CustomerModel GetCustomerInFo(String Id)
        {
            return Database.POS.Customer.CustomerDB.getCustomerInFo(Id);
        }

        private List<Models.POS.Customer.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.POS.Customer.AddressDB.getCustomerAddresses(Id);
        }
        //----------------------------------------------------------


        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/AddAddress.aspx?CustomerID=" + customerID);
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (customerID == "0")
                AddNewCustomer();
            else
                UpdateCustomer();
        }

        private void UpdateCustomer()
        {
            // Create new Model from the textfields
            // Model will have ID = customerID
            // Method call: Database.CustomerDB.UpdateCustomer(model)
        }

        private void AddNewCustomer()
        {
            // Create new model from the textfields
            // Model will NOT have ID
            // Method call : insert
            // Return model: ID - response.redirect("ID=" + model.ID)
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Cashier/CustomerList.aspx");
        }
    }
}