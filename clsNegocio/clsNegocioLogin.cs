using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsDatos;

namespace clsNegocio
{
    public class clsNegocioLogin
    {
        clsDatosLogin datosLogin = new clsDatosLogin();

        public string login(string idEmpleado, string claveEmpleado)
        {
            try
            {
                string idValido = datosLogin.login(idEmpleado, claveEmpleado);
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
