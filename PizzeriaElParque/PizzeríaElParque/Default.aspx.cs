using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Object;
using System.Web.Script.Services;
using System.Web.Services;

namespace PizzeríaElParque
{
    /// <summary>
    /// Clase encragada de la pagina principal de ingreso de usuario
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        LogicUser data = new LogicUser();

        /// <summary>
        /// Metodo encargado de envar los datos para deshabilitar un usuario en la capa lógica
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["cashier"] != null)
            {

                Session.Remove("cashier");
                Response.Redirect("Default.aspx?men=1");

            }
            else if (Session["Admin"] != null)
            {

                Session.Remove("Admin");
                Response.Redirect("Default.aspx?men=1");

            }
            else if (Session["chef"] != null)
            {

                Session.Remove("chef");
                Response.Redirect("Default.aspx?men=1");

            }

            if (!IsPostBack)
            {

                if (Request.Params["men"] != null)
                {
                    string menssage = Request.Params["men"];

                    if (menssage == "1")
                    {
                        StringBuilder sbMensaje = new StringBuilder();
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("toastr.warning('Debe iniciar sesión');");
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());
                    }
                    dlEmployees.DataSource = data.ConsultUsers();

                    dlEmployees.DataTextField = "fullName";
                    dlEmployees.DataValueField = "fullName";

                    dlEmployees.DataBind();
                }
                else
                {

                    dlEmployees.DataSource = data.ConsultUsers();

                    dlEmployees.DataTextField = "fullName";
                    dlEmployees.DataValueField = "fullName";

                    dlEmployees.DataBind();
                }
            }
        }

        /// <summary>
        /// Metodo encargado de asignar la acción al boton para  optener los datos de entrada para enviarlos a la capa lógica para realizar el rpoceso de ingreso.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string typeUser;
            char firstS;

            string[] user;
            string[] name;

            name = dlEmployees.SelectedItem.ToString().Split('/');

            typeUser = data.typeUser(Convert.ToInt32(name[0]));



            user = typeUser.ToString().Split('/');



            firstS = data.firstS(Int32.Parse(name[0]));


            if (firstS.Equals('s'))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "key", "showModal()", true);
            }
            else
            {
                if (tbPassword.Text.Trim() == "")
                {

                    StringBuilder sbMensaje = new StringBuilder();
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("toastr.warning('Ingresar Contraseña');");
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                }
                else if (user[0].Equals(tbPassword.Text.Trim()))
                {
                    if (Int64.Parse(user[1]) == 1)
                    {
                        Session["Admin"] = name[1] + " / " + 1;
                        Response.Redirect("AdminPage.aspx");
                    }
                    else if (Int64.Parse(user[1]) == 2)
                    {
                        Session["cashier"] = name[1] + " / " + 2;
                        Response.Redirect("CashierPage.aspx");
                    }
                    else if (Int64.Parse(user[1]) == 3)
                    {
                        Session["chef"] = name[1] + " / " + 3;
                        Response.Redirect("Cook.aspx");
                    }
                }
                else
                {
                    StringBuilder sbMensaje = new StringBuilder();
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("toastr.error('Contraseña Incorrecta');");
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                }
            }


        }

        /// <summary>
        /// Metodo encargado de asignar la acción al boton para desplegar una ventana para optener los datos de crear una nueva contraseñapara el usuario
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void newPasswordUser_Click1(object sender, EventArgs e)
        {

            if (tbNewPassword.Text.Trim() == "" || tbConfirnPassword.Text.Trim() == "")
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("toastr.error('Existen campos en blanco');");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                ClientScript.RegisterStartupScript(this.GetType(), "key", "showModal()", true);


            }
            else if (tbNewPassword.Text.Equals(tbConfirnPassword.Text))
            {


                string typeUser;

                string[] user;
                string[] name;

                name = dlEmployees.SelectedItem.ToString().Split('/');

                typeUser = data.typeUser(Convert.ToInt32(name[0]));



                user = typeUser.ToString().Split('/');


                LogicUser modify = new LogicUser();

                modify.modifyPassword(Convert.ToInt32(name[0]), tbNewPassword.Text, 'n');

                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("toastr.success('Contraseña Modificada');");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                if (Int64.Parse(user[1]) == 1)
                {
                    Session["Admin"] = name[1] + " / " + 1;
                    Response.Redirect("AdminPage.aspx");
                }
                else if (Int64.Parse(user[1]) == 2)
                {
                    Session["cashier"] = name[1] + " / " + 2;
                    Response.Redirect("CashierPage.aspx");
                }
                else if (Int64.Parse(user[1]) == 3)
                {
                    Session["chef"] = name[1] + " / " + 3;
                    Response.Redirect("Cook.aspx");
                }
            }
            else
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("toastr.error('Una de las contraseñas es diferente');");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                ClientScript.RegisterStartupScript(this.GetType(), "key", "showModal()", true);
            }
        }
    }
}