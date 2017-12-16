using System;

namespace Practica1_201503600.Estructuras.Usuario
{
	public class ListaUsuario
	{
		private NodoUsuario head, bottom;
		private int size;

		public ListaUsuario ()
		{
			this.head = null;
			this.bottom = null;
			this.size = 0;
		}

		public void addUser(String username, String password){
			NodoUsuario nodo = new NodoUsuario (username, password);
			if (head == null) {
                nodo.setSiguiente(nodo);
                nodo.setAnterior(nodo);
				head = nodo;
				bottom = nodo;
			}
			else {
				nodo.setAnterior (bottom);
				nodo.setSiguiente(head);
				bottom.setSiguiente(nodo);
                head.setAnterior(nodo);
				bottom = nodo;
			}
			size++;
		}

        public NodoUsuario findUser(String username, String password)
        {
            NodoUsuario auxiliar = head;
            for (int pos = 0; pos < size; pos++)
                if (auxiliar.getUsername().Equals(username) && auxiliar.getPassword().Equals(password))
                    return auxiliar;
                else
                    auxiliar = auxiliar.getSiguiente();
            return null;
        }

        public void updateUser(NodoUsuario user)
        {
            if (size == 1)
            {
                head = user;
                bottom = user;
            }
            else
            {
                NodoUsuario auxiliar = head;
                for (int pos = 0; pos < size; pos++)
                    if (auxiliar.getUsername().Equals(user.getUsername()) &&
                        auxiliar.getPassword().Equals(user.getPassword()))
                    {
                        auxiliar.getAnterior().setSiguiente(user);
                        user.setAnterior(auxiliar.getAnterior());
                        auxiliar.getSiguiente().setAnterior(user);
                        user.setSiguiente(auxiliar.getSiguiente());
                        break;
                    }
                    else
                        auxiliar = auxiliar.getSiguiente();
            }
            
        }

        public bool deleteUser(String username, String password)
        {
            NodoUsuario aux = head;
            if (size == 1){
                head = null;
                bottom = null;
                size = 0;
            }else
                for (int pos = 0; pos < size; pos++)
                    if (aux.getUsername().Equals(username) && aux.getPassword().Equals(password))
                    {
                        aux.getAnterior().setSiguiente(aux.getSiguiente());
                        aux.getSiguiente().setAnterior(aux.getAnterior());
                        size--;
                        break;
                    }
                    else
                        aux = aux.getSiguiente();
            return false;
        }

        public bool isEmpty()
        {
            if (size == 0)
                return true;
            else
                return false;
        }

        public NodoUsuario get(int index)
        {
            NodoUsuario aux = head;
            if (index < size)
            {
                int contador = 0;
                while (contador++ < index)
                    aux = aux.getSiguiente();
            }
            else
                throw new Exception("Excepción: Indice fuera de rango");
            return aux;
        }

        public int getSize()
        {
            return this.size;
        }

        public String generarImagen()
        {
            String dot = "digraph g {\nrankdir=LR;\nnode [shape = record, height = 0.1];\n";

            NodoUsuario auxiliar = head;
            for (int pos = 0; pos < size; pos++)
            {
                dot += "nodo" + pos + "[label = \"<f0> |<f1> " + auxiliar.getUsername() + 
                        " |<f2> \"];\n";
                auxiliar = auxiliar.getSiguiente();
            }

            if (size == 1)
                dot += "nodo0:f0 -> nodo0:f2;\nnodo0:f2 -> nodo0:f0;\nPrimero -> nodo0:f1;\n"
                        + "Último -> nodo0:f1;\n";
            else
                for (int i = 0; i < size; i++)
                    if (i == 0)
                        dot += "nodo" + i + ":f0 -> nodo" + (size - 1) + ":f2;\n" +
                                "nodo" + i + ":f2 -> nodo" + (i + 1) + ":f0;\n";
                    else if (i == size - 1)
                        dot += "nodo" + i + ":f0 -> nodo" + (i - 1) + ":f2;\n" +
                                "nodo" + i + ":f2 -> nodo0:f0;\n" +
                                "Primero -> nodo0:f1;\nÚltimo -> nodo" + i + ":f1;\n";
                    else
                        dot += "nodo" + i + ":f0 -> nodo" + (i - 1) + ":f2;\n" +
                                "nodo" + i + ":f2 -> nodo" + (i + 1) + ":f0;\n";
            dot += "label = \"Lista de Usuarios Doblemente Enlazada\"\n}";
            return dot;
        }
	}
}

