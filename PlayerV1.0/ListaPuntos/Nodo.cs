using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerV1._0.ListaPuntos
{
    public class Nodo
    {
        public String dato;
        public Nodo enlace;

        public Nodo(String x)
        {
            dato = x;
            enlace = null;
        }
        public String getDato()
        {
            return dato;

        }

        public Nodo getEnlace()
        {
            return enlace;
        }
        public void setEnlace(Nodo enlace)
        {
            this.enlace = enlace;
        }
    }
}
