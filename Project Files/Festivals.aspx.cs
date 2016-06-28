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
using System.Drawing;

public partial class Project_Files_Festivals : System.Web.UI.Page
{
    //Vult de dropdown vanuit de Database 
    protected void Page_Load(object sender, EventArgs e)
    {
        lblUsername.Text = (string)Session["Usernaam"]; //Checkt de  SessieState voor de username van de gebruiker

        if (!this.IsPostBack) //Checkt of er postbak is
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))  //selecteert 
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Naam FROM Festival"))  //Het commando
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;  //Maakt een connectie
                    con.Open();
                    ddlFestival.DataSource = cmd.ExecuteReader();
                    ddlFestival.DataTextField = "Naam";  //Data velden
                    ddlFestival.DataValueField = "Naam";
                    ddlFestival.DataBind();
                    con.Close();
                }
            }
        }
    }
    //Dopdown Als deze verandert gaat hij de tekstboxen invullen 
    protected void ddlFestival_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtNaam.Text = "";
        txtPlaats.Text = "";
        txtBegin.Text = "";
        txtEind.Text = "";
        txtPrijs.Text = "";

        // Gemaakt: Wesley van Osch - 26-6-2016
        txtPrimaryColor.Text = "";
        txtSecondaryColor.Text = "";

        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = String.Format("SELECT * FROM Festival WHERE Naam = '{0}'", ddlFestival.Text);

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
        cmdImg.CommandText = String.Format("SELECT FestivalImage FROM Festival WHERE Naam = '{0}'", ddlFestival.Text);

        byte[] imgData = (byte[])cmdImg.ExecuteScalar();
        imgBanner.Attributes["src"] = "data:image/png" + ";base64," + Convert.ToBase64String(imgData);

    }

    //Knoppen voor het menu


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

    //Log out knop
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        Session.Clear(); //Haalt alle values leeg zodat er opnieuw iets wordt aangemaakt 
        Session.Abandon(); //Dit destroyed heel de session
        Server.Transfer("Home.aspx");  //Gaat terug naar de login page
    }
}