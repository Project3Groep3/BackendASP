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
        lblUsername.Text = (string)Session["Usernaam"]; //Checkt de  SessieState voor de username van de gebruiker
        lblwachtwoord.Text = (string)Session["Wachtwoord"]; //Checkt de SessieState

        if (!this.IsPostBack) //Checkt of er postbak is
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))  //selecteert 
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Artiest, UserID FROM ArtiestenPagina"))  //Het commando
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;  //Maakt een connectie
                    con.Open();
                    ddlArtiest.DataSource = cmd.ExecuteReader();
                    ddlArtiest.DataTextField = "Artiest";  //Data velden
                    ddlArtiest.DataValueField = "UserID";
                    ddlArtiest.DataBind();
                    con.Close();
                }
            }
        }
    }

    protected void ddlArtiest_SelectedIndexChanged(object sender, EventArgs e)
    {
        string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            con.Open();

            // Pagina Table
            SqlCommand cmdPagina = new SqlCommand();
            cmdPagina.CommandType = CommandType.Text;
            cmdPagina.Connection = con;
            cmdPagina.CommandText = String.Format("SELECT Artiest, InnerContent FROM ArtiestenPagina WHERE Artiest = '{0}'", ddlArtiest.SelectedItem.Text);

            SqlDataReader readerPagina = cmdPagina.ExecuteReader();

            while (readerPagina.Read())
            {
                txtSQLNaam.Text = readerPagina.GetString(0);
                txtSQLInfo.Text = readerPagina.GetString(1);
            }
            readerPagina.Close();

            // Image Ophalen
            SqlCommand cmdImage = new SqlCommand();
            cmdImage.CommandType = CommandType.Text;
            cmdImage.Connection = con;
            cmdImage.CommandText = String.Format("SELECT ArtistImage FROM ArtiestenPagina WHERE Artiest = '{0}'", ddlArtiest.SelectedItem.Text);

            byte[] imgData = (byte[])cmdImage.ExecuteScalar();
            imgArtiest.Attributes["src"] = "data:image/png" + ";base64," + Convert.ToBase64String(imgData);

            // Artiest Table
            SqlCommand cmdArtiest = new SqlCommand();
            cmdArtiest.CommandType = CommandType.Text;
            cmdArtiest.Connection = con;
            cmdArtiest.CommandText = String.Format("SELECT Email FROM Artiesten WHERE Naam = '{0}'", ddlArtiest.SelectedItem.Text);

            SqlDataReader readerArtiest = cmdArtiest.ExecuteReader();

            while(readerArtiest.Read())
            {
                txtSQLEmail.Text = readerArtiest.GetString(0);
            }
            readerArtiest.Close();

            // User Table
            SqlCommand cmdUser = new SqlCommand();
            cmdUser.CommandType = CommandType.Text;
            cmdUser.Connection = con;
            cmdUser.CommandText = String.Format("SELECT Username, Passwords FROM Users WHERE UserID = {0}", ddlArtiest.SelectedValue);

            SqlDataReader readerUser = cmdUser.ExecuteReader();

            while (readerUser.Read())
            {
                txtSQLUsername.Text = readerUser.GetString(0);
                txtSQLPassword.Text = readerUser.GetString(1);
            }
            readerUser.Close();
            con.Close();
        }
    }

    protected void btnEmail_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtSQLEmail.Text))
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = String.Format("UPDATE Artiesten SET Email = @Email WHERE Naam = '{0}'", ddlArtiest.SelectedItem.Text);
                cmd.Parameters.AddWithValue("Email", txtSQLEmail.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Veld is niet ingevuld!');", true);
        }
    }


    protected void btnPassword_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtSQLPassword.Text))
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = String.Format("UPDATE Users SET Passwords = @Password WHERE UserID = {0}", ddlArtiest.SelectedValue);
                cmd.Parameters.AddWithValue("Password", txtSQLPassword.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Veld is niet ingevuld!');", true);
        }
    }

    protected void btnContent_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txtSQLInfo.Text))
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = String.Format("UPDATE ArtiestenPagina SET InnerContent = @InnerContent WHERE Artiest = '{0}'", ddlArtiest.SelectedItem.Text);
                cmd.Parameters.AddWithValue("InnerContent", txtSQLInfo.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Veld is niet ingevuld!');", true); //Geeft een bevestigins popup als het gelukt is
        }
    }

    protected void btnImage_Click(object sender, EventArgs e)
    {
        if (imgUpload.FileBytes.Length > 0)
        {
            string constr = ConfigurationManager.ConnectionStrings["MojoConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandText = String.Format("UPDATE ArtiestenPagina SET ArtistImage = @ArtistImage WHERE Artiest = '{0}'", ddlArtiest.SelectedItem.Text);
                cmd.Parameters.AddWithValue("ArtistImage", SqlDbType.Image).Value = imgUpload.FileBytes;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Image is niet aangegeven!');", true);
        }
    }

    //Alle knoppen voor het menu
    protected void btnInstellingen_Click1(object sender, EventArgs e)
    {
        Server.Transfer("SiteInstellingen.aspx");
    }

    protected void btnData_Click(object sender, EventArgs e)
    {
        Server.Transfer("Festivals.aspx");
    }

    protected void btnArtiest_Click(object sender, EventArgs e)
    {
        Server.Transfer("Artiest.aspx");
    }

    protected void btnEditMenu_Click(object sender, EventArgs e)
    {
        Server.Transfer("Edit.aspx");
    }

    //Log out knop
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        Session.Clear(); //Haalt alle values leeg zodat er opnieuw iets wordt aangemaakt 
        Session.Abandon(); //Dit destroyed heel de session
        Server.Transfer("Home.aspx");  //Gaat terug naar de login page
    }
}