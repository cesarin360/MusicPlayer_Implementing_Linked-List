using PlayerV1._0.ListaPuntos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerV1._0.objListaOrdenada
{
    public class LinkedList : Lista
    {
        public  LinkedList() : base() {
        }
        public LinkedList Inserta(String entrada)
        {
            Nodo nuevo;
            nuevo = new Nodo(entrada);
            if (primero == null)
            {
                primero = nuevo;
            }
            else if (entrada.Length > primero.getDato().Length)
            {
                nuevo.setEnlace(primero);
                primero = nuevo;
            }
            else
            {
                //busqueda del nodo anterior, a partir de aquí
                //se hara la inserción 
                Nodo anterior, p;
                anterior = p = primero;
                while ((p.getEnlace() != null) && (entrada.Length > p.getDato().Length))
                {
                    anterior = p;
                    p = p.getEnlace();
                }
                if (entrada.Length > p.getDato().Length)
                {//se inserta despues del ultimo nodo
                    anterior = p;
                }
                nuevo.setEnlace(anterior.getEnlace());
                anterior.setEnlace(nuevo);
            }
            return this;
        }
       
        public Nodo BuscarPosicion(int posicion)
        {
            Nodo indice;
            int i;
            if (posicion < 0)
            {
                return null;
            }
            indice = primero;
            for (i = 0; (i < posicion) && (indice != null); i++)
            {
                indice = indice.enlace;
            }
            int pause;
            pause = 0;
            return indice;
        }
        
        public void eliminar(int entrada)
        {
            Nodo actual, anterior;
            bool encontrado;
            //Inicializa los apuntadores
            Nodo dato = BuscarPosicion(entrada);
            actual = primero;
            anterior = null;
            encontrado = false;
            //Busqueda del nodo anterior
            while ((actual != null) && (!encontrado))
            {
                encontrado = (actual.dato == dato.dato);
                if (!encontrado)
                {
                    anterior = actual;
                    actual = actual.enlace;
                }
            }//end while

            //enlace del nodo anterior con el siguiente 
            if (actual != null)
            {
                //distinguir si el nodo inicial o cabeza o si
                if (actual == primero)
                {
                    primero = actual.enlace;
                }
                else
                {
                    anterior.enlace = actual.enlace;
                }
            }
        }
    }
}
