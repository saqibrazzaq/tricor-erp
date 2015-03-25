<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="SearchSupplier.aspx.cs" Inherits="TricorERP.SCM.SearchSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <h2 class="h2">Search Supplier</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchSupplierText" CssClass="form-control" placeholder="Search Supplier by Name/CNIC" runat="server"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search"  OnClick="SearchWareHouse"/>
                </span>
            </div>
        </div> 
    </div>

    <div class="panel-body">

        <asp:ListView ID="SupplierListview" runat="server" OnItemCommand="SupplierListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="SupplierTable">
                    <tr class="active">
                        <th>Name</th>
                        <th>CNIC</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditSupplier" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditSupplier" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("CNIC") %>'></asp:LinkButton>
                    </td>
                
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
