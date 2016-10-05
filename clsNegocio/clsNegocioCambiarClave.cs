using clsDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio
{
    public class clsNegocioCambiarClave
    {
        clsDatosCambiarClave datosClave = new clsDatosCambiarClave();

        public string cambiarPassword(int idEmpleado, string clave)
        {
            try
            {
                return datosClave.cambiarPassword(idEmpleado, clave);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
