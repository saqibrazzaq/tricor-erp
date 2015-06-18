using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class SearchConfirmedPurchaseOrder : System.Web.UI.Page
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
                pOrderList = GetConfirmedOrdersListFromDatabase(null);
            }
            else if (SearchOrder != null)
            {
                pOrderList = GetConfirmedOrdersListFromDatabase(SearchOrder);
            }
            PurchaseOrderListview.DataSource = pOrderList;
            PurchaseOrderListview.DataBind();
        }

        private List<Models.SCM.PurchaseOrderModel> GetConfirmedOrdersListFromDatabase(string SearchOrder)
        {
            return Database.SCM.PurchaseOrderDB.GetSpecificPurchaseOrdersList("2", SearchOrder);
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
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=2");
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