<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ProductComposition.aspx.cs" Inherits="TricorERP.SCM.ProductComposition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="ProductComposition.js"></script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">

        <h2 class="h2">Product Composition</h2>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Product</label>
                    <asp:TextBox ID="PNameText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <br />
                <div class="input-group">
                    <label for="InputName">RawMaterial</label>
                    <asp:DropDownList ID="ProductDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Quantity</label>
                <asp:TextBox ID="QuantityText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4" />
                <asp:LinkButton ID="btnAddNewItem" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewItem_Click">Add New Item</asp:LinkButton>
            </div>
        </div>
        <div class="row">
        </div>

        <div class="row container-fluid">
            <div class="col-lg-9">
                <h2 class="h2">Product is Composed of:</h2>
                <div class="panel-body">
                    <asp:ListView ID="RawMaterialListview" OnItemCommand="RawMaterialListview_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>ID</th>
                                    <th>RawMaterial ID</th>
                                    <th>Quantity</th>
                                    <th>Edit</th>
                                    <th>Delete</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr runat="server">
                                <td class="ItemCol_ItemID">
                                    <%# Eval("ID") %>
                                </td>
                                <td>
                                    <%# Eval("RawMaterialID") %>
                                </td>
                                <td>
                                    <%# Eval("Quantity") %>
                                </td>
                                <td>
                                    <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#WareHouseModal">
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
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-5">
                <%--<asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>--%>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <h4 class="h4">
                    <asp:Label ID="message" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
    </div>

    <div class="modal fade" id="ProductCompositionItemEditModal" tabindex="-1" role="dialog" aria-labelledby="ProductCompositionLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ProductCompositionLabel">Update Item</h4>
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
                        </div>
                    <!-- some hidden values and buttons of dialog box -->
                    <div class="modal-footer">
                        <asp:TextBox CssClass="hidden txtProductCompositionItemID" runat="server" ID="txtProductCompositionItemID" Text=""></asp:TextBox>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" OnClick="UpdateProductCompositionItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                        <asp:Button runat="server" CssClass="hidden DeleteProductCompositionItem" OnClick="deleteProductCompositionItem_onClick" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>

