<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="EditStock.aspx.cs" Inherits="TricorERP.POS.Stock.EditStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">

            <h2 class="h2">
                <asp:Label ID="Head" runat="server" Text="Edit Stock"></asp:Label>
            </h2>
        </div>
        <div class="panel-body">
            <div class="row container-fluid">
                <div class="col-lg-12">
                    <h3 class="h3">Manual Entery Of Data</h3>
                </div>
            </div>
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <label for="InputName">Product :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select product" ControlToValidate="ProductDropDownList" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:DropDownList Font-Names="InputName" CssClass="form-control" ID="ProductDropDownList" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4">
                    <label for="InputName">Quantity :</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter quantity" ControlToValidate="Quantity" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <div class="input-group">
                        <asp:TextBox ID="Quantity" Font-Names="InputName" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:Label ID="MessageLable" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="input-group">
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </div>
            </div>
            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <asp:LinkButton ID="btnAddStock" runat="server" CssClass="btn btn-primary" OnClick="btnAddStock_Click">Add Stock</asp:LinkButton>
                </div>
            </div>

            <div class="hidden row container-fluid">
                <div class="col-lg-12">
                    <h3 class="h3">Data Entering Using csv File</h3>
                </div>
            </div>
            <div class="hidden row container-fluid">
                <div class="col-lg-12">
                    <div>
                        <asp:FileUpload ID="CsvFileUpload" runat="server" CssClass="" /><br />
                        <asp:Button ID="UploadStock" Text="Upload" OnClick="UploadStock_Click" runat="server" CausesValidation="False" />
                    </div>
                </div>
            </div>



            <br />
            <div class="row container-fluid">
                <div class="col-lg-4">
                    <asp:LinkButton ID="btnBack" runat="server" CssClass="btn btn-primary" OnClick="btnBack_Click" CausesValidation="False">Back</asp:LinkButton>
                </div>
            </div>

        </div>
    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" />
</asp:Content>
