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


        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();

        // Maak de database commands

        SqlCommand naam = new SqlCommand();

        naam.Connection = conn;  // Selecteer connection object mee
        naam.CommandText = String.Format("SELECT Naam FROM Festival WHERE Naam = '{0}'", ddlFestival.SelectedItem.Text);  //Naam van het festival

        SqlCommand Plaats = new SqlCommand();

        Plaats.Connection = conn;  // Selecteer connection object mee
        Plaats.CommandText = String.Format("SELECT Plaats FROM Festival WHERE Naam = '{0}' ", ddlFestival.SelectedItem.Text); //De platts

        SqlCommand Begin = new SqlCommand();
        Begin.Connection = conn;  // Selecteer connection object mee
        Begin.CommandText = String.Format("SELECT cast(Begindatum as varchar(50)) FROM Festival WHERE Naam = '{0}' ", ddlFestival.SelectedItem.Text);


        SqlCommand Eind = new SqlCommand();

        Eind.Connection = conn;  // Selecteer connection object mee
        Eind.CommandText = String.Format("SELECT cast(Einddatum as varchar(50)) FROM Festival WHERE Naam = '{0}' ", ddlFestival.SelectedItem.Text);

        SqlCommand Prijs = new SqlCommand();

        Prijs.Connection = conn;  // Selecteer connection object mee
        Prijs.CommandText = String.Format("select cast(Prijs as varchar(50))FROM Festival WHERE Naam = '{0}' ", ddlFestival.SelectedItem.Text);

        // Zend het database commando en ontvang data terug.
        SqlDataReader dr = naam.ExecuteReader();

        while (dr.Read())
        {
            txtNaam.Text += dr.GetString(0);
        }
        dr.Close();

        SqlDataReader dr2 = Plaats.ExecuteReader();
        while (dr2.Read())
        {
            txtPlaats.Text += dr2.GetString(0);
        }
        dr2.Close();

        SqlDataReader dr3 = Begin.ExecuteReader();
        while (dr3.Read())
        {
                txtBegin.Text += dr3.GetString(0);
        }
        dr3.Close();

        SqlDataReader dr4 = Eind.ExecuteReader();
        while (dr4.Read())
        {
            txtEind.Text += dr4.GetString(0);
        }
        dr4.Close();

        SqlDataReader dr5 = Prijs.ExecuteReader();
        while (dr5.Read())
        {
            txtPrijs.Text += dr5.GetString(0);
        }
        dr5.Close();
    }

    //Knoppen voor het menu

    protected void btnInstellingen_Click(object sender, EventArgs e)
    {
        Server.Transfer("SiteInstellingen.aspx");
    }

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
}