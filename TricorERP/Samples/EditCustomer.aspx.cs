using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.Samples
{
    public partial class EditCustomer : System.Web.UI.Page
    {
        // Customer ID as a member
        int customerID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                InitializeContents();
            }
        }

        private void InitializeContents()
        {
            LoadCustomerDetails();
        }

        private void LoadCustomerDetails()
        {
            // Set default to7 new customer
            lblEditCustomer.Text = "New Customer";

            // If ID is passed, then edit the customer
            if (Request["ID"] != null)
            {
                int customerID = int.Parse(Request["ID"]);
                lblEditCustomer.Text = "Edit Customer: " + customerID;
            }
        }
    }
}