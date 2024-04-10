<!--Code by Alexis Holland-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Project5.Staff" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Dashboard - Sustainable Shopper</title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Staff Dashboard</h1>
            <p>Welcome to the staff area, where there will eventually be functions. For now please use our default username, "user", and password, "pass", to check out our Member page and find our offered services!</p>
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" CssClass="button" />
            </div>
    </form>
</body>
</html>
