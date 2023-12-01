using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEProveedor
    {
        private Conexion _conexion = new Conexion();

        public short CargarID()
        {
            string sql = "select MAX(id) from Proveedores";
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

        public bool Alta(Proveedor pProveedor)
        {
            string sql = "INSERT INTO Proveedores(id, cedula, nombre, apellido, direccion, telefono, tipoproducto, procedencia, impuestos) values(" +
                pProveedor.Id + "," + pProveedor.Cedula + "," + pProveedor.Nombre + "','" + pProveedor.Apellido + "','" + pProveedor.Direccion + "','" + pProveedor.Telefono + "','" + pProveedor.TipoProductoProvee + "','" + pProveedor.Procedencia + "'," + pProveedor.Impuestos + ")";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM Proveedores WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(Proveedor pProveedor)
        {
            string sql = "UPDATE Proveedores" +
                " SET cedula = " + pProveedor.Cedula + "," +
                " nombre = '" + pProveedor.Nombre + "'," +
                " apellido = '" + pProveedor.Apellido + "'," +
                " direccion = '" + pProveedor.Direccion + "'," +
                " telefono = " + pProveedor.Telefono + "," +
                " tipoproducto = '" + pProveedor.TipoProductoProvee + "'," +
                " procedencia = '" + pProveedor.Procedencia + "'," +
                " impuestos = " + pProveedor.Impuestos +
                " WHERE id = " + pProveedor.Id;
            return _conexion.Consulta(sql);
        }

        public List<Proveedor> Listar()
        {
            string sql = "select * from Proveedores";
            DataSet datos = _conexion.Seleccion(sql);
            List<Proveedor> lista = new List<Proveedor>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Proveedor unProveedor = new Proveedor(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    int.Parse(fila[5].ToString()),
                    fila[6].ToString(),
                    fila[7].ToString(),
                    int.Parse(fila[8].ToString())

                    );
                lista.Add(unProveedor);
            }
            return lista;
        }



        public Proveedor Buscar(int pId)
        {
            string sql = "SELECT * FROM Proveedores WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;

            if (filas.Count > 0)
            {
                var campos = filas[0];
                Proveedor unCliente = new Proveedor(short.Parse(campos[0].ToString()),
                    campos[1].ToString(),
                    campos[2].ToString(),
                    campos[3].ToString(),
                    campos[4].ToString(),
                    int.Parse(campos[5].ToString()),
                    campos[6].ToString(),
                    campos[7].ToString(),
                    int.Parse(campos[8].ToString())

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
