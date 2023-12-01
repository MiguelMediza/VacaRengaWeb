using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEInsumo
    {
        private Conexion _conexion = new Conexion();

        public short CargarID()
        {
            string sql = "select MAX(id) from Insumos";
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

        public bool Alta(Insumo pInsumo)
        {
            string sql = "INSERT INTO Insumos(id, nombre, comentario, id_proveedor, stock) values(" +
                pInsumo.Id + ",'" + pInsumo.Nombre + "','" + pInsumo.Comentario + "','" + pInsumo.Proveedor.Id + "'," + pInsumo.Stock + ")";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM Insumos WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(Insumo pInsumo)
        {
            string sql = "UPDATE Insumos" +
                " SET nombre = '" + pInsumo.Nombre + "'," +
                " comentario = '" + pInsumo.Comentario + "'," +
                " id_proveedor = " + pInsumo.Proveedor.Id + "," +
                " stock = " + pInsumo.Stock +
                " WHERE id = " + pInsumo.Id;
            return _conexion.Consulta(sql);
        }

        public List<Insumo> Listar()
        {
            string sql = "select * from Insumos";
            DataSet datos = _conexion.Seleccion(sql);
            List<Insumo> lista = new List<Insumo>();

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Insumo unInsumo = new Insumo(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    UnaCP.BuscarProveedor(short.Parse(fila[3].ToString())),
                    int.Parse(fila[4].ToString())


                    );
                lista.Add(unInsumo);
            }
            return lista;
        }



        public Insumo Buscar(int pId)
        {
            string sql = "SELECT * FROM Insumos WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            if (filas.Count > 0)
            {
                var campos = filas[0];
                Insumo unInsumo = new Insumo(short.Parse(campos[0].ToString()),
                    campos[1].ToString(),
                    campos[2].ToString(),
                    UnaCP.BuscarProveedor(short.Parse(campos[3].ToString())),
                    int.Parse(campos[4].ToString())

                    );
                return unInsumo;
            }
            else
            {
                return null;
            }
        }
    }
}
