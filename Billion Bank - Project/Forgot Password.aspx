<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot Password.aspx.cs" Inherits="Billion_Bank___Project.Forgot_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 541px;
        }
        .auto-style2 {
            width: 179px;
        }
        .auto-style3 {
            width: 184px;
        }
        .auto-style4 {
            width: 541px;
            height: 48px;
        }
        .auto-style5 {
            width: 179px;
            height: 48px;
        }
        .auto-style6 {
            width: 184px;
            height: 48px;
        }
        .auto-style7 {
            height: 48px;
        }
        .auto-style8 {
            width: 541px;
            height: 35px;
        }
        .auto-style9 {
            width: 179px;
            height: 35px;
        }
        .auto-style10 {
            width: 184px;
            height: 35px;
        }
        .auto-style11 {
            height: 35px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblTitleForgot" runat="server" Font-Bold="True" Font-Size="Large" Text="Please enter your email and then answer the question:"></asp:Label>
                    </td>
                    <td class="auto-style2">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style5">
                        <asp:Label ID="lblEmailForgot" runat="server" Text="Email Address:"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:TextBox ID="txtEmailForgot" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:RequiredFieldValidator ID="rfvEmailForgot" runat="server" ControlToValidate="txtEmailForgot" ErrorMessage="Please enter data into this field."></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td class="auto-style9">
                        <asp:Button ID="btnEmailSubmit" runat="server" OnClick="btnEmailSubmit_Click" Text="Submit Email" />
                    </td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblQuestionForgot" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txtAnswerForgot" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="rfvAswerForgot" runat="server" ControlToValidate="txtAnswerForgot" ErrorMessage="Please enter data into this field." Visible="False"></asp:RequiredFieldValidator>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmitAnswer" runat="server" Text="Submit Answer" Visible="False" OnClick="btnSubmitAnswer_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp;</td>
                    <td class="auto-style2">
                        <asp:Label ID="lblNewPassword" runat="server" Visible="False">New Password:</asp:Label>
                    </td>
                    <td class="auto-style3">
                        <asp:TextBox ID="txtNewPassword" runat="server" Visible="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="Please enter data into this field." Visible="False"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="lblErrorForgot" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:Button ID="btnSubmitPassword" runat="server" Text="Submit Password" Visible="False" OnClick="btnSubmitPassword_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
