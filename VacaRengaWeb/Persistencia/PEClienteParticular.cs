using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEClienteParticular
    {
        private Conexion _conexion = new Conexion();

        public short CargarID()
        {
            string sql = "select MAX(id) from ClienteParticular";
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

        public bool Alta(ClienteParticular pClienteParticular)
        {
            string sql = "INSERT INTO ClienteParticular(id, cedula, nombre, apellido, direccion, telefono) values(" +
                pClienteParticular.Id + ",'" + pClienteParticular.Cedula + "','" + pClienteParticular.Nombre + "','" + pClienteParticular.Apellido + "','" + pClienteParticular.Direccion + "'," + pClienteParticular.Telefono + ")";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM ClienteParticular WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(ClienteParticular pClienteParticular)
        {
            string sql = "UPDATE ClienteParticular" +
                " SET cedula = " + pClienteParticular.Cedula + "," +
                " nombre = '" + pClienteParticular.Nombre + "'," +
                " apellido = '" + pClienteParticular.Apellido + "'," +
                " direccion = '" + pClienteParticular.Direccion + "'," +
                " telefono = " + pClienteParticular.Telefono +
                " WHERE id = " + pClienteParticular.Id;
            return _conexion.Consulta(sql);
        }

        public List<ClienteParticular> Listar()
        {
            string sql = "select * from ClienteParticular";
            DataSet datos = _conexion.Seleccion(sql);
            List<ClienteParticular> lista = new List<ClienteParticular>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                ClienteParticular unCliente = new ClienteParticular(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    int.Parse(fila[5].ToString())

                    );
                lista.Add(unCliente);
            }
            return lista;
        }



        public ClienteParticular Buscar(int pId)
        {
            string sql = "SELECT * FROM ClienteParticular WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;

            if (filas.Count > 0)
            {
                var campos = filas[0];
                ClienteParticular unCliente = new ClienteParticular(short.Parse(campos[0].ToString()),
                    campos[1].ToString(),
                    campos[2].ToString(),
                    campos[3].ToString(),
                    campos[4].ToString(),
                    int.Parse(campos[5].ToString())

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
