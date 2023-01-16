<%@ Page Title="" Language="C#" MasterPageFile="~/MainMenu.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPH" runat="server">

    <div class="container-div">
        
        <div style="text-align:center;font-size:30px;">
            <h4 class="dashboard-header">DASHBOARD</h4>
        </div>


        <div class="row-eq-height d-flex" style="text-align:center;">

            <div class="col-xs-4 flex-fill dashboard-content">

                <h6 class="dashboard-h6-div content-1">
                    TOTAL NO. TRANSACTION
                </h6>

                <asp:Label CssClass="dashboard-label-class" ID="lblTotalTransaction" runat="server"></asp:Label>

            </div>

            <div class="col-xs-4 flex-fill dashboard-content">

                <h6 class="dashboard-h6-div content-2">
                    TOTAL AMOUNT
                </h6>

                <asp:Label CssClass="dashboard-label-class" ID="lblTotalAmount" runat="server"></asp:Label>
            </div>

            <div class="col-xs-4 flex-fill dashboard-content">

                <h6 class="dashboard-h6-div content-3">
                    TOTAL USERS
                </h6>

                <asp:Label CssClass="dashboard-label-class" ID="TotalUser" runat="server"></asp:Label>
            </div>

            <div class="col-xs-4 flex-fill dashboard-content">

                <h6 class="dashboard-h6-div content-4">
                    TOTAL EMPLOYEES
                </h6>

                <asp:Label CssClass="dashboard-label-class" ID="TotalEmployee" runat="server"></asp:Label>
            </div>
        </div>

    </div>

</asp:Content>
