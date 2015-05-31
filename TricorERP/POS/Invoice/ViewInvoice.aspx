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
                    <h3 class="pull-right">Order #
                        <asp:Label runat="server" ID="laborderid" Text=""></asp:Label></h3>
                </div>
                <hr><br />
                <div class="row">
                    <div class="col-xs-6">
                        <address>
                            <strong>Billed To:</strong><br>
                            <asp:Label runat="server" ID="labcustomernamebil" Text=""></asp:Label><br>
                            <asp:Label runat="server" ID="labcnicbil" Text=""></asp:Label><br />
                            <asp:Label runat="server" ID="labaddressbil" Text=""></asp:Label>
                        </address>
                    </div>
                    <div class="col-xs-6 text-right">
                        <address>
                            <strong>Shipped To:</strong><br>
                            <asp:Label runat="server" ID="labcidship" Text=""></asp:Label><br />
                            <asp:Label runat="server" ID="labcnicship" Text=""></asp:Label><br />
                            <asp:Label runat="server" ID="labaddressship" Text=""></asp:Label>
                        </address>
                    </div>
                </div>
                <div class="row">
                    <div class="col-xs-6">
                        <address>
                          <%--  <strong>Payment Method:</strong><br>
                            <asp:Label runat="server" ID="labpaymentmathord" Text=""></asp:Label><br>
                         --%>   <asp:Label runat="server" ID="labecustomermail" Text=""></asp:Label>
                        </address>
                    </div>
                    <div class="col-xs-6 text-right">
                        <address>
                            <strong>Order Date:</strong><br>
                            <asp:Label runat="server" ID="laborderdate" Text=""></asp:Label><br>
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


                                            <td><strong>Product Name</strong></td>
                                            <td class="text-center"><strong>Quantity</strong></td>
                                            <td class="text-center"><strong>Unit Price</strong></td>
                                            <td class="text-right"><strong>Per Unit Total Price</strong></td>

                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="ItemRow" id="ItemRow" runat="server">
                                        <td>
                                            <%# Eval("ProductName") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td class="text-center">
                                            <%# Eval("Price") %>
                                        </td>
                                        <td class="text-right">
                                            <%#Eval("PerUnitTotalPrice") %>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                            <table class="table table-condensed">
                                <tr>
                                    <td class="text-center"></td>
                                    <td class="text-center"></td>
                                    <td class="text-center"></td>
                                    <td class="text-right"><strong>Total : </strong><asp:Label runat="server" ID="labtotalprice" Text=""></asp:Label></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
