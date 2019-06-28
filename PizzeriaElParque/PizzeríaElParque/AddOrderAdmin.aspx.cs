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
    public partial class AddOrderAdmin : System.Web.UI.Page
    {
        string[] nameUser;
        DataTable table = new DataTable();
        LogicOrder order = new LogicOrder();
        int[] idLineOrder;
        int orderList;
        int posicion;
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

            orderList = order.lastOrder();
            table.Columns.Add("Código");
            table.Columns.Add("Nombre");
            table.Columns.Add("Cantidad");
            table.Columns.Add("Total");

            idLineOrder = new int[order.ConsulLineOders(orderList).Count];

            for (int i = 0; i < order.ConsulLineOders(orderList).Count; i++)
            {
                DataRow row = table.NewRow();
                row["Código"] = order.ConsulLineOders(orderList)[i].productId;
                row["Nombre"] = order.ConsulLineOders(orderList)[i].nameProduct;
                row["Cantidad"] = order.ConsulLineOders(orderList)[i].quantity;
                row["Total"] = order.ConsulLineOders(orderList)[i].price;
                idLineOrder[i] = order.ConsulLineOders(orderList)[i].lineOrderID;
                table.Rows.Add(row);
            }

            GridView1.DataSource = table;
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            
            posicion = int.Parse(e.CommandArgument.ToString());

            tbCodeModify.Text = GridView1.Rows[posicion].Cells[1].Text;
            tbquantityModify.Text = GridView1.Rows[posicion].Cells[3].Text;
            tbNameProduct.Text = GridView1.Rows[posicion].Cells[2].Text;

            ClientScript.RegisterStartupScript(this.GetType(), "key", "showModalOrder()", true);

            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("toastr.error('Número fila grid"+ posicion + "  Número de tabla MySQL" + idLineOrder[posicion] +"');");
            sbMensaje.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "key", "showModal()", true);

        }

        protected void bntCreate_Click(object sender, EventArgs e)
        {
            order.insertLineOders(int.Parse(tbquantity.Text.Trim()), DateTime.Now.Date, DateTime.Now, orderList, int.Parse(tbCode.Text.Trim()));
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            order.modifytLineOders(int.Parse(tbquantityModify.Text.Trim()), DateTime.Now.Date, DateTime.Now, orderList, int.Parse(tbCodeModify.Text.Trim()),idLineOrder[posicion]);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

      
    }
}