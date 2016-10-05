using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosDepartamento
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

        public int buscaridDepartamento()
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Departamento", cn);
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

        public int buscarId(int idDepartamento)
        {
            try
            {
                int cont = 0;
                this.Abrir();
                cmdBD = new SqlCommand("select * from Departamento where idDepartamento = " + idDepartamento + "", cn);
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

        public string nombreDepartamento(int idDepartamento)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select nombreDepartamento from Departamento where idDepartamento = " + idDepartamento + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["nombreDepartamento"].ToString();
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

        public string descripcionDepartamento(int idDepartamento)
        {
            try
            {
                string cont = "";
                this.Abrir();
                cmdBD = new SqlCommand("select descripcionDepartamento from Departamento where idDepartamento = " + idDepartamento + "", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    cont = leerDataBD["descripcionDepartamento"].ToString();
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

        public string InsertarDepartamento(string nombreDepartamento, string descripcionDepartamento)
        {
            string salida = "Datos ingresados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("insert into Departamento values ( '" + nombreDepartamento + "', '"+descripcionDepartamento+"')", cn);
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

        public string modificarDepartamento(int idDepartamento, string nombreDepartamento, string descripcionDepartamento)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Departamento set nombreDepartamento = '" + nombreDepartamento + "', descripcionDepartamento = '"+descripcionDepartamento+"' where idDepartamento = " + idDepartamento + "", cn);
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

        public string elimminarDepartamento(int idDepartamento)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from Departamento where idDepartamento = " + idDepartamento + "", cn);
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
