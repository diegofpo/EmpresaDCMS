using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosRol
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

        public int buscaridRol()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Rol", cn);
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

        public string InsertarRol(string nombreRol)
        {
            string salida = "Datos ingresados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("insert into Rol values ( '"+nombreRol+"')", cn);
                cmdBD.ExecuteNonQuery();
                return salida;
            }
            catch (Exception ex)
            {
                salida = "No se pudo actualizar: " + ex.ToString();
                return salida;
            }
            finally
            {
                this.Cerrar();
            }
        }

        public int buscarId(int idRol)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Rol where idRol = " + idRol + "", cn);
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

        public string nombreRol(int idRol)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select nombreRol from Rol where idRol = " + idRol + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["nombreRol"].ToString();
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

        public string modificarRol(int idRol, string rol)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Rol set nombreRol = '" + rol + "' where idRol = " + idRol + "", cn);
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

        public string eliminarRol(int idRol)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from Rol where idRol = " + idRol + "", cn);
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
    }
}
