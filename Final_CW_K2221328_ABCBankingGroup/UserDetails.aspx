<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">


    <div>
        <h4 style="padding:30px;text-align:center;font-weight:600;">PERSONAL DETAILS</h4>
    </div>

    <div style="padding:30px;">
        <table class="table user-details" align="center">

            <%--USER NAME--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblUserName" runat="server"></asp:Label>
                </td>
            </tr>
            <%--USER NAME ENDS--%>

            <%--ACCOUNT HOLDER NAME--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="ACCOUNT HOLDER NAME"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblAccountHolderName" runat="server"></asp:Label>
                </td>
            </tr>
            <%--ACCOUNT HOLDER NAME ENDS--%>

            <%--ACCOUNT NUMBER--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label4" runat="server" Text="ACCOUNT NUMBER"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblAccountNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <%--ACCOUNT NUMBER ENDS--%>

            <%--ACCOUNT TYPE--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label6" runat="server" Text="ACCOUNT TYPE"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblAccountType" runat="server"></asp:Label>
                </td>
            </tr>
            <%--ACCOUNT TYPE ENDS--%>

            <%--EMAIL--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label8" runat="server" Text="EMAIL"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
            </tr>
            <%--EMAIL ENDS--%>

            <%--MOBILE NUMBER--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label10" runat="server" Text="MOBILE NUMBER"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblMobileNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <%--MOBILE NUMBER ENDS--%>

            <%--ADDRESS--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label3" runat="server" Text="ADDRESS"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <%--ADDRESS ENDS--%>

            
            <%--PASSPORT--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label7" runat="server" Text="PASSPORT"></asp:Label>
                    </h4>
                </td>
                <td>
                        <asp:Label ID="lblPassport" runat="server"></asp:Label>
                </td>
            </tr>
            <%--PASSPORT ENDS--%>

            <%--REGISTER AND CANCEL BUTTONS--%>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btneditAccount" runat="server" CssClass="lnr-button" Text="Edit Account" OnClick="btneditAccount_Click"/>
                </td>
                <td>
                    <asp:Button ID="btndeleteAccount" runat="server" CssClass="lnr-button" Text="Delete Account" OnClick="btndeleteAccount_Click" CausesValidation="false"/>
                </td>
            </tr>
            <%--REGISTER AND CANCEL BUTTONS ENDS--%>

            <%--ERROR DIV--%>
            <tr>
                <td colspan="2">
                    <div id="error" runat="server" style="color:darkred;">

                    </div>
                </td>
                <td></td>
            </tr>
            <%--ERROR DIV ENDS--%>
            
        </table>
    </div>

</asp:Content>
