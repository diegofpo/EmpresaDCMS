using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        clsNegocioRol negocioRol = new clsNegocioRol();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void HojasRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaRoles.SelectedItem.Value;
            if (op.Equals("1"))
            {
                Panel1.Visible = true;
                txtIdRol.Enabled = false;
                txtIdRol.Text = (buscarId()).ToString();
                habilitar();
                habilitarValidacion();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                Panel1.Visible = true;
                txtIdRol.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                txtIdRol.Enabled = true;
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
                cont = negocioRol.buscaridRol();
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtNombreRol.Enabled = true;
        }

        private void deshabilitar()
        {
            txtNombreRol.Enabled = false;
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
            if (HojaRoles.SelectedItem.Value.Equals("2"))
            {
                if (negocioRol.buscarId(int.Parse(txtIdRol.Text)) != 0)
                {
                    habilitarValidacion();
                    habilitar();
                    btnGuardar.Enabled = true;
                    txtNombreRol.Text = negocioRol.nombreRol(int.Parse(txtIdRol.Text));
                }
                else
                {
                    txtNombreRol.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else if (HojaRoles.SelectedItem.Value.Equals("3"))
            {
                if (negocioRol.buscarId(int.Parse(txtIdRol.Text)) != 0)
                {
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = true;
                    txtNombreRol.Text = negocioRol.nombreRol(int.Parse(txtIdRol.Text));
                }
                else
                {
                    txtNombreRol.Text = "";
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
            int idRol = int.Parse(txtIdRol.Text);
            string rol = txtNombreRol.Text;
            switch (HojaRoles.SelectedItem.Value)
            {
                case "1":
                    try
                    {
                        Response.Write(negocioRol.InsertarRol(rol));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioRol.modificarRol(idRol, rol));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        Response.Write(negocioRol.eliminarRol(idRol));
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