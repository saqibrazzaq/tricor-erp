<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="TricorERP.SCM.PurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container-fluid">
        <h2 class="h2">Purchase Order</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Ware House </label>
                <asp:DropDownList ID="WareHouseDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Supplier</label>
               <asp:DropDownList ID="SupplierDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
            </div>
            </div>
         <br />
         <div class="row container-fluid">
             <div class="col-lg-3">
                <label for="InputName">Order Type</label>
               <asp:DropDownList ID="OrderTypeDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                    <asp:ListItem Value="1">Processing</asp:ListItem>
                        <asp:ListItem Value="2">Confirmed</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Order Date</label>
                 <asp:TextBox ID="OrderDateText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
         </div>
         <br />
         <div class="row container-fluid">
                <div class="col-lg-5">
                <asp:LinkButton ID="Addbtn" runat="server" CssClass="btn btn-primary"  OnClick="Addbtn_Click" >ADD Order Products</asp:LinkButton>
                </div>
         </div>
    <br />
        <div class="panel-body"> 
        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>Product Code</th>
                        <th>Quantity</th>
                        <th>Purchase Price</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditOrderProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("ProductID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditOrderProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Quantity") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditOrderProduct" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("PurchasePrice") %>'></asp:LinkButton>
                    </td>
                    <td>
                      <asp:LinkButton runat="server" CommandName="EditOrderProduct" CommandArgument='<%#  Eval("ID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                     </td>
                     <td>
                     <asp:LinkButton runat="server" CommandName="DeleteOrderProduct" CommandArgument='<%#  Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                     </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
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

