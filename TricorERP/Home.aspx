<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TricorERP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div runat="server" id="StockStatusalert" class="alert alert-danger">
        <a href="#" class="close" data-dismiss="alert">&times;
        </a>
        <strong>Warning!</strong> Number Of Products which are Low in the.
        <a href="POS/Stock/StockList.aspx">stock :
             <asp:Label ID="StockStatusLab" runat="server" Text="">
             </asp:Label>
        </a>
    </div>

    <div id="PendingSales" class="panel panel-info">
        <div class="panel-heading">
            <h3 class="panel-title">Pending Sales</h3>
        </div>
        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
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
    
    
</asp:Content>
