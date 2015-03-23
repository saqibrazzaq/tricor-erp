<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.EditCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="h2">Customer</h2>
        <%-- to be continue... --%>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Full Name :</label>
                <div class="input-group">
                    <asp:TextBox ID="CustomerNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Type :</label>
                <div class="input-group">
                    <asp:DropDownList ID="CustomerTyepDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem Value="1">Individual</asp:ListItem>
                        <asp:ListItem Value="2">Company  </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">CNIC</label>
                <div class="input-group">
                    <asp:TextBox ID="CNICText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Gender :</label>
                <div class="input-group">
                    <asp:DropDownList ID="GenderDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        <asp:ListItem Value="M">Male</asp:ListItem>
                        <asp:ListItem Value="F">Female</asp:ListItem>
                        <asp:ListItem Value="O">Other</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                    <label for="InputName">Address :</label></h4>
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-3">
                <asp:Label ID="message" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-9">
                <h5 class="h5">
                    <label for="InputName">All Possible Addresses...</label></h5>
                <div class="panel-body">
                    <asp:ListView ID="CustomerAddressesview" OnItemCommand="CustomerListview_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>Address ID</th>
                                    <th>Phone Number</th>
                                    <th>City</th>
                                    <th>Location</th>
                                     <th>Edit</th>
                                    <th>Delete</th>
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
                                    <%# Eval("Phonenumber") %>
                                </td>
                                <td>
                                    <%# Eval("City") %>

                                </td>
                                <td>
                                    <%# Eval("Location1") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="AddAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="DeleteAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
        
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
