<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="FestivalManager.aspx.cs" Inherits="Project_Files_FestivalManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <!--Head content-->
    <link href="../CSS/StyleSheet.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
        <!--Kop tekst-->
    <h1>Manager</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
     <!--Menu-->
    <h3>Menu</h3>
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnEdit_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
    </asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
     <!--Middelste tekst-->
    <h1>Festivals</h1>
    <br />
    <br />
    <h3>Hoe je deze site gebruikt</h3>
    <p>Je kant festivals bewerken op de "Bewerk Festivals", site <br />
        Je kan festival data ophalen bij festival Data. <br />
        Je kan artiesten: Data ophalen, Gegevens wijzigen en artiesten toevoegen.
    </p>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij menu-->
    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" BorderStyle="None" Height="5%" Width="50%" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
      <!--Rechtse tekst-->
    <asp:Label ID="lblAuto" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:Label ID="lblAls" runat="server" Text="Je bent Ingelogd Als:"></asp:Label>
    <br />
    <asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

