<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchWareHouse.aspx.cs" Inherits="TricorERP.SCM.SearchWH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="h2">Search WareHouses</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchWareHouseText" CssClass="form-control" placeholder="Search WareHouse by Name" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchWareHouse" />
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">

        <asp:ListView ID="WareHouseListview" runat="server" OnItemCommand="WareHouseListview_ItemCommand">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="WareHouseTable">
                    <tr class="active">
                        <th>Name</th>
                        <th>Description</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Description") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="DeleteAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
