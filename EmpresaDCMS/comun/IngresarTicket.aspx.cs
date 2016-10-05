using clsNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS.comun
{
    public partial class IngresarTicket : System.Web.UI.Page
    {
        clsNegocioInsertarTicket negocioInsertar = new clsNegocioInsertarTicket();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                txtId.Text = Request.QueryString["Id"].ToString();
                txtId.ReadOnly = true;
                panelPregunta.Visible = false;
                txtFechaIngreso.Text = DateTime.Now.ToString("yyyy-MM-dd");
                if (ddlPrioridad.Items.Count == 0)
                {
                    DataTable dtPrioridad = new DataTable();
                    llenarPrioridad(dtPrioridad);
                }
                if (ddlCategoria.Items.Count == 0)
                {
                    DataTable dtCategoria = new DataTable();
                    llenarCategoria(dtCategoria);
                }
            }
            else
            {
                Response.Redirect("~/comun/login.aspx");
            }
        }

        private void llenarPrioridad(DataTable dtPrioridad)
        {
            try
            {
                ddlPrioridad.Items.Add("--Seleccionar--");
                dtPrioridad = negocioInsertar.TablaPrioridad();
                ddlPrioridad.DataTextField = "nombrePrioridad";
                ddlPrioridad.DataValueField = "idPrioridad";
                ddlPrioridad.DataSource = dtPrioridad;
                ddlPrioridad.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarCategoria(DataTable dtCategoria)
        {
            try
            {
                ddlCategoria.Items.Add("--Seleccionar--");
                dtCategoria = negocioInsertar.TablaCategoria();
                ddlCategoria.DataTextField = "nombreCategoria";
                ddlCategoria.DataValueField = "idCategoria";
                ddlCategoria.DataSource = dtCategoria;
                ddlCategoria.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPrioridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fechaS;
            System.DateTime today = System.DateTime.Now;
            switch (ddlPrioridad.SelectedItem.Text)
            {
                case "Alta":
                    coloPrioridad.Visible = true;
                    coloPrioridad.BackColor = System.Drawing.Color.Red;
                    fechaS = (today.AddDays(0)).ToString("yyyy-MM-dd");
                    txtFechaSolucion.Text = fechaS;
                    break;
                case "Media":
                    coloPrioridad.Visible = true;
                    coloPrioridad.BackColor = System.Drawing.Color.Orange;
                    fechaS = (today.AddDays(1)).ToString("yyyy-MM-dd");
                    txtFechaSolucion.Text = fechaS;
                    break;
                case "Baja":
                    coloPrioridad.Visible = true;
                    coloPrioridad.BackColor = System.Drawing.Color.Green;
                    fechaS = (today.AddDays(2)).ToString("yyyy-MM-dd");
                    txtFechaSolucion.Text = fechaS;
                    break;
                default:
                    coloPrioridad.Visible = false;
                    txtFechaSolucion.Text = "";
                    break;
            }
        }

        protected void btnIngresarTicket_Click(object sender, EventArgs e)
        {
            int idEmpleado = int.Parse(txtId.Text);
            int idPrioridad = int.Parse(ddlPrioridad.SelectedItem.Value);
            int idCategoria = int.Parse(ddlCategoria.SelectedItem.Value);
            string descripcion = txtDescripcion.Text;
            string fechaI = txtFechaIngreso.Text;
            string fechaS = txtFechaSolucion.Text;
            List<int> listaTecnicos = new List<int>();
            Random rand = new Random();
            listaTecnicos = listaTecnicosDB(listaTecnicos);
            int idTecnico = listaTecnicos[rand.Next(0, (listaTecnicos.Count))];
            while (idTecnico.ToString().Equals(txtId.Text))
            {
                idTecnico = listaTecnicos[rand.Next(0, (listaTecnicos.Count))];
            }
            if (hojaPregunta.SelectedItem ==null)
            {
                int valido = negocioInsertar.InsertarTicket(idEmpleado, idTecnico, fechaI, fechaS);
                if (valido == 1)
                {
                    int idTicket = negocioInsertar.buscarIdTicket();
                    int aux = negocioInsertar.InsertarDetalle(idTicket, idCategoria, descripcion, idPrioridad);
                    if (aux == 1)
                    {
                        panelPregunta.Visible = true;
                        Panel1.Enabled = false;
                        panelPregunta.Enabled = true;
                        Response.Write("Ticket ingresado.");
                        notificarTecnico(idTecnico);
                    }
                }
            }
            else
            {
                int idTicket = negocioInsertar.buscarIdTicket();
                int aux = negocioInsertar.InsertarDetalle(idTicket, idCategoria, descripcion, idPrioridad);
                if (aux == 1)
                {
                    panelPregunta.Enabled = true;
                    panelPregunta.Visible = true;
                    Panel1.Enabled = false;
                    Response.Write("Ticket actualizado.");
                }
            }
        }

        private void notificarTecnico(int idTecnico)
        {
            try
            {
                string email = negocioInsertar.emailTecnico(idTecnico);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("infodcmshelp@gmail.com");
                mail.To.Add(email);
                mail.Subject = "No contestar a este correo.";
                mail.Body = "Se le ha asignado la solucion de un problema, por favor ingrese a su peril para ver dicho problema.";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("infodcmshelp@gmail.com", "P4ssw0rD");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Response.Write("No se pudo conectar con el servidor.");
            }
        }

        private List<int> listaTecnicosDB(List<int> listaTecnicos)
        {
            listaTecnicos = negocioInsertar.listaTecnicosBD(listaTecnicos);
            return listaTecnicos;
        }

        protected void hojaPregunta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (hojaPregunta.SelectedItem.Text.Equals("Si"))
            {
                panelPregunta.Visible = true;
                panelPregunta.Enabled = false;
                Panel1.Enabled = true;
                txtId.Enabled = false;
                txtFechaIngreso.Enabled = false;
                txtFechaSolucion.Enabled = false;
            }
            else if (hojaPregunta.SelectedItem.Text.Equals("No"))
            {
                Panel1.Enabled = false;
                panelPregunta.Enabled = false;
                txtId.Enabled = true;
                txtFechaIngreso.Enabled = true;
                txtFechaSolucion.Enabled = true;
                lblMensaje.Text = "Gracias por registrar su ticket.";
            }
        }
    }
}