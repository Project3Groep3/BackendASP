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
using System.Web.SessionState;

public partial class Project_Files_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Wist de tekst van de tabel
       lblTest.Text = "";

        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();

        // Maak de database commands

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;  // Selecteer connection object mee
        cmd.CommandText = String.Format("SELECT cast([Type] as varchar(50)) FROM Users WHERE Username = '{0}' ", txtUsername.Text);

        // Zend het database commando en ontvang data terug.
        SqlDataReader dr = cmd.ExecuteReader();

        while (dr.Read())
        {
            lblTest.Text += dr.GetString(0);
        }

        dr.Close();

        conn.Close();
    }

    //login knop
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        SqlDataAdapter adp = new SqlDataAdapter(); //Nieuwe database adapter
        try
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Login_Check", con);  //Pakt de parameter die aangemaakt is in sql
            cmd.CommandType = CommandType.StoredProcedure; 
            cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            cmd.Parameters.AddWithValue("@pwd", txtPassword.Text.Trim());   //Haalt alles uit de strings
            adp.SelectCommand = cmd;
            adp.Fill(dt);
            cmd.Dispose();
            if (dt.Rows.Count > 0)
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Login Successvol";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Login Succesvol');", true);
                //Server.Transfer("Home.aspx", true);
                // Sla authorisatie op in een SessionState
                Session["Auto"] = lblTest.Text;
                Session["Usernaam"] = txtUsername.Text;
                Session["Wachtwoord"] = txtPassword.Text;
                //Validatie regelt naar welke pagina je geredirect wordt
                if (lblTest.Text == "0")
                {
                    Server.Transfer("Admin.aspx", true);
                }
                else if (lblTest.Text == "1")
                {
                    Server.Transfer("FestivalManager.aspx");
                }
                else if (lblTest.Text == "2")
                {
                    Server.Transfer("Artiest.aspx");
                }
            }
            else
            {
                lblStatus.Visible = true;
                lblStatus.Text = "Foute Gebruikersnaam of Wachtwoord";
                //test 
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Foute Username/Password');", true);
            }
        }
        finally
        //Ruimt alle restjes op
        {
            dt.Clear();
            dt.Dispose();
            adp.Dispose();
        }
    }

    //Was eer bedoeld om terug te gaan naar de login
    //Maakt nu de textboxen leeg en dat doe hij nu
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("Home.aspx");
    }
   
}