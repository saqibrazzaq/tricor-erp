<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TricorERP.POS.POS_Home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- The above 3 meta tags *must* come first in the head; any other head content must come *after* these tags -->
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Signin</title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="Content/signin.css" rel="stylesheet" />
    <script lang="javascript">
        function errorMessageCheck() {
            var a = document.getElementById("loginMsg").innerHTML;
            document.getElementById("loginMsg").innerHTML="";
        }
    </script>
</head>
<body>
    <div class="container">
        <h1 class="text-center">Welcome To TRICOR!</h1>
        <hr />
        <form class="form-signin" runat="server">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" BorderStyle="None" Font-Bold="False" ForeColor="Red" Width="461px" DisplayMode="List" />
            <asp:Label ID="loginMsg" runat="server" ForeColor="Red" CssClass="alert"></asp:Label>
            <table>
                <tr>
                    <td colspan="2">
                        <h2 class="form-signin-heading">Please sign in</h2>
                    </td>
                </tr>
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
                        <asp:TextBox runat="server" ID="PasswordTextBox" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox></td>
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
                        <asp:Button ID="Login" runat="server" class="btn btn-lg btn-primary btn-block" Text="Sign in" OnClick="Login_Click" OnClientClick="javascript:errorMessageCheck();" /></td>
                    <td></td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
