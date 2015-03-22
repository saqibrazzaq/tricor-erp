<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditWareHouse.aspx.cs" Inherits="TricorERP.SCM.EditWareHouse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container-fluid">
        <h2 class="h2">Ware House</h2>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Name</label>
                 <asp:TextBox ID="WHNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Description</label>
                <asp:TextBox ID="WHDescriptionText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
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
                <h5 class="h5">
                    <label for="InputName">All Possible Addresses.</label></h5>
                <div class="panel-body">
                    <asp:ListView ID="WareHouseAddressesview" OnItemCommand="WareHouseListview_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                                <tr class="active">
                                    <th>Address ID</th>
                                    <th>Phone Number</th>
                                    <th>City</th>
                                    <th>Location 1</th>
                                    <th>Location 2</th>
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
                                    <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("PhoneNumber") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("City") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location1") %>'></asp:LinkButton>
                                  </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Location2") %>'></asp:LinkButton>
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
        <div class="row container-fluid">
            <div class="col-lg-5">
             <h4 class="h4">
                    <asp:Label ID="message" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
    </div>
</asp:Content>
