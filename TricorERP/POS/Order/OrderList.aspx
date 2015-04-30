<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TricorERP.POS.Order.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">Order's List</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="SearchOrderData" CssClass="form-control" placeholder="Search for..." runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchOrderDataButton1_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="page-header">
            <div class="panel-body">
                <div class="row">
                    <div class="col-lg-12">
                        <asp:ListView ID="OrderListview" runat="server" OnItemCommand="OrderListview_ItemCommand">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                                    <tr class="active">
                                        <th class="hidden">ID</th>
                                        <th class="hidden">Customer ID</th>
                                        <th>Customer Name</th>
                                        <th>Order Date</th>
                                        <th>Delivery Date</th>
                                        <th>Order Status</th>
                                        <th>Edit</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr runat="server">

                                    <td class="hidden">
                                        <%# Eval("ID") %>
                                    </td>
                                    <td class="hidden">
                                        <%# Eval("CustomerID") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" CommandName="EditSaleOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("CustomerName") %>'></asp:LinkButton>
                                    </td>
                                    <td>
                                        <%# Eval("OrderDate") %>
                                    </td>
                                    <td>
                                        <%# Eval("DeliveryDate") %>
                                    </td>
                                    <td>
                                        <%# Eval("OrderStatusName") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-default btn-xs" CommandName="EditSaleOrder" CommandArgument='<%# Eval("ID") %>' Text=''>
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-default btn-xs" Text="View" CommandName="EditSaleOrder" CommandArgument='<%# Eval("ID") %>' />
                                            
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6">
                        <div class="input-group">
                            <asp:Label ID="ErrorMessage" CssClass="alert-danger" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="row">

                    <div class="row container-fluid">
                        <div class="col-lg-4">
                            <asp:LinkButton ID="Cancel" runat="server" CssClass="btn btn-primary " OnClick="Cancel_Click">Cancel</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>

    </div>
</asp:Content>
