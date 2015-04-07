<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TricorERP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    THis is Home page <% = Session["Username"] + " - " + Session["RoleID"] +"----"+ Session["CustomerID"] %>



    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Pending Sales</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-4">
                    <label class="">Pending Sales Order :</label>
                    <asp:Label ID="PandingSaleOrderLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <label class="">In-Progress Order :</label>
                    <asp:Label ID="InProgressOrderLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>



    <%--<div class="panel panel-default">
        <div class="panel-body">This page is temporarily disabled by the site administrator for some reason.</div> 
        <div class="panel-footer clearfix">
            <div class="pull-right">
                <a href="#" class="btn btn-primary">Learn More</a>
                <a href="#" class="btn btn-default">Go Back</a>
            </div>
        </div>
    </div>--%>




</asp:Content>
