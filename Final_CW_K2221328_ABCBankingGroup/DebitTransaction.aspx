<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="DebitTransaction.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.DebitTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div align="center">
        <div>
            <h4 style="padding:30px;">MY DEBITS</h4>
        </div>
        <asp:GridView ID="gvMyDebits" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover table-center gvDebit">
            <Columns>

                <%--ACCOUNT NUMBER--%>
                <asp:TemplateField HeaderText="TO ACCOUNT">
                    <ItemTemplate>
                        <asp:Label ID="accNumber" runat="server" Text='<%# Eval("account_number") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <%--ACCOUNT NUMBER ENDS--%>

                <%--PAYEE NAME--%>
                <asp:TemplateField HeaderText="PAYEE NAME">
                    <ItemTemplate>
                        <asp:Label ID="payeeName" runat="server" Text='<%# Eval("user_name") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <%--PAYEE NAME ENDS--%>

                <%--AMOUNT--%>
                <asp:TemplateField HeaderText="AMOUNT">
                    <ItemTemplate>
                        <asp:Label ID="amount" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <%--AMOUNT ENDS--%>

                <%--REMARKS--%>
                <asp:TemplateField HeaderText="REMARKS">
                    <ItemTemplate>
                        <asp:Label ID="remarks" runat="server" Text='<%# Eval("remarks") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <%--REMARKS ENDS--%>

                <%--TIMESTAMP--%>
                <asp:TemplateField HeaderText="TIMESTAMP">
                    <ItemTemplate>
                        <asp:Label ID="timestamp" runat="server" Text='<%# Eval("timestamp") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>
                <%--REMARKS ENDS--%>

            </Columns>

        </asp:GridView>

        <div id="error" runat="server" style="color:darkred;"></div>

    </div>


</asp:Content>
