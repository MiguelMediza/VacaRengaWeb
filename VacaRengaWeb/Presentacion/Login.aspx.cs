using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VacaRengaWeb.Presentacion
{
    public partial class Login : System.Web.UI.Page
    {
        private Dominio.Controladora Controladora = new Dominio.Controladora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control c = this.Master.FindControl("menu");
                c.Visible = false;
                this.Controladora.AltaUsuarioLogueado(null);
            }
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtUsuario.Text.Trim() == "" || this.txtContrasenia.Text.Trim() == "")
                {
                    throw new Exception("Usuario y/o contraseña requeridos");
                }

                Dominio.Usuario unUsuario = this.Controladora.BuscarUsuarioXEmail(this.txtUsuario.Text);
                if (unUsuario != null)
                {
                    if(unUsuario.Contrasenia == txtContrasenia.Text)
                    {
                        this.Controladora.AltaUsuarioLogueado(unUsuario);
                        Response.Redirect("~/Presentacion/Default.aspx");
                    }
                    else
                    {
                        throw new Exception("Contraseña incorrecta");
                    }
                }
                else
                {
                    throw new Exception("Usuario incorrecto");
                }

            }
            catch (Exception Error)
            {
                lblMensaje.Text = Error.Message;
            }
            
        }
    }
}