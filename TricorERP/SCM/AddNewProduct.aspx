<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddNewProduct.aspx.cs" Inherits="TricorERP.SCM.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <h2 class="h2">Add Product</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Product Name</label>
                 <asp:TextBox ID="ProductNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Product Code</label>
                <asp:TextBox ID="ProductCodeText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Product Price</label>
                 <asp:TextBox ID="ProductPriceText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                <label for="InputName">Product Discription</label>
                <asp:TextBox ID="ProductDescriptionText" CssClass="form-control" Font-Names="InputName"  width="430px" Height="55px" wrap="true" runat="server" TextMode="MultiLine"></asp:TextBox>
             </div>
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
