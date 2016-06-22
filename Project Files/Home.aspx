<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Project_Files_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" /> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <h1>Welkom Op Deze Site</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <h3>Menu</h3>
    <asp:Button ID="btnLogout" runat="server" Text="Log Uit" BackColor="Red" BorderStyle="None" Font-Bold="True" ForeColor="Black" Height="29px" OnClick="btnLogout_Click" style="margin-top: 0px" Width="257px" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

