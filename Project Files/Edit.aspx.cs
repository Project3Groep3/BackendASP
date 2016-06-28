using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Collections;
using System.IO;
using System.Text;
using System.Data.SqlTypes;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

public partial class Project_Files_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsername.Text = (string)Session["Usernaam"]; //Checkt de  SessieState voor de username van de gebruiker

        //Textbox Vullen
        if (!this.IsPostBack) //Checkt of er postbak is
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))  //De nieuwe connectie
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Naam FROM Festival"))  //Het commando
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;  //Maakt een connectie
                    con.Open();
                    ddlFestivals.DataSource = cmd.ExecuteReader();
                    ddlFestivals.DataTextField = "Naam";  //Data velden
                    ddlFestivals.DataValueField = "Naam";
                    ddlFestivals.DataBind();
                    con.Close();
                }
            }
        }
    }

    //Knoppen voor menu 
    protected void btnData_Click(object sender, EventArgs e)
    {
        Server.Transfer("Festivals.aspx");
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Server.Transfer("Edit.aspx");
    }

    protected void btnArtiest_Click(object sender, EventArgs e)
    {
        Server.Transfer("Artiest.aspx");
    }

    //Dropbox filler
    protected void ddlFestivals_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Maakt de textboxen standaard leeg iedere keer als hij update
        txtNaam.Text = "";
        txtPlaats.Text = "";
        txtBegin.Text = "";
        txtEind.Text = "";
        txtPrijs.Text = "";
        txtPrimaryColor.Text = "";
        txtSecondaryColor.Text = "";
        txtFontColor.Text = "";

        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();


        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = String.Format("SELECT * FROM Festival WHERE Naam = '{0}'", ddlFestivals.Text);

        // Execute het command
        int ID = 0;
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            // Festival Naam
            txtNaam.Text = reader.GetString(1);

            // Plaats Naam
            txtPlaats.Text = reader.GetString(2);

            // Begin Datum
            string begin = reader.GetDateTime(3).ToString("yyyy-MM-dd");
            string[] splBegin = begin.Split('-');
            txtBegin.Text = splBegin[2] + "-" + splBegin[1] + "-" + splBegin[0];

            // Eind Datum
            string eind = reader.GetDateTime(4).ToString("yyyy-MM-dd");
            string[] splEind = eind.Split('-');
            txtEind.Text = splEind[2] + "-" + splEind[1] + "-" + splEind[0];

            // Prijs
            txtPrijs.Text = Math.Round(reader.GetDecimal(5), 2).ToString();

            // ID voor thema
            ID = reader.GetInt32(0);
        }
        reader.Close();

        // De kleuren
        SqlCommand cmdColor = new SqlCommand();
        cmdColor.Connection = conn;
        cmdColor.CommandText = String.Format("SELECT * FROM Themas WHERE FestivalID = '{0}'", ID);

        SqlDataReader colorReader = cmdColor.ExecuteReader();

        while (colorReader.Read())
        {
            // Primary Color
            txtPrimaryColor.Text = colorReader.GetString(1);

            // Secondary Color
            txtSecondaryColor.Text = colorReader.GetString(2);

            // Font Color
            txtFontColor.Text = colorReader.GetString(3);
        }
        colorReader.Close();

        // De afbeelding, moet in aparten SELECT omdat ik het als scalar moet executen
        SqlCommand cmdImg = new SqlCommand();
        cmdImg.Connection = conn;
        cmdImg.CommandText = String.Format("SELECT FestivalImage FROM Festival WHERE Naam = '{0}'", ddlFestivals.Text);

        byte[] imgData = (byte[])cmdImg.ExecuteScalar();
        imgBanner.Attributes["src"] = "data:image/png" + ";base64," + Convert.ToBase64String(imgData);
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))  //selecteert 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            // Welke van de twee regels er moet worden gebruikt, met of zonder image
            if (imgUpload.FileBytes.Length > 0)
            {
                cmd.CommandText = String.Format("UPDATE Festival SET Naam = @Naam, Plaats = @Plaats, Begindatum = @BeginDatum, Einddatum = @EindDatum, Prijs = @Prijs, FestivalImage = @FestivalImage WHERE Naam = '{0}'", ddlFestivals.SelectedItem.Text);
            }
            else
            {
                cmd.CommandText = String.Format("UPDATE Festival SET Naam = @Naam, Plaats = @Plaats, Begindatum = @BeginDatum, Einddatum = @EindDatum, Prijs = @Prijs WHERE Naam = '{0}'", ddlFestivals.SelectedItem.Text);
            }

            // Open de connectie
            con.Open();

            // Naam Toevoegen
            cmd.Parameters.AddWithValue("Naam", txtNaam.Text);

            // Plaats Toevoegen
            cmd.Parameters.AddWithValue("Plaats", txtPlaats.Text);

            // Begin Datum Toevoegen en formatten
            string[] splBegin = txtBegin.Text.Split('-');
            string beginDatum = splBegin[2] + "/" + splBegin[1] + "/" + splBegin[0];

            cmd.Parameters.AddWithValue("BeginDatum", SqlDbType.Date).Value = beginDatum;

            // Eind Datum Toevoegen en formatten
            string[] splEind = txtEind.Text.Split('-');
            string eindDatum = splEind[2] + "/" + splEind[1] + "/" + splEind[0];

            cmd.Parameters.AddWithValue("EindDatum", SqlDbType.Date).Value = eindDatum;

            // Prijs Toevoegen
            cmd.Parameters.AddWithValue("Prijs", SqlDbType.Money).Value = float.Parse(txtPrijs.Text);

            // Festival Image Toevoegen
            if (imgUpload.FileBytes.Length > 0)
            {
                cmd.Parameters.AddWithValue("FestivalImage", SqlDbType.Image).Value = imgUpload.FileBytes;
            }

            // Main Command Executen
            cmd.ExecuteNonQuery();

            // Sub Query Command
            SqlCommand sub = new SqlCommand();
            sub.Connection = con;
            sub.CommandText = String.Format("SELECT FestivalID FROM Festival WHERE Naam =  '{0}'", ddlFestivals.SelectedItem.Text);

            // Sub Query Uitlezen
            int subID = 0;
            SqlDataReader subRead = sub.ExecuteReader();
            while (subRead.Read())
            {
                subID = subRead.GetInt32(0);
            }
            subRead.Close();

            // Thema Command
            SqlCommand cmdColor = new SqlCommand();
            cmdColor.CommandType = CommandType.Text;
            cmdColor.Connection = con;
            cmdColor.CommandText = String.Format("UPDATE Themas SET PrimaryColor = @PrimaryColor, SecondaryColor = @SecondaryColor, FontColor = @FontColor WHERE FestivalID = '{0}'", subID);

            // Primary Color Toevoegen
            cmdColor.Parameters.AddWithValue("PrimaryColor", txtPrimaryColor.Text);

            // Secondary Color Toevoegen
            cmdColor.Parameters.AddWithValue("SecondaryColor", txtSecondaryColor.Text);

            // Font Color Toevoegen
            cmdColor.Parameters.AddWithValue("FontColor", txtFontColor.Text);

            // Kleur Command Executen
            cmdColor.ExecuteNonQuery();

            //Bevestiging
            //Werkt niet omdat je Refresht kan gebruikt worden als javascript popup 
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wijziging compleet');", true); //Geeft een bevestigins popup als het gelukt is

            // Sluit Connectie
            con.Close();

            // Pagina Refresh
            Response.Redirect(Request.RawUrl);
        }
    }
    //Log out knop
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        Session.Clear(); //Haalt alle values leeg zodat er opnieuw iets wordt aangemaakt 
        Session.Abandon(); //Dit destroyed heel de session
        Server.Transfer("Home.aspx");  //Gaat terug naar de login page
    }
}