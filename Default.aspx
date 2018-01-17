<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="form1" runat="server">
    <div style="position: center; padding-left: 40%; padding-bottom: 10%;">
        Url: <asp:TextBox ID="txtUrl" runat="server"></asp:TextBox>
        <asp:Button ID="btnFind" runat="server" Text="Find" OnClick="btnFind_Click"/>
    </div>
    <table id="table" runat="server">
        <tr style="width: 100%;">
            <td style="width: 50%;" > Internal Links <br/><asp:ListBox ID="listInternalLinks" runat="server" Width="100%" Height="400px"></asp:ListBox></td>
            <td style="width: 50%;"> External Links <br/><asp:ListBox ID="listExternalLinks" runat="server" Width="100%" Height="400px"></asp:ListBox></td>
        </tr>

    </table>
</form>
</body>
</html>