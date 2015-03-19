﻿using System;
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
            SearchCustomers("");
        }
        private void SearchCustomers(String SearchCustomer)
        {
            // Declare list
            List<Models.POS.Customer.CustomerModel> customers = null;
            if (SearchCustomer == null)
            {
                customers = GetFromDatabase(null);
            }
            else if (SearchCustomer != null)
            {
                customers = GetFromDatabase(SearchCustomer);
            }
            else
            {

            }
            CustomerListview.DataSource = customers;
            CustomerListview.DataBind();
        }

        private List<Models.POS.Customer.CustomerModel> GetFromDatabase(String x)
        {
            //what is CustomerDatabase?
            return Database.POS.Customer.CustomerDB.getCustomersList(x);
        }

        protected void CustomerListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            // Edit customer command
            if (e.CommandName == "EditCustomer")
            {
                // Customer ID is in argument
                String customerID = e.CommandArgument.ToString();
                // Open the edit customer page
                Response.Redirect("EditCustomer.aspx?ID=" + customerID + "&AddressID=0");
                Session["CustomerID"] = customerID;
            }
        }

        protected void SearchCustomerButton1_Click(object sender, EventArgs e)
        {
            SearchCustomers(SearchCustomer.Text);
        }

    }
}