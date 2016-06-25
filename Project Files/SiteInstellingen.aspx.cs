using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Project_Files_SiteInstellingen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //Buttons voor het Menu
    protected void btnInstellingen_Click1(object sender, EventArgs e)
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