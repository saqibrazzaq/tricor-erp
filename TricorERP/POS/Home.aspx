<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TricorERP.POS.POS_Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <title>Home</title>
</head>
<body>
    <h1 class="text-center">Welcome to TRICOR Point Of Sale</h1>
    <hr />
    <form runat="server" class="form-horizontal">
        <div class="container-f">
            <div class="row vertical-center-row">
                <div class="col-lg-12">
                    <div class="row glyphicon-align-center">
                        <div class="col-xs-4 col-xs-offset-4">

                            <asp:Label ID="loginMsg" runat="server" ForeColor="Red" CssClass="alert">
                            </asp:Label>

                            <div class="form-group">
                                <label class="col-sm-2 control-label">Name</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="NameTextBox" CssClass="form-control" placeholder="Name" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-2 control-label">Password</label>
                                <div class="col-sm-10">
                                    <asp:TextBox ID="PasswordTextBox" CssClass="form-control" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="input-group">
                                <div class="control-group">
                                    <div class="controls">
                                        <div class="radio">
                                            <label>
                                                <asp:RadioButton ID="BranchManagerRadio" GroupName="worker" Text="BranchManager" runat="server" />
                                            </label>
                                            <label>
                                                <asp:RadioButton ID="CashierRadio" GroupName="worker" Text="Cashier" runat="server" />
                                            </label>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <br />
                            <br />
                            <div class="form-group">
                                <div class="col-sm-offset-2 col-sm-10">
                                    <asp:Button ID="Login" CssClass="btn btn-default" runat="server" Text="Login" OnClick="Login_Click"  />
                                    <button type="reset" class="btn btn-default">Reset</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src='<%=ResolveClientUrl("~/Scripts/bootstrap.js")%>'></script>
</body>
</html>
