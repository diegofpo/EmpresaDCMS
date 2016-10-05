using clsDatos.Tecnico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio.Tecnico
{
    public class clsNegocioTicketRetrasado
    {
        clsDatosTicketRetrasado datosTretrasados = new clsDatosTicketRetrasado();

        public DataTable datosTretrasado(int idTecnico)
        {
            try
            {
                return datosTretrasados.tablaTretrasado(idTecnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable tablaTdetalles(int idTicketSeleccionado)
        {
            try
            {
                return datosTretrasados.tablaTdetalles(idTicketSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
