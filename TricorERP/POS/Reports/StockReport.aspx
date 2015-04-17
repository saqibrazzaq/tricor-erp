<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="TricorERP.POS.Reports.StockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-4">
                    <div class="h3">
                        <asp:Label ID="HeadingOfSalesReport" runat="server" Text="Stock Report">
                        </asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="col-lg-8">
                <div class="panel-body">
                    <asp:ListView ID="StockReportView" runat="server" OnItemDataBound="StockReportView_ItemDataBound">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="StockTable">
                                <tr class="active">
                                    <th>Product Name</th>
                                    <th>Total Quantity</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="Tr1" runat="server" class="">
                                <td class="AddressID">
                                    <%# Eval("ProductName") %>
                                    
                                </td>
                                <td>
                                    <%# Eval("Quantity") %>
                                    <asp:Label ID="StockLowMessage" runat="server" Text="(Low Stock)"></asp:Label>
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
