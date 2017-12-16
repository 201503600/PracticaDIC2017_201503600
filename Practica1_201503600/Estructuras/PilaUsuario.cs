using Practica1_201503600.Estructuras.MoldeMatriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.Estructuras
{
    public class PilaUsuario
    {
        private NodoPilaCola inicio;
        private int size;

        public PilaUsuario()
        {
            this.inicio = null;
            this.size = 0;
        }

        public int getSize()
        {
            return this.size;
        }

        public void push(Matriz m)
        {
            NodoPilaCola nuevo = new NodoPilaCola(m);
            nuevo.setSiguiente(inicio);
            inicio = nuevo;
            size++;
        }

        public bool isEmpty()
        {
            if (size == 0)
                return true;
            else
                return false;
        }

        public NodoPilaCola pop()
        {
            NodoPilaCola matrizEliminada;
            if (isEmpty())
                throw new Exception("Excepción: Pila vacía");
            else
                matrizEliminada = inicio;
            inicio = inicio.getSiguiente();
            size--;
            return matrizEliminada;
        }

        public NodoPilaCola peek()
        {
            NodoPilaCola aux;
            if (!isEmpty())
                aux = inicio;
            else
                throw new Exception("Excepción: Pila vacía");

            return aux;
        }

        public String generarImagenPila()
        {
            String dot = "digraph g{\nrankdir=TB;\nnode [shape = record, width = 0.1, height = 0.1];\n";
            dot += "struct [label = \"{";
            NodoPilaCola aux = inicio;
            while (aux != null)
            {
                if (aux == inicio)
                    dot += "<f0> Suma\\n" + aux.getMatriz().getSuma();
                else
                    dot += " | Suma\\n" + aux.getMatriz().getSuma();
                aux = aux.getSiguiente();
            }

            dot += "}\"];\n\nlabel = \"Pila\"\n}";
            return dot;
        }
    }
}
