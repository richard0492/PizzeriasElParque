using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PizzeríaElParque
{
    public partial class AdminPage : System.Web.UI.Page
    {
        string[] nameUser;

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
                lbNombre.Text = nameUser[0];
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