<%@ Page Title="Purchaser Order List" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchPurchaseOrder.aspx.cs" Inherits="TricorERP.POS.PurchaseOrder.SearchPurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="PurchaseOrder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">Purchase Order List</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchPurchaseOrderFromDB" CssClass="form-control" placeholder="Search by Product By WareHouse Name..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchPurchaseOrderButton1_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="panel-body">
                <div class="col-lg-10">
                    <asp:ListView ID="PurchaseOrderListview" runat="server" OnItemCommand="PurchaseOrderListview_ItemCommand">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="PurchaseOrderTable">
                                <tr class="active">
                                    <th class="hidden PurchaseOrderItemID">ID</th>
                                    <th>OrderDate</th>
                                    <th>Warehouse Name</th>
                                    <th>Order Status</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="Tr1" runat="server">
                                <td class="hidden PurchaseOrderItemID">
                                    <%# Eval("ID") %>
                                </td>
                                <td>
                                    <%# Eval("OrderDate") %>
                                </td>
                                <td>
                                    <%# Eval("WHName") %>
                                </td>
                                <td>
                                    <%# Eval("OrderStatus") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </button>
                                    <asp:Button ID="deletePurchaseItem" runat="server" CssClass="hidden deletePurchaseItem" CommandName="" OnClick="deletePurchaseOrder_Click" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <asp:TextBox CssClass="hidden txtPurchaseItemID" runat="server" ID="txtPurchaseItemID" Text=""></asp:TextBox>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <asp:Label ID="Message" ForeColor="Red" runat="server" Text=""></asp:Label>
                    </div>
                </div>

                <div class="row">

                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary " OnClick="btnBack_Click">Back</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
