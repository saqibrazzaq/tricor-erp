<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchWareHouse.aspx.cs" Inherits="TricorERP.SCM.SearchWH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <h2 class="h2">View Product</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchWareHouseText" CssClass="form-control" placeholder="Search WareHouse by Name/City/PhoneNumber/Email" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search"  OnClick="SearchWareHouse"/>
                </span>
            </div>
        </div> 
    </div>

    <div class="panel-body">

        <asp:ListView ID="WareHouseListview" runat="server" OnItemCommand="WareHouseListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="WareHouseTable">
                    <tr class="active">
                        <th>Name</th>
                        <th>City</th>
                        <th>PhoneNumber</th>
                        <th>Email</th>
                        <th>Location1</th>
                        <th>Location2</th>
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
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("City") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("PhoneNumber") %>'></asp:LinkButton>
                    </td>
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Email") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location1") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditWareHouse" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location2") %>'></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
