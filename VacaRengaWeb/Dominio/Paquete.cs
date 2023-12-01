using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class Paquete
    {
        private short _id;
        private string _destino;
        private DateTime _horaSalida;
        private string _almuerzo;
        private string _detallesItinerario;
        private DateTime _horaRetorno;
        private double _precio;


        public short Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }
        public DateTime HoraSalida
        {
            get { return _horaSalida; }
            set { _horaSalida = value; }
        }
        public string Almuerzo
        {
            get { return _almuerzo; }
            set { _almuerzo = value; }
        }
        public string Itinerario
        {
            get { return _detallesItinerario; }
            set { _detallesItinerario = value; }
        }
        public DateTime HoraRetorno
        {
            get { return _horaRetorno; }
            set { _horaRetorno = value; }
        }
        public Double Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


        public override string ToString()
        {
            return this.Id + " " + this.Destino + " " + this.HoraSalida.ToShortTimeString() + " " + this.Almuerzo + " " + this.Itinerario + " " + this.HoraRetorno.ToShortTimeString() + " " + this.Precio;
        }

        public Paquete(short pId, string pDestino, DateTime pHoraSalida, string pAlmuerzo, string pItinerario, DateTime pHoraRetorno, Double pPrecio)

        {
            this.Id = pId;
            this.Destino = pDestino;
            this.HoraSalida = pHoraSalida;
            this.Almuerzo = pAlmuerzo;
            this.Itinerario = pItinerario;
            this.HoraRetorno = pHoraRetorno;
            this.Precio = pPrecio;
        }
    }
}