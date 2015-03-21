<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="TricorERP.POS.Order.EditOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1>Add Order</h1>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Customer :</b><asp:DropDownList ID="CustomerDropDown" Font-Names="InputName" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Date :</b><asp:Label ID="DateLab" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Products :</b><asp:DropDownList ID="ProductsDropDown" Font-Names="InputName" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="AddProducts" runat="server" CssClass="btn btn-primary" OnClick="AddProducts_Click" >Add</asp:LinkButton>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-8">
                <%-- greed view --%>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" OnClick="LinkButton1_Click">Save</asp:LinkButton>
                </div>
            </div>
        </div>


    </div>
</asp:Content>
