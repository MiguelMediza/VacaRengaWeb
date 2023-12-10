using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarProveedor();
                this.Inicio();
                this.LimpiarCajas();
            }
        }

        private void Inicio()
        {
            this.txtImpuestos.Visible = false;
            this.Label6.Visible = false;
        }

        private void LimpiarCajas()//Permite limpiar todas las cajas y volverlas a su valor inicial
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.txtId.Text = unaControladora.ProximoIdProveedor().ToString();
            this.txtCedula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtTipoProducto.Text = string.Empty;
            this.txtImpuestos.Text = string.Empty;
        }

        private void ListarProveedor()
        {
            Dominio.Controladora controladora = new Dominio.Controladora();
            this.lstProveedores.DataSource = null;
            this.lstProveedores.DataSource = controladora.ListaProveedores().ToList();
            this.lstProveedores.DataBind();
        }


        private bool ValidacionDatos()
        {
            if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
            {
                lblMensajes.Text = "El Id ingresado no cumple los requisitos!";
                return false;
            }
            if (txtCedula.Text.Trim() == "" || !int.TryParse(txtCedula.Text, out _))
            {
                lblMensajes.Text = "Debe ingresar una cédula valida!";
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblMensajes.Text = "Debe ingresar un nombre!";
                return false;
            }
            if (txtApellido.Text.Trim() == "")
            {
                lblMensajes.Text = "Debe ingresar un apellido!";
                return false;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                lblMensajes.Text = "Debe ingresar una dirección!";
                return false;
            }
            if (txtTelefono.Text.Trim() == "" || !int.TryParse(txtTelefono.Text, out _))
            {
                lblMensajes.Text = "Debe ingresar un teléfono valido!";
                return false;
            }
            if (txtTipoProducto.Text.Trim() == "")
            {
                lblMensajes.Text = "Debe ingresar un tipo de producto que provee!";
                return false;
            }

            return true;
        }
        private void CargarProveedor(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {
            Dominio.Controladora controladora = new Dominio.Controladora();

            Dominio.Proveedor unProveedor = controladora.BuscarProveedor(pId);

            if (unProveedor != null)
            {
                this.txtId.Text = unProveedor.Id.ToString();
                this.txtCedula.Text = unProveedor.Cedula.ToString();
                this.txtNombre.Text = unProveedor.Nombre.ToString();
                this.txtApellido.Text = unProveedor.Apellido.ToString();
                this.txtDireccion.Text = unProveedor.Direccion.ToString();
                this.txtTelefono.Text = unProveedor.Telefono.ToString();
                this.txtTipoProducto.Text = unProveedor.TipoProductoProvee.ToString();
                this.txtImpuestos.Text = unProveedor.Impuestos.ToString();
            }
        }

        protected void rbtNacional_CheckedChanged(object sender, EventArgs e)
        {
            this.txtImpuestos.Visible = false;
            this.Label6.Visible = false;
        }

        protected void rbtExtranjero_CheckedChanged(object sender, EventArgs e)
        {
            this.txtImpuestos.Visible = true;
            this.Label6.Visible = true;
        }

        protected void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstProveedores.SelectedIndex != -1)
            {

                //Si colocan un espacio, ya sea en direccion  u otro de los campos se rompe (arreglado)
                string linea = this.lstProveedores.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                Persistencia.PEProveedor PE = new Persistencia.PEProveedor();
                Dominio.Proveedor unProveedor =PE.Buscar(Id);
                if (unProveedor.Procedencia == "Nacional")
                {
                    this.txtImpuestos.Visible = false;
                    this.Label6.Visible = false;
                    this.rbtNacional.Checked = true;
                    this.rbtExtranjero.Checked = false;
                }
                else
                {
                    this.txtImpuestos.Visible = true;
                    this.Label6.Visible = true;
                    this.rbtNacional.Checked = false;
                    this.rbtExtranjero.Checked = true;
                }


                this.CargarProveedor(Id);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos())
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();

                short Id = Convert.ToInt16(txtId.Text);
                string Cedula = txtCedula.Text.ToString();
                string Nombre = txtNombre.Text.ToString();
                string Apellido = txtApellido.Text.ToString();
                string Direccion = txtDireccion.Text.ToString();
                int Telefono = Convert.ToInt32(txtTelefono.Text);
                string TipoProducto = txtTipoProducto.Text.ToString();
                int Impuestos = 0;
                string Procedencia = "";

                if (rbtExtranjero.Checked == true)
                {
                    Procedencia = "Extranjero";
                    Impuestos = Convert.ToInt32(txtImpuestos.Text);
                }
                else
                {
                    Procedencia = "Nacional";
                }
                Dominio.Proveedor unProveedor = new Dominio.Proveedor(Id, Cedula, Nombre, Apellido, Direccion, Telefono, TipoProducto, Procedencia, Impuestos);


                    if (unaControladora.AltaProveedor(unProveedor))
                    {
                        this.ListarProveedor();
                        lblMensajes.Text = "Proveedor ID:{" + Id + "}" + " " + Nombre + " ingresado correctamente!";
                        this.LimpiarCajas();
                    }
                    else
                    {
                        return;
                    }

                

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos())
            {
                Dominio.Controladora unaControladora = new Dominio.Controladora();

                short Id = Convert.ToInt16(txtId.Text);
                string Cedula = txtCedula.Text.ToString();
                string Nombre = txtNombre.Text.ToString();
                string Apellido = txtApellido.Text.ToString();
                string Direccion = txtDireccion.Text.ToString();
                int Telefono = Convert.ToInt32(txtTelefono.Text);
                string TipoProducto = txtTipoProducto.Text.ToString();
                int Impuestos = 0;
                string Procedencia = "";

                if (rbtExtranjero.Checked == true)
                {
                    Procedencia = "Extranjero";
                    Impuestos = Convert.ToInt32(txtImpuestos.Text);
                }
                else
                {
                    Procedencia = "Nacional";
                }
              


                if (unaControladora.ModificarProveedor(Id, Cedula, Nombre, Apellido, Direccion, Telefono, TipoProducto, Procedencia, Impuestos))
                {
                    this.ListarProveedor();
                    lblMensajes.Text = "Proveedor ID:{" + Id + "}" + " " + Nombre + " modificado correctamente!";
                    this.LimpiarCajas();
                }
                else
                {
                    return;
                }



            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
                {
                    throw new Exception("El ID no es correcto");
                }

                short Id = Convert.ToInt16(txtId.Text);
                string Nombre = txtNombre.Text;

                Dominio.Controladora unaControladora = new Dominio.Controladora();

                if (unaControladora.BajaProveedor(Id))
                {
                    this.ListarProveedor();
                    lblMensajes.Text = "Proveedor ID:{" + Id + "}" + " " + Nombre + " eliminado correctamente!";
                    this.LimpiarCajas();
                }
                else
                {
                    throw new Exception("ERROR: Proveedor ID:{" + Id + "}" + " " + Nombre + " no se pudo eliminar!");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }
        }
    }
}