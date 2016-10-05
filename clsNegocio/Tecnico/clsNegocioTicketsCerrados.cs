using clsDatos.Tecnico;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio.Tecnico
{
    public class clsNegocioTicketsCerrados
    {
        clsDatosTicketsCerrados datosTcerrados = new clsDatosTicketsCerrados();

        public DataTable tablaTasignados(int idTecnico)
        {
            try
            {
                return datosTcerrados.tablaTcerrados(idTecnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
