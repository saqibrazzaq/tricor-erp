<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddNewStockItem.aspx.cs" Inherits="TricorERP.SCM.AddNewStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <h2 class="h2">Add New Stock Item</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Product Code</label>
                <asp:DropDownList ID="ProductDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">WareHouse ID</label>
               <asp:DropDownList ID="WareHouseDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Quantity</label>
                 <asp:TextBox ID="QuantityText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary"   >Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" >Cancel</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
             <h4 class="h4">
                <asp:Label ID="ErrorMessageLable" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
    </div>
</asp:Content>
