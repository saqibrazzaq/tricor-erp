<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="TricorERP.POS.Reports.SalesReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">

        <div class="panel-heading">
            <h3 class="h3">
                <asp:Label ID="HeadingOfSalesReport" runat="server" Text="Sales Report of ">
                    <asp:Label runat="server" ID="error" Text=""> </asp:Label>
                </asp:Label>
            </h3>
        </div>
        <div class="panel-body">
            <div class="col-lg-10">
                <div class="panel-body">

                    <asp:ListView ID="SalesReportView" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>Product Name</th>
                                    <th>Quantity</th>
                                    <th>Sale Price</th>
                                    <th>Purchase Price</th>

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
                    </div>

                </div>
            </div>
        </div>

    </div>
</asp:Content>
