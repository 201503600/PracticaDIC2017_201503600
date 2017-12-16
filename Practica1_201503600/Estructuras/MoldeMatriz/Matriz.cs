using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.Estructuras.MoldeMatriz
{
    public class Matriz
    {
        private int size_x;
        private int size_y;
        private NodoMatriz raiz;
        private int suma;

        public Matriz(int x, int y)
        {
            this.size_x = x;
            this.size_y = y;
            this.suma = 0;

            NodoMatriz nodo = new NodoMatriz(0, 0);
            NodoMatriz auxN = null;
            NodoMatriz auxF = null;
            NodoMatriz auxFA = null;
            for (int posy = 0; posy < size_y; posy++)
                for (int posx = 0; posx < size_x; posx++)
                {
                    if (posx == 0 && posy == 0)
                        auxF = nodo;
                    else if (posx == 0 && posy > 0)
                    {
                        auxFA = nodo;
                        auxN = new NodoMatriz(posx, posy);
                        nodo.setAbajo(auxN);
                        auxN.setArriba(nodo);
                        nodo = auxN;
                        auxF = nodo;
                    }
                    else if (posx > 0 && posy == 0)
                    {
                        auxN = new NodoMatriz(posx, posy);
                        auxF.setDerecha(auxN);
                        auxN.setIzquierda(auxF);
                        auxF = auxN;
                    }
                    else if (posx > 0 && posy > 0)
                    {
                        auxFA = auxFA.getDerecha();
                        auxN = new NodoMatriz(posx, posy);
                        auxN.setArriba(auxFA);
                        auxFA.setAbajo(auxN);
                        auxN.setIzquierda(auxF);
                        auxF.setDerecha(auxN);
                        auxF = auxN;
                    }
                }

            while (nodo.getArriba() != null)
                nodo = nodo.getArriba();

            this.raiz = nodo;
        }

        public int getSuma()
        {
            return this.suma;
        }

        public int getSizeX()
        {
            return this.size_x;
        }

        public int getSizeY()
        {
            return this.size_y;
        }

        public NodoMatriz getRaiz()
        {
            return this.raiz;
        }

        public void setValorMatriz(int x, int y, int valor)
        {
            suma += valor;
            NodoMatriz aux = raiz;

            for (int posx = 1; posx <= x; posx++)
                aux = aux.getDerecha();

            for (int posy = 1; posy <= y; posy++)
                aux = aux.getAbajo();

            aux.setDato(valor);

        }

        public int getValor(int x, int y)
        {
            NodoMatriz aux = raiz;
            int indice = 0;
            while (indice < x)
            {
                aux = aux.getDerecha();
                indice++;
            }
            indice = 0;
            while (indice < y)
            {
                aux = aux.getAbajo();
                indice++;
            }
            return aux.getDato();
        }

        public String generarImagenMatriz()
        {
            String dot = "digraph g{\nnode [shape = record, width = 0.1, height = 0.1];\n" +
                            "estructura [label = \"{";
            int posx, posy;

            NodoMatriz auxF = raiz;
            NodoMatriz auxC = auxF;

            for (posy = 0; posy < size_y; posy++)
            {
                if (posy == 0)
                    dot += " {";
                else
                    dot += " | {";
                for (posx = 0; posx < size_x; posx++)
                {
                    if (posx == 0)
                        dot += auxC.getDato();
                    else
                        dot += " | " + auxC.getDato();
                    auxC = auxC.getDerecha();
                }
                dot += " }";
                auxF = auxF.getAbajo();
                auxC = auxF;
            }

            dot += " }\"]\nlabel = \"Matriz\"\n}";
            return dot;
        }
    }
}
