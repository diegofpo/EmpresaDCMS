using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsDatos.Administrador;

namespace clsNegocio.Administrador
{
    public class clsNegocioPrioridadTicket
    {
        clsDatosPrioridadTicket datosPrioridad = new clsDatosPrioridadTicket();

        public int buscaridPrioridad()
        {
            try
            {
                int idValido = datosPrioridad.buscaridPrioridad();
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idPrioridad)
        {
            try
            {
                return datosPrioridad.buscarId(idPrioridad);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string nombrePrioridad(int idPrioridad)
        {
            try
            {
                return datosPrioridad.nombrePrioridad(idPrioridad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string insertarPrioridad(string nombrePrioridad)
        {
            try
            {
                return datosPrioridad.insertarPrioridad(nombrePrioridad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarPrioridad(int idPrioridad, string nombrePrioridad)
        {
            try
            {
                return datosPrioridad.modificarPrioridad(idPrioridad, nombrePrioridad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarPrioridad(int idPrioridad)
        {
            try
            {
                return datosPrioridad.eliminarPrioridad(idPrioridad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
