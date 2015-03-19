<%@ Page Title="" Language="C#" MasterPageFile="~/Tricor.Master" AutoEventWireup="true" CodeBehind="NewOrder.aspx.cs" Inherits="TricorERP.POS.Order.NewOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container-fluid">
        <h2 class="h2">New Order</h2>
        <%-- to be continue... --%>
        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Customer :</label>
                <div class="input-group">
                    <asp:DropDownList ID="CustomerDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Customer---</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-3">
                <label for="InputName">Date :</label>
                <div class="input-group">
                    <%--<asp:TextBox ID="CustomerNameText" Font-Names="InputName" CssClass="form-control" runat="server"></asp:TextBox>--%>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <label for="InputName">Products :</label>
                <div class="input-group">
                    <asp:DropDownList ID="ProductsDropDown" Font-Names="InputName" CssClass="form-control" runat="server">
                        <asp:ListItem>---Select---</asp:ListItem>
                        
                    </asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row container-fluid">
            <div class="col-lg-3">
                <asp:LinkButton ID="AddProducts" runat="server" CssClass="btn btn-primary" OnClick="AddProducts_Click" Text="">AddNew</asp:LinkButton>
            </div>
        </div>
        
        <div class="row">
            <div class="col-lg-3">
                <asp:Label ID="message" runat="server"></asp:Label>
            </div>
        </div>
        <div class="row container-fluid">
            <div class="col-lg-5">
                <asp:LinkButton ID="Savebtn" runat="server" CssClass="btn btn-primary" OnClick="Savebtn_Click" >Save</asp:LinkButton>
                <asp:LinkButton ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click" >Cancel</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
