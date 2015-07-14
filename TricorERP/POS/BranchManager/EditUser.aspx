<%@ Page Title="EditCashier" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="TricorERP.POS.BranchManager.EditCashier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditCashier.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">
                <span class="glyphicon glyphicon-user" aria-hidden="true"></span> <asp:Label ID="Head" runat="server" Text=""></asp:Label>
            </h2>
        </div>
        <div class="panel-body">
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" />
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Full Name :</label>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter user full name!" ControlToValidate="CashierNameText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CashierNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                    <asp:Label ID="message" runat="server" CssClass="alert" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Password :</label>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter user password!" ControlToValidate="CashierPasswordText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegExp1" runat="server" ErrorMessage="Password length must be between 7 to 15 characters"
                                    ControlToValidate="CashierPasswordText" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{7,15}$"
                                    ForeColor="Red">*</asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CashierPasswordText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">CNIC :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter user CNIC number!" ControlToValidate="CNIC" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter user valid CNIC number!" ControlToValidate="CNIC" ValidationExpression="^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$" ForeColor="Red">*</asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CNIC" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">User-Type :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please select user type!" ControlToValidate="UserTypeDropDownList" ForeColor="Red">*</asp:RequiredFieldValidator>
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
                    <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New Address</asp:LinkButton>
                </div>

            </div>
            <div class="row container-fluid">
                <div class="col-lg-10">
                    <h5 class="h5">
                        <label for="InputName">All Possible Addresses...</label>
                    </h5>
                    <div class="row">
                        <asp:Label runat="server" ID="ErroMessage" ForeColor="Red" Text=""></asp:Label>
                    </div>
                    <div class="panel-body">
                        <asp:ListView ID="CashierAddressesview" OnItemCommand="CashierListview_ItemCommand" runat="server">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                    <tr class="active">
                                        <th class="hidden">Address ID</th>
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
                                    <td class="hidden AddressID">
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
                    <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click" Text="">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
