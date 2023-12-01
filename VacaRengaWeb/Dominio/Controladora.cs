using System;
using System.Collections.Generic;
using VacaRengaWeb.Persistencia;

namespace VacaRengaWeb.Dominio
{
	public class Controladora
	{

        private ControladoraPersistente _persistencia;

        private List<ClienteEmpresa> _listaClientesEmpresa = new List<ClienteEmpresa>();
        private List<ClienteParticular> _listaClientesParticular = new List<ClienteParticular>();
        private List<Proveedor> _listaProveedores = new List<Proveedor>();
        private List<Insumo> _listaInsumos = new List<Insumo>();
        private List<Venta> _listaVentas = new List<Venta>();
        private List<Empresa> _listaEmpresas = new List<Empresa>();
        private static List<Paquete> _listaPaquetes = new List<Paquete>();

        private static short _proximoIdPaquete = 1;


        #region " ABM Empresa "

        public short ProximoIdEmpresa()//Guarda el proximo ID de Empresas
        {
            return _persistencia.ProximoIdEmpresa();
        }

        public List<Empresa> ListaEmpresas()
        {
            return _listaEmpresas;
        }

        public Empresa BuscarEmpresa(short pId)
        {
            foreach (Empresa unaEmpresa in _listaEmpresas)
            {
                if (unaEmpresa.Id.Equals(pId))
                {
                    return unaEmpresa;
                }
            }
            return null;
        }

