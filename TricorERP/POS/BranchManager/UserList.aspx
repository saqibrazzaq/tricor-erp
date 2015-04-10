<%@ Page Title="CashierList" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="TricorERP.POS.BranchManager.CashierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditCashier.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">User's List</h2>

            <div class="row">

                <div class="col-lg-3">
                    <div class="input-group">
                        <label for="InputName">User-Type :</label>
                        <asp:DropDownList Font-Names="InputName" CssClass="form-control" ID="UserTypeDropDownList" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-6">
                    <br />
                    <div class="input-group">
                        <asp:TextBox ID="SearchCustomer" CssClass="form-control" placeholder="Search for..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchCustomerButton1_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-10">
                    <asp:ListView ID="CashierListview" runat="server" OnItemCommand="CashierListview_ItemCommand">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>ID</th>
                                    <th>Full Name</th>
                                    <th>Phone Number</th>
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
                                    <asp:LinkButton runat="server" CommandName="EditCashier" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("PhoneNo") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditCashier" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </td>

                                <td>
                                    <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </button>
                                    <asp:Button runat="server" CssClass="hidden DeleteAddress" CommandName="DeleteAddress" OnClick="deleteCashier_onClick" />
                                </td>

                                <%--<td>
                        <asp:LinkButton runat="server" CommandName="DeleteCashier" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                    </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:TextBox CssClass="hidden txtAddressID" runat="server" ID="txtAddressID" Text=""></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:Label ID="Message" runat="server" Text=""></asp:Label>
                </div>
            </div>

            <div class="row container-fluid">
                <div class="col-lg-4">
                    <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary" OnClick="Cancel_Click">Cancel</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
