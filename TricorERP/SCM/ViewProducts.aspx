<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="ViewProducts.aspx.cs" Inherits="TricorERP.SCM.ViewProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ViewProducts.js" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-heading">
    <h2 class="h2">View Product</h2>
    <div class="row">
        <div class="col-lg-6">
            <div class="input-group">
                <asp:TextBox ID="SearchProductText" CssClass="form-control" placeholder="Search Product by Code/Name" runat="server" OnTextChanged="SearchProductText_TextChanged"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="Search" CssClass="btn btn-default" runat="server" Text="Search" OnClick="SearchProduct" />
                </span>
            </div>
        </div>
    </div>

    <div class="panel-body">
        <asp:ListView ID="ProductListview" runat="server" OnItemCommand="ProductListview_ItemCommand" OnSelectedIndexChanged="ProductListview_SelectedIndexChanged">
        <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="productTable">
                    <tr class="active">
                        <th>ID</th>
                        <th>Product Code</th>
                        <th>Product Name</th>
                        <th>Threshold Value</th>
                        <th>Re Order Value</th>
                        <th>Sale Price</th>
                        <th>Purchase Price</th>
                        <th>Product Composotion</th>
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
                    <td class="ItemCol_ID">
                        <%# Eval("ProductID") %>
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
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("SalesPrice") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>' Text='<%# Eval("PurchasePrice") %>'></asp:LinkButton>
                    </td>
                    <td>
                        <asp:LinkButton runat="server" CommandName="ProductComposition" CommandArgument='<%# Eval("ProductID") %>' Text="Product Composition" ></asp:LinkButton>
                    </td>
                    <td>
                      <asp:LinkButton runat="server" CommandName="EditProduct" CommandArgument='<%# Eval("ProductID") %>'><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                    
                    </td>
                    <td>
                        <button type="button" class="ProductDelete btn btn-default btn-xs confirm">
                            <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                        </button>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div></div>

     <div class="modal fade" id="ViewProduct" tabindex="-1" role="dialog" aria-labelledby="ViewProductLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="ViewProductLabel">Delete Item</h4>
                    </div>
                   
                    <!-- some hidden values and buttons of dialog box -->
                    <div class="modal-footer">
                        <asp:TextBox CssClass="hidden txtProductID" runat="server" ID="txtProductID" Text=""></asp:TextBox>
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button runat="server" CssClass="hidden DeleteProduct" OnClick="deleteProduct_onClick" />
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
