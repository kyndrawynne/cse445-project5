<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SustainableShopper.Default" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sustainable Shopper</title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <h1>Welcome to Sustainable Shopper</h1>
        <p>Your guide to making eco-friendly shopping choices.</p>
        <asp:Button ID="btnMemberPage" runat="server" Text="Member Page" PostBackUrl="~/Member.aspx" CssClass="button" />
        <asp:Button ID="btnStaffPage" runat="server" Text="Staff Page" PostBackUrl="~/Staff.aspx" CssClass="button" />
        <h2>Explore Our Services</h2>
        <ul>
            <li><strong>Find the Nearest Store:</strong> Discover eco-friendly stores near you.</li>
            <li><strong>Steps to Savings:</strong> Calculate how much you save in gas by walking to stores.</li>
        </ul>
    </div>
    </form>
</body>
</html>
