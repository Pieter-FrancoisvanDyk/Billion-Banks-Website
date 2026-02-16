<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update Info.aspx.cs" Inherits="Billion_Bank___Project.Update_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 508px;
        }
        .auto-style2 {
            width: 181px;
        }
        .auto-style3 {
            width: 508px;
            height: 92px;
        }
        .auto-style4 {
            width: 181px;
            height: 92px;
        }
        .auto-style5 {
            height: 92px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblUpdateTitle" runat="server" Font-Bold="True" Font-Size="Large" Text="Please update your personal info where desired."></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3"></td>
                    <td class="auto-style4">
                        <asp:Label ID="lblDescription" runat="server" Text="Please fill in text boxes where necessary and press corresponding button:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblNameFailure" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtNameUpdate" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdateName" runat="server" OnClick="btnUpdateName_Click" Text="Update Name" Width="310px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblEmailFailure" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtEmailUpdate" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdateEmail" runat="server" Text="Update Email" Width="310px" OnClick="btnUpdateEmail_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblPasswordFailure" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtPasswordUpdate" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="btnUpdatePassword" runat="server" OnClick="btnUpdatePassword_Click" Text="Update Password" Width="310px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Home.aspx">Return Home</asp:HyperLink>
                    </td>
                    <td class="auto-style2">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
