<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="Withdrawl.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Withdrawl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div>
        <table align="center">
            <%--HEADER--%>
            <tr>
                <td colspan="2" align="center">
                    <h4>WITHDRAWL</h4>
                </td>
            </tr>
            <%--HEADER ENDS--%>

            <%--PAYEE ACCOUNT NUMBER--%>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Payee Account Number"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlPayeeAccountNumber" runat="server" Height="28px" Width="208px" AppendDataBoundItems="true">
                        <asp:ListItem Value="0">Please Select Payee Account Number</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="ddlPayeeAccountNumber" SetFocusOnError="true" Display="Dynamic" InitialValue="0"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <%--PAYEE ACCOUNT NUMBER ENDS--%>

            <%--PAYEE NAME--%>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Payee Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPayeeName" placeholder="Tom Holland" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPayeeName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Min. length of the Payee Name must be 6(alphanuberic)" ControlToValidate="txtPayeeName" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9\s]{6,15}$"></asp:RegularExpressionValidator>
                    </div>

                </td>
            </tr>
            <%--PAYEE NAME ENDS--%>

            <%--PAYEE Mobile--%>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Mobile Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNumber" placeholder="+449999999999" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMobileNumber" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>

                        <%--
                        #I have used Most Simple Regular => ^((\+44)|(0)) ?\d{4} ?\d{6}$.

                        #But I can also use some complex REGEX such as => ^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$

                        #Possibility Matches => +449999999999   | +44 9999 999 999 | (0999) 9999999 #2222
                        
                        --%>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid Mobile Number" ControlToValidate="txtMobileNumber" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"></asp:RegularExpressionValidator>
                    </div>

                </td>
            </tr>
            <%--PAYEE MOBILE ENDS--%>

            <%--TRANSFER AMOUNT--%>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="WITHDRAWL AMOUNT"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAmount" placeholder="10000" runat="server" Height="28px" Width="200px" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAmount" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Amount" ControlToValidate="txtAmount" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator>
                    </div>

                </td>
            </tr>

            <%--TRANSFER AMOUNT ENDS--%>

            <%--REMARKS INPUT--%>
            <tr>
                <td style="width:50%">
                    <asp:Label ID="Label10" runat="server" Text="Remarks"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtRemarks" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
        <%--REMARKS INPUT ENDS--%>

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
