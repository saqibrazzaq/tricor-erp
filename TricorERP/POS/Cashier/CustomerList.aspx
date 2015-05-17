<%@ Page Title="CustomerList" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TricorERP.POS.Cashier.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">Customer's List</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchCustomer" CssClass="form-control" placeholder="Search Customer By Name Or Phone Number..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchCustomerButton1_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="panel-body">
                <div class="col-lg-10">
                    <asp:ListView ID="CustomerListview" runat="server" OnItemCommand="CustomerListview_ItemCommand">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th class="hidden">ID</th>
                                    <th>Full Name</th>
                                    <th>Phone Number</th>
                                    <th>Edit</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr runat="server">
                                <td class="hidden">
                                    <%# Eval("ID") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditCustomer" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("Phonenumber") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditCustomer" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Label ID="Message" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="row">

                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary " OnClick="btnBack_Click">Back</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
