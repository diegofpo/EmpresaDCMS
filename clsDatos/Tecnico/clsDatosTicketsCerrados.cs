using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Tecnico
{
    public class clsDatosTicketsCerrados
    {
        SqlCommand cmdBD;
        SqlDataReader leerDataBD;
        SqlDataAdapter adaptadorBD;
        DataTable tablasDatos;
        public SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=DCMS;Integrated Security=True");

        public void Abrir()
        {
            try
            {
                if (cn.State == ConnectionState.Closed)
                    cn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Cerrar()
        {
            try
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable tablaTcerrados(int idTecnico)
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select idTicket as 'Ticket', idEmpleado as'Solicitante',CONVERT(VARCHAR(11), fechaIngreso,6) as 'Fecha de ingreso',CONVERT(VARCHAR(11), fechaSolucion,6) as 'Fecha maxima para solucionar' from Ticket where idTecnico = " + idTecnico + " and estadoTicket = 4", cn);
                tablasDatos = new DataTable();
                adaptadorBD.Fill(tablasDatos);
                return tablasDatos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cerrar();
            }
        }
    }
}
