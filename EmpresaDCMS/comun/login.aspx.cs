using clsNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS.comun
{
    public partial class login : System.Web.UI.Page
    {
        clsNegocioLogin negocioLogin = new clsNegocioLogin();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string idEmpleado = Login1.UserName.ToString();
            string claveEmpleado = Login1.Password.ToString();
            string cont = negocioLogin.login(idEmpleado, claveEmpleado);
            if (cont.Equals("0"))
            {
                Login1.FailureText = "Usuario y/o password incorrecto.";
            }
            else
            {
                switch (cont)
                {
                    case "1":
                            Session.Add("Administrador", Login1.UserName);
                            FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                            Response.Redirect("../Administrador/admin.aspx?Rol=" + cont + "?Id=" + idEmpleado);
                        break;
                    case "2":
                            Session.Add("Tecnico", Login1.UserName);
                            FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                            Response.Redirect("../Tecnico/tecnico.aspx?Rol=" + cont + "?Id=" + idEmpleado);
                        break;
                    case "3":
                            Session.Add("Usuario", Login1.UserName);
                            FormsAuthentication.SetAuthCookie(Login1.UserName, Login1.RememberMeSet);
                            Response.Redirect("../Usuario/usuario.aspx?Rol=" + cont + "?Id=" + idEmpleado);
                        break;
                }
            }
        }
    }
}