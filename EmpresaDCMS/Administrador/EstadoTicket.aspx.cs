using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        clsNegocioEstadoTicket negocioEstado = new clsNegocioEstadoTicket();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void HojaEstadoTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaEstadoTicket.SelectedItem.Value;
            if (op.Equals("1"))
            {
                Panel1.Visible = true;
                txtIdEstado.Enabled = false;
                txtIdEstado.Text = (buscarId()).ToString();
                habilitar();
                habilitarValidacion();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                Panel1.Visible = true;
                txtIdEstado.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                txtIdEstado.Enabled = true;
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
                cont = negocioEstado.buscaridEstado();
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtNombreEstado.Enabled = true;
        }

        private void deshabilitar()
        {
            txtNombreEstado.Enabled = false;
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
            if (HojaEstadoTicket.SelectedItem.Value.Equals("2"))
            {
                if (negocioEstado.buscarId(int.Parse(txtIdEstado.Text)) != 0)
                {
                    habilitarValidacion();
                    habilitar();
                    btnGuardar.Enabled = true;
                    txtNombreEstado.Text = negocioEstado.nombreEstado(int.Parse(txtIdEstado.Text));
                }
                else
                {
                    txtNombreEstado.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else if (HojaEstadoTicket.SelectedItem.Value.Equals("3"))
            {
                if (negocioEstado.buscarId(int.Parse(txtIdEstado.Text)) != 0)
                {
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = true;
                    txtNombreEstado.Text = negocioEstado.nombreEstado(int.Parse(txtIdEstado.Text));
                }
                else
                {
                    txtNombreEstado.Text = "";
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
            int idEstado = int.Parse(txtIdEstado.Text);
            string estado = txtNombreEstado.Text;
            switch(HojaEstadoTicket.SelectedItem.Value)
            {
                case "1":                    
                    try
                    {
                        Response.Write(negocioEstado.ingresarEstado(estado));
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioEstado.modificarEstado(idEstado, estado));
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        Response.Write(negocioEstado.eliminarEstado(idEstado));
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