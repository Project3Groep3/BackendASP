<%@ Page Title="" Language="C#" MasterPageFile="~/Project Files/MasterPage.master" AutoEventWireup="true" CodeFile="Artiest.aspx.cs" Inherits="Project_Files_Artiest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--Head Content-->
    <link href="../CSS/StyleSheet.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphKop" Runat="Server">
    <!--Kop tekst-->
    <h1>Artiesten Pagina</h1>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphMenu" Runat="Server">
    <!--Menu-->
    <h3>Menu</h3>
    <asp:Button ID="btnData" runat="server" Text="Festival Data" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnData_Click" />
    <asp:Button ID="btnEditMenu" runat="server" Text="Bewerk Festivals" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnEditMenu_Click" />
    <asp:Button ID="btnArtiest" runat="server" Text="Artiesten" Width="26.67%" BorderStyle="None" Height="50%" OnClick="btnArtiest_Click" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="cphTekst" Runat="Server">
    <!--Middelste tekst-->
    <h1>&nbsp;</h1>
    <h1>Artiesten</h1>
    <asp:Label ID="lblSelect" runat="server" Text="Selecteer een Artiest:"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlArtiest" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlArtiest_SelectedIndexChanged" Width="120px" style="margin-bottom: 0px">
        <asp:ListItem Selected="True">Artiesten</asp:ListItem>
    </asp:DropDownList>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Image ID="imgArtiest" runat="server" Width="250" Height="250" />
    <br />
    <asp:FileUpload ID="imgUpload" runat="server" />
    <br />
    <asp:Button ID="btnImage" runat="server" OnClick="btnImage_Click" Text="Opslaan" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Naam:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLNaam" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
    &nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;<br />
&nbsp;<br />
    <asp:Label ID="lblPssword0" runat="server" Text="Username:"></asp:Label>
    <br />
    <asp:TextBox ID="txtSQLUsername" runat="server" Width="120px" ReadOnly="True"></asp:TextBox>
    &nbsp;
    <br />
&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="lblPssword" runat="server" Text="Password:"></asp:Label>
    <br />
    <asp:TextBox ID="txtSQLPassword" runat="server" Width="120px" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Button ID="btnPassword" runat="server" Text="Opslaan" Width="70px" OnClick="btnPassword_Click" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
    <br />
    <asp:TextBox ID="txtSQLEmail" runat="server" Width="121px" Height="25px"></asp:TextBox>
    <br />
    <asp:Button ID="btnEmail" runat="server" Text="Opslaan" Width="70px" OnClick="btnEmail_Click" />
    <br />
    <br />
    <asp:Label ID="lblOver" runat="server" Text="Over de Artiest:"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtSQLInfo" runat="server" Height="113px" TextMode="MultiLine" Width="420px"></asp:TextBox>
    <br />
    <asp:Button ID="btnContent" runat="server" OnClick="btnContent_Click" Text="Opslaan" />
    <br />
    <br />
    </asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphZijMenu" Runat="Server">
    <!--Zij menu-->
    <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" BorderStyle="None" Height="5%" Width="50%" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphRechts" Runat="Server">
    <!--Rechtse tekst-->
    <asp:Label ID="lblAuto" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lblwachtwoord" runat="server" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Je bent Ingelogd Als:"></asp:Label>
    <br />
    <asp:Label ID="lblUsername" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>

