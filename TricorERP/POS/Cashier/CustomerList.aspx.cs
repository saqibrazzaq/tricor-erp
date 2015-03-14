using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.Cashier
{
    public partial class CustomerList : System.Web.UI.Page
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
            SearchCustomers();
        }
        private void SearchCustomers()
        {
            // Declare list
            List<Models.Customer.CustomerModel> customers = null;
            customers = GetFromDatabase();
            // Bind it to the list-view
            CustomerListview.DataSource = customers;
            CustomerListview.DataBind();
        }

        private List<Models.Customer.CustomerModel> GetFromDatabase()
        {
            return Database.CustomerDatabase.CustomerDB.getCustomersList("");
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit customer command
            if (e.CommandName == "EditCustomer")
            {
                // Customer ID is in argument
                String customerID = e.CommandArgument.ToString();
                // Open the edit customer page
                Response.Redirect("EditCustomer.aspx?ID=" + customerID);
            }
        }

        protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        {

        }

    }
}