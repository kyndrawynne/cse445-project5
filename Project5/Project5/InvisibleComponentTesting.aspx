<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvisibleComponentTesting.aspx.cs" Inherits="Project5.InvisibleComponentTesting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Encryption Testing Section -->
            <h2>Encryption Testing</h2>
            <asp:Label ID="LabelEncryptInput" runat="server" Text="Enter text to encrypt:" />
            <asp:TextBox ID="TextBoxEncrypt" runat="server" />
            <asp:Button ID="ButtonEncrypt" runat="server" Text="Encrypt" OnClick="ButtonEncrypt_Click" />
            <asp:Label ID="LabelEncryptOutput" runat="server" Text="Encrypted text will appear here" />

            <br /><br />

            <!-- Decryption Testing Section -->
            <h2>Decryption Testing</h2>
            <asp:Label ID="LabelDecryptInput" runat="server" Text="Enter text to decrypt:" />
            <asp:TextBox ID="TextBoxDecrypt" runat="server" />
            <asp:Button ID="ButtonDecrypt" runat="server" Text="Decrypt" OnClick="ButtonDecrypt_Click" />
            <asp:Label ID="LabelDecryptOutput" runat="server" Text="Decrypted text will appear here" />
        </div>
    </form>
</body>
</html>
