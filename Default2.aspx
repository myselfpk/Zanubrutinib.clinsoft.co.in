<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged" MaxLength="3"></asp:TextBox>
            <br />
            <asp:CheckBox ID="CheckBoxSAECRIET4" Text="Required/prolonged  hospitalisation" runat="server" />
        </div>
    </form>
</body>
</html>
