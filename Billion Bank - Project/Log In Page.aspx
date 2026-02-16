<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log In Page.aspx.cs" Inherits="Billion_Bank___Project.Log_In_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 373px;
        }
        .auto-style2 {
            width: 141px;
        }
        .auto-style3 {
            width: 373px;
            height: 34px;
        }
        .auto-style4 {
            width: 141px;
            height: 34px;
        }
        .auto-style5 {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblTitleLog" runat="server" Font-Bold="True" Font-Size="Large" Text="Please fill out your log in information:"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <asp:Label ID="lblEmailLog" runat="server" Text="Email Address:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="txtEmailLog" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvEmailLog" runat="server" ControlToValidate="txtEmailLog" ErrorMessage="Please enter data into this field."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblPasswordLog" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPasswordLog" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPasswordLog" runat="server" ControlToValidate="txtPasswordLog" ErrorMessage="Please enter data into this field."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:HyperLink ID="hlForgotPass" runat="server" ForeColor="Blue" NavigateUrl="~/Forgot Password.aspx">Forgot Password</asp:HyperLink>
                    </td>
                    <td>
                        <asp:Button ID="btnLogIn" runat="server" OnClick="btnLogIn_Click" Text="Log In" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblLogError" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
