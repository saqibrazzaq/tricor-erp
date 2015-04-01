<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TricorERP.POS.Order.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

    <div class="panel-body">
        <asp:ListView ID="OrderListview" runat="server" OnItemCommand="OrderListview_ItemCommand">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Customer ID</th>
                        <th>Full Name</th>
                        <th>Order Date</th>
                        <th>Delivery Date</th>
                        <th>Edit</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td>
                        <%# Eval("ID") %>
                    </td>
                    <td>
                        <%# Eval("CustomerID") %>
                    </td>
                    <td>
                        <%# Eval("CName") %>
                    </td>
                    <td>
                        <%# Eval("OrderDate") %>
                    </td>
                    <td>
                        <%# Eval("DeliveryDate") %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditSaleOrder" CommandArgument='<%# Eval("ID")%>' >
                            <span class="glyphicon glyphicon-edit">
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <div>
        <div class="col-lg-6">
            <div class="input-group">
                <asp:Label ID="ErrorMessage" CssClass="alert-danger" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
