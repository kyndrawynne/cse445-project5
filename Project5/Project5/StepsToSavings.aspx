<!--Code by Alexis Holland-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StepsToSavings.aspx.cs" Inherits="Project5.StepsToSavings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Steps to Savings Converter</h2>
                Enter Number of Steps: <asp:TextBox ID="txtSteps" runat="server"></asp:TextBox>
                <br />
                Enter Local Gas Price (per gallon): <asp:TextBox ID="txtGasPrice" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnCalculateSavings" runat="server" Text="Calculate Savings" OnClick="btnCalculateSavings_Click" />
                <br />
                <asp:Label ID="lblSavingsResult" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
