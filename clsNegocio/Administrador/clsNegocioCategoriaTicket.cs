using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clsDatos.Administrador;

namespace clsNegocio.Administrador
{
    public class clsNegocioCategoriaTicket
    {
        clsDatosCategoriaTicket datosCategoria = new clsDatosCategoriaTicket();

        public int buscaridCategoria()
        {
            try
            {
                int idValido = datosCategoria.buscaridCategoria();
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public string InsertarCategoria(string nombreCategoria)
        {
            try
            {
                return datosCategoria.InsertarCategoria(nombreCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idCategoria)
        {
            try
            {
                return datosCategoria.buscarId(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string nombreCategoria(int idCategoria)
        {
            try
            {
                return datosCategoria.nombreCategoria(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string insertarCategoria(string nombreCategoria)
        {
            try
            {
                return datosCategoria.InsertarCategoria(nombreCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarCategoria(int idCategoria, string nombreCategoria)
        {
            try
            {
                return datosCategoria.modificarCategoria(idCategoria, nombreCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarCategoria(int idCategoria)
        {
            try
            {
                return datosCategoria.elimminarCategoria(idCategoria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
