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
            List<Models.Samples.CustomerModel> customers = null;
            customers = GetFromDatabase();
            // Bind it to the list-view
            CustomerListview.DataSource = customers;
            CustomerListview.DataBind();
        }

        private List<Models.Samples.CustomerModel> GetFromDatabase()
        {
            return Database.Samples.Customer.SearchCustomers("");
        }

    }
}