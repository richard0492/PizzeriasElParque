using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logic;

namespace PizzeríaElParque
{
    /// <summary>
    /// clase encargada de la parte visual para deshabilitar un producto
    /// </summary>
    public partial class DisableProduct : System.Web.UI.Page
    {
        string[] nameUser;
        LogicProduct product = new LogicProduct();

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
        }

        /// <summary>
        /// Metodo encargado de envar los datos para deshabilitar un producto en la capa lógica
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void btnDisable_Click(object sender, EventArgs e)
        {
            product.DeleteProduct(Convert.ToInt32(Identification.Text.Trim()), 'n');
        }

        /// <summary>
        /// Metodo encargado para asignar la acción de deshabilitar un producto a un botón
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string[] splitProduct;



            String newProduct = "";

            newProduct = product.ConsultProduct(Identification.Text.Trim());

            splitProduct = newProduct.Split('/');

            txtName.Text = splitProduct[0];

            DropDownListPreparationTime.SelectedItem.Text = splitProduct[1];

            txtPrice.Text = splitProduct[2];
        }
    }
}