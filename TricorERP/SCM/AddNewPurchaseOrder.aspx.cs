using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{

    public partial class PurchaseOrder : System.Web.UI.Page
    {
        public String WHID = "-1";
        public String SID = "-1";
        public String UpdateCheck = null;
        public String POID = null;

       // List<Models.SCM.ProductModel> Orderproducts = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            UpdateCheck = Request.QueryString["Update"];
            POID = Request.QueryString["POID"];
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            LoadSupplierDropDown();
            LoadwareHouseDropDown();
            if (POID != null)
            {
                LoadPurchaseOrderItemsList(POID);
                LoadPageForUpdate(POID);   
            }
        }
        private void LoadPurchaseOrderItemsList(String POID)
        {
            List<Models.SCM.PurchaseOrderItemsModel> POIModel = new List<Models.SCM.PurchaseOrderItemsModel>();
            
            if(UpdateCheck != "2")
            {
                 POIModel = GetPurchaseOrderitemsFromDatabase(POID);
            ProductListview.DataSource = POIModel;
            ProductListview.DataBind();
            }
            else
            {
                POIModel = GetPurchaseOrderitemsFromDatabase(POID);
                ProductListviewconfirmed.DataSource = POIModel;
                ProductListviewconfirmed.DataBind();
            }
        }
        private List<PurchaseOrderItemsModel> GetPurchaseOrderitemsFromDatabase(String POID)
        {
            return Database.SCM.PurchaseOrderDB.getAllPurchaseOrderitemsList(POID);
        }
        private void LoadPageForUpdate(string POID)
        {
            PurchaseOrderModel POModel = GetOrderDataFromDateBase(POID);
            
            OrderDateText.Text = POModel.OrderDate;
           
            WareHouseDropDown.SelectedValue = POModel.WHID.ToString();
            SupplierDropDown.SelectedValue = POModel.SID.ToString();
            OrderTypeDropDown.SelectedValue = POModel.OrderType;
            if (UpdateCheck == "2")
            {
                SupplierDropDown.Enabled = false;
                OrderDateText.Enabled = false;
                OrderTypeDropDown.Enabled = false;
            }
        }

        private PurchaseOrderModel GetOrderDataFromDateBase(string POID)
        {
            return Database.SCM.PurchaseOrderDB.getPurchaseOrderInFo(POID);
        }
        private void LoadwareHouseDropDown()
        {
            // Declare list
            List<Models.SCM.WareHouseModel> wareHouse = null;
            wareHouse = GetWareHouseListFromDatabase();
            WareHouseDropDown.DataTextField = "Name";
            WareHouseDropDown.DataValueField = "ID";
            WareHouseDropDown.DataSource = wareHouse;
            WareHouseDropDown.DataBind();
            WareHouseDropDown.Enabled = false;
        }
        private void LoadSupplierDropDown()
        {
            // Declare list
            List<Models.SCM.SupplierModel> supplier = null;
            supplier = GetSuppliersListFromDatabase();
            SupplierDropDown.DataTextField = "Name";
            SupplierDropDown.DataValueField = "ID";
            SupplierDropDown.DataSource = supplier;
            SupplierDropDown.DataBind();
        }
        private List<Models.SCM.WareHouseModel> GetWareHouseListFromDatabase()
        {
            return Database.SCM.WareHouseDB.getWareHouseList(null, Session["UserID"].ToString());
        }
        private List<Models.SCM.SupplierModel> GetSuppliersListFromDatabase()
        {
            return Database.SCM.SupplierDB.getSupplierList(null);
        }
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
                WHID = WareHouseDropDown.SelectedValue;
                SID = SupplierDropDown.SelectedValue;
                String PID = e.CommandArgument.ToString();
            
            if (e.CommandName == "EditOrderProduct")
            {
              
            }
            else if (e.CommandName == "DeleteOrderProduct")
            {

            }
        }
        private PurchaseOrderModel addPurchaseProduct(PurchaseOrderModel POModel)
        {
            return Database.SCM.PurchaseOrderDB.addPurchaseProduct(POModel);
        }

        private int updatePurchaseOrder(PurchaseOrderModel POModel)
        {
            return Database.SCM.PurchaseOrderDB.updatePurchaseOrder(POModel);
        }
        private int updatePurchaseOrderItems(PurchaseOrderItemsModel POIModel)
        {
            return Database.SCM.PurchaseOrderDB.updatePurchaseOrderItems(POIModel);
        }
        private int updatePurchaseOrderQuantity(PurchaseOrderItemsModel POIModel)
        {
            return Database.SCM.PurchaseOrderDB.updatePurchaseOrderQuantity(POIModel);
        }
        private int deletePurchaseOrderItems(String ID)
        {
            return Database.SCM.PurchaseOrderDB.deletePurchaseOrderItems(ID);
        }
        protected void AddProductbtn_Click(object sender, EventArgs e)
        {
            WHID = WareHouseDropDown.SelectedValue;
            SID = SupplierDropDown.SelectedValue;
            Response.Redirect("~/SCM/PurchaseOrderItem.aspx?WHID=" + WHID + "&SID=" + SID + "&PID=-1"+"&POID="+POID);
        }

        protected void UpdatePurchaseOrderItem_onClick(object sender, EventArgs e)
        {
            PurchaseOrderItemsModel POIModel = new PurchaseOrderItemsModel();
            POIModel.ID = int.Parse(txtPurchaseOrderItemID.Text);
            if (UpdateCheck != "2")
            {
                POIModel.PurchasePrice = float.Parse(txtPrice.Text);
                POIModel.Quantity = int.Parse(txtQuantity.Text);
                updatePurchaseOrderItems(POIModel);
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=1");
            }
            else
            {
                POIModel.RecivedQuantity = int.Parse(txtRecivedQuantity.Text);
               // POIModel.Quantity = int.Parse(txtQuantity.Text);
                updatePurchaseOrderQuantity(POIModel);
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=2");
            }
           
        }
        protected void deletePurchaseOrderItem_onClick(object sender, EventArgs e)
        {
            deletePurchaseOrderItems(txtPurchaseOrderItemID.Text);
            Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            PurchaseOrderModel POModel = new PurchaseOrderModel();
            POModel.WHID = int.Parse(WareHouseDropDown.SelectedValue);
            POModel.SID = int.Parse(SupplierDropDown.SelectedValue);
            POModel.OrderDate = OrderDateText.Text;
            POModel.OrderType = OrderTypeDropDown.SelectedValue;
            int updated = 0;
            PurchaseOrderModel NewPurchaseOrder = null;
            if (UpdateCheck != null)
            {
                
                 POModel.ID = int.Parse(POID);
                if (UpdateCheck != "2")
                {
                  updated = updatePurchaseOrder(POModel);
                }
                else
                {
                    updated = updatePurchaseOrder(POModel);
                }
            }
            else
            {
                NewPurchaseOrder = addPurchaseProduct(POModel);
            }
            if (NewPurchaseOrder != null)
            {
                POID =""+NewPurchaseOrder.ID;
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=1");
                //ErrorMessageLable.Text = "Data of new Purchase Order is saved...";
            }
            else if (updated == 1)
            {
                Response.Redirect("~/SCM/AddNewPurchaseOrder.aspx?POID=" + POID + "&update=1");
                //ErrorMessageLable.Text = "Data is Updated Successfully...";
            }
        }
    }
}