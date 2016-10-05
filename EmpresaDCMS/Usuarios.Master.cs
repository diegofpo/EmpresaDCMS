using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class Usuarios : System.Web.UI.MasterPage
    {
        public string IdUsuario
        {
            get { return (string)(Session["Usuario"]); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] != null)
            {
                usuario.Text = "Id activo:" + Session["Usuario"].ToString();
            }
        }
    }
}