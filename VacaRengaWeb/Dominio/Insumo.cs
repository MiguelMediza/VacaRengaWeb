using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Insumo
    {
        private short _id;
        private string _nombre;
        private string _comentario;
        Proveedor _proveedor;
        private int _stock;


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
        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
        public Proveedor Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }
        public int Stock
        {
            get { return _stock; }
            set { _stock = value; }
        }

        public override string ToString()
        {
            return this.Id + " " + this.Nombre + " " + this.Comentario + " " + this.Proveedor.Nombre + " " + this.Stock;
        }

        public Insumo(short pId, string pNombre, string pComentario, Proveedor pProveedor, int pStock)
        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Comentario = pComentario;
            this.Proveedor = pProveedor;
            this.Stock = pStock;
        }

    }
}