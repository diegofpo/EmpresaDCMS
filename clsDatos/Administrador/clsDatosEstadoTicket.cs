using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosEstadoTicket
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

        public int buscaridEstado()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from EstadoTicket", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont++;
                }
                leerDataBD.Close();
                if (cont == 0)
                {
                    cont = 1;
                    return cont;
                }
                else
                {
                    return (cont + 1);
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

        public string insertarEstado(string estado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("insert into EstadoTicket values ('" + estado + "')", cn);
                cmdBD.ExecuteNonQuery();
                return "La informacion se ingreso de manera correcta.";
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Cerrar();
            }
        }

        public string modificarEstado(int idEstado, string estado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update EstadoTicket set nombreEstadoTicket = '" + estado + "' where idEstadoTicket = "+idEstado+"", cn);
                cmdBD.ExecuteNonQuery();
                return "La informacion se actualizo de manera correcta.";
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

        public string eliminarEstado(int idEstado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from EstadoTicket where idEstadoTicket = " + idEstado + "", cn);
                cmdBD.ExecuteNonQuery();
                return "La informacion se actualizo de manera correcta.";
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

        public int buscarId(int idEstado)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from EstadoTicket where idEstadoTicket = " + idEstado + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont++;
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

        public string nombreEstado(int idEstado)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select nombreEstadoTicket from EstadoTicket where idEstadoTicket = " + idEstado + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["nombreEstadoTicket"].ToString();
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
    }
}
