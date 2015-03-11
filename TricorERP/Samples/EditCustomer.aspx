<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="TricorERP.Samples.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Customer</title>
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
        <h2><asp:Label runat="server" ID="lblEditCustomer" Text="Default Text"></asp:Label></h2>
    </div>
    </form>
</body>
</html>
