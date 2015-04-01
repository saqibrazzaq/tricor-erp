<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TricorERP.Samples.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test page</title>
    <!-- Project stylesheets and JavaScript -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

    <script src="../Scripts/jquery-2.1.3.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/jquery.confirm.min.js"></script>

    <!-- Module stylesheets and JavaScript -->
    <link href="Samples.css" rel="stylesheet" />
    <script src="Samples.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1>Testing jQuery and Bootstrap</h1>
        </div>

        <div class="container">
            <label>Testing Working of jQuery and Bootstrap</label>
            <asp:Button ID="btnShowJumbotron" CssClass="btn btn-primary btnShowJumbotron" runat="server" Text="Show Jumbotron" OnClick="btnShowJumbotron_Click" />
            <asp:Button ID="btnHideJumbotron" CssClass="btn btn-info btnHideJumbotron" runat="server" Text="Hide Jumbotron" OnClick="btnHideJumbotron_Click" />
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                Customer:
                <asp:DropDownList runat="server" ID="CustomerList"></asp:DropDownList>
                &nbsp;&nbsp;
                Product: 
                <asp:DropDownList runat="server" ID="ProductList"></asp:DropDownList>
                <asp:Button runat="server" ID="btnAddProduct" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-default" />

                <br />
                <asp:Button ID="btnSaveSalesOrder" CssClass="btn btn-primary" runat="server" OnClick="Unnamed1_Click" Text=" Create Sales Order " />
            </div>
            <div class="panel-body">
                <asp:ListView ID="SalesOrderItemListview" runat="server" OnItemCommand="SalesOrderItemListview_ItemCommand">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover">
                            <tr>
                                <th>ID</th>
                                <th>Sales Order ID</th>
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Price</th>
                                <th></th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr class="ItemRow" runat="server" >
                            <td class="ItemCol_ItemID">
                                <%# Eval("ID") %>
                            </td>
                            <td>
                                <%# Eval("SalesOrderID") %>
                            </td>
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
                                <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#SalesOrderItemEditModal">
                                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                </button>
                                <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                </button>
                                <asp:Button runat="server" CssClass="hidden DeleteSalesOrder" OnClick="deleteSalesOrderItem_onClick" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal fade" id="SalesOrderItemEditModal" tabindex="-1" role="dialog" aria-labelledby="SalesOrderLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="SalesOrderLabel">Update Item</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Quantity</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="hidden txtSalesOrderItemID" runat="server" ID="txtSalesOrderItemID" Text=""></asp:TextBox>
                            </div>
                        </div>



                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Price</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtPrice" runat="server" ID="txtPrice" Text=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" onclick="SaveSalesOrderItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
