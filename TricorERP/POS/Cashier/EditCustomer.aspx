<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.EditCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <asp:Label ID="l" runat="server" Text="Label"></asp:Label>
        <h2 class="h2">Customer</h2>
        <%-- to be continue... --%>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Full Name :</label>
                <div class="input-group">

                    <asp:Label ID="CustomerNameLab" Font-Names="InputName" CssClass="form-control" runat="server" Text="Name is"></asp:Label>

                    <%-- <asp:TextBox ID="InputName" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>--%>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Type :</label>
                <div class="input-group">
                    <asp:Label ID="CustomerTyeppLab" Font-Names="InputName" CssClass="form-control" runat="server" Text="Type is.."></asp:Label>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                    <label for="InputName">Address :</label></h4>
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-6">
                <h5 class="h5">
                    <label for="InputName">All Possible Addresses...</label></h5>
                <div class="table">
                    <%--<asp:GridView CssClass="table table-hover table-responsive" ID="AddressGridView" runat="server">
                    </asp:GridView>--%>
                </div>
            </div>
        </div>
        <div class="row"></div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
