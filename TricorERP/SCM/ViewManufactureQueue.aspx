<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ViewManufactureQueue.aspx.cs" Inherits="TricorERP.SCM.ViewManufactureQueue" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Manufacture Queue</h2>
    <div class="panel-body">
        <asp:ListView ID="MQListview" runat="server" OnItemCommand="MQListview_ItemCommand" OnSelectedIndexChanged="MQListview_SelectedIndexChanged">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="OrderTable">
                    <tr class="active">
                        <th>Order ID</th>
                        <th>Customer</th>
                        <th>Delivery Date</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">

                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("CustomerName") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="none" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("DeliveryDate") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="viewdetails" CommandArgument='<%# Eval("ID") %>' Text="View Details">  </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
