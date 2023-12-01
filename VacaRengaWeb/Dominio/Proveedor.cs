using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Proveedor : Persona
    {
        private string _tipoProducto;
        private string _procedencia;
        private int _impuestos;


        public string TipoProductoProvee
        {
            get { return _tipoProducto; }
            set { _tipoProducto = value; }
        }

        public string Procedencia
        {
            get { return _procedencia; }
            set { _procedencia = value; }
        }

        public int Impuestos
        {
            get { return _impuestos; }
            set { _impuestos = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.TipoProductoProvee + " " + this.Procedencia + " " + this.Impuestos;
        }

        public Proveedor(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono, string pTipoProductoProvee, string pProcedencia, int pImpuestos)
            : base(pId, pCedula, pNombre, pApellido, pDireccion, pTelefono)
        {
            this.TipoProductoProvee = pTipoProductoProvee;
            this.Procedencia = pProcedencia;
            this.Impuestos = pImpuestos;

        }
    }
}