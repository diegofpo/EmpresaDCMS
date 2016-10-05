using clsDatos.Tecnico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio.Tecnico
{
    public class clsNegocioTicketsAsignados
    {
        clsDatosTicketsAsignados datosTasignados = new clsDatosTicketsAsignados();
        int estadoCompletado = 3;

        public DataTable tablaTasignados(int idTecnico)
        {
            try
            {
                return datosTasignados.tablaTasignados(idTecnico);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable tablaTdetalles(int idTicketSeleccionado)
        {
            try
            {
                return datosTasignados.tablaTdetalles(idTicketSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string actualizarEstado(int idTicketSeleccionado)
        {
            try
            {
                return datosTasignados.actualizarEstado(idTicketSeleccionado, estadoCompletado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string emailEmpeado(int idTicketSeleccionado)
        {
            try
            {
                return datosTasignados.emailEmpleado(idTicketSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
