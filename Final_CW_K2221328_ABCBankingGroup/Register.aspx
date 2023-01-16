<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        table td{
            padding-right: 80px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table align="center">

        <%--REGISTER HEADING--%>
        <tr>
            <td colspan="2" align="center">
                <h4>REGISTER</h4>
            </td>
        </tr>
        <%--REGISTER HEADING ENDS--%>

        <%--ACCOUNT NUMBER--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="lblaccNumber" runat="server" Text="ACCOUNT NUMBER" Visible="true"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblAccountNumber" runat="server" Visible="true"></asp:Label>
                <input id="accountnumber" runat="server" type="hidden" value =""/>
            </td>
        </tr>
        <%--ACCOUNT NUMBER ENDS--%>


        <%--ACCOUNT TYPE--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label2" runat="server" Text="ACCOUNT TYPE"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAccountType" runat="server" Height="28px" Width="208px" DataTextField="accType" DataValueField="account_type_id" DataSourceID="ctl001">
                </asp:DropDownList>
                <asp:SqlDataSource ID="ctl001" runat="server" ConnectionString="<%$ ConnectionStrings:abc_bankConnectionString %>" SelectCommand="SELECT [account_type_id], [accType] FROM [AccountType]"></asp:SqlDataSource>
            </td>
        </tr>
        <%--ACCOUNT TYPE ENDS--%>

        <%--USER NAME--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label3" runat="server" Text="USER NAME"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsername" placeholder="TomHolland" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsername" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Min. length of the User Name must be 6(alphanuberic)" ControlToValidate="txtUsername" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@#$.!]{6,15}$"></asp:RegularExpressionValidator>
                </div>
                
            </td>
        </tr>
        <%--USER NAME ENDS--%>

        <%--FIRST NAME--%>
        <tr>
            <td style="width:50%">
                
                <asp:TextBox ID="txtFirstName" placeholder="FIRST NAME" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFirstName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtFirstName" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="[a-zA-Z]{2,15}$"></asp:RegularExpressionValidator>
                </div>
            </td>
            <%--FIRST NAME ENDS--%>

            <%--LAST NAME--%>
            <td>
                
                <asp:TextBox ID="txtLastName" placeholder="LAST NAME" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLastName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtLastName" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z]{2,15}$"></asp:RegularExpressionValidator>
                </div>
            </td>
        </tr>
        <%--LAST NAME ENDS--%>


        <%--PASSWORD--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label4" runat="server" Text="PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" placeholder="123456" runat="server" Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@#$.!\s]{6,15}$"></asp:RegularExpressionValidator>
                </div>
                
            </td>
        </tr>
        <%--PASSWORD ENDS--%>

        <%--CONFIRM PASSWORD--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label5" runat="server" Text="CONFIRM PASSWORD"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtComfirmPassword" placeholder="123456" runat="server" Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtComfirmPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Min. length of the Password must be 6" ControlToValidate="txtComfirmPassword" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9'@#$.!\s]{6,15}$"></asp:RegularExpressionValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Not Matched" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ControlToValidate="txtComfirmPassword" ControlToCompare="txtPassword"></asp:CompareValidator>
                </div>
                
                
            </td>
        </tr>
        <%--CONFIRM PASSWORD ENDS--%>

        <%--MOBILE NUMBER--%>
            <tr>
                <td style="width:50%">
                        <asp:Label ID="Label15" runat="server" Text="MOBILE NUMBER"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMobileNumber" placeholder="+449999999999" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMobileNumber" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                    <div>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ErrorMessage="Invalid Mobile Number" ControlToValidate="txtMobileNumber" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^(((\+44\s?\d{4}|\(?0\d{4}\)?)\s?\d{3}\s?\d{3})|((\+44\s?\d{3}|\(?0\d{3}\)?)\s?\d{3}\s?\d{4})|((\+44\s?\d{2}|\(?0\d{2}\)?)\s?\d{4}\s?\d{4}))(\s?\#(\d{4}|\d{3}))?$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <%--MOBILE NUMBER ENDS--%>

        <%--GENDER--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label6" runat="server" Text="GENDER"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server" Height="28px" Width="208px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                    <asp:ListItem>Trans</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <%--GENDER ENDS--%>

        <%--EMAIL--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label7" runat="server" Text="EMAIL"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" placeholder="tom.holland@gmail.com" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="Invalid Email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </div>
                
            </td>
        </tr>
        <%--EMAIL ENDS--%>

        <%--ADDRESS--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label8" runat="server" Text="ADDRESS"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" placeholder="Kingston, UK" runat="server" Height="28px" Width="200px" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAddress" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--ADDRESS ENDS--%>

        <%--PASSPORT--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label16" runat="server" Text="PASSPORT"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassport" placeholder="A1234567" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassport" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ErrorMessage="Min. length of the User Name must be 6(alphanuberic)" ControlToValidate="txtPassport" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="^[a-zA-Z0-9]{6,15}$"></asp:RegularExpressionValidator>
                </div>
                
            </td>
        </tr>
        <%--PASSPORT ENDS--%>

        <%--SALARIED--%>

        <tr>
            <td>
                <asp:Label ID="Label13" runat="server" Text="SALARIED"></asp:Label>
            </td>
            <td>

                <asp:DropDownList ID="isSalaried" runat="server" Height="28px" Width="208px">
                    <asp:ListItem>YES</asp:ListItem>
                    <asp:ListItem>NO</asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>

        <%--SALARIED ENDS--%>

        <%--JOINT ACCOUNT--%>

        <tr>
            <td>
                <asp:Label ID="Label14" runat="server" Text="JOINT ACCOUNT"></asp:Label>
                <asp:CheckBox ID="cbJointAccount" runat="server" OnCheckedChanged="cbJointAccount_CheckedChanged" AutoPostBack="true" Checked="false"/>
            </td>
            <td>
                
                <asp:TextBox ID="txtAccountHolder1" placeholder="ACCOUNT HOLDER 1" runat="server" Height="28px" Width="200px" Visible="false" ></asp:TextBox>
            </td>
        </tr>

        <%--JOINT ACCOUNT ENDS--%>

        <%--JOINT ACCOUNT--%>

        <tr>
            <td>
                <asp:TextBox ID="txtAccountHolder2" placeholder="ACCOUNT HOLDER 2" runat="server" Height="28px" Width="200px" Visible="false"></asp:TextBox>
                
            </td>
            <td>
                <asp:TextBox ID="txtAccountHolder3" placeholder="ACCOUNT HOLDER 2" runat="server" Height="28px" Width="200px" Visible="false"></asp:TextBox>
                
            </td>
        </tr>

        <%--JOINT ACCOUNT ENDS--%>

        <%--SECURITY QUESTION--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label9" runat="server" Text="SECURITY QUESTION"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSecurityQuestion" runat="server" Height="28px" Width="208px" DataTextField="question_value" DataValueField="question_id" DataSourceID="ctl03">
                </asp:DropDownList>
                <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:abc_bankConnectionString %>" SelectCommand="SELECT * FROM [security_question]" ID="ctl03"></asp:SqlDataSource>
            </td>
        </tr>
        <%--SECURITY QUESTION ENDS--%>

        <%--SECURITY ANSWER--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label10" runat="server" Text="ANSWER"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnswer" runat="server" Height="28px" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAnswer" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--SECURITY ANSWER ENDS--%>

        <%--AMOUNT--%>
        <tr>
            <td style="width:50%">
                <asp:Label ID="Label11" runat="server" Text="AMOUNT"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAmount" placeholder="99999" runat="server" Height="28px" Width="200px" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAmount" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                <div>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="Invalid Amount" ControlToValidate="txtAmount" ForeColor="Red" SetFocusOnError="true" Display="Dynamic" ValidationExpression="\d{1,5}"></asp:RegularExpressionValidator>
                </div>
                <div id="errorAmount" runat="server" style="color:darkred;">

                </div>
                
            </td>
        </tr>
        <%--AMOUNT ENDS--%>

        <%--USER TYPE--%>

        <tr>
            <td>
                <asp:Label ID="Label12" runat="server" Text="USER TYPE"></asp:Label>
            </td>
            <td>
                    
                    <asp:DropDownList ID="ddlUserType" runat="server" Height="28px" Width="208px">
                        <asp:ListItem>USER</asp:ListItem>
                        <asp:ListItem>EMP</asp:ListItem>
                        <asp:ListItem>ADMIN</asp:ListItem>
                    </asp:DropDownList>
                
                </td>
        </tr>

        <%--USER TYPE ENDS--%>
        
        <%--REGISTER AND CANCEL BUTTONS--%>
        <tr>
            <td align="center">
                <asp:Button ID="btnregister" runat="server" CssClass="lnr-button" Text="REGISTER" OnClick="btnregister_Click"/>
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


</asp:Content>
