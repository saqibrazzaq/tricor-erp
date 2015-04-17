<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="TricorERP.POS.Order.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AddOrder.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="panel panel-default">
        <div class="panel-heading">

            <div class="row container-fluid">
                <label for="InputName">Customer :</label>
                <asp:DropDownList CssClass="" ID="CustomerList" runat="server"></asp:DropDownList>
                <label for="InputName">Product:</label>
                <asp:DropDownList runat="server" ID="ProductList"></asp:DropDownList>
                <asp:Button runat="server" ID="btnAddProduct" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-default" />

                <ul id="OrderStatus" class="nav navbar-nav navbar-right">
                    <li>
                        <label for="InputName">Order-Status :</label>
                        <asp:DropDownList ID="OrderStatusList" runat="server"></asp:DropDownList>
                    </li>
                </ul>
            </div>
        
        <asp:Button ID="NewSalesOrder" CssClass="btn btn-primary" runat="server" Text=" Create Sales Order " OnClick="NewSalesOrder_Click" />
        </div>
        
        <div class="panel-body">
            <asp:ListView ID="SalesOrderItemListview" runat="server" OnItemDataBound="SalesOrderItemListview_ItemDataBound">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <tr class="active">
                            <th>ID</th>
                            <th>Sales Order ID</th>
                            <th>WareHouseID</th>
                            <th>Product Name</th>
                            <%--<th>WareHouseName</th>--%>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="ItemRow" id="ItemRow" runat="server">
                        <td class="ItemCol_ItemID">
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("OrderID") %>
                        </td>
                        <td>
                            <%#Eval("WareHouseID") %>
                        </td>

                        <%-- <td>
                                <%#Eval("WareHouseName") %>
                            </td>--%>

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
                            <asp:Button runat="server" ID="DeleteItem" CssClass="hidden DeleteSalesOrder" OnClick="deleteSalesOrderItem_onClick" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <table class="table">
                <tr>
                    <td>
                        <b><asp:Label ID="Label1" runat="server" Text="Total Price Is : "></asp:Label></b>
                        <asp:Label ID="TotalPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="ErroMessage"  runat="server" ForeColor="Red"></asp:Label>
        </div>


        <div class="row container-fluid">
            <div class="col-lg-5">
                <ul id="OrderApproved" class="nav navbar-nav">
                    
                    <li>
                        <asp:Button ID="Cancel" runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="Cancel_Click" />
                    </li>
                </ul>
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
                                <asp:TextBox CssClass="hidden txtProductName" runat="server" ID="txtProductName" Text=""></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <label class="">WaherHouse</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:DropDownList ID="WaherHouseDropDownList" runat="server">
                                </asp:DropDownList>
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
                        <asp:Button runat="server" ID="SaveSaleOrder" OnClick="SaveSalesOrderItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
