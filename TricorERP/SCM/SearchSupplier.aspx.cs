using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchSupplier : System.Web.UI.Page
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
            searchSupplier("");
        }
        private void searchSupplier(String searchSupplier)
        {
            // Declare list
            List<Models.SCM.SupplierModel> supplier = null;
            if (searchSupplier == "")
            {
                supplier = GetFromDatabase(null);
            }
            else if (searchSupplier != null)
            {
                supplier = GetFromDatabase(searchSupplier);
            }
            SupplierListview.DataSource = supplier;
            SupplierListview.DataBind();
        }
        private List<Models.SCM.SupplierModel> GetFromDatabase(String searchSupplier)
        {
            return Database.SCM.SupplierDB.getSupplierList(searchSupplier);
        }
        protected void SupplierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditSupplier")
            {
                String SID = e.CommandArgument.ToString();
                Session["SupplierID"] = SID;
                Response.Redirect("~/SCM/EditSupplier.aspx?SID=" + SID);
            }
        }
        protected void SearchWareHouse(object sender, EventArgs e)
        {
            searchSupplier(SearchSupplierText.Text);
        }

    }
}