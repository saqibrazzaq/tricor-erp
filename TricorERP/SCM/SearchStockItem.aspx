<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchStockItem.aspx.cs" Inherits="TricorERP.SCM.SearchStockItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h2 class="h2">View Stock Items</h2>
    <div class="row">
        
            <div class="col-lg-3">
                <label for="InputName">WareHouse</label>
               <asp:DropDownList ID="WareHouseDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
        <div class="col-lg-6">
            <br>
            <div class="input-group">
                <asp:TextBox ID="SearchStockItemText" CssClass="form-control" placeholder="Search Stock item by Name/Code/Price" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search"  OnClick="SearchWareHouse"/>
                </span>
            </div>
        </div> 
    </div>

      <div class="panel-body">

        <asp:ListView ID="StockProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Product Code</th>
                        <th>Product Quantity</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditStockItem" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditStockItem" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ProductID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditStockItem" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Quantity") %>'></asp:LinkButton>
                    </td>
                     <td>
                      <asp:LinkButton runat="server" CommandName="EditStockItem" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                    </td>
                    <td>
                    <asp:LinkButton runat="server" CommandName="DeleteStockItem" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
