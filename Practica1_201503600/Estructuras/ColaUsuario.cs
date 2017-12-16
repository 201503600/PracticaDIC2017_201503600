using Practica1_201503600.Estructuras.MoldeMatriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.Estructuras
{
    public class ColaUsuario
    {
        private NodoPilaCola inicio;
        private NodoPilaCola fin;
        private int size;

        public ColaUsuario()
        {
            this.inicio = null;
            this.fin = null;
            this.size = 0;
        }

        public int getSize()
        {
            return this.size;
        }

        public void queue(Matriz m)
        {
            NodoPilaCola nuevo = new NodoPilaCola(m);
            if (isEmpty())
                inicio = nuevo;
            else
                fin.setSiguiente(nuevo);
            fin = nuevo;
            size++;
            
        }

        public NodoPilaCola dequeue()
        {
            NodoPilaCola aux;
            if (!isEmpty())
            {
                aux = inicio;
                inicio = inicio.getSiguiente();
                size--;
            }
            else
                throw new Exception("Excepción: Cola vacía");
            return aux;
        }

        public bool isEmpty()
        {
            if (size == 0)
                return true;
            else
                return false;
        }

        public NodoPilaCola peek()
        {
            NodoPilaCola aux;
            if (!isEmpty())
                aux = inicio;
            else
                throw new Exception("Excepción: Cola vacía");

            return aux;
        }

        public String generarImagenCola()
        {
            String dot = "digraph g{\nrankdir=LR\nnode [shape = record, width = 0.1, height = 0.1];\n";
            String cuerpo = "";
            NodoPilaCola aux = inicio;
            for (int pos = 0; pos < size; pos++)
            {
                dot += "struct" + pos + " [label = \"{<f0> Suma\\n" + aux.getMatriz().getSuma() + 
                                                    " |<f1> }\"];\n";
                if (pos == 0)
                    cuerpo += "head -> struct0:f0;\n";
                else
                    cuerpo += "struct" + (pos - 1) + ":f1 -> struct" + pos + ":f0;\n";
                aux = aux.getSiguiente();
            }
            dot += cuerpo + "struct" + (size - 1) + ":f1 -> null;\nbottom -> struct" + (size - 1) + ":f0;\n";

            dot += "label = \"Cola\"\n}";
            return dot;
        }
    }
}
