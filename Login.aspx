<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CurdOperation_Project1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-weight: 700">
    <form id="form1" runat="server">
        <div style="font-size: x-large">
            Username:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <p style="font-size: x-large">
            Password:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p style="font-size: x-large">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="X-Large" OnClick="Button1_Click" Text="Login" />
        </p>
    </form>
</body>
</html>
