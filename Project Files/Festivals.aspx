<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Festivals.aspx.cs" Inherits="Project_Files_Festivals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <h3>Menu</h3>
    <asp:Button ID="btnInstellingen" runat="server" Text="Thema's en site Instellingen" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="20%" BorderStyle="None" Height="50%" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTekst" Runat="Server">
    <h1>Festival Data</h1>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblSelect" runat="server" Text="Selecteer een Festival"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlFestival" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFestival_SelectedIndexChanged" style="margin-left: 0px" Width="147px"></asp:DropDownList>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblNaam" runat="server" Text="Naam:"></asp:Label>
&nbsp;<asp:TextBox ID="txtNaam" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblPlaats" runat="server" Text="Plaats:"></asp:Label>
&nbsp;
    <asp:TextBox ID="txtPlaats" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblBegin" runat="server" Text="Begin Datum:"></asp:Label>
&nbsp;<asp:TextBox ID="txtBegin" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
&nbsp;<asp:Label ID="lblEind" runat="server" Text="Eind Datum:"></asp:Label>
&nbsp;<asp:TextBox ID="txtEind" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblPrijs" runat="server" Text="Prijs:"></asp:Label>
&nbsp;<asp:TextBox ID="txtPrijs" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

