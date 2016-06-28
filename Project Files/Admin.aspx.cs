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


public partial class Project_Files_Admin : System.Web.UI.Page
{
    //buttons voor het menu
    protected void Page_Load(object sender, EventArgs e)
    {

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

    //Log out knop
    protected void btnLogout_Click(object sender, EventArgs e)
    {

        Session.Clear(); //Haalt alle values leeg zodat er opnieuw iets wordt aangemaakt 
        Session.Abandon(); //Dit destroyed heel de session
        Server.Transfer("Home.aspx");  //Gaat terug naar de login page
    }
}