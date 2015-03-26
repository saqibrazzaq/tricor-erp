using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class AddNewSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected SupplierModel addNewSupplier(SupplierModel supplierModel)
        {
            return Database.SCM.SupplierDB.addNewSupplier(supplierModel);
        }
        protected void Savebtn_Click(object sender, EventArgs e)
        {
            SupplierModel sMOdel = new SupplierModel();
            sMOdel.Name = SupplierNameText.Text;
            sMOdel.CNIC = SupplierCNICText.Text;
            SupplierModel newSupplier = addNewSupplier(sMOdel);
            if (newSupplier != null)
                ErrorMessageLable.Text = "Data of new Supplier is saved.";
        }
    }
}
