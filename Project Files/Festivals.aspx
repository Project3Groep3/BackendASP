<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Festivals.aspx.cs" Inherits="Project_Files_Festivals" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--Head content-->
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <!--Kop tekst-->
    <h1>Festivals</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <!--Het button Menu -->
    <h3>Menu</h3>
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnEdit_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTekst" Runat="Server">
    <!--Middelste tekst-->
    <h1>Festival Data</h1>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblSelect" runat="server" Text="Selecteer een Festival"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlFestival" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFestival_SelectedIndexChanged" style="margin-left: 0px" Width="147px"></asp:DropDownList>
    <br />
    <asp:Image ID="imgBanner" runat="server" Width="250px" Height="250px" />
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
    <br />
    <h2>Thema</h2>
    <asp:Label ID="lblPrimaryColor" runat="server" Text="Primaire Kleur:"></asp:Label>
    &nbsp;<asp:TextBox ID="txtPrimaryColor" runat="server" ReadOnly="True"></asp:TextBox>
    &nbsp;<br />
    <asp:Label ID="lblSecondaryColor" runat="server" Text="Secundaire Kleur:"></asp:Label>
    &nbsp;<asp:TextBox ID="txtSecondaryColor" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblFontColor" runat="server" Text="Tekst Kleur:"></asp:Label>
&nbsp;<asp:TextBox ID="txtFontColor" runat="server" ReadOnly="True"></asp:TextBox>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij Menu-->
    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" BorderStyle="None" Height="5%" Width="50%" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
      <!--Rechtse tekst-->
        <asp:Label ID="Label3" runat="server" Text="Je bent Ingelogd Als"></asp:Label>
    :<asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

