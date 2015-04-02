using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class PurchaseOrderItem : System.Web.UI.Page
    {

        public String WHID = "-1";
        public String SID = "-1";
        public String PID = "-1";
        public String POID = "-1";
        public String UpdateCheck = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            WHID = Request.QueryString["WHID"];
            SID = Request.QueryString["SID"];
            PID = Request.QueryString["PID"];
            POID = Request.QueryString["POID"];
            UpdateCheck = Request.QueryString["Update"];
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            LoadProductDropDown();
            WHNameText.Text = WHID;
            SupplierText.Text = SID; 
        }

     
       
        private void LoadProductDropDown()
        {
            // Declare list

            List<Models.SCM.ProductModel> Newproduct = new List<Models.SCM.ProductModel>();
            if (PID != "-1" || true)
            {
                    Newproduct = GetAllProductsFromDatabase();
             }
            //else
            //{
            //    Newproduct.Add(GetSelectedProductFromDatabase);
            //}
                ProductsDropDown.DataTextField = "ProductName";
                ProductsDropDown.DataValueField = "ProductID";
            
            ProductsDropDown.DataSource = Newproduct;
            ProductsDropDown.DataBind();
        }
        
        private List<Models.SCM.ProductModel> GetAllProductsFromDatabase()
        {
            return Database.SCM.ProductDB.getProductList(null);
        }
        private ProductModel GetSelectedProductFromDatabase()
        {
            return Database.SCM.ProductDB.getProductInFo(PID);
        }
        protected void ProductListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            WHID = WHNameText.Text;
            SID = SupplierText.Text;
            String PID = e.CommandArgument.ToString();
            if (e.CommandName == "EditProduct")
            {
                Response.Redirect("~/SCM/PurchaseOrderItem.aspx?WHID=" + WHID + "&SID=" + SID + "&PID=" + PID);
            }
            else if (e.CommandName == "DeleteProduct")
            {
                //DeleteOrderItem();
            }
        }

        
        protected void Addbtn_Click(object sender, EventArgs e)
        {
           
        }
        private List<PurchaseOrderItemsModel> GetPurchaseOrderitemsFromDatabase(String POID)
        {
            return Database.SCM.PurchaseOrderDB.getAllPurchaseOrderitemsList(POID);
        }
        private int updatePurchaseOrderItem(PurchaseOrderItemsModel POIModel)
        {
            return Database.SCM.PurchaseOrderDB.updatePurchaseOrderItems(POIModel);
        }
        private PurchaseOrderItemsModel addNewPurchaeOrderItem(PurchaseOrderItemsModel POIModel)
        {
            return Database.SCM.PurchaseOrderDB.addPurchaseProductItems(POIModel);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            PurchaseOrderItemsModel POIModel = new PurchaseOrderItemsModel();
            POIModel.PurchaseOrderID = int.Parse(POID);
            POIModel.PurchasePrice = float.Parse(PurchasePriceText.Text);
            POIModel.Quantity = int.Parse(QuantityText.Text);
            POIModel.ProductID = int.Parse(ProductsDropDown.SelectedValue);
            int updated = 0;
            PurchaseOrderItemsModel NewPurchaseOrderItem = null;
            if (UpdateCheck != null)
            {
                POIModel.ID = int.Parse(POID);
                updated = updatePurchaseOrderItem(POIModel);
            }
            else
            {
                NewPurchaseOrderItem = addNewPurchaeOrderItem(POIModel);
            }

            if (NewPurchaseOrderItem != null)
            {
                Response.Redirect("~/SCM/PurchaseOrder.aspx?POID=" + POID);
                ErrorMessageLable.Text = "Data of new Purchase Order is saved...";
            }
            else if (updated == 1)
            {
                Response.Redirect("~/SCM/PurchaseOrder.aspx?POID=" + POID);
                ErrorMessageLable.Text = "Data is Updated Successfully...";
            }
        }

    }

}