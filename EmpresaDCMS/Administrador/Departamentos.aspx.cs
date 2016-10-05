using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        clsNegocioDepartamento negocioDepartamento = new clsNegocioDepartamento();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void HojaDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaDepartamentos.SelectedItem.Value;
            if (op.Equals("1"))
            {
                Panel1.Visible = true;
                txtIdDepartamento.Enabled = false;
                txtIdDepartamento.Text = (buscarId()).ToString();
                habilitar();
                habilitarValidacion();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                Panel1.Visible = true;
                txtIdDepartamento.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                Panel1.Visible = true;
                txtIdDepartamento.Enabled = true;
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
                cont = negocioDepartamento.buscaridDepartamento();
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtNombreDepartamento.Enabled = true;
            txtDescripcionDepartamento.Enabled = true;
        }

        private void deshabilitar()
        {
            txtNombreDepartamento.Enabled = false;
            txtDescripcionDepartamento.Enabled = false;
        }

        private void habilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
        }

        private void deshabilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            if (HojaDepartamentos.SelectedItem.Value.Equals("2"))
            {
                if (negocioDepartamento.buscarId(int.Parse(txtIdDepartamento.Text)) != 0)
                {
                    habilitarValidacion();
                    habilitar();
                    btnGuardar.Enabled = true;
                    txtNombreDepartamento.Text = negocioDepartamento.nombreDepartamento(int.Parse(txtIdDepartamento.Text));
                    txtDescripcionDepartamento.Text = negocioDepartamento.descripcionDepartamento(int.Parse(txtIdDepartamento.Text));
                }
                else
                {
                    txtNombreDepartamento.Text = "";
                    txtDescripcionDepartamento.Text = "";
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
            }
            else if (HojaDepartamentos.SelectedItem.Value.Equals("3"))
            {
                if (negocioDepartamento.buscarId(int.Parse(txtIdDepartamento.Text)) != 0)
                {
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = true;
                    txtNombreDepartamento.Text = negocioDepartamento.nombreDepartamento(int.Parse(txtIdDepartamento.Text));
                    txtDescripcionDepartamento.Text = negocioDepartamento.descripcionDepartamento(int.Parse(txtIdDepartamento.Text));
                }
                else
                {
                    txtNombreDepartamento.Text = "";
                    txtDescripcionDepartamento.Text = "";
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
            int idDepartamento = int.Parse(txtIdDepartamento.Text);
            string nombreDepartamento = txtNombreDepartamento.Text;
            string descripcionDepartamento = txtDescripcionDepartamento.Text;
            switch (HojaDepartamentos.SelectedItem.Value)
            {
                case "1":
                    try
                    {
                        Response.Write(negocioDepartamento.insertarDepartamento(idDepartamento, nombreDepartamento, descripcionDepartamento));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioDepartamento.modificarDepartamento(idDepartamento, nombreDepartamento, descripcionDepartamento));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        Response.Write(negocioDepartamento.eliminarDepartamento(idDepartamento));
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    break;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}