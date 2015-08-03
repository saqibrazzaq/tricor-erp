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
        </div>
        <%-- POS Dashbord panal --%>
        <div class="panel-body" id="POSPanelBody">
            <div class="row">
                <div class="col-lg-12">
                    <div runat="server" id="StockStatusalert" class="alert alert-danger">
                        <a href="#" class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>Warning!</strong> Number Of Products which are Low in the stock are
                            <a href="POS/Stock/StockList.aspx"> 
                                 <asp:Label ID="StockStatusLab" runat="server" Text="">
                                 </asp:Label> Click to check
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
                                        <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>Total Items in stock:
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
                                        <span class="glyphicon glyphicon-save" aria-hidden="true"></span>Pending Order:
                                        <asp:Label ID="Labtotalsales" runat="server" Text=""></asp:Label>
                                    </asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <%-- POS Dashbord panal End--%>

        <div class="panel-body" id="SCMPanelBody">
            <div class="row">
                <div class="col-lg-12">
                    <div runat="server" id="SCMStockStatusalert" class="alert alert-danger">
                        <a href="#" class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>Warning!</strong> Number Of low stock products:
                            <a href="SCM/SearchStockItem.aspx">
                                <asp:Label ID="SCMStockStatusLab" runat="server" Text="">
                                </asp:Label>
                            </a>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12">
                    <div runat="server" id="SCMPendingOrdersAlert" class="alert alert-danger">
                        <a href="#" class="close" data-dismiss="alert">&times;
                        </a>
                        <strong>Warning!</strong> Number Of pending orders:
                            <a href="SCM/ViewManufactureRequests.aspx">
                                <asp:Label ID="SCMPendingOrdersLabel" runat="server" Text="">
                                </asp:Label>
                            </a>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
