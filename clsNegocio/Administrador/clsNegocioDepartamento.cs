using clsDatos.Administrador;
using clsNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio.Administrador
{
    public class clsNegocioDepartamento
    {
        clsDatosDepartamento datosDepartamento = new clsDatosDepartamento();

        public int buscaridDepartamento()
        {
            try
            {
                int idValido = datosDepartamento.buscaridDepartamento();
                return idValido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarId(int idDepartamento)
        {
            try
            {
                return datosDepartamento.buscarId(idDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string nombreDepartamento(int idDepartamento)
        {
            try
            {
                return datosDepartamento.nombreDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string descripcionDepartamento(int idDepartamento)
        {
            try
            {
                return datosDepartamento.descripcionDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string eliminarDepartamento(int idDepartamento)
        {
            try
            {
                return datosDepartamento.elimminarDepartamento(idDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string modificarDepartamento(int idDepartamento, string nombreDepartamento, string descripcionDepartamento)
        {
            try
            {
                return datosDepartamento.modificarDepartamento(idDepartamento, nombreDepartamento, descripcionDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string insertarDepartamento(int idDepartamento, string nombreDepartamento, string descripcionDepartamento)
        {
            try
            {
                return datosDepartamento.InsertarDepartamento(nombreDepartamento,descripcionDepartamento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
