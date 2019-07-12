using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace PizzeríaElParque
{
    /// <summary>
    /// Pagina encaragada de mostrar la lista de usuarios
    /// </summary>
    public partial class ListUser : System.Web.UI.Page
    {
        string[] nameUser;
        LogicUser user = new LogicUser();


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

                DataTable dt = new DataTable();
                dt.Columns.Add("Cédula");
                dt.Columns.Add("Nombre");
                dt.Columns.Add("Segundo Nombre");
                dt.Columns.Add("Primer Apellido");
                dt.Columns.Add("Segundo Apellido");
                dt.Columns.Add("Tipo de Usuario");


                for (int i = 0; i < user.ConsultUsersList().Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["Cédula"] = user.ConsultUsersList()[i].IDnumber;
                    dr["Nombre"] = user.ConsultUsersList()[i].name;
                    dr["Segundo Nombre"] = user.ConsultUsersList()[i].secondName;
                    dr["Primer Apellido"] = user.ConsultUsersList()[i].lastName1;
                    dr["Segundo Apellido"] = user.ConsultUsersList()[i].lastName2;
                    dr["Tipo de Usuario"] = user.ConsultUsersList()[i].nameType;
                    dt.Rows.Add(dr);
                }

                GridView1.DataSource = dt;
                GridView1.DataBind();

                
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
        }
    }
}