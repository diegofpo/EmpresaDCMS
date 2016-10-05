using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsNegocio;
using System.Data;
using clsDatos.Administrador;
namespace clsNegocio.Administrador
{
    public class clsNegocioUsuarios
    {
        clsDatosUsuarios datosEmpleado = new clsDatosUsuarios();

        public int buscaridEmpleado(int idEmpleado)
        {
            try
            {
                int idValido = datosEmpleado.buscaridEmpleado(idEmpleado);
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable cargarEmpleados()
        {
            try
            {
                return datosEmpleado.cargarEmpleado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable TablaRol()
        {
            try
            {
                return datosEmpleado.TablaRol();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TablaDepartamento()
        {
            try
            {
                return datosEmpleado.TablaDepartamento();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string insertarEmpleado(int idEmpleado, string cedula, string nombreEmpleado, string apellidoEmpleado, string celular, string email, int rol, int departamento, string clave)
        {
            try
            {
                return datosEmpleado.insertarEmpleado(idEmpleado,  cedula,  nombreEmpleado,  apellidoEmpleado,  celular,  email,  rol,  departamento,  clave);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<string> listaDatos(List<string> lista, int idEmpleado)
        {
            try
            {
                return datosEmpleado.listaDatos(lista, idEmpleado);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string modificarEmpleado(int idEmpleado, string cedula, string nombreEmpleado, string apellidoEmpleado, string celular, string email, int rol, int departamento)
        {
            try
            {
                return datosEmpleado.modificarEmpleado(idEmpleado,cedula,nombreEmpleado,apellidoEmpleado,celular,email,rol,departamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarEmpleado(int idEmpleado)
        {
            try
            {
                return datosEmpleado.elimminarEmpleado(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idEmpleado)
        {
            try
            {
                return datosEmpleado.buscarId(idEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
