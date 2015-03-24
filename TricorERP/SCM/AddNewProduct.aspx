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
                 <label for="InputName">Threshold Value</label>
                 <asp:TextBox ID="ThresholdValueText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
       <div class="col-lg-3">
                <div class="input-group">
                 <label for="InputName">ReOrder Value</label>
                 <asp:TextBox ID="ReOrderValueText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        <div class="col-lg-3">
                <div class="input-group">
                <label for="InputName">Product Discription</label>
                <asp:TextBox ID="ProductDescriptionText" CssClass="form-control" Font-Names="InputName"  width="230px" Height="50px" wrap="true" runat="server" TextMode="MultiLine"></asp:TextBox>
             </div>
            </div>
          </div>
        <br />
      <div class="row container-fluid">
            <div class="col-lg-3">
                <asp:LinkButton ID="btnAddRM" runat="server" CssClass="btn btn-primary" OnClick="btnAddItem_Click">Add RawMaterial Items</asp:LinkButton>
            </div>
        </div>
        
        <div class="row container-fluid">
            <div class="col-lg-9">
                <h2 class="h2">Products Composition.</h2>
                <div class="panel-body">
                    <asp:ListView ID="RMItemsview" OnItemCommand="RMItems_ItemCommand" runat="server">
                        <LayoutTemplate>
                            <table class="table table-bordered table-hover" runat="server" id="ProductComposition">
                                <tr class="active">
                                    <th>ID</th>
                                    <th>Name</th>
                                    <th>Code</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Delete</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr runat="server">
                                <td>
                                    <%# Eval("ID") %>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProductComposition" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Name") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProductComposition" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Code") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProductComposition" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Price") %>'></asp:LinkButton>
                                  </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="EditProductComposition" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("Quantity") %>'></asp:LinkButton>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CommandName="DeleteProductComposition" CommandArgument='<%# Eval("ID") %>'><span class="glyphicon glyphicon-remove"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
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


</asp:Content>
