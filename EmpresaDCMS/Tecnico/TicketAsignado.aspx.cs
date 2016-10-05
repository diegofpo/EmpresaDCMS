using clsNegocio.Tecnico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        clsNegocioTicketsAsignados negocioTicketAsignado = new clsNegocioTicketsAsignados();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string idTecnico = Master.IdUsuario;
                DataTable tablaTicketsAsignados = new DataTable();
                tablaTicketsAsignados = negocioTicketAsignado.tablaTasignados(int.Parse(idTecnico));
                if (tablaTicketsAsignados != null && tablaTicketsAsignados.Rows.Count > 0)
                {
                    gvAsignado.DataSource = tablaTicketsAsignados;
                    gvAsignado.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No existen tickets asignados.";
                }
            }
            catch (Exception ex)
            {
                Response.Write("Su sesion ha expirado.");
                Response.Redirect("../comun/login.aspx");
            }
        }

        public void notificarEmpleado()
        {
            try
            {
                int idTicketSeleccionado = int.Parse(gvAsignado.SelectedRow.Cells[1].Text);
                string email = negocioTicketAsignado.emailEmpeado(idTicketSeleccionado);

                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("infodcmshelp@gmail.com");
                mail.To.Add(email);
                mail.Subject = "No contestar a este correo.";
                mail.Body = "Se ha realizado la solucion al ticket que ha ingresado, por favor ingrese a su pagina para calificar la solucion.";

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

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Write(negocioTicketAsignado.actualizarEstado(int.Parse(gvAsignado.SelectedRow.Cells[1].Text)));
            notificarEmpleado();
            panelDetalle.Visible = false;
            Response.Redirect(Request.RawUrl);
        }

        protected void gvAsignado_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetalle.Visible = true;
            int idTicketSeleccionado = int.Parse(gvAsignado.SelectedRow.Cells[1].Text);
            DataTable tablaTicketsSeleccionado = new DataTable();
            tablaTicketsSeleccionado = negocioTicketAsignado.tablaTdetalles(idTicketSeleccionado);
            gvDetalle.DataSource = tablaTicketsSeleccionado;
            gvDetalle.DataBind();
        }
    }
}