using clsNegocio.Administrador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmpresaDCMS
{
    public partial class WebForm13 : System.Web.UI.Page
    {
        clsNegocioUsuarios negocioEmpleado = new clsNegocioUsuarios();

        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            gvUsuarios.DataSource = negocioEmpleado.cargarEmpleados();
            gvUsuarios.DataBind();

            if (ddlRol.Items.Count == 0)
            {
                DataTable dtRol = new DataTable();
                llenarRol(dtRol);
            }
            if (ddlDepartamento.Items.Count == 0)
            {
                DataTable dtDepartamento = new DataTable();
                llenarDepartamento(dtDepartamento);
            }
        }

        private void llenarRol(DataTable dtRol)
        {
            try
            {
                ddlRol.Items.Add("--Seleccionar--");
                dtRol = negocioEmpleado.TablaRol();
                ddlRol.DataTextField = "nombreRol";
                ddlRol.DataValueField = "idRol";
                ddlRol.DataSource = dtRol;
                ddlRol.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarDepartamento(DataTable dtDepartamento)
        {
            try
            {
                ddlDepartamento.Items.Add("--Seleccionar--");
                dtDepartamento = negocioEmpleado.TablaDepartamento();
                ddlDepartamento.DataTextField = "nombreDepartamento";
                ddlDepartamento.DataValueField = "idDepartamento";
                ddlDepartamento.DataSource = dtDepartamento;
                ddlDepartamento.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void HojaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            string op = HojaUsuarios.SelectedItem.Value;
            if (op.Equals("1"))
            {
                limpiar();
                Panel1.Visible = true;
                habilitarValidacion();
                txtIdUsuario.Enabled = false;
                txtIdUsuario.Text = (buscarId()).ToString();
                habilitar();
                btnGuardar.Enabled = true;
                panelBuscar.Visible = false;
            }
            else if (op.Equals("2"))
            {
                limpiar();
                Panel1.Visible = true;
                txtIdUsuario.Enabled = true;
                deshabilitar();
                deshabilitarValidacion();
                btnGuardar.Enabled = false;
                panelBuscar.Visible = true;
            }
            else
            {
                limpiar();
                Panel1.Visible = true;
                txtIdUsuario.Enabled = true;
                deshabilitar();
                panelBuscar.Visible = true;
                btnGuardar.Enabled = false;
                deshabilitarValidacion();
            }
        }

        private void habilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = true;
            RequiredFieldValidator3.Enabled = true;
            RequiredFieldValidator4.Enabled = true;
            RequiredFieldValidator5.Enabled = true;
            RequiredFieldValidator6.Enabled = true;
            RequiredFieldValidator7.Enabled = true;
            RequiredFieldValidator8.Enabled = true;
            RequiredFieldValidator9.Enabled = true;
        }

        private void deshabilitarValidacion()
        {
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            RequiredFieldValidator5.Enabled = false;
            RequiredFieldValidator6.Enabled = false;
            RequiredFieldValidator7.Enabled = false;
            RequiredFieldValidator8.Enabled = false;
            RequiredFieldValidator9.Enabled = false;
        }

        private int buscarId()
        {
            try
            {
                int id = 1;
                int cont = 0;
                int aux = 0;
                while (id == 1)
                {
                    Random rand = new Random();
                    aux = rand.Next(100000, 900000);
                    cont = negocioEmpleado.buscaridEmpleado(aux);
                    if (cont == 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = 0;
                    }
                }
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitar()
        {
            txtCedula.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtApellidoUsuario.Enabled = true;
            txtCorreoUsuario.Enabled = true;
            txtPasswordUsuario.Enabled = true;
            txtCelularUsuario.Enabled = true;
            ddlDepartamento.Enabled = true;
            ddlRol.Enabled = true;
        }

        private void deshabilitar()
        {
            txtCedula.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtApellidoUsuario.Enabled = false;
            txtCorreoUsuario.Enabled = false;
            txtPasswordUsuario.Enabled = false;
            txtCelularUsuario.Enabled = false;
            ddlDepartamento.Enabled = false;
            ddlRol.Enabled = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (HojaUsuarios.SelectedItem.Value)
            {
                case "1":
                    try
                    {
                        Response.Write(negocioEmpleado.insertarEmpleado(int.Parse(txtIdUsuario.Text), txtCedula.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, txtCelularUsuario.Text, txtCorreoUsuario.Text, int.Parse(ddlRol.SelectedItem.Value), int.Parse(ddlDepartamento.SelectedItem.Value), txtPasswordUsuario.Text));
                        Response.Redirect(Request.RawUrl);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("No se ha podido crear el perfil del Empleado.");
                        throw ex;
                    }
                    break;
                case "2":
                    try
                    {
                        Response.Write(negocioEmpleado.modificarEmpleado(int.Parse(txtIdUsuario.Text), txtCedula.Text, txtNombreUsuario.Text, txtApellidoUsuario.Text, txtCelularUsuario.Text, txtCorreoUsuario.Text, int.Parse(ddlRol.SelectedItem.Value), int.Parse(ddlDepartamento.SelectedItem.Value)));
                    }
                    catch (Exception ex)
                    {
                        Response.Write("No se ha podido actualizar el perfil del Empleado.");
                        throw ex;
                    }
                    break;
                case "3":
                    try
                    {
                        int idEmpleado = int.Parse(txtIdUsuario.Text);
                        Response.Write(negocioEmpleado.eliminarEmpleado(idEmpleado));
                    }
                    catch (Exception ex)
                    {
                        Response.Write("No se ha podido actualizar el perfil del Empleado.");
                        throw ex;
                    }
                    break;
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            if (HojaUsuarios.SelectedItem.Value.Equals("2"))
            {
                if (negocioEmpleado.buscarId(int.Parse(txtIdUsuario.Text)) != 0)
                {
                    List<string> lista = new List<string>();
                    int idEmpleado = int.Parse(txtIdUsuario.Text);
                    lista = negocioEmpleado.listaDatos(lista, idEmpleado);
                    llenarDatos(lista);
                    habilitarValidacion();
                    habilitar();
                    RequiredFieldValidator8.Enabled = false;
                    btnGuardar.Enabled = true;
                }
                else
                {
                    limpiar();
                    deshabilitarValidacion();
                    deshabilitar();
                    btnGuardar.Enabled = false;
                    Response.Write("Id no existente.");
                }
                
            }
            else if (HojaUsuarios.SelectedItem.Value.Equals("3"))
            {
                if (negocioEmpleado.buscarId(int.Parse(txtIdUsuario.Text)) != 0)
                {
                    List<string> lista = new List<string>();
                    int idEmpleado = int.Parse(txtIdUsuario.Text);
                    lista = negocioEmpleado.listaDatos(lista, idEmpleado);
                    llenarDatos(lista);
                    deshabilitarValidacion();
                    deshabilitar();
                    RequiredFieldValidator8.Enabled = false;
                    btnGuardar.Enabled = true;   
                }
                else
                {
                    limpiar();
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

        private void limpiar()
        {
            txtCedula.Text = String.Empty;
            txtNombreUsuario.Text = String.Empty;
            txtApellidoUsuario.Text = String.Empty;
            txtCelularUsuario.Text = String.Empty;
            txtCorreoUsuario.Text = String.Empty;
            txtPasswordUsuario.Text = String.Empty;
        }

        private void llenarDatos(List<string> lista)
        {
            try
            {
                txtCedula.Text = lista[0].ToString();
                txtNombreUsuario.Text = lista[1].ToString();
                txtApellidoUsuario.Text = lista[2].ToString();
                txtCelularUsuario.Text = lista[3].ToString();
                txtCorreoUsuario.Text = lista[4].ToString();
                ddlRol.SelectedValue = lista[5].ToString();
                ddlDepartamento.SelectedValue = lista[6].ToString();
                txtPasswordUsuario.Enabled = false;
            }
            catch(Exception ex)
            {
                Response.Write("Usuario no existente.");
            }
        }
    }
}