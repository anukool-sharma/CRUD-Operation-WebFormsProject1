<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="CurdOperation_Project1.Employee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: x-large; font-weight: 700">
            Empno:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <p style="font-size: x-large; font-weight: 700">
            Name:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p style="font-size: x-large; font-weight: 700">
            Address:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p style="font-size: x-large; font-weight: 700">
            Salary:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <p style="font-size: x-large; font-weight: 700">
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="135px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="221px"></asp:ListBox>
        </p>
        <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="X-Large" OnClick="Button1_Click" Text="Save" />
        <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Update" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Delete" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Display" OnClick="Button4_Click" />
    </form>
</body>
</html>
