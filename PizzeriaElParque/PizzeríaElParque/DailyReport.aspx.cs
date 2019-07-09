﻿using System;
using System.Collections.Generic;
using System.Data;
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
    /// Clase encargada de realizar la gráfica de la pagina de reportes por producto
    /// </summary>
    public partial class DailyReport : System.Web.UI.Page
    {
        string[] nameUser;
        LogicReport logicReport = new LogicReport();

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
        /// Crea una ventana con mensaje de error
        /// </summary>
        /// <param name="message">Texto que contendrá el mensaje</param>
        
        public void ErrorMessage(string message) {


            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("toastr.error('"+message+ "');");
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

            ClientScript.RegisterStartupScript(this.GetType(), "key", "showModal()", true);

        }

        /// <summary>
        /// Se encarga de realizar al acción del boton de reportes, validar la informacion ingresada y crea un reporte
        /// </summary>
        /// <param name="sender">Bjeto genérico</param>
        /// <param name="e">Evento</param>
        /// 
        protected void btnSearchReportProduct_Click(object sender, EventArgs e)
        {
           
            DataTable dt = new DataTable();
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Total");


            if (StartDateProduct.Value.ToString().Equals("") || EndDateProduct.ToString().Equals(""))
            {


                ErrorMessage("Debe elegir una fecha");
            }
            else
            {

                DateTime startDate = logicReport.ConvertDateTime(StartDateProduct.Value);
                DateTime endDate = logicReport.ConvertDateTime(EndDateProduct.Value);
                List<Report> reports = new List<Report>();


                if (logicReport.isnumber(TBCodeProduct.Text) == false)
                {
            
                      ErrorMessage("El codigo debe ser un numero o no puede estar vacio");
                   

                }
                else if (int.Parse(TBCodeProduct.Text) == 0 || int.Parse(TBCodeProduct.Text) < 0)
                {

                    ErrorMessage("El codigo del producto debe ser mayor a cero");

                }
                else if (startDate < endDate)
                {
;
                    ErrorMessage("Las fechas son incorrectas");

                }
                else
                {

                    reports = logicReport.ConsulReports_Product(startDate, endDate, int.Parse(TBCodeProduct.Text));

                    for (int i = 0; i < reports.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Cantidad"] = reports[i].quantity;
                        dr["Nombre"] = reports[i].Name;
                        dr["Total"] = reports[i].Total;
                        dt.Rows.Add(dr);
                    }


                    GridViewOneProduct.DataSource = dt;
                    GridViewOneProduct.DataBind();
                }
            }
        }

        /// <summary>
        /// Se encarga de realizar la acción dl boton de refrescar y refrescar la pagina
        /// </summary>
        /// <param name="sender">Objeto genérico</param>
        /// <param name="e">Evento</param>
        /// 
        protected void btnDRefresh_Click(object sender, EventArgs e)
        {
        }


        }
    }