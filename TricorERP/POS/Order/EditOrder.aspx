<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="TricorERP.POS.Order.EditOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h1>Add Order</h1>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Customer :</b><asp:DropDownList ID="CustomerDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Date :</b><asp:Label ID="DateLab" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <b>Products :</b><asp:DropDownList ID="ProductsDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="AddProducts" runat="server" CssClass="btn btn-primary" OnClick="AddProducts_Click">Add</asp:LinkButton>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-8">

                <asp:ListView ID="OrderListview" runat="server" OnSelectedIndexChanged="OrderListview_SelectedIndexChanged">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                            <tr class="active">
                                <th>Product Name</th>
                                <th>Quantity</th>
                                <th>Price</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr runat="server">
                            <td>
                                 <%# Eval("ProductName") %>
                            </td>
                            <td>
                                <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <%# Eval("ProductPrice") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>

            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:LinkButton ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click">Save</asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <asp:Label ID="Message" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
