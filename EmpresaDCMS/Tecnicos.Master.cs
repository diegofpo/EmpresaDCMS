using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class Tecnicos : System.Web.UI.MasterPage
    {
        public string IdUsuario
        {
            get { return (string)(Session["Tecnico"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Tecnico"] != null)
            {
                usuario.Text = "Id activo: " + Session["Tecnico"].ToString();
            }
        }
    }
}