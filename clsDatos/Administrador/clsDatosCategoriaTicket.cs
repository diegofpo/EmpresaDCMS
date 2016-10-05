using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosCategoriaTicket
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

        public int buscaridCategoria()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Categoria", cn);
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

        public int buscarId(int idCategoria)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Categoria where idCategoria = " + idCategoria + "", cn);
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

        public string nombreCategoria(int idCategoria)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select nombreCategoria from Categoria where idCategoria = " + idCategoria + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["nombreCategoria"].ToString();
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

        public string InsertarCategoria(string nombreCategoria)
        {
            string salida = "Datos ingresados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("insert into Categoria values ( '" + nombreCategoria + "')", cn);
                cmdBD.ExecuteNonQuery();
                return salida;
            }
            catch (Exception ex)
            {
                salida = "No se pudo ingresar: " + ex.ToString();
                return salida;
            }
            finally
            {
                this.Cerrar();
            }
        }

        public string modificarCategoria(int idCategoria, string nombreCategoria)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Categoria set nombreCategoria = '" + nombreCategoria + "' where idCategoria = "+idCategoria+"", cn);
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

        public string elimminarCategoria(int idCategoria)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from Categoria where idCategoria = " + idCategoria + "", cn);
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
    }
}
