using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchWH : System.Web.UI.Page
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
            SearchWareHouse("");
        }
        private void SearchWareHouse(String searchWareHouse)
        {
            // Declare list
            List<Models.SCM.WareHouseModel> warehouse = null;
            if (searchWareHouse == "")
            {
                warehouse = GetFromDatabase(null);
            }
            else if (searchWareHouse != null)
            {
                warehouse = GetFromDatabase(searchWareHouse);
            }
            WareHouseListview.DataSource = warehouse;
            WareHouseListview.DataBind();
        }
        private List<Models.SCM.WareHouseModel> GetFromDatabase(String searchWareHouse)
        {
            return Database.SCM.WareHouseDB.getWareHouseList(searchWareHouse);
        }
        protected void WareHouseListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditWareHouse")
            {
                String WareHouseID = e.CommandArgument.ToString();
                Session["WareHouseID"] = WareHouseID;
                Response.Redirect("~/SCM/EditWareHouse.aspx?WHID=" + WareHouseID);
            }
        }
        protected void SearchWareHouse(object sender, EventArgs e)
        {
            SearchWareHouse(SearchWareHouseText.Text);
        }

    }
}