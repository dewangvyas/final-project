<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table align="center">

        <%--HEADING--%>
        <tr>
            <td colspan="2" align="center">
                <h4>CHANGE PASSWORD</h4>
            </td>
        </tr>
        <%--HEADING ENDS--%>

        <%--NEW PASSWORD--%>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label4" runat="server" Text="New Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNewPassword" runat="server" Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNewPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtNewPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@#$.!\s]{6,15}$"></asp:RegularExpressionValidator>
                </div>
                
            </td>
        </tr>
        
        <%--NEW PASSWORD ENDS--%>

        <%--CONFIRM PASSWORD--%>
        <tr>
            <td style="width:160px;">
                <asp:Label ID="Label5" runat="server" Text="Comfirm Password"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComfirmPassword" runat="server" Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtComfirmPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtComfirmPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@#$.!\s]{6,15}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matched" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtComfirmPassword" ControlToCompare="txtNewPassword"></asp:CompareValidator>
                </div>
                
                
            </td>
        </tr>
        <%--CONFIRM PASSWORD ENDS--%>

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
