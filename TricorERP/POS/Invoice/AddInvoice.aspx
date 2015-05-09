<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddInvoice.aspx.cs" Inherits="TricorERP.POS.Invoice.AddInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="AddInvoice.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-heading">
            <div class="row container-fluid">
                <div class="col-lg-2">
                    <label for="InputName">Customer :</label>
                    <asp:TextBox ID="CustomerNameTextBox" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label for="InputName">Date:</label>
                    <asp:TextBox ID="DateTextBox" ReadOnly="true" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-lg-2">
                    <label for="InputName">Price :</label>
                    <asp:TextBox ID="Price" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="input-group col-lg-2">
                    <label for="InputName">Payment method :</label>
                    <asp:DropDownList CssClass="form-control" ID="PaymentMethodDropDownList" runat="server">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-4">
                    <asp:Label ID="ErrorMessage" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-3">
                    <asp:Button runat="server" ID="btnAddInvoice" Text="Add Invoice" OnClick="btnAddInvoice_Click" CssClass="btn btn-default" />
                </div>
            </div>
        </div>

        <div class="panel-body">
            <asp:ListView ID="AddInvoiceListview" runat="server">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover">
                        <tr class="active">
                            <th class="hidden">ID</th>
                            <th class="hidden">Sales Order ID</th>
                            <th class="">Date</th>
                            <th class="">Payment method</th>
                            <th>Price</th>
                            <th>Edit/Delete</th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr class="ItemRow" id="ItemRow" runat="server">
                        <td class="hidden Col_InvoiceID">
                            <%# Eval("ID") %>
                        </td>
                        <td class="hidden ItemCol_OrderID">
                            <%# Eval("OrderID") %>
                        </td>
                        <td class="ItemCol_InvoiceDate">
                            <%# Eval("Date") %>
                        </td>
                        <td class="ItemCol_Invoice">
                            <%# Eval("PaymentMathordName") %>
                        </td>

                        <td class="ItemCol_Price">
                            <%# Eval("Price") %>
                        </td>
                        <td>
                            <div runat="server" id="ItemCommandtd">
                                <button type="button" class="ItemRowEdit btn btn-default btn-xs" data-toggle="modal" data-target="#InvoiceItemEditModal">
                                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                </button>

                                <button type="button" class="ItemRowDelete btn btn-default btn-xs confirm">
                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                </button>
                                <asp:Button runat="server" ID="DeleteInvoice" CssClass="hidden DeleteInvoice" OnClick="DeleteInvoice_Click" />
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <asp:Label ID="ErroMessage" runat="server" ForeColor="Red"></asp:Label>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <ul id="OrderApproved" class="nav navbar-nav">
                    <li>
                        <asp:Button ID="Cancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="Cancel_Click" CausesValidation="False" />
                    </li>
                </ul>
            </div>
            <br />
            <br />
            <br />
        </div>


        <!-- Modal -->
        <div class="modal fade" id="InvoiceItemEditModal" tabindex="-1" role="dialog" aria-labelledby="InvoiceLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="InvoiceLabel">Update Invoice</h4>
                    </div>
                    <div class="modal-body">

                        <div class="row form-group">
                            
                            <div class="col-lg-3">
                                <label class="">Price :</label>
                                <asp:TextBox CssClass="hidden txtInvoiceID" runat="server" ID="txtInvoiceID" Text=""></asp:TextBox>
                                <asp:TextBox CssClass="form-control txtPrice" runat="server" ID="txtPrice" Text=""></asp:TextBox>
                            </div>
                            <div class="input-group col-lg-3">
                                <label for="InputName">Payment method :</label>
                                <asp:DropDownList CssClass="form-control" ID="PaymentMethordDropDownListPop" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" ID="UpdateInvoicePrice" OnClick="UpdateInvoicePrice_Click" type="button" class="btn btn-primary" Text="Save changes"></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
