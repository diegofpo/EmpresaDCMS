using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsNegocio;
using clsDatos.Administrador;
namespace clsNegocio.Administrador
{
    public class clsNegocioRol
    {
        clsDatosRol datosRol = new clsDatosRol();

        public int buscaridRol()
        {
            try
            {
                int idValido = datosRol.buscaridRol();
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string InsertarRol(string nombreRol)
        {
            try
            {
                return datosRol.InsertarRol(nombreRol);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idRol)
        {
            try
            {
                return datosRol.buscarId(idRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string nombreRol(int idRol)
        {
            try
            {
                return datosRol.nombreRol(idRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarRol(int idRol, string rol)
        {
            try
            {
                return datosRol.modificarRol(idRol, rol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarRol(int idRol)
        {
            try
            {
                return datosRol.eliminarRol(idRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
