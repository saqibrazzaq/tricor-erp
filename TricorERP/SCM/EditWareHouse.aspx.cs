﻿using Models.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TricorERP.SCM
{
    public partial class EditWareHouse : System.Web.UI.Page
    {
        String WHID = "-1";
        WareHouseModel WareHouseModel = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            WHID = Request.QueryString["WHID"];
            if (IsPostBack == false)
            {
                InitializePageContents(WHID);
            }
        }
        private void InitializePageContents(String Id)
        {
            WareHouseData(Id);
        }
        private void WareHouseData(String Id)
        {
            WareHouseModel  WHModel = null;
            List<Models.Global.AddressModel> wareHouseAddresses = null;
            WHModel = GetWareHouseInFo(Id);
            wareHouseAddresses = GetAddressesFromDB(Id);
            WHNameText.Text = WHModel.Name;
            WHDescriptionText.Text = WHModel.Description;

            WareHouseModel = WHModel;
            WareHouseAddressesview.DataSource = wareHouseAddresses;
            WareHouseAddressesview.DataBind();
        }
        private WareHouseModel GetWareHouseInFo(String Id)
        {
            return Database.SCM.WareHouseDB.getWareHouseInFo(Id);
        }
        private List<Models.Global.AddressModel> GetAddressesFromDB(String Id)
        {
            return Database.SCM.WareHouseDB.getWareHouseAddresses(Id);
        }

        protected void btnAddNewAddress_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SCM/AddWareHouseAddress.aspx?WHID=" + WHID + "&AddressID=0");
        }

        protected void Savebtn_Click(object sender, EventArgs e)
        {
            if (WHID == "-1")
                AddNewWareHouse();
            else
                UpdateWareHouse();
        }
        private void AddNewWareHouse()
        {
            WareHouseModel wareHouse = new WareHouseModel();
            wareHouse.Name = WHNameText.Text;
            wareHouse.Description = WHDescriptionText.Text;
            wareHouse = Database.SCM.WareHouseDB.addNewWareHouse(wareHouse);
            Response.Redirect("~/SCM/AddWareHouseAddress.aspx?WHID=" + wareHouse.ID + "&AddressID=0");
        }
        private void UpdateWareHouse()
        {
            WareHouseModel wareHouse = new WareHouseModel();

            wareHouse.ID = int.Parse(WHID.ToString());
            wareHouse.Name = WHNameText.Text;
            wareHouse.Description = WHDescriptionText.Text;
            int check = Database.SCM.WareHouseDB.updateWareHouse(wareHouse);
            if (check == 1)
            {
                message.Text = "Data is Updated";
            }
            else
            {
                message.Text = "Data is not Updated";
            }
        }

        protected void WareHouseListview_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            String AddressID = e.CommandArgument.ToString();
            if (e.CommandName == "EditAddress")
            {
               Response.Redirect("AddWareHouseAddress.aspx?WHID=" + WHID + "&AddressID=" + AddressID);
            }
            else if (e.CommandName == "DeleteAddress")
            {
                deleteWareHouseAddress(AddressID);
                Response.Redirect("~/SCM/EditWareHouse.aspx?WHID=" + WHID);
            }
        }
        private void deleteWareHouseAddress(String AddressID)
        {
            int check = Database.SCM.WareHouseDB.deleteAddress(WHID, AddressID);
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

        protected void WHDescriptionText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}