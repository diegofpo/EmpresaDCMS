using clsDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsNegocio
{
    public class clsNegocioTicketsRegistrados
    {
        clsDatosTicketsRegistrados datosTicketRegistrado = new clsDatosTicketsRegistrados();
        int TicketCerrado = 4;
        int TicketRechazado = 5;
        char calificacionSolucion;

        public DataTable tablaTregistrados(int idEmpleado)
        {
            try
            {
                return datosTicketRegistrado.tablaTregistrados(idEmpleado);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string calificarTicket(int idTicket, int calificacion)
        {
            try
            {
                if (calificacion > 9 && calificacion < 15)
                {
                    calificacionSolucion = 'B';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketCerrado);
                }
                else if (calificacion == 9)
                {
                    calificacionSolucion = 'C';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketCerrado);
                }
                else if(calificacion == 15)
                {
                    calificacionSolucion = 'A';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketCerrado);
                }
                else if (calificacion >= 6 && calificacion < 9)
                {
                    calificacionSolucion = 'D';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketCerrado);
                }
                else if (calificacion >= 3 && calificacion < 6)
                {
                    calificacionSolucion = 'E';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketCerrado);
                }
                else
                {
                    calificacionSolucion = 'F';
                    return datosTicketRegistrado.calificarTicket(idTicket, calificacionSolucion, TicketRechazado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
