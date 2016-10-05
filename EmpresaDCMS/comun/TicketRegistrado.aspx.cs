using clsNegocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS.comun
{
    public partial class TicketRegistrado : System.Web.UI.Page
    {
        clsNegocioTicketsRegistrados negocioTicketRegistrado = new clsNegocioTicketsRegistrados();

        protected void Page_Load(object sender, EventArgs e)
        {
            PanelBoton.Visible = false;
            string idEmpleado = "";
            if (Request.QueryString["Id"] != null)
            {
                idEmpleado = Request.QueryString["Id"].ToString();
            }
            DataTable tablaTicketsRegistrados = new DataTable();
            tablaTicketsRegistrados = negocioTicketRegistrado.tablaTregistrados(int.Parse(idEmpleado));
            if (tablaTicketsRegistrados != null && tablaTicketsRegistrados.Rows.Count > 0)
            {
                gvRegistro.DataSource = tablaTicketsRegistrados;
                gvRegistro.DataBind();
                lblMensaje.Text = "";
            }
            else
            {
                lblMensaje.Text = "No existen tickets registrados.";
            }
        }

        protected void gvRegistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvRegistro.SelectedRow.Cells[4].Text.Equals("Completado"))
            {
                panelCalificar.Visible = true;
            }
            else
            {
                Response.Write("Este ticket no se puede calificar.");
                panelCalificar.Visible = false;
            }
        }

        protected void btnCalificar_Click(object sender, EventArgs e)
        {
            int idTicket = int.Parse(gvRegistro.SelectedRow.Cells[1].Text);
            if (PanelCalificacion2.Visible == true)
            {
                int cf1, cf2, cf3;
                cf1 = int.Parse(rbCalificacion4.SelectedItem.Value);
                cf2 = int.Parse(rbCalificacion2.SelectedItem.Value);
                cf3 = int.Parse(rbCalificacion3.SelectedItem.Value);
                int calificacion = cf1 + cf2 + cf3;
                Response.Write(negocioTicketRegistrado.calificarTicket(idTicket, calificacion));
                panelCalificar.Visible = false;
                PanelCalificacion2.Visible = false;
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                int calificacion = 0;
                Response.Write(negocioTicketRegistrado.calificarTicket(idTicket, calificacion));
                panelCalificar.Visible = false;
                PanelCalificacion2.Visible = false;
                Response.Redirect(Request.UrlReferrer.ToString());
            }
        }

        protected void rbCalificacion4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rbCalificacion1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbCalificacion1.SelectedItem.Text.Equals("Si"))
            {
                PanelCalificacion2.Visible = true;
                PanelBoton.Visible = true;
            }
            else if (rbCalificacion1.SelectedItem.Text.Equals("No"))
            {
                PanelCalificacion2.Visible = false;
                PanelBoton.Visible = true;
            }
        }
    }
}