        public bool AltaEmpresa(Empresa pEmpresa)
        {
            Empresa unaEmpresa = BuscarEmpresa(pEmpresa.Id);

            if (unaEmpresa == null)
            {
                if (_persistencia.AltaEmpresa(pEmpresa))
                {
                    
                    _listaEmpresas.Add(pEmpresa);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool ModificarEmpresa(short pId, string pNombre)
        {
            Empresa unaEmpresa = BuscarEmpresa(pId);
            if (unaEmpresa != null)
            {
                unaEmpresa.Nombre = pNombre;
                if (_persistencia.ModificarEmpresa(unaEmpresa))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool BajaEmpresa(short pId)
        {
            Empresa unaEmpresa = BuscarEmpresa(pId);
            if (unaEmpresa != null)
            {
                if (_persistencia.BajaEmpresa(pId))
                {
                    _listaEmpresas.Remove(unaEmpresa);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region " ABM Cliente Empresa "

        public short ProximoIdClienteEmpresa()//Guarda el proximo id de cliente
        {
            return _persistencia.ProximoIdClienteEmpresa();
        }

        public short ProximoIdClienteParticular()//Guarda el proximo id de cliente
        {
            return _persistencia.ProximoIdClienteParticular();
        }

        public List<ClienteEmpresa> ListaClientesEmpresa()//Crea una lista publica que devuelve la lista de clientes
        {
            return _listaClientesEmpresa;
        }



        public ClienteEmpresa BuscarClienteEmpresa(short pId)//Busca en la lista clientes mediante el codigo, si encuentra uno que coicida devuelve el cliente
        {
            foreach (ClienteEmpresa unCliente in _listaClientesEmpresa)
            {
                if (unCliente.Id.Equals(pId))
                {
                    return unCliente;
                }
            }
            return null;
        }


        public bool AltaClienteEmpresa(ClienteEmpresa pCliente)//Agrega un nuevo cliente a la lista clientes
        {
            ClienteEmpresa unCliente = BuscarClienteEmpresa(pCliente.Id);


            if (unCliente == null)
            {
                if (_persistencia.AltaClienteEmpresa(pCliente))
                {
                    _listaClientesEmpresa.Add(pCliente);
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            else
            {
                return false;
            }

        }

        //Modifica un cliente ya agregado
        public bool ModificarClienteEmpresa(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono, Empresa pEmpresa, Double pDescuento)
        {
            ClienteEmpresa unCliente = BuscarClienteEmpresa(pId);
            if (unCliente != null)
            {
                unCliente.Cedula = pCedula;
                unCliente.Nombre = pNombre;
                unCliente.Apellido = pApellido;
                unCliente.Direccion = pDireccion;
                unCliente.Telefono = pTelefono;
                unCliente.Empresa = pEmpresa;
                unCliente.Descuento = pDescuento;
                if (_persistencia.ModificarClienteEmpresa(unCliente))
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool BajaClienteEmpresa(short pId)//Elimina un cliente ya agregado
        {
            ClienteEmpresa unCliente = BuscarClienteEmpresa(pId);
            if (unCliente != null)
            {
                if (_persistencia.BajaClienteEmpresa(pId))
                {
                    _listaClientesEmpresa.Remove(unCliente);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

#endregion

        #region " ABM Cliente Particular "


        public List<ClienteParticular> ListaClientesParticular()//Crea una lista publica que devuelve la lista de clientes
        {
            return _listaClientesParticular;
        }



        public ClienteParticular BuscarClienteParticular(short pId)//Busca en la lista clientes mediante el codigo, si encuentra uno que coicida devuelve el cliente
        {
            foreach (ClienteParticular unCliente in _listaClientesParticular)
            {
                if (unCliente.Id.Equals(pId))
                {
                    return unCliente;
                }
            }
            return null;
        }


        public bool AltaClienteParticular(ClienteParticular pClienteParticular)//Agrega un nuevo cliente a la lista clientes
        {
            ClienteParticular unCliente = BuscarClienteParticular(pClienteParticular.Id);


            if (unCliente == null)
            {
                if (_persistencia.AltaClienteParticular(pClienteParticular))
                {
                    _listaClientesParticular.Add(pClienteParticular);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        //Modifica un cliente ya agregado

        public bool ModificarClienteParticular(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono)
        {
            ClienteParticular unCliente = BuscarClienteParticular(pId);
            if (unCliente != null)
            {
                unCliente.Cedula = pCedula;
                unCliente.Nombre = pNombre;
                unCliente.Apellido = pApellido;
                unCliente.Direccion = pDireccion;
                unCliente.Telefono = pTelefono;
                if (_persistencia.ModificarClienteParticular(unCliente))
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }


        public bool BajaClienteParticular(short pId)//Elimina un cliente ya agregado
        {
            ClienteParticular unCliente = BuscarClienteParticular(pId);
            if (unCliente != null)
            {
                if (_persistencia.BajaClienteParticular(pId))
                {
                    _listaClientesParticular.Remove(unCliente);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region " ABM Proveedor "

        public short ProximoIdProveedor()//Guarda el proximo ID de Empresas
        {
            return _persistencia.ProximoIdProveedor();
        }

        public List<Proveedor> ListaProveedores()//Crea una lista publica que devuelve la lista de clientes
        {
            return _listaProveedores;
        }



        public Proveedor BuscarProveedor(short pId)//Busca en la lista clientes mediante el codigo, si encuentra uno que coicida devuelve el cliente
        {
            foreach (Proveedor unProveedor in _listaProveedores)
            {
                if (unProveedor.Id.Equals(pId))
                {
                    return unProveedor;
                }
            }
            return null;
        }


        public bool AltaProveedor(Proveedor pProveedor)//Agrega un nuevo cliente a la lista clientes
        {
            Proveedor unProveedor = BuscarProveedor(pProveedor.Id);


            if (unProveedor == null)
            {
                if (_persistencia.AltaProveedor(pProveedor))
                {
                    _listaProveedores.Add(pProveedor);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        //Modifica un cliente ya agregado

        public bool ModificarProveedor(short pId,  string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono, string pTipoProducto, string pProcedencia, int pImpuestos)
        {
            Proveedor unProveedor = BuscarProveedor(pId);
            if (unProveedor != null)
            {
                unProveedor.Cedula = pCedula;
                unProveedor.Nombre = pNombre;
                unProveedor.Apellido = pApellido;
                unProveedor.Direccion = pDireccion;
                unProveedor.Telefono = pTelefono;
                unProveedor.TipoProductoProvee = pTipoProducto;
                unProveedor.Procedencia = pProcedencia;
                unProveedor.Impuestos = pImpuestos;
                if (_persistencia.ModificarProveedor(unProveedor))
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }


        public bool BajaProveedor(short pId)//Elimina un cliente ya agregado
        {
            Proveedor unProveedor = BuscarProveedor(pId);
            if (unProveedor != null)
            {
                if (_persistencia.BajaProveedor(pId))
                {
                    _listaProveedores.Remove(unProveedor);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region " ABM Insumos "

        public short ProximoIdInsumos()//Guarda el proximo id de cliente
        {
            return _persistencia.ProximoIdInsumos();
        }

        public List<Insumo> ListaInsumos()//Crea una lista publica que devuelve la lista de clientes
        {
            return _listaInsumos;
        }



        public Insumo BuscarInsumo(short pId)//Busca en la lista clientes mediante el codigo, si encuentra uno que coicida devuelve el cliente
        {
            foreach (Insumo unInsumo in _listaInsumos)
            {
                if (unInsumo.Id.Equals(pId))
                {
                    return unInsumo;
                }
            }
            return null;
        }


        public bool AltaInsumo(Insumo pInsumo)//Agrega un nuevo cliente a la lista clientes
        {
            Insumo unInsumo = BuscarInsumo(pInsumo.Id);


            if (unInsumo == null)
            {
                if (_persistencia.AltaInsumo(pInsumo))
                {
                    _listaInsumos.Add(pInsumo);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        //Modifica un cliente ya agregado
        public bool ModificarInsumo(short pId, string pNombre, string pComentario, Proveedor pProveedor, int pStock)
        {
            Insumo unInsumo = BuscarInsumo(pId);
            if (unInsumo != null)
            {
                unInsumo.Nombre = pNombre;
                unInsumo.Comentario = pComentario;
                unInsumo.Proveedor = pProveedor;
                unInsumo.Stock = pStock;
                if (_persistencia.ModificarInsumo(unInsumo))
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool BajaInsumo(short pId)//Elimina un cliente ya agregado
        {
            Insumo unInsumo = BuscarInsumo(pId);
            if (unInsumo != null)
            {
                if (_persistencia.BajaInsumo(pId))
                {
                    _listaInsumos.Remove(unInsumo);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region " ABM Ventas "

        public short ProximoIdVentas()//Guarda el proximo id de cliente
        {
            return _persistencia.ProximoIdVentas();
        }

        public List<Venta> ListaVentas()//Crea una lista publica que devuelve la lista de clientes
        {
            return _listaVentas;
        }



        public Venta BuscarVenta(short pId)//Busca en la lista clientes mediante el codigo, si encuentra uno que coicida devuelve el cliente
        {
            foreach (Venta unaVenta in _listaVentas)
            {
                if (unaVenta.Id.Equals(pId))
                {
                    return unaVenta;
                }
            }
            return null;
        }


        public bool AltaVenta(Venta pVenta)//Agrega un nuevo cliente a la lista clientes
        {
            Venta unaVenta = BuscarVenta(pVenta.Id);


            if (unaVenta == null)
            {
                if (_persistencia.AltaVenta(pVenta))
                {
                    _listaVentas.Add(pVenta);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        //Modifica un cliente ya agregado
        public bool ModificarVenta(short pId, DateTime pFecha, DateTime pHora, Insumo pInsumo, int pUnidades, ClienteEmpresa pClienteEmpresa, ClienteParticular pClienteParticular, Double pPrecio, string pTipoCliente)
        {
            Venta unaVenta = BuscarVenta(pId);
            if (unaVenta != null)
            {
                unaVenta.Fecha = pFecha;
                unaVenta.Hora = pHora;
                unaVenta.Insumo = pInsumo;
                unaVenta.Unidades = pUnidades;
                unaVenta.ClienteEmpresa = pClienteEmpresa;
                unaVenta.ClienteParticular = pClienteParticular;
                unaVenta.Precio = pPrecio;
                unaVenta.TipoCliente = pTipoCliente;
                if (_persistencia.ModificarVenta(unaVenta))
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool BajaVenta(short pId)//Elimina un cliente ya agregado
        {
            Venta unaVenta = BuscarVenta(pId);
            if (unaVenta != null)
            {
                if (_persistencia.BajaVenta(pId))
                {
                    _listaVentas.Remove(unaVenta);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Validar CI
        private static int ValidarDigito(string ci)
        {
            var a = 0;
            var i = 0;
            if (ci.Length <= 6)
            {
                for (i = ci.Length; i < 7; i++)
                {
                    ci = '0' + ci;
                }
            }
            for (i = 0; i < 7; i++)
            {
                a += (Int32.Parse("2987634"[i].ToString()) * Int32.Parse(ci[i].ToString())) % 10;
            }
            if (a % 10 == 0)
            {
                return 0;
            }
            else
            {
                return 10 - a % 10;
            }
        }
        public  bool ValidarCI(string ci)
        {
            string dig = ci[ci.Length - 1].ToString();
            ci = ci.Substring(0, ci.Length - 1);

            int validDigitCalculated = ValidarDigito(ci);
            return (Int32.Parse(dig.ToString()) == validDigitCalculated);
        }

        #endregion

        //#region " ABM Paquete "

        //public void IncrementoIdPaquete()//Incrementa la ID de Paquete
        //{
        //    _proximoIdPaquete++;

        //}
        //public short ProximoIdPaquete()//Guarda el proximo ID de Paquete
        //{
        //    return _proximoIdPaquete;
        //}

        //public List<Paquete> ListaPaquetes()//Crea una lista publica de Paquetes, devuelve la lista de Empresas previamente creada
        //{
        //    return _listaPaquetes;
        //}



        //public Paquete BuscarPaquete(short pId)//Busca en la lista de Paquetes por codigo, si la encuentra la devuelve
        //{
        //    foreach (Paquete unPaquete in _listaPaquetes)
        //    {
        //        if (unPaquete.Id.Equals(pId))
        //        {
        //            return unPaquete;
        //        }
        //    }
        //    return null;
        //}

        //public bool AltaPaquete(Paquete pPaquete)//Agrega un nuevo paquete 
        //{
        //    Paquete unPaquete = BuscarPaquete(pPaquete.Id);

        //    if (unPaquete == null)
        //    {
        //        _listaPaquetes.Add(pPaquete);
        //        this.IncrementoIdPaquete();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //}


        ////Modifica una Empresa ya agregada
        //public bool ModificarPaquete(short pId, string pDestino, DateTime pHoraSalida, string pAlmuerzo, string pItinerario, DateTime pHoraRetorno, Double pPrecio)
        //{
        //    Paquete unPaquete = BuscarPaquete(pId);
        //    if (unPaquete != null)
        //    {
        //        unPaquete.Destino = pDestino;
        //        unPaquete.HoraSalida = pHoraSalida;
        //        unPaquete.Almuerzo = pAlmuerzo;
        //        unPaquete.Itinerario = pItinerario;
        //        unPaquete.HoraRetorno = pHoraRetorno;
        //        unPaquete.Precio = pPrecio;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool BajaPaquete(short pCodigo)//Elimina un paquete ya agregado
        //{
        //    Paquete unPaquete = BuscarPaquete(pCodigo);
        //    if (unPaquete != null)
        //    {
        //        _listaPaquetes.Remove(unPaquete);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //#endregion


        public Controladora()
		{
            _persistencia = new ControladoraPersistente();
            this._listaEmpresas = _persistencia.ListaEmpresas();
            this._listaClientesEmpresa = _persistencia.ListaClientesEmpresa();
            this._listaClientesParticular = _persistencia.ListaClientesParticular();
            this._listaProveedores = _persistencia.ListaProveedores();
            this._listaInsumos = _persistencia.ListaInsumos();
            this._listaVentas = _persistencia.ListaVentas();
        }
	}
}

