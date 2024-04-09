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
            <p>Welcome to the staff area, where you can manage application content and view user analytics.</p>
            <div class="staff-functions">
                <asp:Button ID="btnUserAnalytics" runat="server" Text="View User Analytics" OnClick="btnUserAnalytics_Click" CssClass="button" />
                <asp:Button ID="btnContentManagement" runat="server" Text="Manage Content" OnClick="btnContentManagement_Click" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" CssClass="button" />
            </div>
        </div>
    </form>
</body>
</html>
