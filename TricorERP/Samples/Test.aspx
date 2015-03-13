<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="TricorERP.Samples.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test page</title>
    <!-- Project stylesheets and JavaScript -->
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />

    <script src="../Scripts/jquery-2.1.3.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

    <!-- Module stylesheets and JavaScript -->
    <link href="Samples.css" rel="stylesheet" />
    <script src="Samples.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
            <h1>Testing jQuery and Bootstrap</h1>
        </div>

        <div class="container">
            <label>Testing Working of jQuery and Bootstrap</label>
            <asp:Button ID="btnShowJumbotron" CssClass="btn btn-primary btnShowJumbotron" runat="server" Text="Show Jumbotron" OnClick="btnShowJumbotron_Click" />
            <asp:Button ID="btnHideJumbotron" CssClass="btn btn-info btnHideJumbotron" runat="server" Text="Hide Jumbotron" OnClick="btnHideJumbotron_Click" />
        </div>

        <div class="panel panel-default">
            <div class="panel-heading">
                <h2>Testing SQL Server Working</h2>
                <asp:Button CssClass="btn btn-primary" runat="server" OnClick="Unnamed1_Click" Text="New Customer" />
            </div>
            <div class="panel-body">
                <asp:ListView ID="CustomerListview" runat="server" OnItemCommand="CustomerListview_ItemCommand" OnSelectedIndexChanged="CustomerListview_SelectedIndexChanged">
                    <LayoutTemplate>
                        <table class="table table-bordered table-hover" runat="server" id="CustomersTable">
                            <tr>
                                <th>ID</th>
                                <th>Full Name</th>
                                <th>Customer Type</th>
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
                                <asp:LinkButton runat="server" CommandName="EditCustomer" CommandArgument='<%# Eval("ID") %>' Text='<%# Eval("FullName") %>'></asp:LinkButton>
                            </td>
                            <td><%# Database.Samples.Customer.GetCustomerType(int.Parse(Eval("CustomerType").ToString())) %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
