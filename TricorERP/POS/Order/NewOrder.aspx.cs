using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;

namespace TricorERP.POS.Order
{
    public partial class NewOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomerDropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List <CustomerModel> allcustomer = null;
            //allcustomer = Database.POS.Customer.CustomerDB.getallCustomer();
            //CustomerDropDown.DataBind = allcustomer;
            //CustomerDropDown.DataBind();
        }

        protected void AddProducts_Click(object sender, EventArgs e)
        {

        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

    }
}