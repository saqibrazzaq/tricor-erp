<%@ Page Title="EditCustomer" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="TricorERP.POS.Cashier.EditCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="EditCustomer.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h2 class="h2">
                <asp:Label runat="server" ID="HeadingOfCuatomer" Text=""></asp:Label></h2>
            <%-- to be continue... --%>
        </div>
        <div class="panel-body">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" />
            <br />
            <div class="row container-fluid">


                <div class="col-lg-3">
                    <label for="InputName">Full Name :</label>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter customer full name!" ControlToValidate="CustomerNameText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="CustomerNameText"
                        ErrorMessage="Only letters are allowed in customer name!" ForeColor="Red"
                        ValidationExpression="^[a-zA-Z\s]+$">*</asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CustomerNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">Type :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select customer type!" ControlToValidate="CustomerTyepDropDown" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:DropDownList ID="CustomerTyepDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                            <asp:ListItem Value="">---Select---</asp:ListItem>
                            <asp:ListItem Value="1">Individual</asp:ListItem>
                            <asp:ListItem Value="2">Company  </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-3">

                    <label for="InputName">CNIC :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter customer CNIC" ControlToValidate="CNICText" ForeColor="Red" Visible="False">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter Correct CNIC Number" ControlToValidate="CNICText" ValidationExpression="^[0-9+]{5}-[0-9+]{7}-[0-9]{1}$">*</asp:RegularExpressionValidator>

                    <div class="input-group">
                        <asp:TextBox ID="CNICText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-3">
                    <label for="InputName">Gender :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter customer gender!" ControlToValidate="GenderDropDown" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:DropDownList ID="GenderDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                            <asp:ListItem Value="">---Select---</asp:ListItem>
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
                    <asp:LinkButton ID="btnAddNewAddress" runat="server" CssClass="btn btn-primary" OnClick="btnAddNewAddress_Click">Add New Address</asp:LinkButton>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-3">
                    <asp:Label ID="message" runat="server"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged" /><span style="color: red;">&nbsp;I agree with <a href="#">terms and conditions.</a></span>
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
                                        <th class="hidden">Address ID</th>
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
                                    <td class="hidden AddressID">
                                        <%# Eval("ID") %>
                                    </td>
                                    <td>
                                        <%# Eval("Phonenumber") %>
                                    </td>
                                    <td>
                                        <%# Eval("City") %>
                                    </td>
                                    <td>
                                        <%# Eval("Location1") %>, <%# Eval("Location2") %>
                                    </td>
                                    <td>
                                        <asp:LinkButton runat="server" CommandName="AddAddress" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-edit"></span></asp:LinkButton>
                                    </td>
                                    <td>
                                        <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                        </button>
                                        <asp:Button runat="server" CssClass="hidden DeleteAddress" CommandName="DeleteAddress" OnClick="deleteCustomerAddress_onClick" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                        <asp:TextBox CssClass="hidden txtAddressID" runat="server" ID="txtAddressID" Text=""></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click" Text="">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
