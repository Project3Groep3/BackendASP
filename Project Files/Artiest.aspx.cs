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


public partial class Project_Files_Artiest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblAuto.Text = (string)Session["Auto"]; //Checkt de SessieState
        lblUsername.Text = (string)Session["Usernaam"]; //Checkt de SessieState
        lblwachtwoord.Text = (string)Session["Wachtwoord"]; //Checkt de SessieState
        if (lblAuto.Text == "0")
        {

        }
        else if(lblAuto.Text == "1")
        {

        }
        else if(lblAuto.Text == "2")
        {
            dplArtiesten.Visible = false;
            lblSelect.Visible = false;
            btnToevoegen.Visible = false;
            txtSQLUsername.Text = lblUsername.Text;
            txtSQLPassword.Text = lblwachtwoord.Text;
            //Begin SQL Code om de naam en de email op te halen
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            conn.Open();
            //Hierboven staat de Connectie
            SqlCommand naam = new SqlCommand();
            naam.Connection = conn;  // Selecteer connection object mee
            //Hier komt het stuk voor het ophalen van de naam
            naam.CommandText = String.Format("SELECT Naam FROM Artiesten WHERE Naam = '{0}'", lblUsername.Text);
            SqlDataReader drNaam = naam.ExecuteReader();

            drNaam.Read();
            {
                txtSQLNaam.Text += drNaam.GetString(0);
            }
            drNaam.Close();
            //Hier komt het stuk voor het ophalen van de email
            SqlConnection conn2 = new SqlConnection();
            SqlCommand email = new SqlCommand();

            email.Connection = conn;  // Selecteer connection object mee
            email.CommandText = String.Format("SELECT Email FROM Artiesten WHERE Naam = 'Seal'");
            SqlDataReader drEmail = email.ExecuteReader();

            drEmail.Read();
            {
                txtSQLEmail.Text += drEmail.GetString(0);
            }
            drEmail.Close();
            conn.Close();
        }
        
        if (!this.IsPostBack) //Checkt of er postbak is
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))  //selecteert 
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Naam FROM Artiesten"))  //Het commando
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;  //Maakt een connectie
                    con.Open();
                    dplArtiesten.DataSource = cmd.ExecuteReader();
                    dplArtiesten.DataTextField = "Naam";  //Data velden
                    dplArtiesten.DataValueField = "Naam";
                    dplArtiesten.DataBind();
                    con.Close();
                }
            }
        }
    }

    protected void dplArtiesten_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtSQLNaam.Text = "";

        // Een connectie maken met de SQL database
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        conn.Open();

        // Maak de database commands

        SqlCommand naam = new SqlCommand();

        naam.Connection = conn;  // Selecteer connection object mee
        naam.CommandText = String.Format("SELECT Naam FROM Artiesten WHERE Naam = '{0}'", dplArtiesten.SelectedItem.Text);

        SqlCommand email = new SqlCommand();

        email.Connection = conn;  // Selecteer connection object mee
        email.CommandText = String.Format("SELECT Email FROM Artiesten WHERE Naam = '{0}' ", dplArtiesten.SelectedItem.Text);

        SqlCommand username = new SqlCommand();
        if (lblAuto.Text == "2")
        {
            txtSQLUsername.Text = lblUsername.Text;
        }
        else
        {
            username.Connection = conn;  // Selecteer connection object mee
            username.CommandText = String.Format("SELECT Username FROM Users WHERE Username = '{0}' ", dplArtiesten.SelectedItem.Text);
            SqlDataReader dr3 = username.ExecuteReader();
            while (dr3.Read())
            {
                txtSQLUsername.Text += dr3.GetString(0);
            }
            dr3.Close();
        }

        SqlCommand password = new SqlCommand();

        username.Connection = conn;  // Selecteer connection object mee
        username.CommandText = String.Format("SELECT Username FROM Users WHERE Naam = '{0}' ", dplArtiesten.SelectedItem.Text);

        SqlCommand Info = new SqlCommand();

        Info.Connection = conn;  // Selecteer connection object mee
        Info.CommandText = String.Format("SELECT InnerContent FROM ArtiestenPagina WHERE Artiest = '{0}' ", dplArtiesten.SelectedItem.Text);

        // Zend het database commando en ontvang data terug.
        SqlDataReader dr = naam.ExecuteReader();

        while (dr.Read())
        {
            txtSQLNaam.Text += dr.GetString(0);
        }
        dr.Close();

        SqlDataReader dr2 = email.ExecuteReader();
        while (dr2.Read())
        {
            txtSQLEmail.Text += dr2.GetString(0);
        }
        dr2.Close();

        //SqlDataReader dr4 = password.ExecuteReader();
        //while (dr4.Read())
        //{
        //    txtSQLPassword.Text += dr4.GetString(0);
        //}
        //dr4.Close();

        SqlDataReader dr5 = Info.ExecuteReader();
        while (dr5.Read())
        {
            txtSQLInfo.Text += dr5.GetString(0);
        }
        dr5.Close();
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
                    dplArtiesten.DataSource = cmd.ExecuteReader();
                    dplArtiesten.DataTextField = "Naam";  //Data velden
                    dplArtiesten.DataValueField = "Naam";
                    dplArtiesten.DataBind();
                    con.Close();
                }
            }
        }
    }


    protected void btnEdit_Click(object sender, EventArgs e)
    {
        txtSQLNaam.ReadOnly = false;
    }

    protected void btnEdit2_Click(object sender, EventArgs e)
    {
        txtSQLEmail.ReadOnly = false;
    }

    protected void btnOpslaan_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))  //selecteert 
        {
            SqlCommand command2 = new SqlCommand();  //Selecteert de Groep
            command2.CommandType = CommandType.Text;
            command2.Connection = con;  //Maakt een connectie
            command2.CommandText = String.Format("update Artiesten set Naam = @Naam where Naam =  '{0}' ", txtSQLNaam.Text);
            {
                con.Open();
                string Naam = txtSQLNaam.Text;
                command2.Parameters.AddWithValue("Naam", Naam);
                command2.ExecuteNonQuery();  //Voert de commands uit
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wijziging compleet');", true);
                con.Close();

            }
        }

    }

    protected void btnToevoegen_Click(object sender, EventArgs e)
    {
        txtSQLEmail.ReadOnly = false;
        txtSQLNaam.ReadOnly = false;
        txtSQLPassword.ReadOnly = false;
        txtSQLUsername.ReadOnly = false;
        btnEdit2.Visible = false;
        btnEdit.Visible = false;
        btnEdit3.Visible = false;
        btnEdit4.Visible = false;
        //btnEdit5.Visible = false;
        btnOpslaan.Visible = false;
        btnOpslaan2.Visible = false;
        btnOpslaan3.Visible = false;
        btnOpslaan4.Visible = false;
        //btnOpslaan5.Visible = false;
        lblAuto.Text = dplArtiesten.SelectedItem.Text;
    }

    //Opslaan email
    protected void btnOpslaan2_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))  //selecteert 
        {
            SqlCommand command3 = new SqlCommand();  //Selecteert de Groep
            command3.CommandType = CommandType.Text;
            command3.Connection = con;  //Maakt een connectie
            command3.CommandText = String.Format("update Artiesten set Email = @Email where Naam =  '{0}' ", txtSQLNaam.Text);
            {
                con.Open();
                string Email = txtSQLEmail.Text;
                command3.Parameters.AddWithValue("Email", Email);
                command3.ExecuteNonQuery();  //Voert de commands uit
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Wijziging compleet');", true);
                con.Close();

            }
        }
    }
    //Toevoegen van mensen in de databse 
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))  //selecteert 
        {
            SqlCommand command = new SqlCommand();  //Selecteert de Groep
            command.CommandType = CommandType.Text;
            command.Connection = con;
            command.CommandText = String.Format(("INSERT INTO Artiesten (Naam, Email, PodiumID, FestivalID, UserID, PaginaID) VALUES (@Naam, @Email, (SELECT PodiumID FROM Podiums WHERE Podiumnaam = 'Podium 0'), (SELECT FestivalID FROM Festival WHERE Naam = 'Woo Hah'), (SELECT UserID FROM Users WHERE Username = @Username), (SELECT PaginaID FROM ArtiestenPagina WHERE Artiest = @Naam"));  //Selecteert de Groep)
            {
                command.CommandType = CommandType.Text;
                command.Connection = con;  //Maakt een connectie
                con.Open();
                string Naam = txtSQLNaam.Text;
                command.Parameters.AddWithValue("Naam", Naam);
                string Email = txtSQLEmail.Text;
                command.Parameters.AddWithValue("Adres", Email);  //Je kan alles toevoegen
                string Username = txtSQLUsername.Text;
                command.Parameters.AddWithValue("Postcode", Username);
                string Password = txtSQLPassword.Text;
                command.Parameters.AddWithValue("Woonplaats", Password);
                command.ExecuteNonQuery();  //Voert de commands uit

            }
            txtSQLEmail.ReadOnly = true;
            txtSQLNaam.ReadOnly = true;
            txtSQLPassword.ReadOnly = true;
            txtSQLUsername.ReadOnly = true;
            btnEdit2.Visible = true;
            btnEdit.Visible = true;
            btnEdit3.Visible = true;
            btnEdit4.Visible = true;
            //btnEdit5.Visible = false;
            btnOpslaan.Visible = true;
            btnOpslaan2.Visible = true;
            btnOpslaan3.Visible = true;
            btnOpslaan4.Visible = true;
            //btnOpslaan5.Visible = false;
        }
    }

    protected void ddlFest_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}