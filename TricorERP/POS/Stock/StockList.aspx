<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="StockList.aspx.cs" Inherits="TricorERP.POS.Stock.StockList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Stock List</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchOrderData" CssClass="form-control" placeholder="Search for..." runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="SearchStockItems" CssClass="btn btn-default" runat="server" Text="Search"/>
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">
        <asp:ListView ID="OrderListview" runat="server" OnItemCommand="StockListview_ItemCommand">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>ID</th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">

                    <td>
                        <%# Eval("ID") %>
                    </td>
                    <td>
                        <%# Eval("CustomerID") %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditSaleOrder" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("CName") %>'></asp:LinkButton>
                    </td>

                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <br />
    <div>
        <div class="col-lg-6">
            <div class="input-group">
                <asp:Label ID="ErrorMessage" CssClass="alert-danger" runat="server"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
