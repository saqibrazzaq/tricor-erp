<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="QueuedOrderDetails.aspx.cs" Inherits="TricorERP.SCM.QueuedOrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Queued Order Details</h2>
    <div class="panel-body">
        <asp:ListView ID="OrderDetialsListview" runat="server" OnItemCommand="OrderDetailsListview_ItemCommand" OnSelectedIndexChanged="OrderDetailsListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>Order ID</th>
                        <th>Product ID</th>
                        <th>TotalQuantity</th>
                        <th>Manufactured Quantity</th>
                        <th>Price</th>
                        <th>Status</th>
                        <th></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">

                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("OrderID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ProductID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("TotalQuantity") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ManufacturedQuantity") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Price") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ProductStatus") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" BorderStyle="Solid" BorderColor="silver" BackColor="WhiteSmoke" CommandName ="one-more-completion" CommandArgument='<%# Eval("ID") %>' Text="1 Item Done" />
                    </td>                    
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
