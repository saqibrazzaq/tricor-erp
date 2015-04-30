<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="TricorERP.POS.Reports.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">

        <div class="panel-heading">
            <h2 class="h2">Sale Report</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchSales" CssClass="form-control" placeholder="Search by date(17-Apr-15)..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="Search_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-12">
                <div class="panel-body">

                    <asp:ListView ID="SalesReportView" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>Product Name</th>
                                    <th>Total Quantity</th>
                                    <th>Total Sale Price</th>
                                    <th>Total Purchase Price</th>
                                    <th>Profit</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="Tr1" runat="server">
                                <td class="AddressID">
                                    <%# Eval("orderdates") %>
                                </td>
                                <td>
                                    <%# Eval("Quantity") %>
                                </td>
                                <td>
                                    <%# Eval("SalePrice") %>
                                </td>
                                <td>
                                    <%# Eval("PurchasePrice") %>
                                </td>
                                <td>
                                    <%# Eval("Profit") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>

                    <div class="row">
                        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    
                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary" OnClick="Cancel_Click">Cancel</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
