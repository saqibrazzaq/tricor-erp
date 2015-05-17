<%@ Page Title="Purchaser Order Items" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaserOrderItems.aspx.cs" Inherits="TricorERP.POS.PurchaseOrder.PurchaserOrderItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="h4">
                <asp:Label ID="PurchaseOrderLable" runat="server" Text="Add New Item :"></asp:Label>
            </h4>
        </div>
        <div class="panel-body">
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Product :</label>
                    <div class="input-group">
                        <asp:DropDownList ID="ProductDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Quantity :</label>
                    <div class="input-group">
                        <asp:TextBox ID="QuantityTextBox" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <br />
            
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:LinkButton ID="SavePurchaseItembtn" runat="server" CssClass="btn btn-primary" OnClick="SavePurchaseItembtn_Click">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>
                </div>
            </div>
            <br />
            <br />
           
        </div>

    </div>
</asp:Content>
