using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.POS.PurchaseOrder
{
    public partial class PurchaserOrderItems : System.Web.UI.Page
    {
        private String purchaseorderid = null;
        Models.Common.PurchaseOrderItemsModel PurchaseOrderItem = new Models.Common.PurchaseOrderItemsModel() { ID = Common.NULL_ID };

        protected void Page_Load(object sender, EventArgs e)
        {
            purchaseorderid = Request.QueryString["ID"].ToString().Trim();
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            InitializeProductDropDown();
        }

        private void InitializeProductDropDown()
        {
            List<Models.POS.ProductModel> products = Database.POS.ProductDB.getProductList();
            ProductDropDownList.DataSource = products;
            // Set text and value
            ProductDropDownList.DataTextField = "ProductName";
            ProductDropDownList.DataValueField = "ProductID";
            ProductDropDownList.DataBind();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/PurchaseOrder/PurchaseOrder.aspx?ID="+purchaseorderid);
        }

        protected void SavePurchaseItembtn_Click(object sender, EventArgs e)
        {
            if (PurchaseOrderItem.ID == Common.NULL_ID)
            {
                AddNewPurchaseOrderItem();
            }
            else 
            {
                
            }
        }

        private void AddNewPurchaseOrderItem()
        {
            PurchaseOrderItem.ProductID = ProductDropDownList.SelectedValue;
            PurchaseOrderItem.Quantity = int.Parse(QuantityTextBox.Text);
            PurchaseOrderItem.PurchaseOrderID = purchaseorderid;
            PurchaseOrderItem.LastUpdatedBy = Session["UserID"].ToString().Trim();
            PurchaseOrderItem.CreatedBy = Session["UserID"].ToString().Trim();
            PurchaseOrderItem = Database.Common.PurchaseOrderItemDB.addPurchaseProductItems(PurchaseOrderItem);
            if (PurchaseOrderItem.ID != Common.NULL_ID) {
                Response.Redirect("~/POS/PurchaseOrder/PurchaseOrder.aspx?ID="+purchaseorderid);
            }
        }
    }
}