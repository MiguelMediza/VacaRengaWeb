using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;

namespace VacaRengaWeb.Persistencia
{
    public class ControladoraPersistente
    {
        #region Empresa
        public bool AltaEmpresa(Empresa pEmpresa)
        {
            if (new PEmpresa().Alta(pEmpresa))
            {
                return true;
            }
            return false;
        }
        public bool BajaEmpresa(short pId)
        {
            return new PEmpresa().Baja(pId);
        }

        public bool ModificarEmpresa(Empresa pEmpresa)
        {
            return new PEmpresa().Modificar(pEmpresa);
        }


        public List<Empresa> ListaEmpresas()
        {
            return new PEmpresa().Listar();
        }

        public Empresa BuscarEmpresa(short pId)
        {
            return new PEmpresa().Buscar(pId);
        }

        public short ProximoIdEmpresa()
        {
            return new PEmpresa().CargarID();
        }

        #endregion


        public short ProximoIdClienteEmpresa()
        {
            return new PEClienteEmpresa().CargarID();
        }

        public short ProximoIdClienteParticular()
        {
            return new PEClienteParticular().CargarID();
        }

        #region "Cliente Empresa"
        public bool AltaClienteEmpresa(ClienteEmpresa pClienteEmpresa)
        {
            if (new PEClienteEmpresa().Alta(pClienteEmpresa))
            {
                return true;
            }
            return false;
        }
        public bool BajaClienteEmpresa(short pId)
        {
            return new PEClienteEmpresa().Baja(pId);
        }

        public bool ModificarClienteEmpresa(ClienteEmpresa pClienteEmpresa)
        {
            return new PEClienteEmpresa().Modificar(pClienteEmpresa);
        }

        public ClienteEmpresa BuscarClienteEmpresa(short pId)
        {
            return new PEClienteEmpresa().Buscar(pId);
        }


        public List<ClienteEmpresa> ListaClientesEmpresa()
        {
            return new PEClienteEmpresa().Listar();
        }

        #endregion

        #region "Cliente Particular"
        public bool AltaClienteParticular(ClienteParticular pClienteParticular)
        {
            if (new PEClienteParticular().Alta(pClienteParticular))
            {
                return true;
            }
            return false;
        }
        public bool BajaClienteParticular(short pId)
        {
            return new PEClienteParticular().Baja(pId);
        }

        public bool ModificarClienteParticular(ClienteParticular pClienteParticular)
        {
            return new PEClienteParticular().Modificar(pClienteParticular);
        }

        public ClienteParticular BuscarClienteParticular(short pId)
        {
            return new PEClienteParticular().Buscar(pId);
        }


        public List<ClienteParticular> ListaClientesParticular()
        {
            return new PEClienteParticular().Listar();
        }

        #endregion

        #region "Proveedor"

        public short ProximoIdProveedor()
        {
            return new PEProveedor().CargarID();
        }
        public bool AltaProveedor(Proveedor pProveedor)
        {
            if (new PEProveedor().Alta(pProveedor))
            {
                return true;
            }
            return false;
        }
        public bool BajaProveedor(short pId)
        {
            return new PEProveedor().Baja(pId);
        }

        public bool ModificarProveedor(Proveedor pProveedor)
        {
            return new PEProveedor().Modificar(pProveedor);
        }

        public Proveedor BuscarProveedor(short pId)
        {
            return new PEProveedor().Buscar(pId);
        }


        public List<Proveedor> ListaProveedores()
        {
            return new PEProveedor().Listar();
        }

        #endregion

        #region "Insumos"

        public short ProximoIdInsumos()
        {
            return new PEInsumo().CargarID();
        }
        public bool AltaInsumo(Insumo pInsumo)
        {
            if (new PEInsumo().Alta(pInsumo))
            {
                return true;
            }
            return false;
        }
        public bool BajaInsumo(short pId)
        {
            return new PEInsumo().Baja(pId);
        }

        public bool ModificarInsumo(Insumo pInsumo)
        {
            return new PEInsumo().Modificar(pInsumo);
        }
        public bool ModificarStock(Insumo pInsumo)
        {
            return new PEInsumo().ModificarStock(pInsumo);
        }

        public Insumo BuscarInsumo(short pId)
        {
            return new PEInsumo().Buscar(pId);
        }


        public List<Insumo> ListaInsumos()
        {
            return new PEInsumo().Listar();
        }

        #endregion

        #region "Ventas"

        public short ProximoIdVentas()
        {
            return new PEVenta().CargarID();
        }
        public bool AltaVenta(Venta pVenta)
        {
            if (new PEVenta().Alta(pVenta))
            {
                return true;
            }
            return false;
        }
        public bool BajaVenta(short pId)
        {
            return new PEVenta().Baja(pId);
        }

        public bool ModificarVenta(Venta pVenta)
        {
            return new PEVenta().Modificar(pVenta);
        }

        public Venta BuscarVenta(short pId)
        {
            return new PEVenta().Buscar(pId);
        }


        public List<Venta> ListaVentas()
        {
            return new PEVenta().Listar();
        }

        #endregion

        #region Usuario
        public short ProximoIdUsuario()
        {
            return new PUsuario().ProximoId();
        }
        public bool AltaUsuario(Usuario pUsuario)
        {
            if (new PUsuario().Alta(pUsuario))
            {
                return true;
            }
            return false;
        }
        public bool BajaUsuario(short pId)
        {
            return new PUsuario().Baja(pId);
        }
        public bool ModificarUsuario(Usuario pUsuario)
        {
            return new PUsuario().Modificar(pUsuario);
        }

        public Usuario BuscarUsuario(short pId)
        {
            return new PUsuario().Buscar(pId);
        }
        public List<Usuario> ListaUsuarios()
        {
            return new PUsuario().Listar();
        }

        #endregion
    }
}