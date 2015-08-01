using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS;
using System.Web.UI.HtmlControls;

namespace TricorERP.POS.PurchaseOrder
{
    public partial class PurchaseOrder : System.Web.UI.Page
    {
        Models.Common.PurchaseOrderModel purchaseOrder = new Models.Common.PurchaseOrderModel() { ID = Common.NULL_ID };

        List<Models.Common.PurchaseOrderItemsModel> items;


        //Models.POS.Order.OrderStatusModel ordersttus = new Models.POS.Order.OrderStatusModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializeOrderModel();
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            ErrorMessage.Text = "";
            InitializeOrderModel();
            InitializeWareHouseDropDowm();
            if (Session["RoleID"].ToString() == "2" || Session["RoleID"].ToString() == "1")
            {
                InitializeHeadLable();
                if (purchaseOrder.ID != Common.NULL_ID)
                {
                    ItemMessageLab.Text = "All Purchase Items are...";
                    purchaseOrder = GetPurchaseOrderInFon();
                    DateTextBoox.Text = purchaseOrder.OrderDate;
                    WaherHouseDropDownList.SelectedValue = purchaseOrder.WHID;
                    SavePurchaseOrderbtn.Text = "Update";
                    txtOrderStatus.Text = purchaseOrder.OrderStatusName;

                    if (purchaseOrder.OrderStatus != Common.OrderPending)
                    {
                        WaherHouseDropDownList.Enabled = false;
                        btnAddNewItem.Enabled = false;
                        SavePurchaseOrderbtn.Enabled = false;
                        btnManufacture.Enabled = false;
                    }

                    if (purchaseOrder.OrderStatus == Common.ManufacturingComplete)
                    {
                        Deliveredbtn.Enabled = true;
                    }
                    else 
                    {
                        Deliveredbtn.Enabled = false;
                    }

                }
                else
                {
                    SavePurchaseOrderbtn.Text = "Save";
                    btnManufacture.Enabled = false;
                    btnAddNewItem.Enabled = false;
                    Deliveredbtn.Enabled = false;
                    txtOrderStatus.Text = "Pending";
                    InitializeCurentDate();
                }
            }
            else
            {
                ErrorMessage.Text = Session["UserID"].ToString();
            } 
        }

        private void InitializeCurentDate()
        {
            DateTextBoox.Text = DateTime.Now.ToShortDateString();
            purchaseOrder.OrderDate = DateTextBoox.Text.Trim();

            txtOrderStatus.Text = "Pending";
        }

        private void InitializeWareHouseDropDowm()
        {
            List<WareHouseModel> WHModel = Database.POS.Order.OrderDB.getWareHouseList();
            WaherHouseDropDownList.DataSource = WHModel;
            WaherHouseDropDownList.DataTextField = "Name";
            WaherHouseDropDownList.DataValueField = "ID";
            WaherHouseDropDownList.DataBind();
        }

        private void InitializeHeadLable()
        {
            if (purchaseOrder.ID == Common.NULL_ID)
            {
                PurchaseOrderLable.Text = "New Purchase Order";
            }
            else
            {
                PurchaseOrderLable.Text = "Update Purchase Order";
            }
        }

        private void InitializeOrderModel()
        {
            try
            {
                if (Common.CheckNullString(Request.QueryString["ID"]) != Common.NULL_ID)
                {
                    purchaseOrder.ID = Request.QueryString["ID"];
                    loadPurchaseOrderItemModel();
                }
                else
                {
                       
                }
            }
            catch (Exception ex)
            {
                purchaseOrder.ID = Common.NULL_ID;
                throw ex;
            }
        }

        private void loadPurchaseOrderItemModel()
        {
            if (purchaseOrder.ID != Common.NULL_ID) {
                items = GetPurchseItemsList();
                PurchaseOrderItemview.DataSource = items;
                PurchaseOrderItemview.DataBind();
            }
        }

        private List<Models.Common.PurchaseOrderItemsModel> GetPurchseItemsList()
        {
            return Database.Common.PurchaseOrderItemDB.getPurchaseOrderItemsList(purchaseOrder.ID);
        }

