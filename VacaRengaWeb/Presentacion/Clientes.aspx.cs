using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Clientes : System.Web.UI.Page
    {
        private Dominio.Controladora Controladora = new Dominio.Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarCliente();
                this.CargarEmpresas();
                this.Inicio();
                this.LimpiarCajas();
                this.CargarIdEmpresa();
            }
        }
        private void LimpiarCajas()//Permite limpiar todas las cajas y volverlas a su valor inicial
        {
            this.txtCedula.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtApellido.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.ddlEmpresa.Text = string.Empty;

            string Tipo = "";

        }

        private void CargarIdParticular()
        {
            
            this.txtId.Text = this.Controladora.ProximoIdClienteParticular().ToString();

        }

        private void CargarIdEmpresa()
        {
            this.txtId.Text = this.Controladora.ProximoIdClienteEmpresa().ToString();

        }

        private void Inicio()
        {
            lblempresa.Style["Visibility"] = "visible";
            ddlEmpresa.Style["Visibility"] = "visible";

        }
        private void ListarCliente()//Lista todos los clientes agregados
        {

            this.lstClienteEmpresario.DataSource = null;
            this.lstClienteEmpresario.DataSource = this.Controladora.ListaClientesEmpresa();
            this.lstClienteEmpresario.DataBind();

            this.lstClienteComun.DataSource = null;
            this.lstClienteComun.DataSource = this.Controladora.ListaClientesParticular();
            this.lstClienteComun.DataBind();

        }

        private void CargarEmpresas()
        {
            this.ddlEmpresa.Items.Clear();
          

            ListItem Item = new ListItem();
            Item.Value = "";
            Item.Text = "Seleccione una empresa";
            this.ddlEmpresa.Items.Add(Item);

            foreach (Dominio.Empresa unaEmpresa in this.Controladora.ListaEmpresas())
            {
                ListItem Item1 = new ListItem();
                Item1.Value = unaEmpresa.Id.ToString();
                Item1.Text = unaEmpresa.Nombre;
                this.ddlEmpresa.Items.Add(Item1);
            }
            this.ddlEmpresa.SelectedIndex = 0;
            this.ddlEmpresa.DataBind();

        }

        private bool ValidacionDatos()
        {
            
            if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
            {
                lblMensajes.Text = "El Id ingresado no cumple los requisitos!";
                return false;
            }
            if (ddlEmpresa.SelectedIndex == 0 && rbtEmpresa.Checked == true)
            {
                lblMensajes.Text = "Debe seleccionar una empresa!";
                return false;
            }

            if (txtCedula.Text.Length < 6 || !this.Controladora.ValidarCI(txtCedula.Text) )
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

            return true;
        }
        private void CargarClienteEmpresa(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {

            Dominio.ClienteEmpresa unEmpresario = this.Controladora.BuscarClienteEmpresa(pId);

            if (unEmpresario != null)
            {
                this.txtId.Text = unEmpresario.Id.ToString();
                this.txtCedula.Text = unEmpresario.Cedula.ToString();
                this.txtNombre.Text = unEmpresario.Nombre.ToString();
                foreach (ListItem item in this.ddlEmpresa.Items)
                {
                    if (item.Value == unEmpresario.Empresa.Id.ToString())
                    {
                        this.ddlEmpresa.SelectedValue = unEmpresario.Empresa.Id.ToString();
                    }
                }
                this.txtApellido.Text = unEmpresario.Apellido.ToString();
                this.txtDireccion.Text = unEmpresario.Direccion.ToString();
                this.txtTelefono.Text = unEmpresario.Telefono.ToString();
            }
        }

        private void CargarClienteParticular(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {

            Dominio.ClienteParticular unClienteParticular = this.Controladora.BuscarClienteParticular(pId);

            if (unClienteParticular != null)
            {
                this.txtId.Text = unClienteParticular.Id.ToString();
                this.txtCedula.Text = unClienteParticular.Cedula.ToString();
                this.txtNombre.Text = unClienteParticular.Nombre.ToString();
                this.txtApellido.Text = unClienteParticular.Apellido.ToString();
                this.txtDireccion.Text = unClienteParticular.Direccion.ToString();
                this.txtTelefono.Text = unClienteParticular.Telefono.ToString();
            }
        }
        protected void rbtEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.lblempresa.Visible = true;
            this.ddlEmpresa.Visible = true;
            this.CargarIdEmpresa();
        }

        protected void rbtPersona_CheckedChanged(object sender, EventArgs e)
        {
            this.lblempresa.Visible = false;
            this.ddlEmpresa.Visible = false;
            this.CargarIdParticular();
        }

        protected void lstClienteEmpresario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstClienteEmpresario.SelectedIndex != -1)
            {
                string linea = this.lstClienteEmpresario.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                this.lblempresa.Visible = true;
                this.ddlEmpresa.Visible = true;
                this.rbtEmpresa.Checked = true;
                this.rbtPersona.Checked = false;
                this.CargarClienteEmpresa(Id);
            }
        }

        protected void lstClienteComun_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstClienteComun.SelectedIndex != -1)
            {
                string linea = this.lstClienteComun.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                this.lblempresa.Visible = false;
                this.ddlEmpresa.Visible = false;
                this.rbtEmpresa.Checked = false;
                this.rbtPersona.Checked = true;
                this.CargarClienteParticular(Id);


            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.rbtEmpresa.Checked = true;
            this.rbtPersona.Checked = false;
            this.lblempresa.Visible = true;
            this.ddlEmpresa.Visible = true;
            LimpiarCajas();

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos())
            {

                short Id = Convert.ToInt16(txtId.Text);
                string Cedula = txtCedula.Text.ToString();
                string Nombre = txtNombre.Text.ToString();
                string Apellido = txtApellido.Text.ToString();
                string Direccion = txtDireccion.Text.ToString();
                int Telefono = Convert.ToInt32(txtTelefono.Text);

                Double Descuento = 10;


                if (rbtPersona.Checked == true)
                {
                    Dominio.ClienteParticular unClienteParticular = new Dominio.ClienteParticular(Id, Cedula, Nombre, Apellido, Direccion, Telefono);

                    if (this.Controladora.AltaClienteParticular(unClienteParticular))
                    {
                        lblMensajes.Text = "Cliente Particular ID:{" + Id + "}" + " " + Nombre + " ingresado correctamente!";
                        this.LimpiarCajas();
                        this.ListarCliente();
                        this.CargarIdParticular();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    string id_string = this.ddlEmpresa.SelectedItem.Value;

                    short id = Convert.ToInt16(id_string);

                    Dominio.Empresa Empresa = this.Controladora.BuscarEmpresa(id);

                    Dominio.ClienteEmpresa unCliente = new Dominio.ClienteEmpresa(Id, Cedula, Nombre, Apellido, Direccion, Telefono, Empresa, Descuento);


                    if (this.Controladora.AltaClienteEmpresa(unCliente))
                    {
                        lblMensajes.Text = "Cliente ID:{" + Id + "}" + " " + Nombre + " ingresado correctamente!";
                        this.LimpiarCajas();
                        this.ListarCliente();
                        this.CargarIdEmpresa();
                    }
                    else
                    {
                        return;
                    }

                }

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos())
            {
                short Id = Convert.ToInt16(txtId.Text);
                string Cedula = txtCedula.Text.ToString();
                string Nombre = txtNombre.Text.ToString();
                string Apellido = txtApellido.Text.ToString();
                string Direccion = txtDireccion.Text.ToString();
                int Telefono = Convert.ToInt32(txtTelefono.Text);
                string Tipo = "Ninguno";
                Double Descuento = 10;



                if (rbtPersona.Checked == true)
                {

                    if (this.Controladora.ModificarClienteParticular(Id, Cedula, Nombre, Apellido, Direccion, Telefono))
                    {
                        this.ListarCliente();
                        lblMensajes.Text = "Cliente Particular ID:{" + Id + "}" + " " + Nombre + " modificado correctamente!";
                        this.LimpiarCajas();
                        this.CargarIdParticular();
                    }
                    else
                    {
                        return;
                    }

                }
                else
                {
                    string id_string = this.ddlEmpresa.SelectedItem.Value;

                    short id = Convert.ToInt16(id_string);

                    Dominio.Empresa Empresa = this.Controladora.BuscarEmpresa(id);
                    if (this.Controladora.ModificarClienteEmpresa(Id, Cedula, Nombre, Apellido, Direccion, Telefono, Empresa, Descuento))
                    {
                        this.ListarCliente();
                        lblMensajes.Text = "Cliente Empresa ID:{" + Id + "}" + " " + Nombre + " modificado correctamente!";
                        this.LimpiarCajas();
                        this.CargarIdEmpresa();
                    }
                    else
                    {
                        return;
                    }

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
                else
                {
                    short Id = Convert.ToInt16(txtId.Text);
                    string Nombre = txtNombre.Text;

                    
                    if (rbtEmpresa.Checked == true)
                    {
                        if (this.Controladora.BajaClienteEmpresa(Id))
                        {
                            this.ListarCliente();
                            lblMensajes.Text = "Cliente Empresa ID:{" + Id + "}" + " " + Nombre + " eliminado correctamente!";
                            this.LimpiarCajas();
                            this.CargarIdEmpresa();
                        }
                        else
                        {
                            throw new Exception("ERROR: Cliente Empresa ID:{" + Id + "}" + " " + Nombre + " no se pudo eliminar!");
                        }
                    }
                    else
                    {
                        if (this.Controladora.BajaClienteParticular(Id))
                        {
                            this.ListarCliente();
                            lblMensajes.Text = "Cliente Particular ID:{" + Id + "}" + " " + Nombre + " eliminado correctamente!";
                            this.LimpiarCajas();
                            this.CargarIdParticular();
                        }
                        else
                        {
                            throw new Exception("ERROR: Cliente Particular ID:{" + Id + "}" + " " + Nombre + " no se pudo eliminar!");
                        }
                    }

                }

            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }
        }
    }
}