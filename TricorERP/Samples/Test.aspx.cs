using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.Samples
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        /// <summary>
        /// Initialize contents of this page, First time load only
        /// </summary>
        private void InitializePageContents()
        {
            SearchCustomers();
        }

        /// <summary>
        /// Search customers
        /// </summary>
        private void SearchCustomers()
        {
            // Declare list
            List<Models.Samples.CustomerModel> customers = null;
            // Get from dummy
            //customers = TryDummyData();
            customers = GetFromDatabase();
            // Bind it to the listview
            CustomerListview.DataSource = customers;
            CustomerListview.DataBind();
        }

        private List<Models.Samples.CustomerModel> GetFromDatabase()
        {
            return Database.Samples.Customer.SearchCustomers("");
        }

        /// <summary>
        /// Get dummy list of customers, NOT from database
        /// </summary>
        /// <returns>List of customers</returns>
        private List<Models.Samples.CustomerModel> TryDummyData()
        {
            // Create new list
            List<Models.Samples.CustomerModel> customers = new List<Models.Samples.CustomerModel>();

            // Add first customer to the list
            Models.Samples.CustomerModel saqib = new Models.Samples.CustomerModel()
            {
                FullName = "Saqib Razzaq",
                CustomerType = 1
            };
            customers.Add(saqib);

            // Add second customer
            Models.Samples.CustomerModel shaheer = new Models.Samples.CustomerModel()
            {
                FullName = "Muhammad Shaheer",
                CustomerType = 1
            };
            customers.Add(shaheer);

            // Return the list
            return customers;
        }

        /// <summary>
        /// Handle command events from the list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            // Open the edit customer page, without any query string
            Response.Redirect("EditCustomer.aspx");
        }
    }
}