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
public partial class Project_Files_Artiest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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

        SqlCommand cmd = new SqlCommand();

        cmd.Connection = conn;  // Selecteer connection object mee
        cmd.CommandText = String.Format("SELECT Naam FROM Artiesten WHERE Naam = '{0}' ", dplArtiesten.SelectedItem.Text);

        SqlCommand email = new SqlCommand();

        email.Connection = conn;  // Selecteer connection object mee
        email.CommandText = String.Format("SELECT Email FROM Artiesten WHERE Naam = '{0}' ", dplArtiesten.SelectedItem.Text);

        SqlCommand username = new SqlCommand();

        username.Connection = conn;  // Selecteer connection object mee
        username.CommandText = String.Format("SELECT Username FROM Users WHERE Naam = '{0}' ", dplArtiesten.SelectedItem.Text);

        // Zend het database commando en ontvang data terug.
        SqlDataReader dr = cmd.ExecuteReader();

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

        conn.Close();
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
            command2.CommandText = String.Format("update Artiesten set Naam = @Naam where Naam =  '{0}' ", dplArtiesten.SelectedItem.Text);
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
}
