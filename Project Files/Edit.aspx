<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Project_Files_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <h3>Menu</h3>
    <asp:Button ID="btnInstellingen" runat="server" Text="Thema's en Site Instellingen" Width="20%" BorderStyle="None" Height="50%" OnClick="btnInstellingen_Click1" />
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="20%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="20%" BorderStyle="None" Height="50%" OnClick="btnEdit_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="20%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTekst" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

