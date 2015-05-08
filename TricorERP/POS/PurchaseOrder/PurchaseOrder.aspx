<%@ Page Title="Purchaser Order" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="TricorERP.POS.PurchaseOrder.PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="PurchaseOrder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="h4">
                <asp:Label ID="PurchaseOrderLable" runat="server" Text=""></asp:Label>
                :</h4>
        </div>
        <div class="panel-body">
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Waher House :</label>
                    <div class="input-group">
                        <asp:DropDownList ID="WaherHouseDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Date :</label>
                    <div class="input-group">
                        <asp:TextBox ID="DateTextBoox" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-3">
                    <h4 class="h4">
                        <asp:label id="ItemMessageLab" runat="server" for="InputName"></asp:label>
                    </h4>
                    <asp:LinkButton ID="btnAddNewItem" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewItem_Click">Add New Item</asp:LinkButton>
                </div> 
            </div>
            
            <div class="row container-fluid">
                <div class="col-lg-9">
                    <h5 class="h5">
                    </h5>
                    <div class="panel-body">
                        <asp:ListView ID="PurchaseOrderItemview" OnItemCommand="PurchaseOrderItemview_ItemCommand" runat="server">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                    <tr class="active">
                                        <th class="hidden PurchaseOrderItemID">ID</th>
                                        <th>Product Name</th>
                                        <th>Quantity</th>
                                        <th>Edit/Delete</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr id="Tr1" runat="server">
                                    <td class="hidden PurchaseOrderItemID">
                                        <%# Eval("ID") %>
                                    </td>
                                    <td class="ItemCol_ProductName">
                                        <%# Eval("ProductName") %>
                                    </td>
                                    <td class="ItemCol_Quantity">
                                        <%# Eval("Quantity") %>
                                    </td>
                                    <td>
                                        <button type="button" class="QuantityRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#PurchaseItemEditModal">
                                            <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                        </button>

                                        <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                        </button>
                                        <asp:Button ID="deletePurchaseItem" runat="server" CssClass="hidden deletePurchaseItem" CommandName="DeleteAddress" OnClick="deletePurchaseItem_Click" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>

                        <asp:TextBox CssClass="hidden txtPurchaseItemID" runat="server" ID="txtPurchaseItemID" Text=""></asp:TextBox>

                    </div>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:LinkButton ID="SavePurchaseOrderbtn" runat="server" CssClass="btn btn-primary" OnClick="SavePurchaseOrderbtn_Click" Text="">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="False">Cancel</asp:LinkButton>
                </div>
            </div>
            <br />
            <br />
        </div>

    </div>
    <div class="modal fade" id="PurchaseItemEditModal" tabindex="-1" role="dialog" aria-labelledby="StockLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="StockLabel">Update Item</h4>
                </div>
                <div class="modal-body">
                    <div class="row form-group">
                        <div class="col-lg-2">
                            <label class="">Quantity</label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
                            <%--<asp:TextBox CssClass="hidden txtStockItemID" runat="server" ID="txtStockItemID" Text=""></asp:TextBox>--%>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="SavePurchaseOrder" runat="server" OnClick="SavePurchaseOrder_Click" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
