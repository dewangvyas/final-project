<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="AllUsers.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.AllUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div align="center">
        <div>
            <h4>USER DATA</h4>
        </div>
        <div style="padding:20px;overflow:scroll; text-align:center;">
            <asp:GridView ID="gvAllUsers" runat="server" AutoGenerateColumns="False" CssClass="table-striped table table-hover table-center table-responsive all-users" DataKeyNames="account_id" OnRowEditing="gvAllUsers_RowEditing" AllowPaging="True" PageSize="11" OnRowUpdating="gvAllUsers_RowUpdating" OnRowCancelingEdit="gvAllUsers_RowCancelingEdit" OnRowDeleting="gvAllUsers_RowDeleting" AllowSorting="True">
                <Columns>


                    <asp:BoundField DataField="account_id" HeaderText="ACCOUNT ID" ReadOnly="True"></asp:BoundField>
                    <asp:BoundField DataField="account_number" HeaderText="ACCOUNT NUMBER" ReadOnly="True"></asp:BoundField>
                    <asp:BoundField DataField="user_name" HeaderText="USERNAME"></asp:BoundField>
                    <asp:BoundField DataField="user_password" HeaderText="PASSWORD"></asp:BoundField>
                    <asp:BoundField DataField="first_name" HeaderText="FIRST NAME"></asp:BoundField>
                    <asp:BoundField DataField="last_name" HeaderText="LAST NAME"></asp:BoundField>
                    <asp:BoundField DataField="gender" HeaderText="GENDER"></asp:BoundField>
                    <asp:BoundField DataField="email" HeaderText="EMAIL"></asp:BoundField>
                    <asp:BoundField DataField="mobile" HeaderText="MOBILE"></asp:BoundField>
                    <asp:BoundField DataField="passport" HeaderText="PASSPORT"></asp:BoundField>
                    <asp:BoundField DataField="address" HeaderText="ADDRESS"></asp:BoundField>
                    <asp:BoundField DataField="user_type" HeaderText="PRIVILEGES" ReadOnly="True"></asp:BoundField>
                    <asp:BoundField DataField="user_balance" HeaderText="AMOUNT"></asp:BoundField>
                    <asp:BoundField DataField="timestamp" HeaderText="START TIME" ReadOnly="True"></asp:BoundField>


                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ButtonType="Button">
                        <ControlStyle CssClass="edit-delete"></ControlStyle>
                    </asp:CommandField>

                </Columns>

                <EditRowStyle HorizontalAlign="Center"></EditRowStyle>

<PagerStyle HorizontalAlign="Center" VerticalAlign="Middle"></PagerStyle>



            </asp:GridView>
        </div>

        <div id="error" runat="server" style="color:darkred;">

        </div>

    </div>

</asp:Content>
