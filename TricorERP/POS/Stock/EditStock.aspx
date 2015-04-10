<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditStock.aspx.cs" Inherits="TricorERP.POS.Stock.EditStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <h2 class="h2">
            <asp:Label ID="Head" runat="server" Text="Edit Stock"></asp:Label>
        </h2>
        <div class="row container-fluid">

            <div class="col-lg-4">
                <label for="InputName">Product :</label>
                <div class="input-group">
                    <asp:DropDownList Font-Names="InputName" CssClass="form-control" ID="ProductDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <br />
        <div class="row container-fluid">
            <div class="col-lg-4">
                <label for="InputName">Quantity</label>
                <div class="input-group">
                    <asp:TextBox ID="Quantity" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        
        <div class="row container-fluid">
            <div class="col-lg-4">
                <asp:LinkButton ID="btnAddStock" runat="server" CssClass="btn btn-primary" OnClick="btnAddStock_Click">Add Stock</asp:LinkButton>
                <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary" OnClick="Cancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
        <br />
        <br />
        <div class="row container-fluid">
            <div class="col-lg-4">
                <asp:Label ID="MessageLable" CssClass="alert-danger" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
