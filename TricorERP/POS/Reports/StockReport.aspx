<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="StockReport.aspx.cs" Inherits="TricorERP.POS.Reports.StockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Stock Report</title>');
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
            <div class="col-lg-12">
                <div class="panel-body">
                    <asp:Panel id="pnlContents" runat = "server">
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
                        </asp:Panel>
                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click">Back</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-primary" Text="Print Report" OnClientClick="return PrintPanel();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
