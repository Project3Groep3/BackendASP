<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Artiest.aspx.cs" Inherits="Project_Files_Artiest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <h1>Artiesten Pagina</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <h3>Menu</h3>
    <asp:Button ID="Button2" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="Button1" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="Button3" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
    <asp:Button ID="Button4" runat="server" Text="Button" Width="20%" BorderStyle="None" Height="50%" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
    <h1>Artiesten</h1>
    <asp:Button ID="btnToevoegen" runat="server" OnClick="btnToevoegen_Click" Text="Artiest toevoegen" Width="189px" />
    <br />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Toevoegen" Width="189px" Visible="False" />
    <br />
    <asp:Label ID="lblSelect" runat="server" Text="Selecteer een Artiest:"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="dplArtiesten" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dplArtiesten_SelectedIndexChanged" Width="120px" style="margin-bottom: 0px">
        <asp:ListItem Selected="True">Artiesten</asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Naam:"></asp:Label>
    &nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLNaam" runat="server" ReadOnly="True" Width="120px" AutoPostBack="True"></asp:TextBox>
    &nbsp;&nbsp;
    <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Wijzigen" Width="70px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnOpslaan" runat="server" OnClick="btnOpslaan_Click" Text="Opslaan" Width="70px" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLEmail" runat="server" Width="120px" ReadOnly="True" Height="25px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEdit2" runat="server" OnClick="btnEdit2_Click" Text="Wijzigen" Width="70px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnOpslaan2" runat="server" Text="Opslaan" Width="70px" OnClick="btnOpslaan2_Click" />
    &nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="lblSQLUsername" runat="server" Text="Username:"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLUsername" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEdit4" runat="server" OnClick="btnEdit2_Click" Text="Wijzigen" Width="70px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnOpslaan4" runat="server" Text="Opslaan" Width="70px" />
    <br />
    <asp:Label ID="lblPssword" runat="server" Text="Password:"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLPassword" runat="server" Width="120px" ReadOnly="True" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnEdit3" runat="server" OnClick="btnEdit2_Click" Text="Wijzigen" Width="70px" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnOpslaan3" runat="server" Text="Opslaan" Width="70px" />
    <br />
    <asp:Label ID="lblOver" runat="server" Text="Over de Artiest:"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLInfo" runat="server" Height="113px" ReadOnly="True" TextMode="MultiLine" Width="420px"></asp:TextBox>
    <br />
    <asp:Label ID="lblFest" runat="server" Text="Foto:"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlFest" runat="server" OnSelectedIndexChanged="ddlFest_SelectedIndexChanged"></asp:DropDownList>
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphZijMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <asp:Label ID="lblAuto" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblwachtwoord" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Je bent Ingelogd Als"></asp:Label>
    :<asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

