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
    public partial class WebForm17 : System.Web.UI.Page
    {
        clsNegocioTicketsCerrados negocioTcerrado = new clsNegocioTicketsCerrados();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string idTecnico = Master.IdUsuario;
                DataTable tablaTicketsAsignados = new DataTable();
                tablaTicketsAsignados = negocioTcerrado.tablaTasignados(int.Parse(idTecnico));
                gvCerrado.DataSource = tablaTicketsAsignados;
                gvCerrado.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}