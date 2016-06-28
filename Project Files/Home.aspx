<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Project_Files_Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--head inhoud-->
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <h1>Welkom Op Deze Site</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <!--Het button Menu -->
    <h3>Menu</h3>
    <h2>Log in voor het Menu</h2>
    </asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
      <!--Middelste tekst-->
    <h1>Log In</h1>
    <div id="LoginForm" draggable="false">
        <table class="auto-style1" draggable="false">
            <tr>
                <td class="auto-style2"> 
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label></td>
                <td class="auto-style3"> <asp:TextBox ID="txtUsername" runat="server" style="margin-top: 1px; margin-left: 0px;" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Label2" runat="server" Text="WachtWoord"></asp:Label></td>
                <td class="auto-style3"> <asp:TextBox ID="txtPassword" runat="server" Width="162px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" Height="24px" />
                </td>
                <td class="auto-style3">
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Terug" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Status"></asp:Label>
                </td>
                <td class="auto-style3">
        <asp:Label ID="lblStatus" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        </div>
        <asp:Label ID="lblTest" runat="server" Text="" Visible="False"></asp:Label>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij Menu-->
    <h2>Mojo</h2>
    </asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <!--rechtse menu-->
    <p>
        Je bent nog niet ingelogd</p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphFooter" Runat="Server">
    <footer>Hallo test</footer>
</asp:Content>

