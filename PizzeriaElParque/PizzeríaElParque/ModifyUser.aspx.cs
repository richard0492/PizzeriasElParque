using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;
using Object;

namespace PizzeríaElParque
{
    /// <summary>
    /// clase encargada de la pagina de modificar usuario
    /// </summary>
    public partial class ModifyUser : System.Web.UI.Page
    {
        string[] nameUser;
        string[] nameUserModify;

        LogicUser data = new LogicUser();

        /// <summary>
        /// Se encarga de verificar que tipo de usuario esta ingresando la pagina,para asignar sus funciones según su rol.
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["cashier"] != null)
            {

                string name = Session["cashier"].ToString();
                this.nameUser = name.Split('/');

            }
            else if (Session["Admin"] != null)
            {

                string name = Session["Admin"].ToString();
                this.nameUser = name.Split('/');

            }
            else if (Session["chef"] != null)
            {

                string name = Session["chef"].ToString();
                this.nameUser = name.Split('/');

            }

            try
            {
                if (Request.Params["men"] != null)
                {
                    string menssage = Request.Params["men"];

                    if (menssage == "1")
                    {
                        StringBuilder sbMensaje = new StringBuilder();
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("toastr.error('No tiene acceso a la página');");
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());
                    }
                }
                Session["Admin"].ToString();
            }
            catch (Exception ex)
            {
                if (nameUser == null)
                {
                    Response.Redirect("Default.aspx?men=1");
                }
                else
                {
                    if (Int64.Parse(nameUser[1]) == 2)
                    {
                        Response.Redirect("CashierPage.aspx?men=1");
                    }
                    else if (Int64.Parse(nameUser[1]) == 3)
                    {
                        Response.Redirect("Cook.aspx?men=1");
                    }
                    else
                    {
                        if (Int64.Parse(nameUser[1]) == 2)
                        {
                            Session.Remove("cashier");
                            Response.Redirect("Default.aspx?men=1");
                        }
                        else if (Int64.Parse(nameUser[1]) == 3)
                        {
                            Session.Remove("chef");
                            Response.Redirect("Default.aspx?men=1");
                        }

                    }
                }
            }

            if (!IsPostBack)
            {
            
                dlEmployees.DataSource = data.ConsultUsers();

                dlEmployees.DataTextField = "fullName";
                dlEmployees.DataValueField = "fullName";

                dlEmployees.DataBind();

                string nameM = dlEmployees.SelectedItem.ToString();

                string[] nameUserM = nameM.Split('/');

                nameUserM[0].ToString();

                string modify = data.ConsultUserModify(nameUserM[0]);

                nameUserModify = modify.Split('/');

                tbIDCard.Text = nameUserModify[0];
                txtName.Text = nameUserModify[1];
                txtSecondName.Text = nameUserModify[2];
                txtLastName.Text = nameUserModify[3];
                txtSecondLastName.Text = nameUserModify[4];
                DropDownList1.SelectedItem.Text = nameUserModify[5];

            }
        }

        /// <summary>
        /// Metodo encargado de aignar al botón la acción para optener los datos de entrada asignados  por el usuario y enviarlos a la capa lógica para modificar el usuario
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void btbModify_Click(object sender, EventArgs e)
        {
            
            data.ModifyUser(Convert.ToInt32(tbIDCard.Text.Trim()),txtName.Text.Trim(),'s',numberType(DropDownList1.SelectedItem.Text),txtSecondName.Text.Trim(),txtLastName.Text.Trim(),txtSecondLastName.Text.Trim());
        }

        /// <summary>
        /// Metodo encargado de otorgar un valor según el rol de usuario
        /// </summary>
        /// <param name="type">Tipo de usuario</param>
        /// <returns>numero según rol de usuario</returns>
        protected int numberType(string type) {

            int numberType = 0;

            if (type.Equals("Administrador")) {
                return 1;
            }

            if (type.Equals("Cajero"))
            {
                return 2;
            }

            if (type.Equals("Cocinero"))
            {
                return 3;
            }

            return numberType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void dlEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nameM = dlEmployees.SelectedItem.ToString();

            string[] nameUserM = nameM.Split('/');

            nameUserM[0].ToString();

            string modify = data.ConsultUserModify(nameUserM[0]);

            nameUserModify = modify.Split('/');

            tbIDCard.Text = nameUserModify[0];
            txtName.Text = nameUserModify[1];
            txtSecondName.Text = nameUserModify[2];
            txtLastName.Text = nameUserModify[3];
            txtSecondLastName.Text = nameUserModify[4];
            DropDownList1.SelectedItem.Text = nameUserModify[5];
        }
    }
}