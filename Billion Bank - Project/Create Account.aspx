<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Create Account.aspx.cs" Inherits="Billion_Bank___Project.Create_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 604px;
        }
        .auto-style2 {
            width: 212px;
        }
        .auto-style3 {
            width: 604px;
            height: 26px;
        }
        .auto-style4 {
            width: 212px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" Text="Please specify what the number of your account should be?"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3"></td>
                <td class="auto-style4">
                    <asp:RequiredFieldValidator ID="RFVAccountNum" runat="server" ControlToValidate="txtAccountNumber" ErrorMessage="Please enter data into the textbox!"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style5"></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="lblDescription" runat="server" Text="Please enter a 13 digit or less Account Number:"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtAccountNumber" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click" Text="Accept" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblFailure" runat="server" Text="Please enter valid data into the textbox!" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
