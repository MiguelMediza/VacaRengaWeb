using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEClienteEmpresa
    {
        private Conexion _conexion = new Conexion();

        public short CargarID()
        {
            string sql = "select MAX(id) from ClienteEmpresa";
            short proxId = 1;
            DataSet datos = _conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            if (filas.Count > 0)
            {
                var campos = filas[0];
                proxId = (short)(short.Parse(campos[0].ToString()) + 1);

            }
            return proxId;
        }

        public bool Alta(ClienteEmpresa pClienteEmpresa)
        {
            string sql = "INSERT INTO ClienteEmpresa(id, cedula, nombre, apellido, direccion, telefono, idempresa, descuento) values(" +
                pClienteEmpresa.Id + "," + pClienteEmpresa.Cedula + ",'" + pClienteEmpresa.Nombre + "','" + pClienteEmpresa.Apellido + "','" + pClienteEmpresa.Direccion + "','" + pClienteEmpresa.Telefono + "'," + pClienteEmpresa.Empresa.Id + "," + pClienteEmpresa.Descuento + ")";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM ClienteEmpresa WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(ClienteEmpresa pClienteEmpresa)
        {
            string sql = "UPDATE ClienteEmpresa" +
                " SET cedula = " + pClienteEmpresa.Cedula + "," +
                " nombre = '" + pClienteEmpresa.Nombre +"'," + 
                " apellido = '" + pClienteEmpresa.Apellido + "'," + 
                " direccion = '" + pClienteEmpresa.Direccion  + "'," + 
                " telefono = " + pClienteEmpresa.Telefono + "," + 
                " idempresa = " + pClienteEmpresa.Empresa.Id + "," + 
                " descuento = " + pClienteEmpresa.Descuento +
                " WHERE id = " + pClienteEmpresa.Id;
            return _conexion.Consulta(sql);
        }

        public List<ClienteEmpresa> Listar()
        {
            string sql = "select * from ClienteEmpresa";
            DataSet datos = _conexion.Seleccion(sql);
            List<ClienteEmpresa> lista = new List<ClienteEmpresa>();

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                ClienteEmpresa unCliente = new ClienteEmpresa(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    int.Parse(fila[5].ToString()),
                    UnaCP.BuscarEmpresa(short.Parse(fila[6].ToString())),
                    double.Parse(fila[7].ToString())


                    );
                lista.Add(unCliente);
            }
            return lista;
        }



        public ClienteEmpresa Buscar(int pId)
        {
            string sql = "SELECT * FROM ClienteEmpresa WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            if (filas.Count > 0)
            {
                var campos = filas[0];
                ClienteEmpresa unCliente = new ClienteEmpresa(short.Parse(campos[0].ToString()),
                    campos[1].ToString(),
                    campos[2].ToString(),
                    campos[3].ToString(),
                    campos[4].ToString(),
                    int.Parse(campos[5].ToString()),
                    UnaCP.BuscarEmpresa(short.Parse(campos[6].ToString())),
                    double.Parse(campos[7].ToString())

                    );
                return unCliente;
            }
            else
            {
                return null;
            }
        }
    }
}