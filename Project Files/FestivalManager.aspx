<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="FestivalManager.aspx.cs" Inherits="Project_Files_FestivalManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <h1>Manager</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <h3>Menu</h3>
    <asp:Button ID="btnInstellingen" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnData" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnEdit" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnArtiest" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    </asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
    <h1>Festivals</h1>
    <asp:Label ID="lblSelect" runat="server" Text="Selecteer een Festival"></asp:Label>
    <br />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphZijMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <asp:Label ID="lblAuto" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Je bent Ingelogd Als"></asp:Label>
    :<asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

