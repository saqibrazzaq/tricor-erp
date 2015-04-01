<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditOrder.aspx.cs" Inherits="TricorERP.POS.Order.EditOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="h3">Customer Order</h3>
    <div class="row container-fluid">
        <div class="col-lg-4">
            <label for="InputName">Customer :</label>
            <div class="input-group">
                <asp:DropDownList ID="CustomerDropDown" Font-Names="InputName" CssClass="form-control" runat="server" AutoPostBack="True">
                    <asp:ListItem>Select Customer</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-4">
            <label for="InputName">Current Date :</label>
            <div class="input-group">
                
                
                <asp:TextBox ID="DateText" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server" ></asp:TextBox>
                
            </div>
        </div>
    </div>
    <br />
    <div class="row container-fluid">

        <div class="col-lg-4">
            <label for="InputName">Delivery Date:</label>
            <div class="input-group">
                <asp:TextBox ID="DeliveryDateText" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Delivery Date"></asp:TextBox>
            </div>
        </div>
    </div>

    <br />
    <div class="row container-fluid">
        <div class="col-lg-4">
            <label for="InputName">Item List...</label>
            <div class="input-group">
                <asp:LinkButton ID="AddProductsButten" runat="server" CssClass="btn btn-primary" OnClick="AddProductsButten_Click">Add Item</asp:LinkButton>
            </div>
        </div>
    </div>
    
    <br />
    <div class="row container-fluid">
        <div class="col-lg-8">
            <asp:ListView ID="OrderListview" runat="server" OnItemCommand="CustomerListview_ItemCommand" OnSelectedIndexChanged="CustomerListview_SelectedIndexChanged">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                        <tr class="active">
                            <th>ID</th>
                            <th>Product Name</th>
                            <th>Quantity</th>
                            <th>Price</th>
                            <th>Edit</th>
                            <th>Delete</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr runat="server">
                        <td>
                            <%# Eval("ProductID") %>
                        </td>
                        <td>
                            <%# Eval("ProductName") %>
                        </td>

                        <td>
                            <%# Eval("Quantity") %>
                        </td>
                        <td>
                            <%# Eval("SalesPrice") %>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="EditOrderItem" CommandArgument='<%# Eval("ProductID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="DeleteOrderItem" CommandArgument='<%# Eval("ProductID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
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
                <asp:Label ID="Message" runat="server" CssClass="alert-danger"></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <div class="row container-fluid">
        <div class="col-lg-3">
            <div class="input-group">
                <asp:LinkButton ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="CancelButton" runat="server" CssClass="btn btn-primary" OnClick="CancelButton_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>


</asp:Content>
