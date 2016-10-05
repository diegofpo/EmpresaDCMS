using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosPrioridadTicket
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

        public int buscaridPrioridad()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Prioridad", cn);
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

        public string insertarPrioridad(string prioridad)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("insert into Prioridad values ('" + prioridad + "')", cn);
                cmdBD.ExecuteNonQuery();
                return "La informacion se ingreso de manera correcta.";
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

        public string modificarPrioridad(int idPrioridad, string prioridad)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Prioridad set nombrePrioridad = '" + prioridad + "' where idPrioridad = " + idPrioridad + "", cn);
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

        public string eliminarPrioridad(int idPrioridad)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from Prioridad where idPrioridad = " + idPrioridad + "", cn);
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

        public int buscarId(int idPrioridad)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Prioridad where idPrioridad = " + idPrioridad + "", cn);
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

        public string nombrePrioridad(int idPrioridad)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select nombrePrioridad from Prioridad where idPrioridad = " + idPrioridad + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["nombrePrioridad"].ToString();
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
