using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos
{
    public class clsDatosInsertarTicket
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

        public int buscaridEmpleado(int idEmpleado)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Empleado where idEmpleado = " + idEmpleado + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont++;
                }
                leerDataBD.Close();
                if (cont != 0)
                {
                    return cont;
                }
                else
                {
                    return idEmpleado;
                }
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

        public DataTable TablaPrioridad()
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select * from Prioridad", cn);
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

        public DataTable TablaCategoria()
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select * from Categoria", cn);
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

        public List<int> listaTecnicosBD(List<int> listaTecnicos)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("select idEmpleado from Empleado where rolEmpleado = 2", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    listaTecnicos.Add(int.Parse(leerDataBD["idEmpleado"].ToString()));
                }
                leerDataBD.Close();
                return listaTecnicos;
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

        public int InsertarTicket(int idEmpleado, int idTecnico, string fechaI, string fechaS, int estado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("exec InsertarTicket " + idEmpleado + ", " + idTecnico + ", '" + fechaI + "', '" + fechaS + "', " + estado + "", cn);
                cmdBD.ExecuteNonQuery();
                return 1;
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

        public int buscarIdTicket()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select max(idTicket) as 'Ultimo' from Ticket", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = int.Parse(leerDataBD["Ultimo"].ToString());
                }
                leerDataBD.Close();
                return cont;
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

        public int InsertarDetalle(int idTicket, int idCategoria, string descripcion, int idPrioridad)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("exec InsertarDetalle "+idCategoria+", "+idPrioridad+", "+idTicket+", '"+descripcion+"'", cn);
                cmdBD.ExecuteNonQuery();
                return 1;
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

        public string emailTecnico(int idTecnico)
        {
            try
            {
                this.Abrir();
                string email = "";
                cmdBD = new SqlCommand("select email from Empleado where idEmpleado = "+idTecnico+"", cn);
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
