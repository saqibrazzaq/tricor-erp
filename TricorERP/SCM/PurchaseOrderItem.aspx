<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderItem.aspx.cs" Inherits="TricorERP.SCM.PurchaseOrderItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container-fluid">
        <h2 class="h2">Purchase Order Item</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Ware House</label>
                <asp:TextBox ID="WHNameText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Supplier</label>
                 <asp:TextBox ID="SupplierText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
               
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
            <div class="col-lg-3">
                <label for="InputName">Purchase Price</label>
                 <asp:TextBox ID="PurchasePriceText" Font-Names="InputName"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>      
         </div>
         <br />
         <div class="row container-fluid">
             <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Products</label>
                <asp:DropDownList ID="ProductsDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-5">
                <br />
                <asp:LinkButton ID="Addbtn" runat="server" CssClass="btn btn-primary"  OnClick="Addbtn_Click" >ADD Order Products</asp:LinkButton>
            </div>
         </div>
    <br />
         <br />
         <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary"  OnClick="Savebtn_Click" >Save</asp:LinkButton>
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

