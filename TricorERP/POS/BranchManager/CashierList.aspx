<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="CashierList.aspx.cs" Inherits="TricorERP.POS.BranchManager.CashierList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Customer's List</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchCustomer" CssClass="form-control" placeholder="Search for..." runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchCustomerButton1_Click" />
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">
        <asp:ListView ID="CashierListview" runat="server" OnItemCommand="CashierListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Full Name</th>
                        <th>Phone Number</th>
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
                        <asp:LinkButton runat="server" CommandName="EditCashier" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <%# Eval("PhoneNo") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    

    <div class="row">
        <div class="col-lg-6">
          <asp:Label ID="Message" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
