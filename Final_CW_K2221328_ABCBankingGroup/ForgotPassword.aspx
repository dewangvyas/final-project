<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center">
        <%--Heading--%>
        <tr>
            <td colspan="2" align="center">
                <h4>FORGOT PASSWORD</h4>
            </td>
        </tr>

        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblUsername" runat="server"></asp:Label>
            </td>
        </tr>
        <%--Heading ENDS--%>

        <%--SECURITY QUESTION--%>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label2" runat="server" Text="Security Question"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblSecurityQuestion" runat="server"></asp:Label>
            </td>
        </tr>
        <%--SECURITY QUESTION ENDS--%>

        <%--SECURITY QUESTION Answer--%>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label3" runat="server" Text="Your Input"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswer" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:HiddenField ID="hdnAnswer" runat="server" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAnswer" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--SECURITY QUESTION Answer ENDS--%>

        <%--CONFIRM BUTTON--%>

        <tr>
            <td align="center">
                <asp:Button ID="btnConfirm" CssClass="lnr-button" runat="server" Text="CONFIRM" OnClick="btnConfirm_Click"/>
            </td>
            <td>
                <asp:Button ID="btnCancel" CssClass="lnr-button" runat="server" Text="CANCEL" OnClick="btnCancel_Click" CausesValidation="false"/>
            </td>
        </tr>
        <%--CONFIRM BUTTON ENDS--%>

        <%--DIV TO DISPLAY ERROR--%>
        <tr>
            <td colspan="2">
                <div id="error" runat="server" style="color:darkred;">

                </div>
            </td>
        </tr>
        <%--ERROR DIV ENDS--%>

    </table>

</asp:Content>
