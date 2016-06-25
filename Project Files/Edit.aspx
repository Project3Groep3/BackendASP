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
    Bewerk een Festival<br />
    <br />
    <asp:DropDownList ID="ddlFestivals" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFestivals_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
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
    <br />
    <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update het Festival" Width="168px" />
&nbsp;
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphZijMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

