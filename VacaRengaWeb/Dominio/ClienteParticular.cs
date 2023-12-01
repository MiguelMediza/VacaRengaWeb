using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VacaRengaWeb.Dominio
{
    public class ClienteParticular : Persona
    {
        public override string ToString()
        {
            return base.ToString();
        }

        public ClienteParticular(short pId, string pCedula, string pNombre, string pApellido, string pDireccion, int pTelefono)
            : base(pId, pCedula, pNombre, pApellido, pDireccion, pTelefono)
        {

        }

        public ClienteParticular()
        {

        }
    }
}