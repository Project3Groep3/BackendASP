﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Edit.aspx.cs" Inherits="Project_Files_Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--Head content-->
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <!--Kop tekst-->
    <h1>Festival Bewerker</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <!--Menu-->
    <h3>Menu</h3>
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Bewerk Festivals" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnEdit_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphTekst" Runat="Server">
    <!--Middelste tekst-->
    <h1>Festival Bewerker</h1>
    Bewerk een Festival<br />
    <asp:DropDownList ID="ddlFestivals" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFestivals_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Image ID="imgBanner" runat="server" Width="250" Height="250" />
    <br />
    <asp:FileUpload ID="imgUpload" runat="server" />
    <br />
    <asp:Label ID="lblNaam" runat="server" Text="Naam:"></asp:Label>
    <br />
    <asp:TextBox ID="txtNaam" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPlaats" runat="server" Text="Plaats:"></asp:Label>
    <br />
    <asp:TextBox ID="txtPlaats" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblBegin" runat="server" Text="Begin Datum:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBegin" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblEind" runat="server" Text="Eind Datum:"></asp:Label>
    <br />
    <asp:TextBox ID="txtEind" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblPrijs" runat="server" Text="Prijs:"></asp:Label>
    <br />
    <asp:TextBox ID="txtPrijs" runat="server"></asp:TextBox>
    <br />
    <h2>Thema</h2>
    <asp:Label ID="lblPrimaryColor" runat="server" Text="Primaire Kleur:"></asp:Label>
    &nbsp;<br />
    <asp:TextBox ID="txtPrimaryColor" runat="server"></asp:TextBox>
    <br />
    &nbsp;<br />
    <asp:Label ID="lblSecondaryColor" runat="server" Text="Secundaire Kleur:"></asp:Label>
    <br />
    &nbsp;<asp:TextBox ID="txtSecondaryColor" runat="server" ></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="lblFontColor" runat="server" Text="Tekst Kleur:"></asp:Label>
&nbsp;<br />
    <asp:TextBox ID="txtFontColor" runat="server"></asp:TextBox>
    <br />
    <br />
    <br />
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update het Festival" Width="168px" />
&nbsp;
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij menu-->
    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" BorderStyle="None" Height="5%" Width="50%" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <!--Rechtse tekst-->
        <asp:Label ID="Label3" runat="server" Text="Je bent Ingelogd Als:"></asp:Label>
    <br />
    <asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

