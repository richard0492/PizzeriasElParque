using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    
    /// <summary>
    /// Pagina para Rol de cosinero
    /// </summary>
    public partial class NestedCook : System.Web.UI.MasterPage
    {
        string[] nameUser;

        /// <summary>
        /// Se encarga de verificar que tipo de usuario esta ingresando la pagina,para asignar sus funciones según su rol.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        ///
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Session["chef"].ToString();
            this.nameUser = name.Split('/');
            lbNombre.Text = nameUser[0];
        }

        /// <summary>
        /// Metodo encargado de asignaral botón la accion para salir del sistema
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("chef");
            Response.Redirect("Default.aspx");
        }
    }
}