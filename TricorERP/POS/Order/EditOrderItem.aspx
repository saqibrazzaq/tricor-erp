<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditOrderItem.aspx.cs" Inherits="TricorERP.POS.Order.EditOrderItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="h3">Customer InFo</h3>
    <div class="row container-fluid">
        <div class="col-lg-4">
            <label for="InputName">Customer Name :</label>
            <div class="input-group">
                <asp:TextBox ID="CustomerNameText" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="col-lg-4">
            <label for="InputName">CNIC :</label>
            <div class="input-group">
                <asp:TextBox ID="CNIC" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

    </div>
    <div class="row container-fluid">
    <div class="col-lg-4">
            <label for="InputName">Order Date :</label>
            <div class="input-group">
                <asp:TextBox ID="OrderDate" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <br />
    <h3 class="h3">Product InFo</h3>
    <div class="row container-fluid">
        <div class="col-lg-4">
            <label for="InputName">Product Name :</label>
            <div class="input-group">
                <asp:DropDownList ID="ProductDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    <asp:ListItem>Select Product</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-4">
            <label for="InputName">Quantity :</label>
            <div class="input-group">
                <asp:DropDownList ID="QuantityDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    <asp:ListItem>Select Quantity</asp:ListItem>
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>

    <br />
    <div class="row container-fluid">
        <div class="col-lg-4">
            <label for="InputName">Product Price :</label>
            <div class="input-group">
                <asp:TextBox ID="ProductPriceText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <br />
    <br />
    <div class="row container-fluid">
        <div class="col-lg-5">
            <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
        </div>
    </div>

</asp:Content>
