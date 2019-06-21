using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    public partial class PrincipalAnidada : System.Web.UI.MasterPage
    {
        string[] nameUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            string name = Session["Admin"].ToString();
            this.nameUser = name.Split('/');
            lbNombre.Text = nameUser[0];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("Default.aspx");
        }
    }
}