<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddNewSupplier.aspx.cs" Inherits="TricorERP.SCM.AddNewSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <div class="container-fluid">
        <h2 class="h2">Supplier</h2>
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
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary"  OnClick="Savebtn_Click" >Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" >Cancel</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
             <h4 class="h4">
                <asp:Label ID="ErrorMessageLable" runat="server" ForeColor="#FF3300"></asp:Label>
                </h4>
            </div>
        </div>
    </div>


</asp:Content>