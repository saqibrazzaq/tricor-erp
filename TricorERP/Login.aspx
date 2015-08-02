<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TricorERP.POS.POS_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<%--<head runat="server">
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
<%--  <div class="col-lg-12">
                <div class="row glyphicon-align-center">
                    <div class="col-xs-4 col-xs-offset-4">

                        <asp:Label ID="loginMsg" runat="server" ForeColor="Red" CssClass="alert"></asp:Label>
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" BackColor="#FFCCCC" BorderColor="#FF9999" BorderStyle="Solid" BorderWidth="1px" HeaderText="Required Fields*" Font-Bold="False" /><br />

                        <div class="form-group">
                            <div class="row">
                                <label class="col-sm-4 control-label">Name
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
                                <div class="col-sm-8">
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
            <%--</div>
        </div>
    </form>
    <%--<script src='<%=ResolveClientUrl("~/Scripts/jquery-2.1.3.min.js")%>'></script>
    <script src='<%=ResolveClientUrl("~/Scripts/bootstrap.js")%>'></script>
</body>--%>


<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Signin Template for Bootstrap</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="Content/signin.css" rel="stylesheet" />

</head>

<body>

    <div class="container">
        <h1 class="text-center">Welcome To TRICOR!</h1>
        <hr />
        <form class="form-signin" runat="server">
            <asp:Label ID="loginMsg" runat="server" ForeColor="Red" CssClass="alert"></asp:Label>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="None" Font-Bold="False" ForeColor="Red" Width="461px" DisplayMode="List" />
            <h2 class="form-signin-heading">Please sign in</h2>
            <table>
                <tr>
                    <td style="width: 350px">
                        <asp:TextBox runat="server" ID="NameTextBox" class="form-control" placeholder="Username"></asp:TextBox></td>
                    <td style="vertical-align:bottom">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Username is required" ControlToValidate="NameTextBox" CssClass="danger" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Only alphbates and digits are allow in Username" ControlToValidate="NameTextBox" ValidationExpression="^[a-zA-Z0-9_]*$" CssClass="danger" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 350px">
                        <asp:TextBox runat="server" ID="PasswordTextBox" class="form-control" placeholder="Password"></asp:TextBox></td>
                    <td style="vertical-align:bottom">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="PasswordTextBox" CssClass="danger" ForeColor="Red">*</asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Enter valid password" ControlToValidate="PasswordTextBox" ValidationExpression="^[a-zA-Z'.\s | \d | \- | \/ | \$ | \£ | \€ | \( | \) | \ | \! | \% | \+ | \&amp; | \, | \! $]{1,200}$" CssClass="danger" ForeColor="Red">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" value="remember-me">
                                Remember me
                            </label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 350px">
                        <asp:Button ID="Login" runat="server" class="btn btn-lg btn-primary btn-block" Text="Sign in" OnClick="Login_Click" /></td>
                    <td></td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
