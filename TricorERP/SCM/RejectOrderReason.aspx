<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="RejectOrderReason.aspx.cs" Inherits="TricorERP.SCM.RjectOrderReason" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="h2">Enter a reason for rejection</h2>
    <div class="panel-body">
        <asp:Label runat="server">Reason: </asp:Label>
        <asp:TextBox runat="server" ID="reason"></asp:TextBox>
        <asp:Button runat="server" OnClick="submitreason" Text="Submit"/>
     
    </div>
</asp:Content>
