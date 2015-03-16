<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="NewCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.NewCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="h2">Customer</h2>
        <%-- to be continue... --%>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Full Name :</label>
                <div class="input-group">
                    <asp:TextBox ID="FullNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    <%--<span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>--%>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Type :</label>
                <div class="input-group">
                    <asp:DropDownList ID="DropDownList1" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>Individual</asp:ListItem>
                        <asp:ListItem>Company  </asp:ListItem>
                    </asp:DropDownList>
                    <%--<span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>--%>
                </div>
            </div>
        </div>

        <br />
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">CNIC :</label>
                <div class="input-group">
                    <asp:TextBox ID="CNICText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    <%--<span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>--%>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Gender :</label>
                <div class="input-group">
                    <asp:DropDownList ID="GenderDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Other</asp:ListItem>
                    </asp:DropDownList>
                    <%--<span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>--%>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                <label for="InputName">Address :</label></h4>
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add Address</asp:LinkButton>
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

    </div>
</asp:Content>
