<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddOrder.aspx.cs" Inherits="TricorERP.POS.Order.AddOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AddOrder.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="panel panel-default">
        <div class="panel-heading">
            <%--<div class="row container-fluid">
                <div class="col-lg-4">
                    <div class="input-group">
                        <asp:TextBox ID="txtSearchCNIC" CssClass="form-control" placeholder="12345-1234-123-1" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="btnSearchCustomer" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchByCNIC_Click" />
                        </span>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSearchCNIC" ErrorMessage="Enter CNIC Number" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-12">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="CNIC is not correct" ControlToValidate="txtSearchCNIC" ForeColor="Red" ValidationExpression="^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-4">
                    <asp:TextBox ID="check" ReadOnly="true" runat="server"></asp:TextBox>
                </div>
            </div>
            --%>
            <br />

            <div class="row container-fluid">
                <div class="col-lg-2">
                    <label for="InputName">Customer :</label>
                    <asp:DropDownList CssClass="form-control" ID="CustomerList" runat="server"></asp:DropDownList>
                </div>
                <div class="col-lg-2">
                    <label for="InputName">Product:</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ProductList"></asp:DropDownList>
                </div>
                <div class="col-lg-8">
                    <ul id="OrderStatus" class="nav navbar-nav navbar-right">
                        <li>
                            <div class="input-group">
                                <label for="InputName">Order-Status :</label>
                                <asp:DropDownList ID="OrderStatusList" CssClass="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </li>
                    </ul>
                </div>

            </div>
            <br />
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Button ID="NewSalesOrder" CssClass="btn btn-primary" runat="server" Text=" Create Sales Order " OnClick="NewSalesOrder_Click" />
                </div>
                <div class="col-lg-2">
                    <asp:Button runat="server" ID="btnAddProduct" Text="Add Product" OnClick="btnAddProduct_Click" CssClass="btn btn-default" CausesValidation="False" />
                </div>
                <div class="col-lg-2">
                    <asp:Button runat="server" ID="btnAddInvoice" Text="Add Payment" OnClick="btnAddInvoice_Click" CssClass="btn btn-default" CausesValidation="False" />
                </div>
                <div class="col-lg-2">
                    <asp:Button runat="server" ID="btnviewInvoice" Text="View Invoice" OnClick="btnviewInvoice_Click" CssClass="btn btn-default" CausesValidation="False" />
                </div>
            </div>
        </div>

        <div class="panel-body">
            <asp:ListView ID="SalesOrderItemListview" runat="server" OnItemDataBound="SalesOrderItemListview_ItemDataBound">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <tr class="active">
                            <th class="hidden">ID</th>
                            <th class="hidden">Sales Order ID</th>
                            <th class="hidden">WareHouseID</th>
                            <th class="hidden">ProductID</th>
                            <th></th>
                            <th>Product Name</th>
                            <th>Product Description</th>
                            <%--<th>WareHouseName</th>--%>
                            <th>Quantity</th>
                            <th>Unit Price</th>
                            <th>Per Unit Total Price</th>
                            <th>Picture</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="ItemRow" id="ItemRow" runat="server">
                        <td class="hidden ItemCol_ItemID">
                            <%# Eval("ID") %>
                        </td>

                        <td class="hidden prodid">
                            <%#Eval("ProductID") %>
                        </td>

                        <td class="hidden">
                            <%# Eval("OrderID") %>
                        </td>
                        <td class="hidden">
                            <%#Eval("WareHouseID") %>
                        </td>


                         <td class="col-md-1">
                            <div runat="server" id="ItemCommandtd">
                                <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#SalesOrderItemEditModal">
                                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                </button>

                                <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                </button>
                                <asp:Button runat="server" ID="DeleteItem" CssClass="hidden DeleteSalesOrder" OnClick="deleteSalesOrderItem_onClick" />
                            </div>
                        </td>


                        <td class="col-md-1 ItemCol_ProductName">
                            <%# Eval("ProductName") %>
                        </td>
                        <td class="col-md-2">
                            <%# Eval("ProductDescription") %>
                        </td>
                        <td class="col-md-1 ItemCol_Quantity">
                            <%# Eval("Quantity") %>
                        </td>
                        <td class="col-md-1 ItemCol_Price">
                            <%# Eval("Price") %>
                        </td>
                        <td class="col-md-1">
                            <%#Eval("PerUnitTotalPrice") %>
                        </td>
                       
                        <td class="col-lg-1">
                             <img src="<%#Eval("ImagePath") %>" width="100" height="100" />
                            
                        </td>

                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <table class="table">
                <tr>
                    <td>
                        <b>
                            <asp:Label ID="Label1" runat="server" Text="Total Price Is : "></asp:Label></b>
                        <asp:Label ID="TotalPrice" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:Label ID="ErroMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <ul id="OrderApproved" class="nav navbar-nav">
                    <li>
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" CausesValidation="False" />
                    </li>
                </ul>
            </div>
            <br />
            <br />
            <br />
        </div>


        <!-- Modal -->
        <div class="modal fade" id="SalesOrderItemEditModal" tabindex="-1" role="dialog" aria-labelledby="SalesOrderLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="SalesOrderLabel">Update Item</h4>
                    </div>
                    <div class="modal-body">
                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Quantity :</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtQuantity" runat="server" ID="txtQuantity" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="hidden txtSalesOrderItemID" runat="server" ID="txtSalesOrderItemID" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="hidden txtProductName" runat="server" ID="txtProductName" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="hidden txtSalesProductID" runat="server" ID="txtSalesProductID" Text=""></asp:TextBox>

                            </div>
                            <div class="hidden col-lg-3">
                                <label class="InputName">WaherHouse :</label>
                            </div>
                            <div class="input-group col-lg-3">

                                <asp:DropDownList CssClass="form-control" ID="WaherHouseDropDownList" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row form-group">
                            <div class="col-lg-2">
                                <label class="">Price :</label>
                            </div>
                            <div class="col-lg-3">
                                <asp:TextBox CssClass="form-control txtPrice" runat="server" ID="txtPrice" Text=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" ID="SaveSaleOrder" OnClick="SaveSalesOrderItem_onClick" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</asp:Content>
