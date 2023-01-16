<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="DeleteUser.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.DeleteUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div align="center">
        <table align="center" style="width:50%;">

            <%--HEADING--%>
            <tr>
                <td colspan="3">
                    <h4 style="text-align:center;">DELETE USER</h4>
                </td>
            </tr>
            <%--HEADING ENDS--%>

            <%--USERNAME--%>
            <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label>
                </td>
                <td style="text-align:center;">
                    <asp:Label ID="lblUsername" runat="server"></asp:Label>
                </td>
            </tr>

            <tr>
                <td colspan="6" >
                    Please keep in mind that after deleting the account, the request will be sent to the bank, and if accepted, the following steps will be taken
                    <%--<asp:Label ID="Label2" runat="server" Text="Please keep in mind that after deleting the account, the request will be sent to the bank, and if accepted, the following steps will be taken"></asp:Label>--%>
                    
                </td> 
            </tr>
            <tr>
                <td colspan="6">
                    1. Submit the credit and debit cards
                    <%--<asp:Label ID="Label3" runat="server" Text="1. Submit the credit and debit cards"></asp:Label>--%>

                </td>
            </tr>

            <tr>
                 <td colspan="6">
                     2. Return the passbook and cheque book
                     <%--<asp:Label ID="Label4" runat="server" Text="2. Return the passbook and cheque book"></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    3. Submit one address and one piece of photo identification.
                    <%--<asp:Label ID="Label5" runat="server" Text="3. Submit one address and one piece of photo identification."></asp:Label>--%>
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    4. Collect the outstanding balance or pay the credit card bill
                    <%--<asp:Label ID="Label6" runat="server" Text="4. Collect the outstanding balance or pay the credit card bill"></asp:Label>--%>
                </td>
            </tr>
            <%--USERNAME ENDS--%>

            <%--REGISTER AND CANCEL BUTTONS--%>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnDelete" runat="server" CssClass="lnr-button" Text="DELETE" OnClick="btnDelete_Click"/>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="lnr-button" Text="CANCEL" OnClick="btnCancel_Click" CausesValidation="false"/>
                </td>
            </tr>
            <%--REGISTER AND CANCEL BUTTONS ENDS--%>

            <%--ERROR DIV--%>
            <tr>
                <td colspan="2">
                    <div id="error" runat="server" style="color:darkred;">

                    </div>
                </td>
            </tr>
            <%--ERROR DIV ENDS--%>

        </table>
    </div>

</asp:Content>
