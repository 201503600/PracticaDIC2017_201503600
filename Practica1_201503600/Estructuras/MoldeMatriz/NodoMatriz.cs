using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.Estructuras.MoldeMatriz
{
    public class NodoMatriz
    {
        private int pos_x;
        private int pos_y;
        private int dato;
        private NodoMatriz arriba;
        private NodoMatriz abajo;
        private NodoMatriz izquierda;
        private NodoMatriz derecha;

        public NodoMatriz(int x, int y)
        {
            this.pos_x = x;
            this.pos_y = y;
            this.dato = 0;
            arriba = null;
            abajo = null;
            izquierda = null;
            derecha = null;
        }

        public void setDato(int valor)
        {
            this.dato = valor;
        }

        public int getPosX()
        {
            return pos_x;
        }

        public int getPosY()
        {
            return pos_y;
        }

        public int getDato()
        {
            return dato;
        }

        public NodoMatriz getArriba()
        {
            return arriba;
        }

        public void setArriba(NodoMatriz arriba)
        {
            this.arriba = arriba;
        }

        public NodoMatriz getAbajo()
        {
            return abajo;
        }

        public void setAbajo(NodoMatriz abajo)
        {
            this.abajo = abajo;
        }

        public NodoMatriz getIzquierda()
        {
            return izquierda;
        }

        public void setIzquierda(NodoMatriz izquierda)
        {
            this.izquierda = izquierda;
        }

        public NodoMatriz getDerecha()
        {
            return derecha;
        }

        public void setDerecha(NodoMatriz derecha)
        {
            this.derecha = derecha;
        }
    }
}
