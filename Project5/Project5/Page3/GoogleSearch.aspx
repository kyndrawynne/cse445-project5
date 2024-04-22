<!--Code by Kyndra Wynne-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoogleSearch.aspx.cs" Inherits="Project5.GoogleSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Perform a Google Search For a Nearby Store</h1>
            <asp:TextBox ID="txtSearchQuery" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
        </div>
    </form>
</body>
</html>
