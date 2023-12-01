using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PEmpresa
    {
        private Conexion _conexion = new Conexion();

        public bool Alta(Empresa pEmpresa)
        {
            string sql = "INSERT INTO Empresas(id, nombre) values(" +
                pEmpresa.Id + ",'" + pEmpresa.Nombre +"')";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM Empresas WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(Empresa pEmpresa)
        {
            string sql = "UPDATE Empresas SET nombre = '"+ pEmpresa.Nombre +"' WHERE id=" + pEmpresa.Id;
            return _conexion.Consulta(sql);
        }

        public short CargarID()
        {
            string sql = "select MAX(id) from Empresas";
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

        public List<Empresa> Listar()
        {
            string sql = "select * from Empresas";
            DataSet datos = _conexion.Seleccion(sql);
            List<Empresa> lista = new List<Empresa>();
            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Empresa unaEmpresa = new Empresa(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString()
                    );
                lista.Add(unaEmpresa);
            }
            return lista;
        }



        public Empresa Buscar(int pId)
        {
            string sql = "SELECT * FROM Empresas WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            if (filas.Count > 0)
            {
                var campos = filas[0];
                Empresa unEmpresa = new Empresa(short.Parse(campos[0].ToString()),
                    campos[1].ToString());
                return unEmpresa;
            }
            else
            {
                return null;
            }
        }
    }
}