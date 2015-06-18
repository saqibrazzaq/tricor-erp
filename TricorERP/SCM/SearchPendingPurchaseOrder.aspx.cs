using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class PendingPurchaseOrder : System.Web.UI.Page
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
                pOrderList = GetPendingOrdersListFromDatabase(null);
            }
            else if (SearchOrder != null)
            {
                pOrderList = GetPendingOrdersListFromDatabase(SearchOrder);
            }
            PurchaseOrderListview.DataSource = pOrderList;
            PurchaseOrderListview.DataBind();
        }

        private List<Models.SCM.PurchaseOrderModel> GetPendingOrdersListFromDatabase(string SearchOrder)
        {
            return Database.SCM.PurchaseOrderDB.GetSpecificPurchaseOrdersList("1",SearchOrder);
        }

        private List<Models.SCM.PurchaseOrderModel> GetOrdersListFromDatabase(String SearchOrder)
        {
            return Database.SCM.PurchaseOrderDB.getPurchaseOrderList(SearchOrder);
        }
        public int DeleteOrdersFromDatabase(String ID)
        {
            return Database.SCM.PurchaseOrderDB.deletePurchaseOrder(ID);
        }

        protected void PurchaseOrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPurchaseOrder")
            {
                String POID = e.CommandArgument.ToString();
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=1");
            }
        }

        protected void SearchPurchaseOrders(object sender, EventArgs e)
        {
            SearchPurchaseOrderList(SearchPurchaseOrderText.Text);
        }
        protected void deletePurchaseOrder_onClick(object sender, EventArgs e)
        {
            String POID = txtPurchaseOrderID.Text;
            DeleteOrdersFromDatabase(POID);
            Response.Redirect("~/SCM/SearchAllPurchaseOrder.aspx");
        }

    }
}