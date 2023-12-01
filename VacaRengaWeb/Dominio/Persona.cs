using System;
namespace VacaRengaWeb.Dominio
{
    public class Persona
    {
        private short _id;
        private string _cedula;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private int _telefono;


        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Cedula
        {
            get { return _cedula; }
            set { _cedula = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }


        public override string ToString()
        {
            return  this.Id + " " + this.Cedula + " " + this.Nombre + " " + this.Apellido + " " + this.Direccion + " " + this.Telefono;
        }

        public Persona(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono)
            
        {
            this.Id = pId;
            this.Cedula = pCedula;
            this.Nombre = pNombre;
            this.Apellido = pApellido;
            this.Direccion = pDireccion;
            this.Telefono = pTelefono;
        }

        public Persona()
        {

        }
    }
}


