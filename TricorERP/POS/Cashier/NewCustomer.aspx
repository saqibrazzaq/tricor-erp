<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="NewCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.NewCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="h2">New Customer</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Full Name :</label>
                <div class="input-group">
                    <asp:TextBox ID="FullNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Type :</label>
                <div class="input-group">
                    <asp:DropDownList ID="CustomerTyepDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Individual</asp:ListItem>
                        <asp:ListItem Value="2">Company  </asp:ListItem>
                    </asp:DropDownList>
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
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Gender :</label>
                <div class="input-group">
                    <asp:DropDownList ID="GenderDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="O">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                    <asp:Label ID="ErrorMessageLable" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                <label for="InputName">Address :</label></h4>
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add Address</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
