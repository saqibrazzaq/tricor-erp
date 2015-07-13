<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TricorERP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="panel panel-default">

        <div class="panel-heading">
            <div class="row">
                <div class="col-lg-12">
                    <h3 class="h3"><span class="glyphicon glyphicon-dashboard" aria-hidden="true"></span>Dashboard</h3>
                </div>
            </div>

            <%--<div class="row">
                <div class="col-lg-12">
                    <center><u><h4 class="h4">Welcome to TRICOR Point Of Sale!</h4></u></center>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div class="btn-group btn-group-lg">
                        <asp:HyperLink runat="server" ID="Customerhyp" NavigateUrl="~/POS/Cashier/CustomerList.aspx" type="button" class="btn btn-primary btn-lg btn-block">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span> Customers
                        </asp:HyperLink>

                        <asp:HyperLink runat="server" ID="Itemhyp" NavigateUrl="~/POS/Catalog/MainCatalog.aspx?CatId=AllProducts&CatName=All Products" type="button" class="btn btn-primary btn-lg btn-block">
                              <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>   Items
                        </asp:HyperLink>
                        <asp:HyperLink runat="server" ID="Employhyp" NavigateUrl="~/POS/BranchManager/UserList.aspx" type="button" class="btn btn-primary btn-lg btn-block">
                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span> Employees
                        </asp:HyperLink>
                        <asp:HyperLink runat="server" ID="Reporthyp" type="button" class="btn btn-primary btn-lg btn-block">
                        <span class="glyphicon glyphicon-stats" aria-hidden="true"></span>  Reports
                        </asp:HyperLink>
                    </div>
                </div>
            </div>--%>
        </div>
        <div class="panel-body" id="POSPanelBody">
            <div class="row">
                <div class="col-lg-12">
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

                    <div class="panel panel-default">
                        <div class="panel-heading"><span class="glyphicon glyphicon-signal" aria-hidden="true"></span>Statistics</div>
                        <div class="panel-body">

                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:HyperLink runat="server" ID="Customerhyp" NavigateUrl="~/POS/Cashier/CustomerList.aspx" type="button" class="btn btn-default btn-lg btn-block">
                                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>Total Customers:
                                        <asp:Label ID="Labtotalcustomer" runat="server" Text=""></asp:Label>
                                    </asp:HyperLink>
                                </div>
                                <div class="col-lg-6">
                                    <asp:HyperLink runat="server" ID="Itemhyp" NavigateUrl="~/POS/Stock/StockList.aspx" type="button" class="btn btn-default btn-lg btn-block">
                                        <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>Total Items:
                                        <asp:Label ID="LabtotalItem" runat="server" Text=""></asp:Label>
                                    </asp:HyperLink>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12">
                                    <hr />
                                </div>
                            </div>
                            <div class="row" id="POSHomeTEandTS">
                                <div class="col-lg-6">
                                    <asp:HyperLink runat="server" ID="Employhyp" NavigateUrl="~/POS/BranchManager/UserList.aspx" type="button" class="btn btn-default btn-lg btn-block">
                                        <span class="glyphicon glyphicon-user" aria-hidden="true"></span>Total Employees:
                                        <asp:Label ID="Labtotalemployees" runat="server" Text=""></asp:Label>
                                    </asp:HyperLink>
                                </div>
                                <div class="col-lg-6">
                                    <asp:HyperLink runat="server" ID="Reporthyp" type="button" NavigateUrl="~/POS/Order/OrderList.aspx" class="btn btn-default btn-lg btn-block">
                                        <span class="glyphicon glyphicon-save" aria-hidden="true"></span>Total Sales :
                                        <asp:Label ID="Labtotalsales" runat="server" Text=""></asp:Label>
                                    </asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
