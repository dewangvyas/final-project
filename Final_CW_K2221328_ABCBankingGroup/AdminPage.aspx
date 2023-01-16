<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div>
        <table align="center">

            <%--ADMIN NAME--%>
            <tr>
                <td>
                    <h4>
                        <asp:Label ID="lblAdminName" runat="server" Text="Label"></asp:Label>

                    </h4>
                </td>
            </tr>
            <%--ADMIN NAME ENDS--%>

            <%--ADMIN DETAILS--%>

            <tr>
                <td style="width:50%;">
                    <asp:Label ID="Label4" runat="server" Text="ACCOUNT NUMBER"></asp:Label>
                </td>
                <td>
                        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
                </td>
            </tr>

            <%--ADMIN DETAILS ENDS--%>
        </table>
    </div>
</asp:Content>
