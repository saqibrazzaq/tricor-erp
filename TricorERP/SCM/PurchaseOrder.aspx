<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="TricorERP.SCM.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">
        <h1>Purchase Order</h1>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Supplier</label>
                    <asp:DropDownList ID="SupplierDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">WareHouse</label>
                    <asp:DropDownList ID="WareHouseDropDownList" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Date :</b><asp:Label ID="DateLab" runat="server" Text=""></asp:Label>
                </div>
            </div>
            </div>
            <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Quantity</label>
                 <asp:TextBox ID="ProductQuantity" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
             <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Products</label>
                    <asp:DropDownList ID="ProductDropDownList" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="AddProducts" runat="server" CssClass="btn btn-primary" OnClick="AddProducts_Click">Add</asp:LinkButton>
                </div>
            </div>
        </div>
        <br />
    <!--
        <div class="row container-fluid">
            <div class="col-lg-8">

                <asp:ListView ID="OrderListview" runat="server" OnSelectedIndexChanged="OrderListview_SelectedIndexChanged">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                            <tr class="active">
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Price</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr runat="server">
                            <td>
                                 <%# Eval("ProductName") %>
                            </td>
                            <td>
                                <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%# Eval("ProductPrice") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click">Save</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row container-fluid">
        <div class="panel-body"> 
        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>Product Code</th>
                        <th>Product Name</th>
                        <th>Purchase Price</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductCode") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductName") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductThresholdValue") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductReOderValue") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("SalesPrice") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("PurchasePrice") %>'></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
        </div>

    </div>
        -->
</asp:Content>
