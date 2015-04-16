<%@ Page Title="EditCashier" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="TricorERP.POS.BranchManager.EditCashier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditCashier.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">
                <asp:Label ID="Head" runat="server" Text=""></asp:Label>
            </h2>
        </div>
        <div class="panel-body">
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Full Name :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter user full name" ControlToValidate="CashierNameText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CashierNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="message" runat="server" CssClass="alert" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Password :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter user password" ControlToValidate="CashierPasswordText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CashierPasswordText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">CNIC :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter user CNIC" ControlToValidate="CNIC" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CNIC" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">User-Type :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select user type" ControlToValidate="UserTypeDropDownList" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:DropDownList Font-Names="InputName" CssClass="form-control" ID="UserTypeDropDownList" runat="server">
                        </asp:DropDownList>
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
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>
