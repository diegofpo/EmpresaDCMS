using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usuario = Master.IdUsuario;
            Response.Redirect("../comun/IngresarTicket.aspx?Id=" + usuario);
        }
    }
}