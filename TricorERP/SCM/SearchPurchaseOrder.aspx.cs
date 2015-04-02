using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchPurchaseOrder : System.Web.UI.Page
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
            SearchPurchaseOrderList("");
        }
        private void SearchPurchaseOrderList(String SearchOrder)
        {
            // Declare list
            List<Models.SCM.PurchaseOrderModel> pOrderList = null;
            if (SearchOrder == "")
            {
                pOrderList = GetOrdersListFromDatabase(null);
            }
            else if (SearchOrder != null)
            {
                pOrderList = GetOrdersListFromDatabase(SearchOrder);
            }
            PurchaseOrderListview.DataSource = pOrderList;
            PurchaseOrderListview.DataBind();
        }

        private List<Models.SCM.PurchaseOrderModel> GetOrdersListFromDatabase(String SearchOrder)
        {
            return Database.SCM.PurchaseOrderDB.getPurchaseOrderList(SearchOrder);
        }
        protected void PurchaseOrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPurchaseOrder")
            {
                String POID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/PurchaseOrder.aspx?POID=" +POID + "&update=1");
            }
        }

        protected void SearchPurchaseOrders(object sender, EventArgs e)
        {
            SearchPurchaseOrderList(SearchPurchaseOrderText.Text);
        }

    }
}