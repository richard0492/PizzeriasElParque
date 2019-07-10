using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    /// <summary>
    /// Clase encargada de mostrar la pagina para el rol de administrador
    /// </summary>
    public partial class PrincipalAnidada : System.Web.UI.MasterPage
    {
        string[] nameUser;
       
        /// <summary>
        /// Metodo encargado de verificar que tipo de usuario esta ingresando la pagina,para asignar sus funciones según su rol.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        ///
        protected void Page_Load(object sender, EventArgs e)
        {
            

            string name = Session["Admin"].ToString();
            this.nameUser = name.Split('/');
            lbNombre.Text = nameUser[0];
        }

        /// <summary>
        /// Metodo encarago de asignar al boton una acción para salir del sistema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("Default.aspx");
        }
    }
}