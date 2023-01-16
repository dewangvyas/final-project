<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="Statement.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Statement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div>
        <table align="center">
            <%--HEADER--%>
            <tr>
                <td colspan="2" align="center">
                    <h4>STATEMENT REQUEST</h4>
                </td>
            </tr>
            <%--HEADER ENDS--%>

            <%--PAYEE ACCOUNT NUMBER--%>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Account Number"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPayeeAccountNumber" runat="server" Height="28px" Width="208px" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Please Select Payee Account Number</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPayeeAccountNumber" SetFocusOnError="true" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <%--PAYEE ACCOUNT NUMBER ENDS--%>

            <%--USERTYPE--%>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="CSV FILE DELIMITER"></asp:Label>
                </td>
                <td>
                    
                    <asp:DropDownList ID="ddlCsvDelimiter" runat="server" Height="28px" Width="208px">
                        <asp:ListItem Text="COMMA DELIMITER" Value="COMMA DELIMITER"></asp:ListItem>
                        <asp:ListItem Text="PIPE DELIMITER" Value="PIPE DELIMITER"></asp:ListItem>
                    </asp:DropDownList>
            
                </td>
                
                
            </tr>
            <%--USERTYPE ENDS--%>

            <%--SEND & CANCEL BUTTONS + ERROR DIV--%>
            <tr>
                <td colspan="2" style="padding-left: 150px;" align="center">
                    <asp:Button ID="btnSend" CssClass="lnr-button" runat="server" Text="Send" OnClick="btnSend_Click" />
                    <asp:Button ID="btnCancel" CssClass="lnr-button" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="error" runat="server" style="color: darkred;">
                        
                    </div>
                    <span id="statusOk" class="status-light-green" runat="server" visible="false"></span>
                    <span id="statusError" class="status-light-red" runat="server" visible="false"></span>
                </td>
            </tr>

            <%--SEND & CANCEL BUTTONS + ERROR DIV ENDS--%>

        </table>
    </div>
</asp:Content>
