using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        clsNegocioCategoriaTicket negocioCategoria = new clsNegocioCategoriaTicket();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void HojaCategoriaTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaCategoriaTicket.SelectedItem.Value;
            if (op.Equals("1"))
            {
                Panel1.Visible = true;
                txtIdCategoria.Enabled = false;
                txtIdCategoria.Text = (buscarId()).ToString();
                habilitar();
                habilitarValidacion();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                Panel1.Visible = true;
                txtIdCategoria.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                txtIdCategoria.Enabled = true;
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
                cont = negocioCategoria.buscaridCategoria();
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtNombreCategoria.Enabled = true;
        }

        private void deshabilitar()
        {
            txtNombreCategoria.Enabled = false;
        }

        private void habilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = true;
        }

        private void deshabilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int idCategoria = int.Parse(txtIdCategoria.Text);
            string nombreCategoria = txtNombreCategoria.Text;
            switch (HojaCategoriaTicket.SelectedItem.Value)
            {
                case "1":
                    try
                    {
                        Response.Write(negocioCategoria.insertarCategoria(nombreCategoria));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioCategoria.modificarCategoria(idCategoria, nombreCategoria));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        Response.Write(negocioCategoria.eliminarCategoria(idCategoria));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            if (HojaCategoriaTicket.SelectedItem.Value.Equals("2"))
            {
                if (negocioCategoria.buscarId(int.Parse(txtIdCategoria.Text)) != 0)
                {
                    habilitarValidacion();
                    habilitar();
                    btnGuardar.Enabled = true;
                    txtNombreCategoria.Text = negocioCategoria.nombreCategoria(int.Parse(txtIdCategoria.Text));
                }
                else
                {
                    txtNombreCategoria.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else if (HojaCategoriaTicket.SelectedItem.Value.Equals("3"))
            {
                if (negocioCategoria.buscarId(int.Parse(txtIdCategoria.Text)) != 0)
                {
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = true;
                    txtNombreCategoria.Text = negocioCategoria.nombreCategoria(int.Parse(txtIdCategoria.Text));
                }
                else
                {
                    txtNombreCategoria.Text = "";
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
    }
}