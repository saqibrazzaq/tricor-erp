﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="TricorERP.POS.Order.AddOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="AddOrder.js"></script>
    <div class="panel panel-default">
            <div class="panel-heading">
                Customer:
                <asp:DropDownList ID="CustomerList" runat="server"></asp:DropDownList>
                &nbsp;&nbsp;
                Product: 
                <asp:DropDownList runat="server" ID="ProductList"></asp:DropDownList>
                <asp:Button runat="server" ID="btnAddProduct" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-default" />

                <br />
                <asp:Button ID="NewSalesOrder" CssClass="btn btn-primary" runat="server"  Text=" Create Sales Order " OnClick="NewSalesOrder_Click"  />
                <br />
                <asp:Label ID="ErroMessage" runat="server" Text=""></asp:Label>

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
                                <%# Eval("OrderID") %>
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
</asp:Content>
