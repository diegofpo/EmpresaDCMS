using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Tecnico
{
    public class clsDatosTicketsAsignados
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

        public System.Data.DataTable tablaTasignados(int idTecnico)
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select idTicket as 'Ticket', idEmpleado as'Solicitante',fechaIngreso as 'Fecha de ingreso', fechaSolucion as 'Fecha maxima para solucionar' from Ticket where idTecnico = " + idTecnico + " and estadoTicket=2", cn);
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

        public DataTable tablaTdetalles(int idTicketSeleccionado)
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select dt.prioridadTicket as 'Prioridad', dt.categoriaTicket as 'Categoria', dt.descripcionProblema as 'Descripcion' from DetalleTicket dt inner join Ticket t on dt.idTicket = t.idTicket where t.estadoTicket=2 and t.idTicket="+idTicketSeleccionado+" order by dt.prioridadTicket asc", cn);
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

        public string actualizarEstado(int idTicketSeleccionado, int estadoCompletado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Ticket set estadoTicket = "+estadoCompletado+" where idTicket = "+idTicketSeleccionado+"", cn);
                cmdBD.ExecuteNonQuery();
                return "Ticket Completado";
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

        public string emailEmpleado(int idTicketSeleccionado)
        {
            try
            {
                this.Abrir();
                string email = "";
                cmdBD = new SqlCommand("select email from Empleado where idEmpleado = (select idEmpleado from Ticket where idTicket = "+idTicketSeleccionado+")", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    email = leerDataBD["email"].ToString();
                }
                leerDataBD.Close();
                return email;
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
