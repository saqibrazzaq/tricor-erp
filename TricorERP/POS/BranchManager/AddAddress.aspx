<%@ Page Title="AddAddress" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="TricorERP.POS.BranchManager.AddAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="h4"><span class="glyphicon glyphicon-user" aria-hidden="true"></span> Cashier Info :</h4>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <div class="input-group">
                        <b>Name: </b>
                        <asp:Label ID="cashierName" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="input-group">
                        <b>CNIC :</b>
                        <asp:Label ID="cashierCNIC" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel-body">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" />
            <br />
            <h4 class="h4">Cashier Address :</h4>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">City :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter user city!" ControlToValidate="CityNameText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="CityNameText" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Name"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Phone Number :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter user phone number!" ControlToValidate="PhoneNumberText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PhoneNumberText"
                        ErrorMessage="Please enter user valid phone number!" ForeColor="Red"
                        ValidationExpression="[0-9]*\.?[0-9]*">*</asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox ID="PhoneNumberText" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Phone Number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Email :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Please enter user email address!" ControlToValidate="email" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="email"
                        ErrorMessage="Please enter user valid email address!" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    <div class="input-group">
                        <asp:TextBox CssClass="form-control" ID="email" Font-Names="InputName" placeholder="Enter email" runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Address :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Please enter user residence address!" ControlToValidate="Location1Text" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="Location1Text" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="House Number, Street Number, Area" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="hidden col-lg-4">
                    <label for="InputName">Location 2:</label>
                    <div class="input-group">
                        <asp:TextBox ID="Location2Text" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Location"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-5">
                    <asp:Label ID="message" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
