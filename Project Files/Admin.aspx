<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Project_Files_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <!--Kop tekst-->
    <h1>Home</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <!--Het MEnu-->
    <h3>Menu</h3>
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnEdit_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
    </asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
    <!--Middelste tekst-->
    <h1>Admin Login</h1>
    <p>Welkom op de admin site <br />
        Hier kan je nu alles editen en updaten
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij Menu-->
    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" BorderStyle="None" Height="5%" Width="50%" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <!--Rechtse menu-->
    <asp:Label ID="lblAuto" runat="server" Text="lblAuto" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblAls" runat="server" Text="Je bent Ingelogd Als:"></asp:Label>
    <br />
    <asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">

</asp:Content>

