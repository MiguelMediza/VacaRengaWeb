using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Insumos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarInsumos();
                this.CargarProveedores();
                this.LimpiarCajas();
                Label3.Visible = false;
                txtInfoProveedor.Visible = false;
            }
        }

        private void LimpiarCajas()//Permite limpiar todas las cajas y volverlas a su valor inicial
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.txtId.Text = unaControladora.ProximoIdInsumos().ToString();
            this.txtNombre.Text = string.Empty;
            this.txtComentario.Text = string.Empty;
            this.ddlProveedor.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            Label3.Visible = false;
            txtInfoProveedor.Visible = false;
        }

        private void ListarInsumos()//Lista todos los clientes agregados
        {
            Dominio.Controladora controladora = new Dominio.Controladora();
            this.lstInsumos.DataSource = null;
            this.lstInsumos.DataSource = controladora.ListaInsumos().ToList();
            this.lstInsumos.DataBind();
        }

        private void CargarProveedores()
        {
            this.ddlProveedor.Items.Clear();
            Dominio.Controladora controladora = new Dominio.Controladora();

            ListItem Item = new ListItem();
            Item.Value = "";
            Item.Text = "Seleccione un proveedor";
            this.ddlProveedor.Items.Add(Item);

            foreach (Dominio.Proveedor unProveedor in controladora.ListaProveedores())
            {
                ListItem Item1 = new ListItem();
                Item1.Value = unProveedor.Id.ToString();
                Item1.Text = unProveedor.Nombre;
                this.ddlProveedor.Items.Add(Item1);
            }
            this.ddlProveedor.SelectedIndex = 0;
            this.ddlProveedor.DataBind();

        }


        private bool ValidacionDatos()
        {
            if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
            {
                lblMensajes.Text = "El Id ingresado no cumple los requisitos!";
                return false;
            }
            if (txtNombre.Text.Trim() == "")
            {
                lblMensajes.Text = "Debe ingresar un nombre!";
                return false;
            }
            if (ddlProveedor.SelectedIndex == 0)
            {
                lblMensajes.Text = "Debe seleccionar un proveedor!";
                return false;
            }
            if (txtStock.Text.Trim() == "" || !int.TryParse(txtStock.Text, out _))
            {
                lblMensajes.Text = "Debe ingresar un stock valido!";
                return false;
            }

            return true;
        }
        private void CargarInsumo(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {
            Dominio.Controladora controladora = new Dominio.Controladora();

            Dominio.Insumo unInsumo = controladora.BuscarInsumo(pId);

            if (unInsumo != null)
            {
                this.txtId.Text = unInsumo.Id.ToString();
                this.txtNombre.Text = unInsumo.Nombre.ToString();
                this.txtComentario.Text = unInsumo.Comentario.ToString();
                foreach (ListItem item in this.ddlProveedor.Items)
                {
                    if (item.Value == unInsumo.Proveedor.Id.ToString())
                    {
                        this.ddlProveedor.SelectedValue = unInsumo.Proveedor.Id.ToString();
                    }
                }
                this.txtStock.Text = unInsumo.Stock.ToString();
                Label3.Visible = true;
                txtInfoProveedor.Visible = true;
                short Id = Convert.ToInt16(ddlProveedor.SelectedValue);
                Dominio.Proveedor Proveedor = controladora.BuscarProveedor(Id);
                txtInfoProveedor.Text = "ID:" + Proveedor.Id + " " + Proveedor.Nombre + " " + Proveedor.Apellido;
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
                string Nombre = txtNombre.Text.ToString();
                string Comentario = txtComentario.Text.ToString();

                string id_string = this.ddlProveedor.SelectedItem.Value;
                short id = Convert.ToInt16(id_string);
                Dominio.Proveedor Proveedor = unaControladora.BuscarProveedor(id);

                int Stock = Convert.ToInt32(txtStock.Text);

                Dominio.Insumo unInsumo = new Dominio.Insumo(Id, Nombre, Comentario, Proveedor, Stock);


                if (unaControladora.AltaInsumo(unInsumo))
                {
                    this.ListarInsumos();
                    lblMensajes.Text = "Insumo ID:{" + Id + "}" + " " + Nombre + " ingresado correctamente!";
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
                string Nombre = txtNombre.Text.ToString();
                string Comentario = txtComentario.Text.ToString();

                string id_string = this.ddlProveedor.SelectedItem.Value;
                short id = Convert.ToInt16(id_string);
                Dominio.Proveedor Proveedor = unaControladora.BuscarProveedor(id);

                int Stock = Convert.ToInt32(txtStock.Text);


                if (unaControladora.ModificarInsumo(Id, Nombre, Comentario, Proveedor, Stock))
                {
                    this.ListarInsumos();
                    lblMensajes.Text = "Insumo ID:{" + Id + "}" + " " + Nombre + " modificado correctamente!";
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

                if (unaControladora.BajaInsumo(Id))
                {
                    this.ListarInsumos();
                    lblMensajes.Text = "Insumo ID:{" + Id + "}" + " " + Nombre + " eliminado correctamente!";
                    this.LimpiarCajas();
                }
                else
                {
                    throw new Exception("ERROR: Insumo ID:{" + Id + "}" + " " + Nombre + " no se pudo eliminar!");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }
        }

        protected void lstInsumos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstInsumos.SelectedIndex != -1)
            {
                string linea = this.lstInsumos.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                this.CargarInsumo(Id);
            }
        }

        protected void ddlProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            Label3.Visible = true;
            txtInfoProveedor.Visible = true;
            short Id = Convert.ToInt16(ddlProveedor.SelectedValue);
            Dominio.Proveedor Proveedor = unaControladora.BuscarProveedor(Id);
            txtInfoProveedor.Text = "ID:" + Proveedor.Id + " " + Proveedor.Nombre + " " + Proveedor.Apellido;

        }
    }
}