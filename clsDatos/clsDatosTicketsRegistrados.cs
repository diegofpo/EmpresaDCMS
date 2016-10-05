using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos
{
    public class clsDatosTicketsRegistrados
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


        public DataTable tablaTregistrados(int idEmpleado)
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select idTicket as 'Ticket', CONVERT(VARCHAR(11), fechaIngreso,6) as 'Fecha de ingreso', CONVERT(VARCHAR(11), fechaSolucion,6) as 'Fecha maxima para solucionar', et.nombreEstadoTicket as 'Estado' from Ticket t inner join EstadoTicket et on t.estadoTicket = et.idEstadoTicket where t.idEmpleado =" + idEmpleado + "", cn);
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

        public string calificarTicket(int idTicket, char calificacionSolucion, int estadoTicket)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Ticket set calificacionSolucion = '" + calificacionSolucion + "', estadoTicket = "+estadoTicket+" where idTicket = " + idTicket + "", cn);
                cmdBD.ExecuteNonQuery();
                return "Calificacion enviada.";
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
