using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    /// <summary>
    /// Pagina encargada de los mensajes de error
    /// </summary>
    public partial class ErrorPage : System.Web.UI.Page
    {
        string[] nameUser;

        /// <summary>
        /// Se encarga de verificar que tipo de usuario esta ingresando la pagina,para asignar sus funciones según su rol.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
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