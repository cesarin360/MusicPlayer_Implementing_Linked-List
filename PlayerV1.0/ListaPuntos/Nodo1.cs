using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerV1._0.ListaPuntos
{
    public class Nodo1
    {
        public String dato1;
        public Nodo1 enlace1;

        public Nodo1(String x)
        {
            dato1 = x;
            enlace1 = null;
        }

        public Nodo1(String x, Nodo1 n)
        {
            dato1 = x;
            enlace1 = n;
        }

        public string getDato()
        {
            return dato1;

        }

        public Nodo1 getEnlace()
        {
            return enlace1;
        }
        public void setEnlace(Nodo1 enlace)
        {
            this.enlace1 = enlace;
        }
    }
}
