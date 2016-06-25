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

public partial class Project_Files_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    protected void btnInstellingen_Click1(object sender, EventArgs e)
    {
        Server.Transfer("SiteInstellingen.aspx");
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

        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();

        // Maak de database commands

        SqlCommand naam = new SqlCommand();

        naam.Connection = conn;  // Selecteer connection object mee
        naam.CommandText = String.Format("SELECT Naam FROM Festival WHERE Naam = '{0}'", ddlFestivals.SelectedItem.Text);  //Naam van het festival

        SqlCommand Plaats = new SqlCommand();

        Plaats.Connection = conn;  // Selecteer connection object mee
        Plaats.CommandText = String.Format("SELECT Plaats FROM Festival WHERE Naam = '{0}' ", ddlFestivals.SelectedItem.Text); //De platts

        SqlCommand Begin = new SqlCommand();
        Begin.Connection = conn;  // Selecteer connection object mee
        Begin.CommandText = String.Format("SELECT Begindatum FROM Festival WHERE Naam = '{0}' ", ddlFestivals.SelectedItem.Text);


        SqlCommand Eind = new SqlCommand();

        Begin.Connection = conn;  // Selecteer connection object mee
        Begin.CommandText = String.Format("SELECT Eindatum FROM Festival WHERE Naam = '{0}' ", ddlFestivals.SelectedItem.Text);

        SqlCommand Prijs = new SqlCommand();

        Prijs.Connection = conn;  // Selecteer connection object mee
        Prijs.CommandText = String.Format("select cast(Prijs as varchar(50))FROM Festival WHERE Naam = '{0}' ", ddlFestivals.SelectedItem.Text);

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

        //SqlDataReader dr3 = Begin.ExecuteReader();
        //while (dr3.Read())
        //{
        //        txtBegin.Text += dr3.GetString(0);
        //}
        //dr3.Close();

        //SqlDataReader dr4 = Eind.ExecuteReader();
        //while (dr4.Read())
        //{
        //    txtEind.Text += dr4.GetString(0);
        //}
        //dr4.Close();

        SqlDataReader dr5 = Prijs.ExecuteReader();
        while (dr5.Read())
        {
            txtPrijs.Text += dr5.GetString(0);
        }
        dr5.Close();

}

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))  //selecteert 
        {
            //Naam command aan maken
            SqlCommand Naam = new SqlCommand();  //Selecteert de Groep
            Naam.CommandType = CommandType.Text;
            Naam.Connection = con;  //Maakt een connectie
            Naam.CommandText = String.Format("update Festival set Naam = @Naam where Naam =  '{0}' ", ddlFestivals.SelectedItem.Text);

            //Plaats command aanmaken
            SqlCommand Plaats = new SqlCommand();  //Selecteert de Groep
            Plaats.CommandType = CommandType.Text;
            Plaats.Connection = con;  //Maakt een connectie
            Plaats.CommandText = String.Format("update Festival set Plaats = @Plaats where Naam =  '{0}' ", ddlFestivals.SelectedItem.Text);
            {
                con.Open();
                //De Naam Update
                Naam.Parameters.AddWithValue("Naam", ddlFestivals.SelectedItem.Text);
                Naam.ExecuteNonQuery();

                //De Plaats Update
                Plaats.Parameters.AddWithValue("Plaats", ddlFestivals.SelectedItem.Text);
                Plaats.ExecuteNonQuery();

                //Hij verandert values nog niet en moet ik ff nakijken met sql 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wijziging compleet');", true); //Geeft een bevestigins popup als het gelukt is
                con.Close();
            }
        }
    }
}