using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    public partial class NestedCashier : System.Web.UI.MasterPage
    {
        string[] nameUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["cashier"].ToString();
            this.nameUser = name.Split('/');
            lbNombre.Text = nameUser[0];
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("cashier");
            Response.Redirect("Default.aspx");
        }
    }
}