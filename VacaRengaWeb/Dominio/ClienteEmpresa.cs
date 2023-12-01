using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacaRengaWeb.Dominio
{
    public class ClienteEmpresa : Persona
    {
        private Empresa _empresa;
        private Double _descuento;

        public Empresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        public Double Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        public override string ToString()
        {
            return base.ToString() + " " + this.Empresa.Nombre + " " + this.Descuento;
        }

        public ClienteEmpresa(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono, Empresa pEmpresa, Double pDescuento)
            : base(pId,pCedula, pNombre, pApellido, pDireccion, pTelefono)
        {
            this.Empresa = pEmpresa;
            this.Descuento = pDescuento;
           
        }

        public ClienteEmpresa()
        {

        }
    }
}
