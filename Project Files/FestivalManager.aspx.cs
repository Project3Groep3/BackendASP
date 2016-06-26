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


public partial class Project_Files_FestivalManager : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        lblUsername.Text = (string)Session["Usernaam"]; //Checkt de  SessieState voor de username van de gebruiker
        lblAuto.Text = (string)Session["Auto"]; //Checkt de SessieState
        if (lblAuto.Text == "0")
        {

        }
        else if (lblAuto.Text == "1")
        {

        }
    }
}