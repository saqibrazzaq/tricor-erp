<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="TricorERP.POS.Reports.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">

        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-4">
                    <div class="h3">
                        <asp:Label ID="HeadingOfSalesReport" runat="server" Text="Sale Report">
                        </asp:Label>
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
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="Tr1" runat="server">
                                <td class="AddressID">
                                    <%# Eval("ProductName") %>
                                </td>
                                <td>
                                    <%# Eval("Quantity") %>
                                </td>
                                <td>
                                    <%# Eval("Price") %>
                                </td>
                                <td>
                                    <%# Eval("PurchasePrice") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary" OnClick="Cancel_Click">Cancel</asp:LinkButton>
                        </div>
                        <div class="col-lg-8">
                            <b>
                                <asp:Label ID="TotalSalePrice" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="TotalPurchasePrice" runat="server" Text=""></asp:Label><br />
                                <asp:Label ID="Profit" runat="server" Text=""></asp:Label></b>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
