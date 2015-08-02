<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReportPrintPreview.aspx.cs" Inherits="TricorERP.POS.PrintPreviews.StockReportPrintPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>Print Stock Report</title>

    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Sales Report</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body>
    <asp:Panel ID="pnlContents" runat="server">
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
        <link href="../../Content/font-awesome.min.css" rel="stylesheet" />
        <script src="../../Scripts/jquery-1.10.2.min.js"></script>
        <link href="../../Content/bootstrap.min.css" rel="stylesheet" />

        <div class="container">
            <br />
            <div class="row">
                <div class="invoice-title">
                    <div class="text-center">
                        <img src="../../Images/Tricorlogo.ico" width="70" height="70" />&nbsp;&nbsp;<div style="font: bold 28px calibri;">Tricor (Pvt.) Ltd Pakistan</div>
                    </div>
                    <p class="text-center">
                        Website: www.tricor.com.pk<br />
                        Email: info@tricor.com.pk<br />
                        Hummak Industrial Estate<br />
                        Islamabad, Pakistan<br />
                        UAN: 051-555-5678<br />
                    </p>
                </div>
                <br />
                <div class="panel-heading">
                    <h3 class="panel-title"><strong>Stock Report Details</strong>&nbsp;<asp:Label ID="CurrentDatVariable" runat="server" Text="Label"></asp:Label></h3>
                </div>
                <hr />
                <br />
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
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
    </asp:Panel>
    <form id="form1" runat="server">
        <div class="text-center">
            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print Report" OnClientClick="return PrintPanel();" />
        </div>
    </form>
</body>
</html>
