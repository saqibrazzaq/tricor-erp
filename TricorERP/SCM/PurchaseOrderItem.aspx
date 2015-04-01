<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderItem.aspx.cs" Inherits="TricorERP.SCM.PurchaseOrderItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container-fluid">
        <h2 class="h2">Purchase Order Item</h2>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Ware House</label>
                <asp:TextBox ID="WHNameText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Supplier</label>
                 <asp:TextBox ID="SupplierText" Font-Names="InputName" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
               
            </div>
            </div>
         <br />
         <div class="row container-fluid">
               <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Quantity</label>
                <asp:TextBox ID="QuantityText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
               
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Purchase Price</label>
                 <asp:TextBox ID="PurchasePriceText" Font-Names="InputName"  CssClass="form-control" runat="server"></asp:TextBox>
            </div>      
         </div>
         <br />
         <div class="row container-fluid">
             <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">Products</label>
                <asp:DropDownList ID="ProductsDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-5">
                <br />
                <asp:LinkButton ID="Addbtn" runat="server" CssClass="btn btn-primary"  OnClick="Addbtn_Click" >ADD Order Products</asp:LinkButton>
            </div>
         </div>
    <br />
        <div class="panel-body"> 
        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" >
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Product Code</th>
                        <th>Product Name</th>
                        <th>Threshold Value</th>
                        <th>ReOrder Value</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr id="Tr1" runat="server">
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductID") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductCode") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductName") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductThresholdValue") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("ProductReOderValue") %>'></asp:LinkButton>
                     </td>
                     <td>
                      <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                     </td>
                     <td>
                     <asp:LinkButton runat="server" CommandName="DeleteProduct" CommandArgument='<%# Eval("ProductID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
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

