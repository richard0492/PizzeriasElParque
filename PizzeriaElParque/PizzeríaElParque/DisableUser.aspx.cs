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
    public partial class DisableUser : System.Web.UI.Page
    {
        string[] nameUser;
        string[] nameUserModify;
        LogicUser data = new LogicUser();


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
                tbType.Text = nameUserModify[5];
            }

           
        }

        protected void btbDisable_Click(object sender, EventArgs e)
        {
            data.DeleteUser(Convert.ToInt32(tbIDCard.Text.Trim()),'n');
        }

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
            tbType.Text = nameUserModify[5];
        }
    }
}