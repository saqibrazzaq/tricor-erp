<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddSupplierAddress.aspx.cs" Inherits="TricorERP.SCM.AddSupplierAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <div class="container-fluid">
        <h2 class="h2">Supplier</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Name</label>
                 <asp:TextBox ID="SupplierNameText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">CNIC</label>
                <asp:TextBox ID="SupplierCNICText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
         <h3 class="h3">Supplier Address </h3>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">City</label>
                 <asp:TextBox ID="CityText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
              <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Location 1</label>
                 <asp:TextBox ID="Location1Text" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         <br />
            <div class="row container-fluid">
              <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Location 2</label>
                 <asp:TextBox ID="Location2Text" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
                <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Phone Number</label>
                 <asp:TextBox ID="PhoneNumberText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                <label for="InputName">Email</label>
                <asp:TextBox ID="EmailText" CssClass="form-control" Font-Names="InputName"  wrap="true" runat="server" ></asp:TextBox>
             </div>
            </div>
        </div>
    <br />
    <br />
    <div class="row container-fluid">
        <div class="col-lg-5">
            <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
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


