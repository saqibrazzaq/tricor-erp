using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class EditSupplier : System.Web.UI.Page
    {
        String sID = "-1";
        SupplierModel supplierModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            sID = Request.QueryString["SID"];
            if (IsPostBack == false)
            {
                InitializePageContents(sID);
            }
        }
        private void InitializePageContents(String Id)
        {
            SupplierData(Id);
        }
        private void SupplierData(String Id)
        {
            SupplierModel sModel = null;
            List<Models.Global.AddressModel> supplierAddresses = null;
            sModel = GetSupplierInFo(Id);
            supplierAddresses = GetAddressesFromDB(Id);
            SupplierNameText.Text = sModel.Name;
            SupplierCNICText.Text = sModel.CNIC;
 
            supplierModel = sModel;
            SupplierAddressesview.DataSource = supplierModel;
            SupplierAddressesview.DataBind();
        }
        private SupplierModel GetSupplierInFo(String Id)
        {
            return Database.SCM.SupplierDB.getSupplierInFo(Id);
        }
        private List<Models.Global.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.SCM.AddressDB.getWareHouseAddresses(Id);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SCM/AddSupplierAddress.aspx?SID=" + sID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (sID == "-1")
                AddNewSupplier();
            else
                UpdateSupplier();
        }

        private void AddNewSupplier()
        {
            SupplierModel supplier = new SupplierModel();
            supplier.Name = SupplierNameText.Text;
            supplier.CNIC = SupplierCNICText.Text;
            supplier = Database.SCM.SupplierDB.addNewSupplier(supplier);
            Response.Redirect("~/SCM/AddSupplierAddress.aspx?SID=" + supplier.ID + "&AddressID=0");
        }

        private void UpdateSupplier()
        {
            SupplierModel supplier = new SupplierModel();

            supplier.ID = int.Parse(sID.ToString());
            supplier.Name = SupplierNameText.Text;
            supplier.CNIC = SupplierCNICText.Text;
            int check = Database.SCM.SupplierDB.updateSupplier(supplier);
            if (check == 1)
            {
                message.Text = "Data is Updated";
             
            }
            else
            {
                message.Text = "Data is not Updated";
            }
        }

        protected void SupplierListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "EditAddress")
            {
                Response.Redirect("AddSupplierAddress.aspx?SID=" + sID + "&AddressID=" + AddressID);
            }
            else if (e.CommandName == "DeleteAddress")
            {
                deleteSupplierAddress(AddressID);
                Response.Redirect("~/SCM/EditSupplier.aspx?SID=" + sID);
            }
        }
        private void deleteSupplierAddress(String AddressID)
        {
            int check = Database.SCM.SupplierDB.deleteSupplierAddress(sID, AddressID);
            if (check == 1)
            {
                message.Text = "Address is Deleted";
            }
            else
            {
                message.Text = "Due to Some error Data is not Deleted";
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
        }
    }
}