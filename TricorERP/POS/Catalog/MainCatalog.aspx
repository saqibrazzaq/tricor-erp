<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="MainCatalog.aspx.cs" Inherits="TricorERP.POS.Catalog.MainCatalog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">Main Catalog</h2>
            <div class="row">
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
                                    <td class="h4" style="width: 180px;">
                                        Product Name
                                    </td>
                                    <td class="h5" style="text-align: center">
                                        <strong><%#Eval("PName") %></strong>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">
                                        Image
                                    </td>
                                    <td style="text-align: center">
                                        <img src="<%#Eval("ImagePath") %>" width="250" height="200" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">
                                        Description
                                    </td>
                                    <td>
                                        <p style="text-align: justify;"><%#Eval("PDescription") %></p>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="h4" style="width: 180px;">
                                        Price
                                    </td>
                                    <td class="h5" style="text-align: center">
                                        Rs <%#Eval("SalePrice") %>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
