using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEVenta
    {
        private Conexion _conexion = new Conexion();

        public short CargarID()
        {
            string sql = "select MAX(id) from Ventas";
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

        public bool Alta(Venta pVenta)
        {
            short idCliente = (pVenta.TipoCliente == "EMP") ? pVenta.ClienteEmpresa.Id : pVenta.ClienteParticular.Id;
            string sql = "INSERT INTO Ventas(id, fecha, hora, insumo, unidades, id_cliente, precio, tipoCliente) values(" +
                pVenta.Id + ",'" + pVenta.Fecha + "','" + pVenta.Hora + "'," + pVenta.Insumo.Id + "," + pVenta.Unidades + "," + idCliente + ",'" + pVenta.Precio + "','" + pVenta.TipoCliente + "'" + ")";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM Ventas WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(Venta pVenta)
        {
            string sql = "UPDATE Insumos" +
                " SET fecha = '" + pVenta.Fecha.ToString("yyyy-MM-dd") + "'," +
                " hora = '" + pVenta.Hora.ToString("HH:mm") + "'," +
                " id_insumo = " + pVenta.Insumo.Id + "," +
                " unidades = " + pVenta.Unidades +
                " WHERE id = " + pVenta.Id;
            return _conexion.Consulta(sql);
        }

        public List<Venta> Listar()
        {
            string sql = "select * from Ventas";
            DataSet datos = _conexion.Seleccion(sql);
            List<Venta> lista = new List<Venta>();

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                ClienteEmpresa pCliEmp = new ClienteEmpresa();
                ClienteParticular pCliPart = new ClienteParticular();

                if (fila[7].ToString() == "EMP")
                {
                    pCliEmp = UnaCP.BuscarClienteEmpresa(short.Parse(fila[5].ToString()));
                }
                else
                {
                    pCliPart = UnaCP.BuscarClienteParticular(short.Parse(fila[5].ToString()));
                }
                Venta unaVenta = new Venta(
                    short.Parse(fila[0].ToString()),
                    DateTime.Parse(fila[1].ToString()),
                    DateTime.Parse(fila[2].ToString()),
                    UnaCP.BuscarInsumo(short.Parse(fila[3].ToString())),
                    int.Parse(fila[4].ToString()),
                    pCliEmp,
                    pCliPart,
                    double.Parse(fila[6].ToString()),
                    fila[7].ToString()

                    );
                lista.Add(unaVenta);
            }
            return lista;
        }



        public Venta Buscar(int pId)
        {
            string sql = "SELECT * FROM Ventas WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;

            ControladoraPersistente UnaCP = new ControladoraPersistente();
            if (filas.Count > 0)
            {
                var campos = filas[0];
                ClienteEmpresa pCliEmp = new ClienteEmpresa();
                ClienteParticular pCliPart = new ClienteParticular();

                if (campos[7].ToString() == "EMP")
                {
                    pCliEmp = UnaCP.BuscarClienteEmpresa(short.Parse(campos[2].ToString()));
                }
                else
                {
                    pCliPart = UnaCP.BuscarClienteParticular(short.Parse(campos[2].ToString()));
                }

                Venta unaVenta = new Venta(
                    short.Parse(campos[0].ToString()),
                    DateTime.Parse(campos[1].ToString()),
                    DateTime.Parse(campos[2].ToString()),
                    UnaCP.BuscarInsumo(short.Parse(campos[3].ToString())),
                    int.Parse(campos[4].ToString()),
                    pCliEmp,
                    pCliPart,
                    double.Parse(campos[6].ToString()),
                    campos[7].ToString()

                    );
                return unaVenta;
            }
            else
            {
                return null;
            }
        }
    }
}
