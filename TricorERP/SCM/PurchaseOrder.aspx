<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="TricorERP.SCM.PurchaseOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="PurchaseOrder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="panel-heading">

            <div class="container-fluid">
                <h2 class="h2">Purchase Order</h2>
                <div class="row container-fluid">
                    <div class="col-lg-3">
                        <div class="input-group">
                            <label for="InputName">Ware House </label>
                            <asp:DropDownList ID="WareHouseDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <label for="InputName">Supplier</label>
                        <asp:DropDownList ID="SupplierDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="row container-fluid">
                    <div class="col-lg-3">
                        <label for="InputName">Order Type</label>
                        <asp:DropDownList ID="OrderTypeDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                            <asp:ListItem Value="1">Processing</asp:ListItem>
                            <asp:ListItem Value="2">Confirmed</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <div class="input-group">
                            <label for="InputName">Order Date</label>
                            <asp:TextBox ID="OrderDateText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row container-fluid">
                    <div class="col-lg-5">
                        <asp:LinkButton ID="Addbtn" runat="server" CssClass="btn btn-primary" OnClick="AddProductbtn_Click">ADD Order Products</asp:LinkButton>
                    </div>
                </div>
                <br />
                <div class="panel-body">
                    <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="productTable">
                                <tr class="active">
                                    <th>ID</th>
                                    <th>Product Code</th>
                                    <th>Quantity</th>
                                    <th>Purchase Price</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr id="Tr1" runat="server">
                                <td class="ItemCol_ItemID">
                                    <%# Eval("ID") %>
                                </td>
                                <td class="ItemCol_ProductID">
                                    <%# Eval("ProductID") %>
                                </td>
                                <td class="ItemCol_Quantity">
                                    <%# Eval("Quantity") %>
                                </td>
                                <td class="ItemCol_Price">
                                    <%# Eval("PurchasePrice") %>
                                </td>
                                <td>
                                    <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#PurchaseOrderItemEditModal">
                                        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                    </button>
                                </td>
                                <td>
                                    <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </button>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                <br />
                <div class="row container-fluid">
                    <div class="col-lg-5">
                        <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary">Cancel</asp:LinkButton>
                    </div>
                </div>
                <div class="row container-fluid">
                    <div class="col-lg-5">
                        <h4 class="h4">
                            <asp:Label ID="ErrorMessageLable" runat="server" ForeColor="#FF3300"></asp:Label>
                        </h4>
                    </div>
                </div>
            </div>
        </div>

        <!--  Dialog box   -->

        <div class="modal fade" id="PurchaseOrderItemEditModal" tabindex="-1" role="dialog" aria-labelledby="PurchaseOrderLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="PurchaseOrderLabel">Update Item</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Quantity</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
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
                    <!-- some hidden values and buttons of dialog box -->
                    <div class="modal-footer">
                        <asp:TextBox CssClass="hidden txtPurchaseOrderItemID" runat="server" ID="txtPurchaseOrderItemID" Text=""></asp:TextBox>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" OnClick="UpdatePurchaseOrderItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                        <asp:Button runat="server" CssClass="hidden DeletePurchaseOrder" OnClick="deletePurchaseOrderItem_onClick" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
