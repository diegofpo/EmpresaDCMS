using clsNegocio.Tecnico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        clsNegocioTicketRetrasado negocioTicketRetrasado = new clsNegocioTicketRetrasado();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string idTecnico = Master.IdUsuario;
                DataTable tablaTicketsAsignados = new DataTable();
                tablaTicketsAsignados = negocioTicketRetrasado.datosTretrasado(int.Parse(idTecnico));
                if (tablaTicketsAsignados != null && tablaTicketsAsignados.Rows.Count > 0)
                {
                    gvRetrasados.DataSource = tablaTicketsAsignados;
                    gvRetrasados.DataBind();
                }
                else
                {
                    lblMensaje.Text = "No existen tickets asignados.";
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void gvRetrasados_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelDetalle.Visible = true;
            int idTicketSeleccionado = int.Parse(gvRetrasados.SelectedRow.Cells[1].Text);
            DataTable tablaTicketsSeleccionado = new DataTable();
            tablaTicketsSeleccionado = negocioTicketRetrasado.tablaTdetalles(idTicketSeleccionado);
            gvDetalle.DataSource = tablaTicketsSeleccionado;
            gvDetalle.DataBind();
        }
    }
}