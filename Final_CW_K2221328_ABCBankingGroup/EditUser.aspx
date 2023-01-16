<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.EditUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">


    <div style="text-align:center;padding:30px;">
        <h4 style="font-size:18px;font-weight:600;">EDIT DETAILS</h4>
    </div>

    <div style="width:40%%;">
        <table class="table-striped table table-center table-responsive edit-user" align="center">

            <%--USER NAME--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label1" runat="server" Text="USERNAME"></asp:Label>
                    </h4>
                </td>
                <td>
                    <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <%--USER NAME ENDS--%>

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

            <%--FIRST NAME--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label2" runat="server" Text="FIRST NAME"></asp:Label>
                    </h4>
                </td>
                <td>
                    <asp:TextBox ID="txtFirstName" CssClass="txtBox" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFirstName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Min. length of the User Name must be 6(alphanuberic)" ControlToValidate="txtFirstName" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z]{2,15}$"></asp:RegularExpressionValidator>
                </div>
                </td>
            </tr>
            <%--FIRST NAME ENDS--%>

            <%--LAST NAME--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label5" runat="server" Text="LAST NAME"></asp:Label>
                    </h4>
                </td>
                <td>
                    <asp:TextBox ID="txtLastName" CssClass="txtBox" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLastName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Min. length of the User Name must be 6(alphanuberic)" ControlToValidate="txtLastName" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z]{2,15}$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <%--LAST NAME ENDS--%>



            <%--EMAIL--%>
            <tr>
                <td colspan="2" style="width:50%;padding:0 20px 0 0;">
                    <h4>
                        <asp:Label ID="Label8" runat="server" Text="EMAIL"></asp:Label>
                    </h4>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="txtBox" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
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
                    <asp:TextBox ID="txtMobileNumber" CssClass="txtBox" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMobileNumber" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Mobile Number" ControlToValidate="txtMobileNumber" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"></asp:RegularExpressionValidator>
                    </div>
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
                    <asp:TextBox ID="txtAddress" CssClass="txtBox" runat="server" Height="28px" Width="200px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAddress" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
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
                    <asp:TextBox ID="txtPassport" CssClass="txtBox" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassport" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--PASSPORT ENDS--%>

            <%--ERROR DIV--%>
            <tr>
                <td colspan="3" style="text-align:center;">
                    <div id="error" runat="server" style="color:darkred;">

                    </div>
                </td>
            </tr>
            <%--ERROR DIV ENDS--%>

            <%--UPDATE AND CANCEL BUTTONS--%>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="lnr-button" Text="Update" OnClick="btnUpdate_Click"/>
                </td>
                <td>
                    <asp:Button ID="btnCancel" runat="server" CssClass="lnr-button" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="false"/>
                </td>
            </tr>
            <%--UPDATE AND CANCEL BUTTONS ENDS--%>

            
            
        </table>
    </div>

</asp:Content>
