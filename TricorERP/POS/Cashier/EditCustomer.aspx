<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.EditCustomer" %>

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
                    <asp:Label ID="CustomerNameLab" Font-Names="InputName" CssClass="form-control" runat="server" Text="Name is"></asp:Label>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-asterisk"></span></span>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">CNIC Number :</label>
                <div class="input-group">
                    <asp:Label ID="CNICpLab" Font-Names="InputName" CssClass="form-control" runat="server" Text="Type is.."></asp:Label>
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
                <div class="panel-body">
                    <asp:ListView ID="CustomerAddressesview" runat="server" >
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr>
                                    <th>Phone Number</th>
                                    <th>City</th>
                                    <th>Location</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr runat="server">
                                <td>
                                    <%# Eval("Phonenumber") %>
                                </td>
                                <td>
                                    <%# Eval("City") %>
                                </td>
                                <td>
                                    <%# Eval("Location") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
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
