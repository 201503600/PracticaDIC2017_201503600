using System;

namespace Practica1_201503600.Estructuras.Usuario
{
	public class NodoUsuario
	{

		private String username;
		private String password;
        private PilaUsuario pila;
        private ColaUsuario cola;
		private NodoUsuario siguiente;
		private NodoUsuario anterior;

		public NodoUsuario (String username, String password)
		{
			this.username = username;
			this.password = password;
            this.pila = new PilaUsuario();
            this.cola = new ColaUsuario();
			this.siguiente = null;
			this.anterior = null;
		}

		public String getUsername(){
			return this.username;
		}

		public String getPassword(){
			return this.password;
		}

		public void setSiguiente(NodoUsuario siguiente){
			this.siguiente = siguiente;
		}

		public void setAnterior(NodoUsuario anterior){
			this.anterior = anterior;
		}

		public NodoUsuario getSiguiente(){
			return this.siguiente;
		}

		public NodoUsuario getAnterior(){
			return this.anterior;
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

