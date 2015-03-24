using Models.Global;
using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class AddSupplierAddress : System.Web.UI.Page
    {
        String AddressID = "0";
        String SID = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            AddressID = Request.QueryString["AddressID"];
            SID = Request.QueryString["SID"];
            if (IsPostBack == false)
            {
                InitializePageContents();
            }
        }
        private void InitializePageContents()
        {
            LoadSupplierAddress();
        }
        //Initializing PageContents
        private void LoadSupplierAddress()
        {
            AddressModel addressModel = new AddressModel();
            addressModel = Database.SCM.AddressDB.getAddress(AddressID);
            Location1Text.Text = addressModel.Location1;
            Location2Text.Text = addressModel.Location2;
            EmailText.Text = addressModel.Email;
            PhoneNumberText.Text = addressModel.Phonenumber;
            CityText.Text = addressModel.City;
            
            SupplierModel supplier = new SupplierModel();
            supplier = Database.SCM.SupplierDB.getSupplierInFo(SID);
            SupplierNameText.Text = supplier.Name;
            SupplierCNICText.Text = supplier.CNIC;
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (AddressID == "0")
                saveNewAddress();
            else
                updateAddress();
        }
        //for saving new address in database
        private void saveNewAddress()
        {
            AddressModel newaddress = new AddressModel();
            newaddress.ID = int.Parse(SID.ToString());
            newaddress.City = CityText.Text;
            newaddress.Location1 = Location1Text.Text;
            newaddress.Location2 = Location2Text.Text;
            newaddress.Phonenumber = PhoneNumberText.Text;
            newaddress.Email = EmailText.Text;
            int result = Database.SCM.SupplierDB.addSupplierAddress(newaddress, SID);
            if (result > 0)
            {
                ErrorMessageLable.Text = "New Address is saved.";
            }
            Response.Redirect("~/SCM/EditSupplier.aspx?SID=" + SID);

        }

        //for update the address 
        private void updateAddress()
        {
            AddressModel updateaddress = new AddressModel();
            updateaddress.ID = int.Parse(AddressID.ToString());
            updateaddress.City = CityText.Text;
            updateaddress.Location1 = Location1Text.Text;
            updateaddress.Location2 = Location2Text.Text;
            updateaddress.Phonenumber = PhoneNumberText.Text;
            updateaddress.Email = EmailText.Text;
            int check = Database.SCM.AddressDB.updateAddress(updateaddress);
            if (check == 1)
            {
                ErrorMessageLable.Text = "Data is Updated";
                Response.Redirect("~/SCM/EditSupplier.aspx?SID=" + SID);
            }
            else if (check != 1)
            {
                ErrorMessageLable.Text = "Data is not Updated...";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SCM/EditSupplier.aspx?SID=" + SID);
        }
    }
}