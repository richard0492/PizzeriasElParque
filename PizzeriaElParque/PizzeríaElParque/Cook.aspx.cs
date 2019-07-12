using Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Object;


namespace PizzeríaElParque
{
    public partial class Cook : System.Web.UI.Page
    {
        string id = "";
        string[] nameUser;
        DataTable tableLocal = new DataTable();
        DataTable tableExpress = new DataTable();
        DataTable tableLineOrder = new DataTable();
        LogicOrder order = new LogicOrder();
        List<Order> orders = new List<Order>();
        List<LineOrder> lineOrders = new List<LineOrder>();

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
                Session["chef"].ToString();


                load();
                colorChange();

                

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
                    else if (Int64.Parse(nameUser[1]) == 1)
                    {
                        Response.Redirect("AdminPage.aspx?men=1");
                    }
                    else
                    {
                        if (Int64.Parse(nameUser[1]) == 2)
                        {
                            Session.Remove("cashier");
                            Response.Redirect("Default.aspx?men=1");
                        }
                        else if (Int64.Parse(nameUser[1]) == 1)
                        {
                            Session.Remove("Admin");
                            Response.Redirect("Default.aspx?men=1");
                        }

                    }
                }
            }
        }

        public void load() {

            orders = order.consultOrders();

            tableLocal.Columns.Add("Orden");
            tableLocal.Columns.Add("Estado");
            tableLocal.Columns.Add("Empleado");
            tableLocal.Columns.Add("Cliente");

            tableExpress.Columns.Add("Orden");
            tableExpress.Columns.Add("Estado");
            tableExpress.Columns.Add("Empleado");
            tableExpress.Columns.Add("Cliente");

            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].orderTypeNumber == 1)
                {
                    DataRow row = tableLocal.NewRow();
                    row["Orden"] = orders[i].orderID;
                    row["Estado"] = orders[i].estadeIdName;
                    row["Empleado"] = orders[i].nameEmployed;
                    row["Cliente"] = orders[i].nameClient;

                    tableLocal.Rows.Add(row);


                    localGridview.DataSource = tableLocal;
                    localGridview.DataBind();
                }


                if (orders[i].orderTypeNumber == 2)
                {
                    DataRow row = tableExpress.NewRow();
                    row["Orden"] = orders[i].orderID;
                    row["Estado"] = orders[i].estadeIdName;
                    row["Empleado"] = orders[i].nameEmployed;
                    row["Cliente"] = orders[i].nameClient;

                    tableExpress.Rows.Add(row);
                    ExpressGridView.DataSource = tableExpress;
                    ExpressGridView.DataBind();
                }
            }

        }

        public void colorChange() {
           


           

                    int gridLength = localGridview.Rows.Count;
                    for (int j = 0; j < gridLength; j++)
                    {

                        if (localGridview.Rows[j].Cells[3].Text.Equals("A Tiempo"))
                        {

                            localGridview.Rows[j].BackColor = System.Drawing.Color.Green;
                        }
                        if (localGridview.Rows[j].Cells[3].Text.Equals("Sobre Tiempo"))
                        {
                            localGridview.Rows[j].BackColor = System.Drawing.Color.Yellow;
                        }
                        if (localGridview.Rows[j].Cells[3].Text.Equals("Atrasado"))
                        {
                            localGridview.Rows[j].BackColor = System.Drawing.Color.Red;
                        }


                    }
                

                    int gridLengthExpress = ExpressGridView.Rows.Count;
            for (int j = 0; j < gridLengthExpress; j++)
            {

                if (ExpressGridView.Rows[j].Cells[3].Text.Equals("A Tiempo"))
                {

                    ExpressGridView.Rows[j].BackColor = System.Drawing.Color.Green;
                }
                if (ExpressGridView.Rows[j].Cells[3].Text.Equals("Sobre Tiempo"))
                {
                    ExpressGridView.Rows[j].BackColor = System.Drawing.Color.Yellow;
                }
                if (ExpressGridView.Rows[j].Cells[3].Text.Equals("Atrasado"))
                {
                    ExpressGridView.Rows[j].BackColor = System.Drawing.Color.Red;
                }



            }
            
        }

        protected void localGridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonView")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = localGridview.Rows[crow].Cells[2].Text;
                Session["id"] = id;


                lineOrders = order.ConsulLineOders(int.Parse(id));

                tableLineOrder.Columns.Add("Código");
                tableLineOrder.Columns.Add("Nombre");
                tableLineOrder.Columns.Add("Cantidad");

                for (int i = 0; i < lineOrders.Count; i++)
                {
                    DataRow row = tableLineOrder.NewRow();
                    row["Código"] = lineOrders[i].productId;
                    row["Nombre"] = lineOrders[i].nameProduct;
                    row["Cantidad"] = lineOrders[i].quantity;
                   
                    tableLineOrder.Rows.Add(row);


                    lineOrderGridView.DataSource = tableLineOrder;
                    lineOrderGridView.DataBind();

                    //lbClient.Text = ExpressGridView.Rows[crow].Cells[5].Text.ToString();

                }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showModal()", true);
            }

            if (e.CommandName == "ButtonDeliver")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = localGridview.Rows[crow].Cells[2].Text;
                Session["id"] = id;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showModalOrder()", true);

            }
        }

        protected void ExpressGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ButtonView")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                string id = ExpressGridView.Rows[crow].Cells[2].Text;
                Session["id"] = id;
                lineOrders = order.ConsulLineOders(int.Parse(id));

                tableLineOrder.Columns.Add("Código");
                tableLineOrder.Columns.Add("Nombre");
                tableLineOrder.Columns.Add("Cantidad");

                for (int i = 0; i < lineOrders.Count; i++)
                {
                    DataRow row = tableLineOrder.NewRow();
                    row["Código"] = lineOrders[i].productId;
                    row["Nombre"] = lineOrders[i].nameProduct;
                    row["Cantidad"] = lineOrders[i].quantity;

                    tableLineOrder.Rows.Add(row);


                    lineOrderGridView.DataSource = tableLineOrder;
                    lineOrderGridView.DataBind();

                    lbClient.Text = ExpressGridView.Rows[crow].Cells[5].Text;


                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showModal()", true);
            }

            if (e.CommandName == "ButtonDeliver")
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                id = ExpressGridView.Rows[crow].Cells[2].Text;
                Session["id"] = id;
                //confirm(id);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "key", "showModalOrder()", true);
            }
        }

        public void confirm(string id) {
           
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            int gridLength = localGridview.Rows.Count;
            int numOrder = 0;
            int timeComparison1 = 0;
            
            int timeToCompare = 0;
            for (int i = 0; i < gridLength; i++)
            {
                int timeComparison2 = 0;
                
                numOrder = int.Parse(localGridview.Rows[i].Cells[2].Text);
                lineOrders = order.ConsulLineOders(numOrder);
                int hoursInitial = Convert.ToDateTime(lineOrders[i].startHour).Minute;
                for (int j = 0; j < lineOrders.Count; j++)
                {
                   
                    timeComparison2 = timeComparison2 + (lineOrders[j].timeMinuteCook * lineOrders[j].quantity);
                }

                timeComparison2 = timeComparison2 + hoursInitial;
                timeComparison1 = System.DateTime.Now.Minute;
                timeToCompare = timeComparison1 - timeComparison2;
                if (timeToCompare >= 1)
                {
                    order.Change_State_Order(numOrder, 2);
                }
                if (timeToCompare >= 2)
                {
                    order.Change_State_Order(numOrder, 3);
                }
            }

            gridLength = ExpressGridView.Rows.Count;
            numOrder = 0;
            timeComparison1 = 0;

            timeToCompare = 0;

            for (int i = 0; i < gridLength; i++)
            {
                int timeComparison2 = 0;

                numOrder = int.Parse(ExpressGridView.Rows[i].Cells[2].Text);
                lineOrders = order.ConsulLineOders(numOrder);
                int hoursInitial = Convert.ToDateTime(lineOrders[i].startHour).Minute;
                for (int j = 0; j < lineOrders.Count; j++)
                {

                    timeComparison2 = timeComparison2 + (lineOrders[j].timeMinuteCook * lineOrders[j].quantity);
                }

                timeComparison2 = timeComparison2 + hoursInitial;
                timeComparison1 = System.DateTime.Now.Minute;
                timeToCompare = timeComparison1 - timeComparison2;
                if (timeToCompare >= 1)
                {
                    order.Change_State_Order(numOrder, 2);
                }
                if (timeToCompare >= 2)
                {
                    order.Change_State_Order(numOrder, 3);
                }
            }
            colorChange();
        }

        private void alert(String message)
        {
            StringBuilder sbMensaje = new StringBuilder();
            sbMensaje.Append("<script type='text/javascript'>");
            sbMensaje.AppendFormat("toastr.warning('" + message + "');");
            sbMensaje.Append("</script>");
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "mensaje", sbMensaje.ToString(), false);
        }

        protected void BntConfirm_Click(object sender, EventArgs e)
        {
            
            order.Change_State_Order(int.Parse(Session["id"].ToString()), 5);
            Response.Redirect("Cook.aspx");
        }

        protected void BntClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cook.aspx");
        }

        protected void bntDeliver_Click(object sender, EventArgs e)
        {
            order.Change_State_Order(int.Parse(Session["id"].ToString()), 5);
            Response.Redirect("Cook.aspx");
        }
    }
}