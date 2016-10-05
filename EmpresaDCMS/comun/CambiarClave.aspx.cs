using clsNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS.comun
{
    public partial class CambiarClave : System.Web.UI.Page
    {
        clsNegocioCambiarClave negocioClave = new clsNegocioCambiarClave();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtId.Text = Session[0].ToString();
            txtId.Enabled = false;
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {
            int idEmpleado = int.Parse(txtId.Text);
            string clave = txtConfirmarPassword.Text;
            try
            {
                Response.Write(negocioClave.cambiarPassword(idEmpleado, clave));
                //Response.Redirect(Request.UrlReferrer.ToString());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}