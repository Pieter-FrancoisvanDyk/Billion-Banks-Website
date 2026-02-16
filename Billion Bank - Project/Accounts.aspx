<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Accounts.aspx.cs" Inherits="Billion_Bank___Project.Accounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 988px;
            margin-left: 40px;
        }
        .auto-style2 {
            width: 988px;
        }
        .auto-style3 {
            width: 154px;
        }
        .auto-style4 {
            width: 324px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="gvAccounts" runat="server">
                        </asp:GridView>
                        <asp:Label ID="lblTransferAcc" runat="server" Text="Transfer Account:" Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddlTransferAcc" runat="server" Visible="False" Width="210px">
                        </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblDestinationAcc" runat="server" Text="Destination Account:" Visible="False"></asp:Label>
                        <asp:DropDownList ID="ddlDestinationAcc" runat="server" Visible="False" Width="210px">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <table style="width: 100%;">
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblAmount" runat="server" Text="Amount:" Visible="False"></asp:Label>
                                    <asp:TextBox ID="txtTransferAmount" runat="server" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblTransferError" runat="server" Text="Please select valid accounts or vaild amounts to transfer money to." Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblAccNotFound" runat="server" Text="Account not found" Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:HyperLink ID="hCreateAccount" runat="server" NavigateUrl="~/Create Account.aspx">Create a New Account</asp:HyperLink>
                    &nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:HyperLink ID="hViewTransactions" runat="server" NavigateUrl="~/Recent Transactions.aspx">View recent transactions.</asp:HyperLink>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Button ID="btnTransfer" runat="server" Text="Transfer Money" OnClick="btnTransfer_Click" />
                        <asp:Button ID="btnTransfer2" runat="server" Text="Transfer Money" Visible="False" OnClick="btnTransfer2_Click" />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label ID="lblSuccessTransfer" runat="server" Text="Transfer was successful." Visible="False"></asp:Label>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
    <p>
&nbsp;&nbsp;
    </p>
</body>
</html>
