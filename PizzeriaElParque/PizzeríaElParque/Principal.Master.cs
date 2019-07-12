using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    /// <summary>
    /// Clase de la pagina maestra
    /// </summary>
    public partial class Principal : System.Web.UI.MasterPage
    {
        /// <summary>
        /// Se encarga de verificar que tipo de usuario esta ingresando la pagina,para asignar sus funciones según su rol.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        ///
        protected void Page_Load(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}