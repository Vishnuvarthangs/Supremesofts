<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Authentication.aspx.cs" Inherits="HR_Authentication" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Authentication</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblUsername" CssClass="">Enter User Name</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUsername" runat="server" CssClass="" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="lblPassword" CssClass="">Enter Password</asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="" Width="120px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <asp:Button runat="server" ID="btnOK" OnClick="btnOK_Click" Text="OK" CssClass="body" Width="120px" BorderColor="Black" BorderWidth="1px" />
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
