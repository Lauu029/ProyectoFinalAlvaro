using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Snake
    {
        private class Nodo
        {
            public Coor pos = new Coor(); //Posision del cuerpo
            public Coor dir = new Coor(); //Direccion del cuerpo
            public Nodo sig; //Referencia al siguiente

        }
        Nodo lst; //Referencia al primer nodo de la lista
        public Snake()
        { //Constructora de la clase
            lst = null;
        }
        //Método para crear la serpiente y añadirle nodos
        public void AñadeElemento(Coor pos, Coor dir)
        {
            //Si no había lista crea un nuevo nodo y establece dirección y posición
            if (lst == null)
            {
                lst = new Nodo();
                lst.dir = dir;
                lst.pos = pos;
                lst.sig = null;
            }

            //si ya existe lista
            else
            {
                //nodo auxiliar
                Nodo aux = lst;
                //bucle para recorrer la lista hasta el finnal
                while (aux.sig != null) aux = aux.sig;
                //aux es el último nodo 
                //crea un nuevo nodo en la siguiente posición
                aux.sig = new Nodo();
                //me posiciono en el nuevo nodo para introducir dirección y posición y poner el siguiente nodo como vacío
                aux = aux.sig;
                aux.dir = dir;
                aux.pos = pos;
                aux.sig = null;
            }
        }
        public Coor[] Coordenadas()
        {
            Nodo aux = lst;

            //Inicializo la longitud a 0
            int longitud = 0;

            //mientras el nodo siguiente exista suma uno a la longitud
            while (aux != null)
            {
                aux = aux.sig;
                longitud++;
            }
            //reseteo aux
            aux = lst;

            //Array que almacena las coordenadas de los nodos de la lista
            Coor[] coordenadasArray = new Coor[longitud];
            int i = 0;//variable contador para el while

            //voy sacando las coordenadas de la lista
            while (i < coordenadasArray.Length && aux != null)
            {
                coordenadasArray[i] = aux.pos;
                i++;
                aux = aux.sig;
            }
            return coordenadasArray;
        }

        public void CambiaDir() { }
    }
}
