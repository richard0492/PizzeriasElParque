using System;
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
    public partial class AddOrderAdmin : System.Web.UI.Page
    {
        string[] nameUser;
        DataTable aux;
        DataTable table = new DataTable();
        LogicOrder order = new LogicOrder();
        LogicProduct logicProduct = new LogicProduct();

        int orderList;
        /// <summary>
        /// Carga la página y incializa variables, así como comprueba el usuario con la sesión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Session["Order"] = null;
                Session["Test"] = null;
                Session["TypeOrder"] = '1';
                loadTable();
            }



        }
        /// <summary>
        /// Carga el dataTable con el formato de la factura de las lineas de orden
        /// </summary>
        public void loadTable() {
            if (Session["Order"] == null)
            {

                aux = new DataTable("Orders");
                aux.Columns.Add("codigoProducto", System.Type.GetType("System.String"));
                aux.Columns.Add("descripcionProducto", System.Type.GetType("System.String"));
                aux.Columns.Add("precioProducto", System.Type.GetType("System.Double"));
                aux.Columns.Add("cantidadProducto", System.Type.GetType("System.Int32"));
                aux.Columns.Add("subTotal", System.Type.GetType("System.Double"));
                Session["Order"] = aux;
                Session["Test"] = aux;
            }
            else {
                Session["Order"] = Session["Test"];
            }

        }
        /// <summary>
        /// Evento click para agragegar un producto a la orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void addProduct_Click(object sender, EventArgs e)
        {


            addItemProduct();

            
        }
        /// <summary>
        /// Agrega un un producto a la factura que se convierte en una linea de orden
        /// </summary>
        /// <returns> Boolean que confirma el resultado</returns>
        public Boolean addItemProduct() {


            string code;
            if (txtProductCode.Text != "")//Se comprueba los campos
            {
                Product product = logicProduct.consultProductObject(txtProductCode.Text.Trim());
                if (product.name != null)
                {
                    table = (DataTable)Session["Order"];// se incializa el datatable que tiene la variable de sesión.
                    if (GridView1.Rows.Count != 0) {

                        foreach (DataRow dr in table.Rows)//Se recorre para agregar y actualizar valores en el grid y en el data table
                        {
                            if (dr["codigoProducto"].ToString() == product.code.ToString())
                            {
                                dr["cantidadProducto"] = (Convert.ToInt32(dr["cantidadProducto"])) + 1;

                                for (int i = 0; i < GridView1.Rows.Count; i++)
                                {
                                    code = (GridView1.Rows[i].Cells[1].Text.Trim());
                                    foreach (DataRow obj in table.Rows)
                                    {
                                        if (obj["codigoProducto"].ToString() == code.ToString())
                                        {
                                            ((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text = obj["cantidadProducto"].ToString();
                                        }
                                    }
                                }
                                updateData();
                                return true;
                            }
                        }
                    }
                   

                    double subTotal;
                    int quantity = 1;
                    subTotal = (quantity * product.price);
                    
                    DataRow row = table.NewRow();
                    row[0] = product.code;
                    row[1] = product.name;
                    row[2] = product.price;
                    row[3] = quantity;
                    row[4] = subTotal;
                    table.Rows.Add(row);
                    Session["Order"] = table;
                    GridView1.DataSource = (DataTable)Session["Order"];
                    GridView1.DataBind();

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        code = (GridView1.Rows[i].Cells[1].Text.Trim());
                        foreach (DataRow dr in table.Rows)
                        {
                            if (dr["codigoProducto"].ToString() == code.ToString())
                            {
                                ((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text = dr["cantidadProducto"].ToString();
                            }
                        }
                    }
                    updateData();
                }
                else
                {
                    StringBuilder sbMensaje = new StringBuilder();
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("toastr.warning('No existe Producto con ese Código');");
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                }
            }
            else
            {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("toastr.error('Debe ingresar un código para buscar el producto');");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

            }
            txtProductCode.Text = "";
            return true;
        }
        /// <summary>
        /// Se llama al evento para eliminar una fila de la linea de orden
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string code;
            int index = e.RowIndex;
            DataTable aux = new DataTable();
            aux = (DataTable)Session["Order"];
            aux.Rows[index].Delete();

            lbTotal.Text = totalOrder(aux).ToString();
            GridView1.DataSource = aux;
            GridView1.DataBind();
            Session["Order"] = aux;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                code = (GridView1.Rows[i].Cells[1].Text.Trim());
                foreach (DataRow dr in aux.Rows)
                {
                    if (dr["codigoProducto"].ToString() == code.ToString())
                    {
                        ((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text = dr["cantidadProducto"].ToString();
                    }
                }
            }
            updateData();
        }
        /// <summary>
        /// Calcula el total de la orden de nuevo
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public double totalOrder(DataTable dt)
        {
            double total = 0;
            foreach (DataRow item in dt.Rows)
            {
                total += Convert.ToDouble(item[4]);
            }
            return total;
        }
        /// <summary>
        /// Evento que llama a actualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData();
        }

        /// <summary>
        /// Método para actualizar los datos que se muestran en el formuario
        /// </summary>
        public void updateData(){
            //int i;
            double total = 0, price, subtotal = 0;
            string code, description;
            int quantity;

            var items = (DataTable)Session["Order"];

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                code = (GridView1.Rows[i].Cells[1].Text.Trim());
                description = (GridView1.Rows[i].Cells[2].Text.Trim());
                price = System.Convert.ToDouble(GridView1.Rows[i].Cells[3].Text.Trim());
                quantity = System.Convert.ToInt32(((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text.Trim());
                double priceAux = System.Convert.ToDouble(price);
                subtotal = quantity * priceAux;
                GridView1.Rows[i].Cells[5].Text = subtotal.ToString();
                foreach (DataRow dr in items.Rows)
                {
                    if (dr["codigoProducto"].ToString() == code.ToString())
                    {
                        dr["cantidadProducto"] = quantity;
                        dr["subTotal"] = subtotal;
                    }
                }

                total = total + subtotal;
            }

           
            lbTotal.Text = "₡ " + total.ToString("0.00");

        }
        /// <summary>
        /// Evento para renderizar componentes y ocultar otros si es orden de local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLocal_Click(object sender, EventArgs e)
        {
            checkExpress.Visible = false;
            checkLocal.Visible = true;
            phone.Visible = false;
            direction.Visible = false;
            tbDirection.Visible = false;
            tbPhone.Visible = false;
            lbtable.Visible = true;
            txtNumTable.Visible = true;
            Session["TypeOrder"] = '1';
        }

        /// <summary>
        ///  Evento para renderizar componentes y ocultar otros si es orden de Express
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExpress_Click(object sender, EventArgs e)
        {
            checkExpress.Visible = true;
            checkLocal.Visible = false;
            phone.Visible = true;
            direction.Visible = true;
            tbDirection.Visible = true;
            tbPhone.Visible = true;
            lbtable.Visible = false;
            txtNumTable.Visible = false;
            Session["TypeOrder"] = '2';
        }
        /// <summary>
        /// Event to insert order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> event</param>
        protected void btnAgregar_Click(object sender, EventArgs e)
        {

           
            try
            {
                if (addOrderAndLineOrders() == true) {


                   ScriptManager.RegisterClientScriptBlock(this,this.GetType(), "key", "showModal()", true);

                };
            }
            catch (Exception ex) {
                StringBuilder sbMensaje = new StringBuilder();
                sbMensaje.Append("<script type='text/javascript'>");
                sbMensaje.AppendFormat("toastr.warning('Ocurrió algún error al agregar la orden');");
                sbMensaje.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

            }

            //}
        }

        protected void btnLocal_Click(object sender, EventArgs e)
        {
            phone.Visible = false;
            direction.Visible = false;
            tbDirection.Visible = false;
            tbPhone.Visible = false;
            lbtable.Visible = true;
            txtNumTable.Visible = true;
        }

        protected void btnExpress_Click(object sender, EventArgs e)
        {
            phone.Visible = true;
            direction.Visible = true;
            tbDirection.Visible = true;
            tbPhone.Visible = true;
            lbtable.Visible = false;
            txtNumTable.Visible = false;
        }
      
        /// <summary>
        /// El evento que inserta la orden a la base de datos y tambien cada línea de orden de la factura
        /// </summary>
        /// <returns>Retorna un boolean con la confirmación de que se agregó</returns>
        public Boolean addOrderAndLineOrders() {
            if (validationForm() == true) {

                if (GridView1.Rows.Count == 0)
                {

                    StringBuilder sbMensaje = new StringBuilder();
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("toastr.warning('Debe insertar productos a la orden para enviarla');");
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());

                }
                else
                {
                   
                    orderList = order.lastOrder();
                    int nextOrder = orderList + 1;


                    Order orderObject = new Order();
                    orderObject.orderID = nextOrder;
                    orderObject.partyId = Convert.ToInt32(Session["ID"]);
                   
                    orderObject.orderType = (Char)Session["TypeOrder"];
                    orderObject.estadeId = 1;
                    if (txtClientName.Text.Trim() == "")
                    {
                        orderObject.nameClient = "Desconocido";
                    }
                    else
                    {
                        orderObject.nameClient = txtClientName.Text.Trim();
                    }
                    if (Session["TypeOrder"].Equals('2'))
                    {
                        orderObject.address = tbDirection.Text.Trim();                    
                        orderObject.phone = Convert.ToInt32(tbPhone.Text.Trim());
                       
                    }
                    else
                    {
                        if (Session["TypeOrder"].Equals('1'))
                        {
                           orderObject.tableNumber = txtNumTable.Text.Trim();
                           orderObject.phone = 0;
                           orderObject.address = "";
                        }
                    }

                    orderObject.additional = txtDescription.Text.Trim();
                    order.insertOrder(orderObject);


                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        LineOrder lineOrder = new LineOrder();
                        lineOrder.orderId = nextOrder;
                        lineOrder.productId = Convert.ToInt32(GridView1.Rows[i].Cells[1].Text.Trim());
                        lineOrder.quantity = System.Convert.ToInt32(((TextBox)this.GridView1.Rows[i].Cells[4].FindControl("TextBox1")).Text.Trim());

                        order.insertLineOders(lineOrder);
                    }
                   
                    return true;
                }

            }
            
            return false;
        }
        /// <summary>
        /// Método que valida los campos del formulario dependiendo del tipo de orden que se inserte.
        /// </summary>
        /// <returns></returns>
        public Boolean validationForm() {


            if (Session["TypeOrder"].Equals('2')) {

                if (tbPhone.Text.Trim() == "")
                    {
                        StringBuilder sbMensaje = new StringBuilder();
                        sbMensaje.Append("<script type='text/javascript'>");
                        sbMensaje.AppendFormat("toastr.warning('Debe insertar un número de teléfono para la orden express');");
                        sbMensaje.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());
                        return false;
                    }


                if ( tbDirection.Text.Trim() == "") {
                    StringBuilder sbMensaje = new StringBuilder();
                    sbMensaje.Append("<script type='text/javascript'>");
                    sbMensaje.AppendFormat("toastr.warning('Debe insertar una dirección de entrega para la orden express');");
                    sbMensaje.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "mensaje", sbMensaje.ToString());
                    return false;

                }
            }

                return true;
        }

      /// <summary>
      /// Evento que reedirecciona a la página madre.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        protected void lnkRedireccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddOrderAdmin.aspx");
        }
        /// <summary>
        ///Evento con un contador de tiempo para que se actualicen las cantidades cada 2 segundos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Unnamed2_Tick(object sender, EventArgs e)
        {
            updateData();
        }
    }

}