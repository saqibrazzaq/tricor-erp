<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseReport.aspx.cs" Inherits="TricorERP.POS.Reports.PurchaseReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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
            <h2 class="h2">Sale Report</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchPurchaseOrder" CssClass="form-control" placeholder="Search by date(17-Apr-15)..." runat="server"></asp:TextBox>
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
                    <asp:Panel ID="pnlContents" runat="server">
                        <asp:ListView ID="PurchaseReportView" runat="server">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                    <tr class="active">
                                        <th>Date</th>
                                        <th>Total Quantity</th>
                                        <th>Order Status</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr id="Tr1" runat="server">
                                    <td>
                                        <%# Eval("orderdates") %>
                                    </td>
                                    <td>
                                        <%# Eval("Quantity") %>
                                    </td>
                                    <td>Approve
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </asp:Panel>
                    <div class="row">
                        <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>
                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click">Back</asp:LinkButton>&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="printPreview" runat="server" CssClass="btn btn-primary" OnClick="printPreview_Click">Print Preview</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
