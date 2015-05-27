<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewInvoice.aspx.cs" Inherits="TricorERP.POS.Invoice.ViewInvoice" %>

<!DOCTYPE html>
<html>
<head>

    <meta charset="utf-8" />
    <title>View Invoice</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.10.2.min.js"></script>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <div class="invoice-title">
                    <h2>Invoice</h2>
                    <h3 class="pull-right">Order # <asp:label runat="server" ID="laborderid" Text=""></asp:label></h3>
                </div>
                <hr>
                <div class="row">
                    <div class="col-xs-6">
                        <address>
                            <strong>Billed To:</strong><br>
                            <asp:label runat="server" ID="labcustomernamebil" Text=""></asp:label><br>
                            <asp:label runat="server" ID="labcnicbil" Text=""></asp:label>
                            <asp:label runat="server" ID="labaddressbil" Text=""></asp:label>
                        </address>
                    </div>
                    <div class="col-xs-6 text-right">
                        <address>
                            <strong>Shipped To:</strong><br>
                            <asp:label runat="server" ID="labcustomernameship" Text=""></asp:label><br>
                            <asp:label runat="server" ID="labcnicship" Text=""></asp:label>
                            <asp:label runat="server" ID="labaddressship" Text=""></asp:label>
                        </address>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <address>
                            <strong>Payment Method:</strong><br>
                            <asp:label runat="server" ID="labpaymentmathord" Text=""></asp:label><br>
                            <asp:label runat="server" ID="labecustomermail" Text=""></asp:label>
                        </address>
                    </div>
                    <div class="col-xs-6 text-right">
                        <address>
                            <strong>Order Date:</strong><br>
                            <asp:label runat="server" ID="laborderdate" Text=""></asp:label><br>
                            <br>
                        </address>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title"><strong>Order Summary</strong></h3>
                    </div>
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:ListView ID="SalesOrderItemInvoiceView" runat="server" OnItemDataBound="SalesOrderItemInvoiceView_ItemDataBound">
                                <LayoutTemplate>
                                    <table class="table table-condensed">
                                        <tr class="">
                                            <th>Product Name</th>
                                            <th>Quantity</th>
                                            <th>Unit Price</th>
                                            <th>Per Unit Total Price</th>
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="ItemRow" id="ItemRow" runat="server">
                                        <td class="ItemCol_ProductName">
                                            <%# Eval("ProductName") %>
                                        </td>
                                        <td class="ItemCol_Quantity">
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td class="ItemCol_Price">
                                            <%# Eval("Price") %>
                                        </td>
                                        <td>
                                            <%#Eval("PerUnitTotalPrice") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
