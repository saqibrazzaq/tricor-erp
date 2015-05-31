<%@ Page Title="AddAddress" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="TricorERP.POS.BranchManager.AddAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <h4 class="h4">Cashier Info :</h4>
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
            <h4 class="h4">Cashier Address :</h4>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">City :</label>
                    <div class="input-group">
                        <asp:TextBox ID="CityNameText" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Name"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Phone Number :</label>
                    <div class="input-group">
                        <asp:TextBox ID="PhoneNumberText" Font-Names="InputName" CssClass="form-control" runat="server" Placeholder="Phone Number"></asp:TextBox>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Email :</label>
                    <div class="input-group">
                        <asp:TextBox CssClass="form-control" ID="email" Font-Names="InputName" placeholder="Enter email" runat="server" TextMode="Email"></asp:TextBox>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Address :</label>
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
