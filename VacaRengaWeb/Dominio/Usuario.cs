using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Usuario
    {
        private short _id;
        private string _nombre;
        private string _email;
        private string _contrasenia;
        private string _tipo;

        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public override string ToString()
        {
            return this.Id + " " + this.Nombre + " " + this.Tipo;
        }
        public Usuario(short pId, string pNombre, string pEmail, string pContrasenia, string pTipo)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Email = pEmail;
            this.Contrasenia = pContrasenia;
            this.Tipo = pTipo;
        }
        public Usuario()
        {

        }
    }
}