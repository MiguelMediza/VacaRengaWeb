using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Empresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.ListarEmpresa();
                this.LimpiarCajas();
            }
        }

        private void LimpiarCajas()//Permite limpiar todas las cajas y volverlas a su valor inicial
        {
            Dominio.Controladora unaControladora = new Dominio.Controladora();
            this.txtId.Text = unaControladora.ProximoIdEmpresa().ToString();
            this.txtNombre.Text = string.Empty;
        }
        private void ListarEmpresa()//Lista todos los clientes agregados
        {
            Dominio.Controladora controladora = new Dominio.Controladora();
            this.lstEmpresas.DataSource = null;
            this.lstEmpresas.DataSource = controladora.ListaEmpresas().OrderBy(Empresa => Empresa.Nombre).ToList();
            this.lstEmpresas.DataBind();

        }

        private void CargarEmpresa(short pId)//Cuando se selecciona un cliente carga sus datos en las cajas de texto
        {
            Dominio.Controladora controladora = new Dominio.Controladora();

            Dominio.Empresa unaEmpresa = controladora.BuscarEmpresa(pId);

            if (unaEmpresa != null)
            {
                this.txtId.Text = unaEmpresa.Id.ToString();
                this.txtNombre.Text = unaEmpresa.Nombre.ToString();
            }
        }

        protected void lstEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstEmpresas.SelectedIndex != -1)
            {
                string linea = this.lstEmpresas.SelectedItem.ToString();
                string[] partes = linea.Split(' ');
                short Id = Convert.ToInt16(partes[0]);
                this.CargarEmpresa(Id);

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LimpiarCajas();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
                {
                    throw new Exception("El ID no es correcto");
                }
                if (txtNombre.Text.Trim() == "")
                {
                    throw new Exception("El Nombre no es correcto");
                }

                short Id = Convert.ToInt16(txtId.Text);
                string Nombre = txtNombre.Text;

                Dominio.Empresa unaEmpresa = new Dominio.Empresa(Id, Nombre);

                Dominio.Controladora unaControladora = new Dominio.Controladora();

                if (unaControladora.AltaEmpresa(unaEmpresa))
                {
                    this.ListarEmpresa();
                    lblMensajes.Text = "Empresa ID:{" + Id + "}" + " " + Nombre + " ingresada correctamente!";
                    this.LimpiarCajas();
                }
                else
                {
                    throw new Exception("Ya existe una Empresa con ese ID");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtId.Text.Trim() == "" || !int.TryParse(txtId.Text, out _))
                {
                    lblMensajes.Text = "El ID no es correcto";
                    return;
                }
                if (txtNombre.Text.Trim() == "")
                {
                    lblMensajes.Text = "El Nombre no es correcto";
                    return;
                }

                short Id = Convert.ToInt16(txtId.Text);
                string Nombre = txtNombre.Text;

                Dominio.Controladora unaControladora = new Dominio.Controladora();

                if (unaControladora.ModificarEmpresa(Id, Nombre))
                {
                    this.ListarEmpresa();
                    lblMensajes.Text = "Empresa ID:{" + Id + "}" + " " + Nombre + " modificada correctamente!";
                    this.LimpiarCajas();

                }
                else
                {
                    throw new Exception("No existe una empresa con ese ID");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
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

                if (unaControladora.BajaEmpresa(Id))
                {
                    this.ListarEmpresa();
                    lblMensajes.Text = "Empresa ID:{" + Id + "}" + " " + Nombre + " eliminada correctamente!";
                    this.LimpiarCajas();
                }
                else
                {
                    throw new Exception("ERROR: Empresa ID:{" + Id + "}" + " " + Nombre + " no se pudo eliminar, un cliente la tiene como Empresa actual!");
                }
            }
            catch (Exception Error)
            {
                lblMensajes.Text = Error.Message;
            }
        }
    }
}