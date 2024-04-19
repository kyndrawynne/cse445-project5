<!--Code by Alexis Holland-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Project5.StaffLogin" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Login Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Staff Login Page
        </div>
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" DisplayRememberMe="false">
        </asp:Login>
    </form>
    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</body>
</html>
