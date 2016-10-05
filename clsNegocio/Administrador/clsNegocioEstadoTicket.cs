using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsNegocio.Administrador;
using clsDatos.Administrador;
namespace clsNegocio.Administrador
{
    public class clsNegocioEstadoTicket
    {
        clsDatosEstadoTicket datosEstado = new clsDatosEstadoTicket();


        public int buscaridEstado()
        {
            try
            {
                int idValido = datosEstado.buscaridEstado();
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ingresarEstado(string estado)
        {
            try
            {
                return datosEstado.insertarEstado(estado);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string modificarEstado(int idEstado, string estado)
        {
            try
            {
                return datosEstado.modificarEstado(idEstado, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarEstado(int idEstado)
        {
            try
            {
                return datosEstado.eliminarEstado(idEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idEstado)
        {
            try
            {
                return datosEstado.buscarId(idEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string nombreEstado(int idEstado)
        {
            try
            {
                return datosEstado.nombreEstado(idEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
