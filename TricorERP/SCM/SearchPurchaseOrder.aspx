<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchPurchaseOrder.aspx.cs" Inherits="TricorERP.SCM.SearchPurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <h2 class="h2">Search Purchase Order</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchPurchaseOrderText" CssClass="form-control" placeholder="Search Order by ID/WHID/SupplierID" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search"  OnClick="SearchPurchaseOrders"/>
                </span>
            </div>
        </div> 
    </div>

    <div class="panel-body"> 
        <asp:ListView ID="PurchaseOrderListview" runat="server" OnItemCommand="PurchaseOrderListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="PurchaseOrderTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>WareHouse ID</th>
                        <th>Supplier ID</th>
                        <th>Order Type</th>
                        <th>Order Date</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("WHID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("SID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("OrderType") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("OrderDate") %>'></asp:LinkButton>
                    </td>
                    <td>
                      <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                    </td>
                    <td>
                    <asp:LinkButton runat="server" CommandName="DeletePurchaseOrder" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
