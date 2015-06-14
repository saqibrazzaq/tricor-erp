<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="MainCatalog.aspx.cs" Inherits="TricorERP.POS.Catalog.MainCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">
                <asp:Label ID="catName" runat="server" Text="Products"></asp:Label>&nbsp;Catalog</h2>
            <div class="row">
                <div class="col-lg-6">
                    <div class="input-group">
                        <asp:TextBox ID="searchProduct" CssClass="form-control" placeholder="Search Product by Name or Price" runat="server"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="Search_Click" />
                        </span>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <div class="row container-fluid">
                <div class="col-lg-12">
                    <h3 class="h3">Available Products Details</h3>
                </div>
            </div>
            <div class="panel-body">
                <div class="col-lg-10">
                    <asp:ListView ID="mainCatalogListview" runat="server">
                        <ItemTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTabled">
                                <tr>
                                    <td class="h4" style="width: 180px;">Product Name
                                    </td>
                                    <td class="h5" style="text-align: center">
                                        <strong><%#Eval("PName") %></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">Image
                                    </td>
                                    <td style="text-align: center">
                                        <img src="<%#Eval("ImagePath") %>" width="250" height="200" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">Description
                                    </td>
                                    <td>
                                        <p style="text-align: justify;"><%#Eval("PDescription") %></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">Price
                                    </td>
                                    <td class="h5" style="text-align: center">Rs <%#Eval("SalePrice") %>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <p>No Record Found</p>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

