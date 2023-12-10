using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VacaRengaWeb.Dominio;
using System.Data;

namespace VacaRengaWeb.Persistencia
{
    public class PUsuario
    {
        private Conexion _conexion = new Conexion();

        public bool Alta(Usuario pUsuario)
        {
            string sql = "INSERT INTO Usuario(id, nombre, email, contrasenia, tipo) values(" +
                pUsuario.Id + ",'" + pUsuario.Nombre + "','" + pUsuario.Email + "','" + pUsuario.Contrasenia + "','" + pUsuario.Tipo + "')";
            return _conexion.Consulta(sql);
        }

        public bool Baja(short pId)
        {
            string sql = "DELETE FROM Usuario WHERE id = " + pId;
            return _conexion.Consulta(sql);
        }
        public bool Modificar(Usuario pUsuario)
        {
            string sql = "UPDATE Usuario SET nombre = '" + pUsuario.Nombre + "', " +
                        " email = '" + pUsuario.Email + "', " +
                        " contrasenia = '" + pUsuario.Contrasenia + "', " +
                        " tipo = '" + pUsuario.Tipo + "' " +
                        " WHERE id=" + pUsuario.Id;
            return _conexion.Consulta(sql);
        }

        public List<Usuario> Listar()
        {
            string sql = "select * from Usuario";
            DataSet datos = _conexion.Seleccion(sql);
            List<Usuario> lista = new List<Usuario>();

            foreach (DataRow fila in datos.Tables[0].Rows)
            {
                Usuario unUsuario = new Usuario(
                    short.Parse(fila[0].ToString()),
                    fila[1].ToString(), fila[2].ToString(), fila[3].ToString(), fila[4].ToString()
                    );
                lista.Add(unUsuario);
            }
            return lista;
        }

        public Usuario Buscar(int pId)
        {
            string sql = "SELECT * FROM Usuario WHERE id =" + pId;
            DataSet datos = this._conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            if (filas.Count > 0)
            {
                var campos = filas[0];
                Usuario unUsuario = new Usuario(short.Parse(campos[0].ToString()),
                    campos[1].ToString(), campos[2].ToString(), campos[3].ToString(), campos[4].ToString());
                return unUsuario;
            }
            else
            {
                return null;
            }
        }
        public short ProximoId()
        {
            string sql = "select max(id) from Usuario";
            DataSet datos = _conexion.Seleccion(sql);
            DataRowCollection filas = datos.Tables[0].Rows;
            var campo = filas[0];
            short Id = short.Parse(campo[0].ToString());
            return Id;
        }
    }
}