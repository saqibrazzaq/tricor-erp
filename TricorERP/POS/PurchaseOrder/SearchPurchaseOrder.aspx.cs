using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.PurchaseOrder
{
    public partial class SearchPurchaseOrder : System.Web.UI.Page
    {
        List<Models.Common.PurchaseOrderModel> purchaseOrderModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            SearchFromPurchaseOrder("");
        }

        private void SearchFromPurchaseOrder(String OrderDate)
        {            
            if (OrderDate == null)
            {
                purchaseOrderModel = GetPurchaseOrderListFromDB(null);
            }
            else
            {
                purchaseOrderModel = GetPurchaseOrderListFromDB(OrderDate);
            }
            
            PurchaseOrderListview.DataSource = purchaseOrderModel;
            PurchaseOrderListview.DataBind();
        }
        private List<Models.Common.PurchaseOrderModel> GetPurchaseOrderListFromDB(String OrderDate)
        {
            return Database.Common.PurchaseOrderDB.getPurchaseOrderList(OrderDate);
        }

        protected void SearchPurchaseOrderButton1_Click(object sender, EventArgs e)
        {
            SearchFromPurchaseOrder(SearchPurchaseOrderFromDB.Text);
            if (purchaseOrderModel.Count == 0)
                Message.Text = "Data is not Founde...";
        }

        protected void PurchaseOrderListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "EditPurchaseOrder")
            {
                String PurchaseOrderID = e.CommandArgument.ToString();
                Response.Redirect("PurchaseOrder.aspx?ID=" + PurchaseOrderID);
            }
        }

        protected void deletePurchaseOrder_Click(object sender, EventArgs e)
        {
            String PurchaseOrderID = txtPurchaseItemID.Text.Trim();
            int check = Database.Common.PurchaseOrderDB.deletePurchaseOrder(PurchaseOrderID);
            if (check > 0)
                InitializePageContents();
            else
                Message.Text = "Due to some Data is Not deleted...";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
        int i = 0;
        protected void PurchaseOrderListview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (purchaseOrderModel[i].OrderStatusName.ToString() != "Pending")
            {
                Control myControl1 = e.Item.FindControl("ItemCommandtd");
                if (myControl1 != null)
                {
                    myControl1.Visible = false;
                }
            }
            i++;
        }
    }
}