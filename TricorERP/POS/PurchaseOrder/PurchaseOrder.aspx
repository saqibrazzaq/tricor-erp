﻿<%@ Page Title="Purchaser Order" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="TricorERP.POS.PurchaseOrder.PurchaseOrder" %>

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
                <div class="hidden col-lg-3">
                    <label for="InputName">Waher House :</label>
                    <div class="input-group">
                        <asp:DropDownList ID="WaherHouseDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">Order Date :</label>
                    <div class="input-group">
                        <asp:TextBox ID="DateTextBoox" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">Expected Delivery Date:</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtExpectedDeliveryDate" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">Current Order Status:</label>
                    <div class="input-group">
                        <asp:TextBox ID="txtOrderStatus" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">*</label>
                    <div class="input-group">
                        <asp:Button ID="btnManufacture" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Manufacture" OnClick="aproveBTN_Click" />
                    </div>
                </div>
            </div>

            <%-- used for checking what is the status of my order --%>
            <div class="hidden row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Order Status :</label>
                    <div class="input-group">
                        <asp:DropDownList ID="dropdownorderstatus" CssClass="form-control" runat="server"></asp:DropDownList>
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
                <div class="col-lg-5">
                    <h4 class="h4">
                        <asp:label id="ItemMessageLab" runat="server" for="InputName"></asp:label>
                    </h4>
                    <asp:LinkButton ID="btnAddNewItem" runat="server" CssClass="btn btn-info" OnClick="btnAddNewItem_Click" CausesValidation="false">Add New Item</asp:LinkButton>
                </div> 
            </div>
            
            <div class="row container-fluid">
                <div class="col-lg-9">
                    <h5 class="h5">
                    </h5>
                    <div class="panel-body">
                        <asp:ListView ID="PurchaseOrderItemview" runat="server" OnItemDataBound="PurchaseOrderItemview_ItemDataBound">
                            <LayoutTemplate>
                                <table class="table table-bordered table-hover" runat="server" id="PurchaseOrderItemTable">
                                    <tr class="active">
                                        <th class="hidden PurchaseOrderItemID">ID</th>
                                        <th>Product Name</th>
                                        <th>Quantity</th>
                                        <th id="editdelete"></th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr class="ItemRow" id="ItemRow" runat="server">
                                    <td class="hidden PurchaseOrderItemID">
                                        <%# Eval("ID") %>
                                    </td>
                                    <td class="ItemCol_ProductName">
                                        <%# Eval("ProductName") %>
                                    </td>
                                    <td class="ItemCol_Quantity">
                                        <%# Eval("Quantity") %>
                                    </td>
                                    <td id="ItemCommandtd">
                                        <div runat="server" >
                                            <button type="button" class="QuantityRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#PurchaseItemEditModal">
                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                            </button>

                                            <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                            </button>
                                            <asp:Button ID="deletePurchaseItem" runat="server" CssClass="hidden deletePurchaseItem" CausesValidation="false" CommandName="DeleteAddress" OnClick="deletePurchaseItem_Click" />
                                        </div>
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
                    <asp:LinkButton ID="SavePurchaseOrderbtn" runat="server" CssClass="btn btn-info" OnClick="SavePurchaseOrderbtn_Click" Text="" CausesValidation="false">Save</asp:LinkButton>
                    <asp:LinkButton ID="Deliveredbtn" runat="server" CssClass="btn btn-success" OnClick="Deliveredbtn_Click" Text="" CausesValidation="false">Delivered</asp:LinkButton>
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-warning" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>
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
                    <h4 class="modal-title" id="PurchaseOrderItemLabel">Update Item</h4>
                </div>
                <div class="modal-body">
                    <div class="row form-group">
                        <div class="col-lg-2">
                            <label class="">
                                Quantity <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ControlToValidate="txtQuantity" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </label>
                        </div>
                        <div class="col-lg-3">
                            <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
                            <%--<asp:TextBox CssClass="hidden txtStockItemID" runat="server" ID="txtStockItemID" Text=""></asp:TextBox>--%>
                        </div>
                        <div class="col-lg-6">
                            <asp:RegularExpressionValidator  ForeColor="Red" ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtQuantity" ValidationExpression="^[0-9]*$" ErrorMessage="Only integers values are allowed"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button ID="SavePurchaseOrder" runat="server" OnClick="SavePurchaseOrder_Click" type="button" CausesValidation="false" class="btn btn-primary" Text="Save changes"></asp:Button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
