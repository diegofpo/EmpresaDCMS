using clsDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio
{
    public class clsNegocioInsertarTicket
    {
        clsDatosInsertarTicket datosInsertar = new clsDatosInsertarTicket();
        int estado = 2;
        public DataTable TablaPrioridad()
        {
            try
            {
                return datosInsertar.TablaPrioridad();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable TablaCategoria()
        {
            try
            {
                return datosInsertar.TablaCategoria();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<int> listaTecnicosBD(List<int> listaTecnicos)
        {
            try
            {
                return datosInsertar.listaTecnicosBD(listaTecnicos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertarTicket(int idEmpleado, int idTecnico, string fechaI, string fechaS)
        {
            try
            {
                return datosInsertar.InsertarTicket(idEmpleado, idTecnico, fechaI, fechaS, estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int buscarIdTicket()
        {
            try
            {
                return datosInsertar.buscarIdTicket();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertarDetalle(int idTicket, int idCategoria, string descripcion, int idPrioridad)
        {
            try
            {
                return datosInsertar.InsertarDetalle(idTicket, idCategoria, descripcion, idPrioridad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string emailTecnico(int idTecnico)
        {
            try
            {
                return datosInsertar.emailTecnico(idTecnico);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
