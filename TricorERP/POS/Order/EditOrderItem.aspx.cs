using Models.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Models.POS.Customer;
using Models.POS.Order;

namespace TricorERP.POS.Order
{
    public partial class EditOrderItem : System.Web.UI.Page
    {
        String SaleOrderID = "0";
        String CustomerID = "0";
        String SaleOrderItemID = "0";
        String ProductID = "0";

        List<ProductModel> productlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            SaleOrderID = Request.QueryString["SaleOrderID"];
            CustomerID = Request.QueryString["CustomerID"];
            SaleOrderItemID = Request.QueryString["SaleOrderItemID"];
            ProductID = Request.QueryString["ProductID"];

            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }

        private void InitializePageContents()
        {
            LoadProductDropdown();
            loadCustomerInFo(CustomerID);
            loadOrderInFo(SaleOrderID);
            if (SaleOrderItemID != "0" && ProductID != "0")
                loadSaleOrderInFo();
        }

        // set all the data of an sales order in case of update
        private void loadSaleOrderInFo()
        {
            SaleOrderItemModel loadsaleorderdata = Database.POS.Order.OrderDB.getSaleOrderItem(int.Parse(SaleOrderID.ToString()), ProductID);
            QuantityDropDown.SelectedValue = loadsaleorderdata.Quantity.ToString();
            ProductPriceText.Text = loadsaleorderdata.Price.ToString();
        }

        // that function can get the information of order and show on text field.
        private void loadOrderInFo(string SaleOrderID)
        {
            SaleOrderModel saleinfo = GetSaleOrderInFo();
            //set the order date of an sale-order
            OrderDate.Text = saleinfo.OrderDate;

        }
        private SaleOrderModel GetSaleOrderInFo()
        {
            return Database.POS.Order.OrderDB.SaleOrderInFo(SaleOrderID);
        }

        // get the customer information for show that information on the page.
        private void loadCustomerInFo(String id)
        {
            CustomerModel customerinfo = GetCustomerInFo(id);
            CustomerNameText.Text = customerinfo.Name;
            CNIC.Text = customerinfo.CNIC;
        }

        private CustomerModel GetCustomerInFo(String id)
        {
            return Database.POS.Customer.CustomerDB.getCustomerInFo(id);
        }

        // load data of products in drop-down list and bind with it. 
        private void LoadProductDropdown()
        {
            //how to get sales price within list?
            productlist = GetProductList();
            ProductDropDown.DataSource = productlist;
            ProductDropDown.DataTextField = "ProductName";
            ProductDropDown.DataValueField = "ProductID";
            ProductDropDown.DataBind();
            if (SaleOrderItemID != "0" && ProductID != "0")
            {
                ProductDropDown.Items.FindByValue(ProductID).Selected = true;
            }
        }

        private List<ProductModel> GetProductList()
        {
            return Database.POS.ProductDB.getProductList("");
        }

        // for saving the data in database
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (SaleOrderItemID == "0")//&& ProductID == "0")
                addNewOrder();
            else
                updateOrder();
        }

        // save data into database when save data into database when new item is save into database
        private void addNewOrder()
        {
            SaleOrderItemModel newsaleproduct = new SaleOrderItemModel();
            newsaleproduct.OrderID = int.Parse(SaleOrderID.ToString());
            newsaleproduct.Price = int.Parse(ProductPriceText.Text);
            newsaleproduct.ProductID = int.Parse(ProductDropDown.SelectedValue);
            newsaleproduct.Quantity = int.Parse(QuantityDropDown.SelectedValue);
            newsaleproduct = Database.POS.Order.OrderDB.addSalesProduct(newsaleproduct);
            if (newsaleproduct != null)
                Response.Redirect("~/POS/Order/EditOrder.aspx?CustomerID="
                    + CustomerID + "&SaleOrderID=" + SaleOrderID);
        }

        private void updateOrder()
        {
            SaleOrderItemModel updatesaleproduct = new SaleOrderItemModel();
            updatesaleproduct.ID = int.Parse(SaleOrderItemID.ToString());
            updatesaleproduct.OrderID = int.Parse(SaleOrderID.ToString());
            updatesaleproduct.Price = int.Parse(ProductPriceText.Text);
            updatesaleproduct.ProductID = int.Parse(ProductDropDown.SelectedValue);
            updatesaleproduct.Quantity = int.Parse(QuantityDropDown.SelectedValue);
            int check = Database.POS.Order.OrderDB.updateSalesProduct(updatesaleproduct);
            if (check > 0)
            {
                ErrorMessage.Text = "Data is updated Success fully";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/POS/Order/EditOrder.aspx?CustomerID="
                    + CustomerID + "&SaleOrderID=" + SaleOrderID);
            //Response.Redirect("~/POS/Order/EditOrder.aspx?SaleOrderID=" + SaleOrderID);
        }


    }
}