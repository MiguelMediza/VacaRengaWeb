using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Venta
    {
        private short _id;
        private DateTime _fecha;
        private DateTime _hora;
        private Insumo _insumo;
        private int _unidades;
        private ClienteEmpresa _clienteEmpresa;
        private ClienteParticular _clienteParticular;
        private Double _precio;
        private string _tipoCliente;


        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public DateTime Hora
        {
            get { return _hora; }
            set { _hora = value; }
        }
        public Insumo Insumo
        {
            get { return _insumo; }
            set { _insumo = value; }
        }
        public int Unidades
        {
            get { return _unidades; }
            set { _unidades = value; }
        }
        public ClienteEmpresa ClienteEmpresa
        {
            get { return _clienteEmpresa; }
            set { _clienteEmpresa = value; }
        }
        public ClienteParticular ClienteParticular
        {
            get { return _clienteParticular; }
            set { _clienteParticular = value; }
        }
        public Double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public string TipoCliente
        {
            get { return _tipoCliente; }
            set { _tipoCliente = value; }
        }

        public override string ToString()
        {
            string Nombre = (this.TipoCliente == "EMP") ? this.ClienteEmpresa.Nombre + " " + this.ClienteEmpresa.Apellido : this.ClienteParticular.Nombre + " " + this.ClienteParticular.Apellido;
            return this.Id + " " + this.Fecha.ToString("dd/MM/yyyy") + " " + this.Hora.ToString("HH:mm") + " " + this.Insumo.Id + " " + this.Unidades + " " + Nombre + " " + this.Precio;
        }

        public Venta(short pId, DateTime pFecha, DateTime pHora, Insumo pInsumo, int pUnidades, ClienteEmpresa pClienteEmpresa, ClienteParticular pClienteParticular, Double pPrecio, string pTipoCliente)
        {
            this.Id = pId;
            this.Fecha = pFecha;
            this.Hora = pHora;
            this.Insumo = pInsumo;
            this.Unidades = pUnidades;
            this.ClienteEmpresa = pClienteEmpresa;
            this.ClienteParticular = pClienteParticular;
            this.Precio = pPrecio;
            this.TipoCliente = pTipoCliente;
        }


    }
}