<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TricorERP.POS.POS_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <title>Home</title>
</head>
<body>
    <h1 class="text-center">Welcome to TRICOR!</h1>
    <hr />
    <form runat="server" class="form-control-static">
        <div class="container-f">
            <%--            <div class="row vertical-center-row">--%>
            <div class="col-lg-12">
                <div class="row glyphicon-align-center">
                    <div class="col-xs-4 col-xs-offset-4">

                        <asp:Label ID="loginMsg" runat="server" ForeColor="Red" CssClass="alert"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" /><br />

                        <div class="form-group">
                            <div class="row">
                                <label class="col-sm-3 control-label">Name
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="NameTextBox" CssClass="danger" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only alphbates and digits are allow in Username" ControlToValidate="NameTextBox" ValidationExpression="^[a-zA-Z0-9_]*$" CssClass="danger" ForeColor="Red">*</asp:RegularExpressionValidator></label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="NameTextBox" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <label for="inputPassword3" class="col-sm-4 control-label">Password
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="PasswordTextBox" CssClass="danger" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid password" ControlToValidate="PasswordTextBox" ValidationExpression="^[a-zA-Z'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \ | \! | \% | \+ | \&amp; | \, | \! $]{1,200}$" CssClass="danger" ForeColor="Red">*</asp:RegularExpressionValidator></label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="PasswordTextBox" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                        </div>

                        <br />
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                                <asp:Button ID="Login" CssClass="btn btn-default" runat="server" Text="Login" OnClick="Login_Click" />
                                <button type="reset" class="btn btn-default">Reset</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--</div>--%>
        </div>
    </form>
    <%--<script src='<%=ResolveClientUrl("~/Scripts/jquery-2.1.3.min.js")%>'></script>--%>
    <script src='<%=ResolveClientUrl("~/Scripts/bootstrap.js")%>'></script>
</body>

</html>
