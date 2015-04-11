﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="TricorERP.SCM.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="h2">View Product</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchProductText" CssClass="form-control" placeholder="Search Product by Code/Name" runat="server" OnTextChanged="SearchProductText_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchProduct" />
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">
        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" OnSelectedIndexChanged="ProductListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Product Code</th>
                        <th>Product Name</th>
                        <th>Threshold Value</th>
                        <th>Re Order Value</th>
                        <th>Sale Price</th>
                        <th>Purchase Price</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">

                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductID") %>'></asp:LinkButton>
                    </td>
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
</asp:Content>
