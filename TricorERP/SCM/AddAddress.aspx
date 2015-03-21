<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddAddress.aspx.cs" Inherits="TricorERP.SCM.AddAddress" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <div class="container-fluid">
        <h2 class="h2">Add Address</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName"></label>
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
              <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Threshold Value</label>
                 <asp:TextBox ID="ThresholdValueText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
         <br />
            <div class="row container-fluid">
              <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">ReOrder Value</label>
                 <asp:TextBox ID="ReOrderValueText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
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
    <br />
    <div class="row container-fluid">
        <div class="col-lg-5">
            <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
            <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click">Cancel</asp:LinkButton>
        </div>
    </div>

    <div class="row container-fluid">
        <div class="col-lg-5">
            <asp:Label ID="message" runat="server" Text=""></asp:Label>
        </div>
    </div>

</asp:Content>