        protected void SavePurchaseOrderbtn_Click(object sender, EventArgs e)
        {
            if (purchaseOrder.ID == Common.NULL_ID)
            {
                NewPurchaseOrder();
            }
            else 
            {
                UpdatePurchaseOrder(purchaseOrder.OrderStatus);
            }
        }
        private void NewPurchaseOrder()
        {
            //purchaseOrder.WHID = WaherHouseDropDownList.SelectedValue.Trim();
            purchaseOrder.WHID = Common.WarehouseIDDefault;
            purchaseOrder.OrderDate = DateTextBoox.Text.Trim();
            purchaseOrder.LastUpdatedBy = Session["UserID"].ToString().Trim();
            purchaseOrder.CreatedBy = Session["UserID"].ToString().Trim();
            purchaseOrder.SID = Common.NULL_ID;
            purchaseOrder.OrderStatus = Common.OrderPending;
            purchaseOrder = Database.Common.PurchaseOrderDB.addPurchaseOrder(purchaseOrder);
            
            if (purchaseOrder.ID != Common.NULL_ID) {
                Response.Redirect("~/POS/PurchaseOrder/PurchaserOrderItems.aspx?ID="+purchaseOrder.ID);                
            }
        }

        private void UpdatePurchaseOrder( String temp )
        {
            purchaseOrder = GetPurchaseOrderInFon();
            purchaseOrder.WHID = WaherHouseDropDownList.SelectedValue.Trim();
            purchaseOrder.OrderStatus = temp; 
            int check = Database.Common.PurchaseOrderDB.updatePurchaseOrder(purchaseOrder);
            if (check > 0)
                ErrorMessage.Text = "Data is Updated...";
        }

        private Models.Common.PurchaseOrderModel GetPurchaseOrderInFon()
        {
            return Database.Common.PurchaseOrderDB.getPurchaseOrderInFol(purchaseOrder.ID);
        }


        protected void btnAddNewItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/PurchaseOrder/PurchaserOrderItems.aspx?ID=" + purchaseOrder.ID);
        }

        protected void deletePurchaseItem_Click(object sender, EventArgs e)
        {
            String PurchaseOrderItemID = txtPurchaseItemID.Text.Trim();
            int check = Database.Common.PurchaseOrderItemDB.deletePurchaseOrderItems(PurchaseOrderItemID.ToString());
            if (check > 0)
                InitializePageContents();
            else
                ErrorMessage.Text = "Due to Some Issue Data is not deleted...";
        }

        protected void SavePurchaseOrder_Click(object sender, EventArgs e)
        {
            Models.Common.PurchaseOrderItemsModel updateItem = new Models.Common.PurchaseOrderItemsModel();
            updateItem.ID = txtPurchaseItemID.Text.Trim();
            updateItem.Quantity = int.Parse(txtQuantity.Text.Trim());
            updateItem.LastUpdatedBy = Session["UserID"].ToString().Trim();
            int check = Database.Common.PurchaseOrderItemDB.updatePurchaseOrderItems(updateItem);
            if (check > 0)
            {
                InitializePageContents();
            }
            else 
            {
                ErrorMessage.Text = "Due to Some Issue Data is not Updated...";
            }
            
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }

        protected void PurchaseOrderItemview_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            purchaseOrder = GetPurchaseOrderInFon();

            if (purchaseOrder.OrderStatus != Common.OrderPending)
            {
                Control myControl1 = e.Item.FindControl("ItemCommandtd");
                if (myControl1 != null)
                {
                    myControl1.Visible = false;
                }
            }
        }

        protected void aproveBTN_Click(object sender, EventArgs e)
        {
            UpdatePurchaseOrder(Common.OrderReadyToManufacturing);
            InitializePageContents();
        }

        protected void Deliveredbtn_Click(object sender, EventArgs e)
        {
            int check = Database.POS.StockDB.updateStockItems(items);
            if (check > 0) {
                UpdatePurchaseOrder(Common.Delivered);
            }
            InitializePageContents();
        }
    }
}