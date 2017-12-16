using Practica1_201503600.Estructuras.MoldeMatriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.Estructuras
{
    public class NodoPilaCola
    {
        private Matriz matriz;
        private NodoPilaCola siguiente;

        public NodoPilaCola(Matriz matriz)
        {
            this.matriz = matriz;
            this.siguiente = null;
        }

        public Matriz getMatriz()
        {
            return this.matriz;
        }

        public NodoPilaCola getSiguiente()
        {
            return this.siguiente;
        }

        public void setSiguiente(NodoPilaCola siguiente)
        {
            this.siguiente = siguiente;
        }
    }
}
