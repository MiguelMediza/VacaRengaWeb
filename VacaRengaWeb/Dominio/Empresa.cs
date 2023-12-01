using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Empresa
    {
        private short _id;
        private string _nombre;


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

        public override string ToString()
        {
            return this.Id + " " + this.Nombre;
        }

        public Empresa(short pId, string pNombre)

        {
            this.Id = pId;
            this.Nombre = pNombre;
        }
    }
}