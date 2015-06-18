<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchConfirmedPurchaseOrder.aspx.cs" Inherits="TricorERP.SCM.SearchConfirmedPurchaseOrder" %>
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
                    <td class="ItemCol_ID">
                        <%# Eval("ID") %>
                       <!-- <asp:LinkButton runat="server" CommandName="EditPurchaseOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ID") %>'></asp:LinkButton>  -->
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
                    <button type="button" class="PurchaseOrderDelete btn btn-default btn-xs confirm">
                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                </button>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
       
     <div class="modal fade" id="SearchPurchaseOrder" tabindex="-1" role="dialog" aria-labelledby="SearchPurchaseOrderLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="SearchPurchaseOrderLabel">Delete Item</h4>
                    </div>
                   
                    <!-- some hidden values and buttons of dialog box -->
                    <div class="modal-footer">
                        <asp:TextBox CssClass="hidden txtPurchaseOrderID" runat="server" ID="txtPurchaseOrderID" Text=""></asp:TextBox>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" CssClass="hidden DeletePurchaseOrder" OnClick="deletePurchaseOrder_onClick" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
