<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="AddNewProduct.aspx.cs" Inherits="TricorERP.POS.Product.AddNewProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <h2 class="h2">Add Product</h2>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" />
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Product Name</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please enter product name!" ControlToValidate="ProductNameText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="ProductNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Product Code</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter product code!" ControlToValidate="ProductCodeText" ForeColor="Red">*</asp:RequiredFieldValidator>
                <asp:TextBox ID="ProductCodeText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Product Type</label>
                <div class="input-group">
                    <asp:DropDownList ID="ProductTypeID" Font-Names="InputName" Width="200px" CssClass="form-control" runat="server">
                        <asp:ListItem Value="1">Finished Product</asp:ListItem>
                        <asp:ListItem Value="2">General</asp:ListItem>
                        <asp:ListItem Value="3">Manufacture</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Unit Type</label>
                <div class="input-group">
                    <asp:DropDownList ID="UnitTypeID" Font-Names="InputName" Width="200px" CssClass="form-control" runat="server">
                        <asp:ListItem Value="1">Quantity</asp:ListItem>
                        <asp:ListItem Value="2">Weight In Grams</asp:ListItem>
                        <asp:ListItem Value="3">Volume in Litters</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Sale Price</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Please enter product sale price!" ControlToValidate="SalePriceText" ForeColor="Red">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="SalePriceText"
                    ErrorMessage="Only integers are allow in product sale price!" ForeColor="Red"
                    ValidationExpression="[0-9]*\.?[0-9]*">*</asp:RegularExpressionValidator>
                <asp:TextBox ID="SalePriceText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Purchase Price</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Please enter product purchase price!" ControlToValidate="PurchasePriceText" ForeColor="Red">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="PurchasePriceText"
                        ErrorMessage="Only integers are allow in product purchase price!" ForeColor="Red"
                        ValidationExpression="[0-9]*\.?[0-9]*">*</asp:RegularExpressionValidator>
                    <asp:TextBox ID="PurchasePriceText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Threshold Value</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Please enter product Threshold value!" ControlToValidate="ThresholdValueText" ForeColor="Red">*</asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="ThresholdValueText"
                        ErrorMessage="Only integers are allow in threshold value!" ForeColor="Red"
                        ValidationExpression="[0-9]*\.?[0-9]*">*</asp:RegularExpressionValidator>
                    <asp:TextBox ID="ThresholdValueText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Product Catagory</label>
                <div class="input-group">
                    <asp:DropDownList ID="Catagory" Font-Names="InputName" Width="200px" CssClass="form-control" runat="server">
                        <asp:ListItem Value="2">Kitchen</asp:ListItem>
                        <asp:ListItem Value="3">Door</asp:ListItem>
                        <asp:ListItem Value="1">Wardrob</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Product Discription</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Please enter product description!" ControlToValidate="ProductDescriptionText" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="ProductDescriptionText" CssClass="form-control" Font-Names="InputName" Width="430px" Height="50px" Wrap="true" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-3">
                <div class="input-group">
                    <label for="InputName">Product Image</label>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Please select product image!" ControlToValidate="FileUpload1" ForeColor="Red">*</asp:RequiredFieldValidator>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
            </div>
        </div>
        <br />
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click">Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" CausesValidation="False">Cancel</asp:LinkButton>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <h4 class="h4">
                    <asp:Label ID="ErrorMessageLable" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
                </h4>
            </div>
        </div>
        <br />
        <br />
        <asp:ListView ID="ProductList" runat="server" OnItemCommand="ProductList_ItemCommand">
            <LayoutTemplate>
                <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                    <tr class="active">
                        <th class="hidden">Id</th>
                        <th style="width: 150px;">Product Name</th>
                        <th style="width: 150px; text-align: center">Product Image</th>
                        <th style="width: 370px; text-align: center">Product Description</th>
                        <th style="text-align: center">Product Price</th>
                        <th style="text-align: center">Edit</th>
                        <th>Delete</th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr runat="server">
                    <td class="hidden AddressID">hh
                    </td>
                    <td>
                        <%#Eval("PName") %>
                    </td>
                    <td style="text-align: center">
                        <img src="<%#Eval("ImagePath") %>" width="60" height="60" />
                    </td>
                    <td style="text-align: center; text-align: justify">
                        <%#Eval("PDescription") %>
                    </td>
                    <td style="text-align: center">Rs <%#Eval("SalePrice") %>
                    </td>
                    <td style="text-align: center">
                        <asp:LinkButton runat="server" CausesValidation="False" ToolTip="Edit a record." CommandName="EditProduct" CommandArgument='<% #Eval("Id") %>'>
                            <span class="glyphicon glyphicon-edit"></span>
                        </asp:LinkButton>
                    </td>
                    <td style="text-align: center">
                        <asp:LinkButton runat="server" CausesValidation="False" ToolTip="Delete a record." OnClientClick="javascript:return confirm('Are you sure to delete record?')" CommandName="DeleteProduct" CommandArgument='<% #Eval("Id") %>'>
                            <span class="glyphicon glyphicon-remove"></span>
                        </asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>