﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditSupplier.aspx.cs" Inherits="TricorERP.SCM.EditSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container-fluid">
        <h2 class="h2">Edit Supplier</h2>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Name</label>
                 <asp:TextBox ID="SupplierNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">CNIC</label>
                <asp:TextBox ID="SupplierCNICText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />

        <div class="row container-fluid">
            <div class="col-lg-3">
                <h4 class="h4">
                <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New Address</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            
        </div>

        <div class="row container-fluid">
            <div class="col-lg-9">
                <h2 class="h2">All Possible Addresses.</h2>
                <div class="panel-body">
                    <asp:ListView ID="SupplierAddressesview" OnItemCommand="SupplierListview_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="SupplierTable">
                                <tr class="active">
                                    <th>Address ID</th>
                                    <th>Phone Number</th>
                                    <th>City</th>
                                    <th>Location 1</th>
                                    <th>Location 2</th>
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
                                    <asp:LinkButton runat="server" CommandName="EditAddress" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("PhoneNumber") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditAddress" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("City") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditAddress" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location1") %>'></asp:LinkButton>
                                  </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditAddress" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location2") %>'></asp:LinkButton>
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
            </div>
        </div>
        
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
             <h4 class="h4">
                    <asp:Label ID="message" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
    </div>
</asp:Content>
