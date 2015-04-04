<%@ Page Title="EditCashier" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditCashier.aspx.cs" Inherits="TricorERP.POS.BranchManager.EditCashier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditCashier.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="h2">
            <asp:Label ID="Head" runat="server" Text=""></asp:Label>
        </h2>
        <div class="row container-fluid">
            <div class="col-lg-4">
                <label for="InputName">Full Name :</label>
                <div class="input-group">
                    <asp:TextBox ID="CashierNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <asp:Label ID="message" runat="server" CssClass="alert" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-lg-4">
                <label for="InputName">Password :</label>
                <div class="input-group">
                    <asp:TextBox ID="CashierPasswordText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-4">
                <label for="InputName">CNIC :</label>
                <div class="input-group">
                    <asp:TextBox ID="CNIC" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-4">
                <h4 class="h4">
                    <label for="InputName">Address :</label></h4>
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New</asp:LinkButton>
            </div>

        </div>
        <div class="row container-fluid">
            <div class="col-lg-10">
                <h5 class="h5">
                    <label for="InputName">All Possible Addresses...</label></h5>
                <div class="panel-body">
                    <asp:ListView ID="CashierAddressesview" OnItemCommand="CashierListview_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>Address ID</th>
                                    <th>Phone Number</th>
                                    <th>City</th>
                                    <th>Location</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr runat="server">
                                <td class="AddressID">
                                    <%# Eval("ID") %>
                                </td>
                                <td>
                                    <%# Eval("Phonenumber") %>
                                </td>
                                <td>
                                    <%# Eval("City") %>

                                </td>
                                <td>
                                    <%# Eval("Location1") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="AddAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </td>

                                <td>
                                        <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                        </button>
                                        <asp:Button runat="server" CssClass="hidden DeleteAddress" CommandName="DeleteAddress" OnClick="deleteCashierrAddress_onClick" />
                                    </td>
                                <%--<td>
                                    <asp:LinkButton runat="server" CommandName="DeleteAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>

                    <asp:TextBox CssClass="hidden txtAddressID" runat="server" ID="txtAddressID" Text=""></asp:TextBox>


                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
                
            </div>
        </div>

    </div>
</asp:Content>
