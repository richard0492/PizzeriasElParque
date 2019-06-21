using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    public partial class ErrorPage : System.Web.UI.Page
    {
        string[] nameUser;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["cashier"] != null)
            {

                Response.Redirect("CashierPage.aspx?men=1");

            }
            else if (Session["Admin"] != null)
            {

                Response.Redirect("AdminPage.aspx?men=1");

            }
            else if (Session["chef"] != null)
            {

                Response.Redirect("Cook.aspx?men=1");

            }
            else
            {
                Response.Redirect("Default.aspx?men=1");
            }

        }
    }
}