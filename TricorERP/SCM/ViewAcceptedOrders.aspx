<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ViewAcceptedOrders.aspx.cs" Inherits="TricorERP.SCM.ViewAcceptedOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h2 class="h2">Accepted Orders</h2>
    
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchOrdersText" CssClass="form-control" placeholder="Search Orders by ID" runat="server" OnTextChanged="SearchOrdersText_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="SearchOrders" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchOrder" />
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">
        <asp:ListView ID="OrderListview" runat="server" OnItemCommand="OrderListview_ItemCommand" OnSelectedIndexChanged="OrderListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Custome</th>
                        <th>Order Date</th>
                        <th>Delivery Date</th>
                        <th>Order Status</th>
                        <th>Action</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">

                    <td>
                        <%# Eval("ID") %>
                    </td>
                    <td>
                        <%# Eval("CustomerName") %>
                    </td>
                    <td>
                        <%# Eval("OrderDate") %>
                    </td>
                    <td>
                        <%# Eval("DeliveryDate") %>
                    </td>
                    <td>
                        <%# Eval("OrderStatusName") %>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="viewdetails" CommandArgument='<%# Eval("ID") %>' Text="View Details">  </asp:LinkButton>
                    </td>   
                </tr>
            </ItemTemplate>
        </asp:ListView>
        </div>
</asp:Content>
