<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="Project5.Member" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Member Dashboard - Sustainable Shopper</title>
    <link href="Styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Welcome Member!</h1>
            <p>Explore the features and services available to you:</p>
            <div>
                <asp:Button ID="btnFindStore" runat="server" Text="Find the Nearest Store" OnClick="btnFindStore_Click" CssClass="button" />
                <asp:Button ID="btnSavings" runat="server" Text="Steps to Savings" OnClick="btnSavings_Click" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" CssClass="button" />
            </div>
            <asp:Label ID="lbl_currentTime" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
