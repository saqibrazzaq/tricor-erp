<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="StockList.aspx.cs" Inherits="TricorERP.POS.Stock.StockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditStock.js"></script>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>Profit Report</title>');
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">Stock Status</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchStockData" CssClass="form-control" placeholder="Search for Product Name..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="SearchStockItems" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchStockItems_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">


            <div class="panel-body">
                <asp:Panel ID="pnlContents" runat="server">
                    <div class="row">
                        <div class="col-lg-10">
                            <asp:ListView ID="OrderListview" runat="server">
                                <LayoutTemplate>
                                    <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                                        <tr class="active">
                                            <th>Stock ID</th>
                                            <th>Product Name</th>
                                            <th>Quantity</th>
                                            <th>Edit/Delete</th>
                                        </tr>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </table>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <tr class="ItemRow" runat="server">

                                        <td class="ItemCol_ItemID">
                                            <%# Eval("ID") %>
                                        </td>
                                        <td class="ItemCol_ProductName">
                                            <%# Eval("ProductName") %>
                                        </td>
                                        <td class="ItemCol_Quantity">
                                            <%# Eval("Quantity") %>
                                        </td>
                                        <td>
                                            <button type="button" class="QuantityRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#StockItemEditModal">
                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                            </button>

                                            <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                            </button>
                                            <asp:Button ID="Button1" runat="server" CssClass="hidden DeleteStockItem" OnClick="deleteStockItem_onClick" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                    </div>
                </asp:Panel>

                <br />
                <div class="row">
                    <div>
                        <div class="col-lg-6">
                            <div class="input-group">
                                <asp:Label ID="ErrorMessage" CssClass="alert-danger" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary " OnClick="Cancel_Click">Cancel</asp:LinkButton>
                            <asp:LinkButton ID="StockReport" runat="server" CssClass="btn btn-primary" OnClientClick="return PrintPanel();">Stock Report</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>


        <div class="modal fade" id="StockItemEditModal" tabindex="-1" role="dialog" aria-labelledby="StockLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="StockLabel">Update Item</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Quantity</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="hidden txtStockItemID" runat="server" ID="txtStockItemID" Text=""></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="Button2" runat="server" OnClick="SaveStockItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>

    </div>

</asp:Content>
