using Practica1_201503600.Estructuras;
using Practica1_201503600.Estructuras.MoldeMatriz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_201503600.JSON
{
    public class CastJsonToObject
    {
        private PilaUsuario pila;
        private ColaUsuario cola;

        public CastJsonToObject() {
            pila = null;
            cola = null;
        }

        public void getModelo(String json)
        {
            ModeloDeserializador modelo = Newtonsoft.Json.JsonConvert.DeserializeObject<ModeloDeserializador>(json);
            try
            {
                this.pila = convertPila(modelo.archivo.pila);
            }
            catch (Exception ex) { }
            try
            {
                this.cola = convertCola(modelo.archivo.cola);
            }
            catch (Exception ex) { }
        }

        private PilaUsuario convertPila(Pila modeloPila)
        {
            PilaUsuario nuevaPila = new PilaUsuario();
            Matriz nuevaMatriz;
            foreach(MatrizModelo nueva in modeloPila.matrices.matriz)
            {
                nuevaMatriz = new Matriz(nueva.size_x, nueva.size_y);
                foreach (Valor valor in nueva.valores.valor)
                    nuevaMatriz.setValorMatriz(valor.pos_x, valor.pos_y, valor.dato);
                nuevaPila.push(nuevaMatriz);
            }
            return nuevaPila;
        }

        private ColaUsuario convertCola(Cola modeloCola)
        {
            ColaUsuario nuevaCola = new ColaUsuario();
            Matriz nuevaMatriz;
            foreach (MatrizModelo nueva in modeloCola.matrices.matriz)
            {
                nuevaMatriz = new Matriz(nueva.size_x, nueva.size_y);
                foreach (Valor valor in nueva.valores.valor)
                    nuevaMatriz.setValorMatriz(valor.pos_x, valor.pos_y, valor.dato);
                nuevaCola.queue(nuevaMatriz);
            }
            return nuevaCola;
        }

        public PilaUsuario getPila()
        {
            return this.pila;
        }

        public ColaUsuario getCola()
        {
            return this.cola;
        }
    }
}
