using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsDatos.Administrador
{
    public class clsDatosUsuarios
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

        public DataTable cargarEmpleado()
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select idEmpleado as 'Id', cedula as 'Cedula', nombreEmpleado as 'Nombre', apellidoEmpleado as 'Apellido', celular, email, rolEmpleado as 'Rol', departamentoEmpleado as 'Departamento' from Empleado", cn);
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

        public DataTable TablaRol()
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select * from Rol", cn);
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

        public DataTable TablaDepartamento()
        {
            try
            {
                this.Abrir();
                adaptadorBD = new SqlDataAdapter("select * from Departamento", cn);
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

        public string insertarEmpleado(int idEmpleado, string cedula, string nombreEmpleado, string apellidoEmpleado, string celular, string email, int rol, int departamento, string clave)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("exec InsertarUsuarios " + idEmpleado + ", '" + cedula + "', '" + nombreEmpleado + "', '" + apellidoEmpleado + "', '"+celular+"', '"+email+"', "+rol+", "+departamento+", '"+clave+"'", cn);
                cmdBD.ExecuteNonQuery();
                return "Se ha creado el perfil del Empleado.";
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

        public string modificarEmpleado(int idEmpleado, string cedula, string nombreEmpleado, string apellidoEmpleado, string celular, string email, int rolEmpleado, int departamentoEmpleado)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("update Empleado set cedula = '" + cedula + "', nombreEmpleado = '" + nombreEmpleado + "', apellidoEmpleado = '"+apellidoEmpleado+"', celular = '"+celular+"', email = '"+email+"', rolEmpleado = "+rolEmpleado+", departamentoEmpleado = "+departamentoEmpleado+" where idEmpleado = " + idEmpleado + "", cn);
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

        public string elimminarEmpleado(int idEmpleado)
        {
            string salida = "Datos actualizados.";
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("delete from Empleado where idEmpleado = " + idEmpleado + "", cn);
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

        public List<string> listaDatos(List<string> lista, int idEmpleado)
        {
            try
            {
                this.Abrir();
                cmdBD = new SqlCommand("select * from Empleado where idEmpleado = "+idEmpleado+"", cn);
                leerDataBD = cmdBD.ExecuteReader();
                while (leerDataBD.Read())
                {
                    lista.Add(leerDataBD["cedula"].ToString());
                    lista.Add(leerDataBD["nombreEmpleado"].ToString());
                    lista.Add(leerDataBD["apellidoEmpleado"].ToString());
                    lista.Add(leerDataBD["celular"].ToString());
                    lista.Add(leerDataBD["email"].ToString());
                    lista.Add(leerDataBD["rolEmpleado"].ToString());
                    lista.Add(leerDataBD["departamentoEmpleado"].ToString());
                }
                leerDataBD.Close();
                return lista;
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


        public int buscarId(int idEmpleado)
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
