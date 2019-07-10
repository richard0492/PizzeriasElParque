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
    /// Clase encargada de realizar la gráfica de la pagina de agregar productos
    /// </summary>
    public partial class AddProduct : System.Web.UI.Page
    {
        string[] nameUser;
        LogicProduct product = new LogicProduct();
        
        /// <summary>
        /// Metodo encargado de envar los datos para deshabilitar un usuario en la capa lógica
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
        /// Metodo encargado de asignar la acción al boton para optener los datos de entrada otorgados para el usuario para enviarlos a la capa lógica para agregar producto
        /// </summary>
        /// <param name="sender">Objeto gnérico</param>
        /// <param name="e">Evento</param>
        protected void btbAgregar_Click(object sender, EventArgs e)
        {
            
            product.InsertProduct(Convert.ToInt32(Identification.Text.Trim()), txtName.Text.Trim(), " ", Convert.ToDouble(txtPrice.Text.Trim()), Convert.ToInt32(DropDownListPreparationTime.SelectedValue), 0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (product.ConsultProductEnabled().Count != 0)
                {
                    for (int i = 0; i < product.ConsultProductEnabled().Count; i++)
                    {
                        if (product.ConsultProductEnabled()[i].name.Equals(txtName.Text.Trim()))
                        {
                            Response.Redirect("ModifyProduct.aspx?code=" + product.ConsultProductEnabled()[i].code);
                        }
                    }
                }
            }
        }
    }
}