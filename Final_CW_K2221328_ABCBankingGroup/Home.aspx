<%@ Page Title="" Language="C#" MasterPageFile="~/HomeHeader.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final_CW_K2221328_ABCBankingGroup.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentHH" runat="server">

    <div>
        <div class="container-div">
            <div><h1>ABC BANK</h1></div>
            <div  class="header-col-div">
                <div class="header-col"><span class="header-col-text">PLAN SMARTER</span>, stay ahead</div>
                <div class="header-col"><span class="header-col-text">OPEN ACCOUNT</span> Within A DAY</div>
                <div class="header-col"><span class="header-col-text">QUICK SERVICES</span> To Stay Up-To-Date</div>
            </div>
            <div align="center" style="padding:20px;">
                <div class="login-button"><asp:HyperLink ID="HyperLink1" CssClass="nav-item-home" runat="server" NavigateUrl="Register.aspx">REGISTER</asp:HyperLink></div>
                
            </div>
        </div>
        <div>
            
        </div>
    </div>
</asp:Content>
