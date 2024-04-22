<!--Code by Alexis Holland-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Project5.Staff" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Dashboard - Sustainable Shopper</title>
    <link href="~/Styles/site.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Staff Dashboard</h1>
            <p>Welcome to the staff management portal!</p>

            <asp:DropDownList ID="ddlUserType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                <asp:ListItem Text="Members" Value="Members.xml" />
                <asp:ListItem Text="Staff" Value="Staff.xml" />
            </asp:DropDownList>


            <!-- Search User Section -->
            <asp:TextBox ID="txtSearch" runat="server" CssClass="input" placeholder="Search by Username" />
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="button" />


            <!-- GridView to display Members with Delete option -->
            <asp:GridView ID="GridViewMembers" runat="server" AutoGenerateColumns="False" CssClass="grid">
                <Columns>
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandArgument='<%# Eval("Username") %>'
                                        OnClick="btnDelete_Click" CssClass="button" OnClientClick="return confirmDelete();" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Add User Section -->
            <h2>Add New Member</h2>
            <asp:TextBox ID="txtNewUsername" runat="server" CssClass="input" placeholder="Enter Username" />
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" CssClass="input" placeholder="Enter Password" />
            <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="btnAddUser_Click" CssClass="button" />

            <div>
                <h2>Funtionality Testing</h2>
                <p>Click the TryIt button below to test our "indivisble components" and see what is happening behind the scenes!</p>
                <asp:Button ID="btnTryIt" runat="server" Text="TryIt" OnClick="btnTryIt_Click" CssClass="button" />
            </div>
            <div>
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" OnClick="btnLogOut_Click" CssClass="button" />
            </div>

        </div>
    </form>
</body>
</html>
