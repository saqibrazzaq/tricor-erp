<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchStockItem.aspx.cs" Inherits="TricorERP.SCM.SearchStockItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="../Scripts/jquery.confirm.min.js"></script>
    <script src="SearchStockItem.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="panel-heading">
        <h2 class="h2">View Stock Items</h2>
        <div class="row">
            <div class="col-lg-3">
                <label for="InputName">WareHouse</label>
                <asp:DropDownList ID="WareHouseDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            <div class="col-lg-6">
                <br />
                <div class="input-group">
                    <asp:TextBox ID="SearchStockItemText" CssClass="form-control" placeholder="Search Stock item by Name/Code/Price" runat="server"></asp:TextBox>
                    <span class="input-group-btn">
                        <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchWareHouse" />
                    </span>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <asp:ListView ID="StockProductListview" runat="server" OnItemCommand="StockProductListview_ItemCommand"  OnItemDataBound="StockProductListview_ItemDataBound">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" runat="server" id="HeadingTable">
                        <tr class="active">
                            <th>ID</th>
                            <th>Product Code</th>
                            <th>Product Quantity</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr id="Tr1" class="Tr1" runat="server">

                        <td class="ItemCol_ItemID">
                            <%# Eval("ID") %>
                        </td>
                        <td class="ItemCol_ProductID">
                            <%# Eval("ProductID") %>

                        </td>
                        <td class="ItemCol_Quantity">
                            <%# Eval("Quantity") %>
                        </td>
                    <td id="ReOrderCol">
                        <asp:LinkButton runat="server" CommandName="ReOrder" CommandArgument='<%# Eval("ProductID") %>' Text= "ReOrder"></asp:LinkButton>
                    </td>
                        <td id="EditCol">
                            <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#StockItemEditModal">
                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                            </button>
                        </td>
                        <td id="DeleteCol">
                            <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                            </button>
                            <asp:Button runat="server" CssClass="hidden DeleteStockItem" OnClick="deleteStockItem_onClick" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </div>

    <div class="modal fade" id="StockItemEditModal" tabindex="-1" role="dialog" aria-labelledby="StockItemLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="StockItemLabel">Update Item</h4>
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
                    <asp:TextBox CssClass="hidden txtStockItemID" runat="server" ID="txtStockItemID" Text=""></asp:TextBox>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                    <asp:Button runat="server" OnClick="UpdateStockItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    <asp:TextBox CssClass="hidden txtStockQuantity" runat="server" ID="txtStockQuantity" Text=""></asp:TextBox>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
