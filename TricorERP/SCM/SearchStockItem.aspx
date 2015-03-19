<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchStockItem.aspx.cs" Inherits="TricorERP.SCM.SearchStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
 <h2 class="h2">View Product</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchProductText" CssClass="form-control" placeholder="Search Product by Code/Name" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search"  OnClick="SearchProduct"/>
                </span>
            </div>
        </div> 
    </div>

    <div class="panel-body">

        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Product Code</th>
                        <th>Product Name</th>
                        <th>Product Price</th>
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
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductPrice") %>'></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
