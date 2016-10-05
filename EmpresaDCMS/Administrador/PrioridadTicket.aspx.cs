using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        clsNegocioPrioridadTicket negocioPrioridad = new clsNegocioPrioridadTicket();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void HojaPrioridadTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaPrioridadTicket.SelectedItem.Value;
            if (op.Equals("1"))
            {
                Panel1.Visible = true;
                txtIdPrioridad.Enabled = false;
                txtIdPrioridad.Text = (buscarId()).ToString();
                habilitar();
                habilitarValidacion();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                Panel1.Visible = true;
                txtIdPrioridad.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                txtIdPrioridad.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
        }

        private int buscarId()
        {
            try
            {
                int cont = 0;
                cont = negocioPrioridad.buscaridPrioridad();
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtNombrePrioridad.Enabled = true;
        }

        private void deshabilitar()
        {
            txtNombrePrioridad.Enabled = false;
        }

        private void habilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = true;
        }

        private void deshabilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = false;
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            if (HojaPrioridadTicket.SelectedItem.Value.Equals("2"))
            {
                if (negocioPrioridad.buscarId(int.Parse(txtIdPrioridad.Text)) != 0)
                {
                    habilitarValidacion();
                    habilitar();
                    btnGuardar.Enabled = true;
                    txtNombrePrioridad.Text = negocioPrioridad.nombrePrioridad(int.Parse(txtIdPrioridad.Text));
                }
                else
                {
                    txtNombrePrioridad.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else if (HojaPrioridadTicket.SelectedItem.Value.Equals("3"))
            {
                if (negocioPrioridad.buscarId(int.Parse(txtIdPrioridad.Text)) != 0)
                {
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = true;
                    txtNombrePrioridad.Text = negocioPrioridad.nombrePrioridad(int.Parse(txtIdPrioridad.Text));
                }
                else
                {
                    txtNombrePrioridad.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else
            {
                deshabilitarValidacion();
                deshabilitar();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idPrioridad = int.Parse(txtIdPrioridad.Text);
            string nombrePrioridad = txtNombrePrioridad.Text;
            switch (HojaPrioridadTicket.SelectedItem.Value)
            {
                case "1":
                    try
                    {
                        Response.Write(negocioPrioridad.insertarPrioridad(nombrePrioridad));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioPrioridad.modificarPrioridad(idPrioridad, nombrePrioridad));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        Response.Write(negocioPrioridad.eliminarPrioridad(idPrioridad));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }
    }
}