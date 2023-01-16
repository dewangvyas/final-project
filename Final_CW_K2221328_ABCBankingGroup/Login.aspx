<%@ Page Title="" Language="C#" MasterPageFile="~/TopHeader.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body{
            font-family: Lato,sans-serif;
        }
        
        .forgot-password{
            color:darkblue;
            margin-bottom: 30px;
        }
        .button-margin{
            margin:10px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="padding:30px;">
        <table align="center">

            <%--HEADER--%>
            <tr>
                <td colspan="4" align="center">
                    <h4>LOGIN</h4>
                </td>
            </tr>
            <%--HEADER ENDS--%>

            <%--USERNAME--%>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" placeholder="Eg: TomHolland@123" runat="server" Height="28px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsername" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td style="padding-right:40px;">
                
                </td>
            
            </tr>
            <%--USERNAME ENDS--%>

            <%--PASSWORD--%>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Height="28px" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
                <td></td>
                <td></td>
            </tr>
            <%--PASSWORD ENDS--%>

            <%--USERTYPE--%>
            <tr>
                <td></td>
                <td>
                    
                    <asp:DropDownList ID="ddlUserType" runat="server" Height="28px" Width="208px">
                        <asp:ListItem>USER</asp:ListItem>
                        <asp:ListItem>EMP</asp:ListItem>
                        <asp:ListItem>ADMIN</asp:ListItem>
                    </asp:DropDownList>
            
                </td>
                <td></td>
                <td></td>
            </tr>
            <%--USERTYPE ENDS--%>

            <%--ERROR DIV--%>
            <tr>
                <td></td>
                <td>
                    <div id="error" runat="server" style="color:darkred;">

                    </div>
                    <div id="errorRetry" runat="server" style="color:darkred;">

                    </div>
                </td>
            </tr>
            <%--ERROR DIV ENDS--%>

            <%--BUTTONS--%>
            <tr>
                <td colspan="2" style="padding-left:77px;">
                    <asp:Button ID="btnLogin" runat="server" CssClass="lnr-button button-margin" Text="LOGIN" OnClick="btnLogin_Click"/>
                    
                    <asp:Button ID="btnregister" runat="server" CssClass="lnr-button button-margin" Text="Register USER" OnClick="btnregister_Click"
                        CausesValidation="false"/>
                    <asp:Label ID="Label3" runat="server" Text="Or"></asp:Label>
                    <asp:Button ID="btnRegisterEmp" runat="server" CssClass="lnr-button button-margin" Text="Register EMP" OnClick="btnRegisterEmp_Click"
                        CausesValidation="false"/>
                </td>
            
            </tr>
            <%--BUTTONS ENDS--%>

            <%--FORGOT PASSWORD--%>
            <tr>
                <td colspan="2" style="padding-left:85px;">
                    <asp:LinkButton ID="lbForgotPassword" CssClass="forgot-password" runat="server" CausesValidation="false" OnClick="lbForgotPassword_Click">Forgot Password</asp:LinkButton>
                </td>
            </tr>

            <%--FORGOT PASSWORD ENDS--%>

        </table>

    </div>

</asp:Content>
