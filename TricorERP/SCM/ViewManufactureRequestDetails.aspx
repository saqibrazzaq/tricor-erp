<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ViewManufactureRequestDetails.aspx.cs" Inherits="TricorERP.SCM.ViewOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Order Details</h2>
    <div class="panel-body">
        <asp:ListView ID="OrderDetialsListview" runat="server" OnItemCommand="OrderDetailsListview_ItemCommand" OnSelectedIndexChanged="OrderDetailsListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>Order ID</th>
                        <th>Product</th>
                        <th>Total Quantity</th>
                        <th>Manufactured Quantity</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">


                    <td>
                        <%# Eval("OrderID") %>
                    </td>
                    <td>
                        <%# Eval("ProductName") %>
                    </td>
                    <td>
                        <%# Eval("TotalQuantity") %>
                    </td>
                    <td>
                        <%# Eval("ManufacturedQuantity") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>

