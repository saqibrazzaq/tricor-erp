﻿<%@ Page Title="" Language="C#" MasterPageFile="~/POS/Cashier/CashierMaster.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TricorERP.POS.Cashier.CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Customer's List</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="TextBox1" CssClass="form-control" placeholder="Search for..." runat="server"></asp:TextBox>
                <%--<input type="text" class="form-control" placeholder="Search for...">--%>
                <span class="input-group-btn">
                    <asp:Button ID="Button1" CssClass="btn btn-default" runat="server" Text="Search" />
                </span>
            </div>
        </div>
    </div>
    <div class="panel-body">
        <asp:ListView ID="CustomerListview" runat="server" OnItemCommand="CustomerListview_ItemCommand" OnSelectedIndexChanged="CustomerListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                    <tr>
                        <th>ID</th>
                        <th>Full Name</th>
                        <%--<th>Customer Type</th>--%>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <%# Eval("ID") %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditCustomer" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("FullName") %>'></asp:LinkButton>
                    </td>
                    <%-- <td><%# Database.Samples.Customer.GetCustomerType(int.Parse(Eval("CustomerType").ToString())) %></td>--%>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
