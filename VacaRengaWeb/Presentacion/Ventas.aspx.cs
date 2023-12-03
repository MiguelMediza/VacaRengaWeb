using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Ventas : System.Web.UI.Page
    {
        private Dominio.Controladora Controladora = new Dominio.Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarVentas();
                LimpiarCajas();
                ListarClientes();
                CargarInsumos();
            }

        }
        private void LimpiarCajas()//Permite limpiar todas las cajas y volverlas a su valor inicial
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.txtId.Text = unaControladora.ProximoIdVentas().ToString();
            this.txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.txthora.Text = DateTime.Now.ToString("HH:mm");
            this.ddlClientes.SelectedIndex = 0;
            this.ddlInsumos.SelectedIndex = 0;
            this.txtunidades.Text = string.Empty;
            this.txtprecio.Text = string.Empty;
            this.txtId.Focus();
        }
        private void ListarVentas()//Lista todos los clientes agregados
        {
            this.lstVentas.DataSource = null;
            this.lstVentas.DataSource = this.Controladora.ListaVentas().ToList();
            this.lstVentas.DataBind();

        }
        private bool ValidacionDatos()
        {
            if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
            {
                lblMensajes.Text = "El Id ingresado no cumple los requisitos!";
                return false;
            }
            if (ddlInsumos.SelectedIndex == 0)
            {
                lblMensajes.Text = "Debe seleccionar un insumo!";
                return false;
            }
            if (txtunidades.Text.Trim() == "" || !int.TryParse(txtunidades.Text, out _))
            {
                lblMensajes.Text = "Debe ingresar un valor de unidades correcto!";
                return false;
            }
            if (ddlClientes.SelectedIndex== 0)
            {
                lblMensajes.Text = "Debe seleccionar un cliente!";
                return false;
            }
            if (txtprecio.Text.Trim() == "" || !double.TryParse(txtprecio.Text, out _))
            {
                lblMensajes.Text = "Debe ingresar un precio valido!";
                return false;
            }

            return true;
        }

        private void CargarVenta(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {

            Dominio.Venta unaVenta = this.Controladora.BuscarVenta(pId);

            if (unaVenta != null)
            {
                this.txtId.Text = unaVenta.Id.ToString();
                foreach (ListItem item in this.ddlInsumos.Items)
                {
                    if (item.Value == unaVenta.Insumo.Id.ToString())
                    {
                        this.ddlInsumos.SelectedValue = unaVenta.Insumo.Id.ToString();
                    }
                }
                this.txtFecha.Text = unaVenta.Fecha.ToString("yyyy-MM-dd");
                this.txthora.Text = unaVenta.Hora.ToString("HH:mm");
                this.txtunidades.Text = unaVenta.Unidades.ToString();
                if (unaVenta.TipoCliente == "EMP")
                {
                    this.rbtEmpresa.Checked = true;
                    this.rbtPersona.Checked = false;
                    this.ListarClientes();
                    
                }
                else
                {
                    this.rbtPersona.Checked = true;
                    this.rbtEmpresa.Checked = false;

                    this.ListarClientes();
                    this.ddlClientes.Text = unaVenta.ClienteParticular.Id + " " + unaVenta.ClienteParticular.Nombre + " " + unaVenta.ClienteParticular.Apellido;
                }

                this.txtprecio.Text = unaVenta.Precio.ToString();
            }
        }

        private void ListarClientes()
        {
            this.ddlClientes.Items.Clear();
            this.ddlClientes.Items.Add("Seleccione un Cliente");

            if (this.rbtEmpresa.Checked == true)
            {

                foreach (Dominio.ClienteEmpresa unCli in this.Controladora.ListaClientesEmpresa())
                {
                    this.ddlClientes.Items.Add(unCli.Id + " " + unCli.Cedula + " " + unCli.Nombre + " " + unCli.Apellido + " " + unCli.Direccion + " " + unCli.Telefono + " " + unCli.Empresa.Nombre + " " + unCli.Descuento);
                }
            }
            else
            {
                foreach (Dominio.ClienteParticular unCli in this.Controladora.ListaClientesParticular())
                {
                    this.ddlClientes.Items.Add(unCli.Id + " " + unCli.Cedula + " " + unCli.Nombre + " " + unCli.Apellido + " " + unCli.Direccion + " " + unCli.Telefono);
                }
            }

            this.ddlClientes.DataBind();
        }
        private void CargarInsumos()
        {
            this.ddlInsumos.Items.Clear();
            Dominio.Controladora controladora = new Dominio.Controladora();

            ListItem Item = new ListItem();
            Item.Value = "";
            Item.Text = "Seleccione un insumo";
            this.ddlInsumos.Items.Add(Item);

            foreach (Dominio.Insumo unInsumo in controladora.ListaInsumos())
            {
                ListItem Item1 = new ListItem();
                Item1.Value = unInsumo.Id.ToString();
                Item1.Text = unInsumo.Nombre;
                this.ddlInsumos.Items.Add(Item1);
            }
            this.ddlInsumos.SelectedIndex = 0;
            this.ddlInsumos.DataBind();

        }

        private void CargarPrecio()
        {
            if (ddlInsumos.SelectedIndex==0)
            {
                lblMensajes.Text = "Seleccione un insumo!";
            }
            else
            {
                if (rbtEmpresa.Checked == true && txtunidades.Text!="")
                {
                    lblMensajes.Text = string.Empty;
                    short Id2 = Convert.ToInt16(ddlInsumos.SelectedValue);
                    Dominio.Insumo unInsumo2 = this.Controladora.BuscarInsumo(Id2);
                    int unidades2 = Convert.ToInt32(txtunidades.Text);
                    double descuento = ((unInsumo2.Precio * unidades2) * 10) / 100;
                    txtprecio.Text = ((unInsumo2.Precio * unidades2) - descuento).ToString();

                }
                else if(rbtPersona.Checked == true && txtunidades.Text != "")
                {
                    lblMensajes.Text = string.Empty;
                    short Id = Convert.ToInt16(ddlInsumos.SelectedValue);
                    Dominio.Insumo unInsumo = this.Controladora.BuscarInsumo(Id);
                    int unidades = Convert.ToInt32(txtunidades.Text);
                    txtprecio.Text = (unInsumo.Precio * unidades).ToString();
                }
                else
                {
                    lblMensajes.Text = "Debe ingresar un valor de unidades!";
                    txtprecio.Text = string.Empty;
                }


            }
            
        }
        protected void rbtEmpresa_CheckedChanged(object sender, EventArgs e)
        {
            this.ListarClientes();
            CargarPrecio();
        }

        protected void rbtPersona_CheckedChanged(object sender, EventArgs e)
        {
            this.ListarClientes();
            CargarPrecio();
        }

        protected void lstVentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstVentas.SelectedIndex != -1)
            {
                string linea = this.lstVentas.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                this.CargarVenta(Id);
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
                short Id = Convert.ToInt16(txtId.Text);
                DateTime Fecha = DateTime.Parse(txtFecha.Text);
                DateTime Hora = DateTime.Parse(txthora.Text);

                string id_string = this.ddlInsumos.SelectedItem.Value;
                short id = Convert.ToInt16(id_string);
                Dominio.Insumo Insumo = this.Controladora.BuscarInsumo(id);

                int Unidades = Convert.ToInt32(txtunidades.Text);

                string lineaC = this.ddlClientes.SelectedItem.ToString();
                string[] partesC = lineaC.Split(' ');
                short IdCliente = Convert.ToInt16(partesC[0]);
                Dominio.ClienteEmpresa unCliEmp = new Dominio.ClienteEmpresa();
                Dominio.ClienteParticular unCliPart = new Dominio.ClienteParticular();

                double Precio = Convert.ToDouble(txtprecio.Text);
                string TipoCliente = "EMP";

                if (this.rbtEmpresa.Checked)
                {
                    unCliEmp = this.Controladora.BuscarClienteEmpresa(IdCliente);
                }
                else
                {
                    unCliPart = this.Controladora.BuscarClienteParticular(IdCliente);
                    TipoCliente = "PART";
                }

                Dominio.Venta unaVenta = new Dominio.Venta(Id, Fecha, Hora, Insumo, Unidades, unCliEmp, unCliPart, Precio, TipoCliente);

                if (this.Controladora.ModificarStock(Insumo.Id, Unidades, "Alta"))
                {
                    if (this.Controladora.AltaVenta(unaVenta))
                    {
                        this.ListarVentas();
                        lblMensajes.Text = "Venta ID:{" + Id + "}" + " ingresada correctamente!";
                        this.LimpiarCajas();

                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    lblMensajes.Text = "Las unidades ingresadas exceden el stock actual del insumo!";
                }

            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidacionDatos())
            {
                short Id = Convert.ToInt16(txtId.Text);
                DateTime Fecha = DateTime.Parse(txtFecha.Text);
                DateTime Hora = DateTime.Parse(txthora.Text);

                string id_string = this.ddlInsumos.SelectedItem.Value;
                short id = Convert.ToInt16(id_string);
                Dominio.Insumo Insumo = this.Controladora.BuscarInsumo(id);

                int Unidades = Convert.ToInt32(txtunidades.Text);

                string lineaC = this.ddlClientes.SelectedItem.ToString();
                string[] partesC = lineaC.Split(' ');
                short IdCliente = Convert.ToInt16(partesC[0]);
                Dominio.ClienteEmpresa unCliEmp = new Dominio.ClienteEmpresa();
                Dominio.ClienteParticular unCliPart = new Dominio.ClienteParticular();

                double Precio = Convert.ToDouble(txtprecio.Text);
                string TipoCliente = "EMP";

                if (this.rbtEmpresa.Checked)
                {
                    unCliEmp = this.Controladora.BuscarClienteEmpresa(IdCliente);
                }
                else
                {
                    unCliPart = this.Controladora.BuscarClienteParticular(IdCliente);
                    TipoCliente = "PART";
                }

                if (this.Controladora.ModificarVenta(Id, Fecha, Hora, Insumo, Unidades, unCliEmp, unCliPart, Precio, TipoCliente))
                {
                    this.ListarVentas();
                    lblMensajes.Text = "Venta ID:{" + Id + "}" + " modificada correctamente!";
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
                int Unidades = Convert.ToInt32(txtunidades.Text);
                string id_string = this.ddlInsumos.SelectedItem.Value;
                short id_insumo = Convert.ToInt16(id_string);
                Dominio.Insumo Insumo = this.Controladora.BuscarInsumo(id_insumo);

                Dominio.Controladora unaControladora = new Dominio.Controladora();

                if (unaControladora.BajaVenta(Id))
                {
                    this.ListarVentas();
                    lblMensajes.Text = "Venta ID:{" + Id + "}" + " eliminada correctamente!";
                    this.LimpiarCajas();
                    this.Controladora.ModificarStock(Insumo.Id, Unidades, "Baja");
                }
                else
                {
                    throw new Exception("ERROR: Venta ID:{" + Id + "}" + " no se pudo eliminar!");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }
        }
    

        protected void ddlInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarPrecio();
        }

        protected void txtunidades_TextChanged(object sender, EventArgs e)
        {
            this.CargarPrecio();
        }
    }
}