<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="LabelDateTime" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="true" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:button runat="server" ID="Button1" text="Button"/>
        <asp:Label ID="lblDifference" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
