using System;
using System.IO;

namespace Snake
{
    class Tablero
    {
        //Personaje
        Snake serpiente = new Snake();

        //info de las casillas
        enum casillas { libre, fruta, muro}

         casillas [,] cas;
        public Tablero(string nivel)
        {
            StreamReader leeTablero = new StreamReader(nivel);

            //Variable tipo texto para leer las líneas
            string lectorNivel;

            //lectura inicial de la primera fila
            lectorNivel = leeTablero.ReadLine();

            //Inicializo otra variable de texto para almacenar las líneas
            string infoNivel = lectorNivel + ";";

            //Lee hasta el final del archivo y lo va almacenando en la variable de texto
            while (!leeTablero.EndOfStream)
            {
                lectorNivel = leeTablero.ReadLine().Trim();
                //separo cada fila con ; para facilitar luego separarlo en la matriz
                infoNivel += lectorNivel + ";";
            }
            //Cierro el lector de nivel
            leeTablero.Close();

            //Creo un array para separar en filas la info de la matriz
            string[] filasMatriz = infoNivel.Split(";");

            string[] valores = filasMatriz[0].Split(" ");

            cas = new casillas[filasMatriz.Length - 1, valores.Length];
            //Recorro el array con las filas para ir introduciendo los valores en la matriz
            for (int i = 0; i < cas.GetLength(0); i++)
            {
                //Variable para cada valor de la fila
                valores = filasMatriz[i].Split(" ");

                for (int j = 0; j < cas.GetLength(1); j++)
                {
                    if (valores[j] == "0")
                    {
                        cas[i, j] = casillas.libre;
                    }
                    else if (valores[j] == "1")
                    {
                        cas[i, j] = casillas.muro;
                    }
                    //Si lee una casilla de tipo jugador añade uno a la lista de la serpiente
                    else if (valores[j] == "2")
                    {
                        serpiente.AñadeElemento(new Coor(i,j), new Coor(1,0));
                    }
                        
                    
                }
            }

        }
        

        // Se crea el tablero en el que se va a poder mover la serpiente
        public void Dibuja()
        {
            Console.SetCursorPosition(0, 0);

            for (int i = 0; i < cas.GetLength(0); i++)
            {
                for (int j = 0; j < cas.GetLength(1); j++)
                {
                    if (cas[i, j] == casillas.muro)
                    {
                        
                        //dibujo de las esquinas del tablero
                        if (i == 0 && j == 0) Console.Write("┌─");
                        else if (i == 0 && j == cas.GetLength(1) - 1) Console.Write("─┐");
                        else if (j == 0 && i == cas.GetLength(0) - 1) Console.Write("└─");
                        else if (j == cas.GetLength(1) - 1 && i == cas.GetLength(0) - 1) Console.Write("─┘");
                        else if (i == 0 || i == cas.GetLength(0) - 1) Console.Write("──");
                        else if (j == 0 ) Console.Write("| ");
                        else if(j == cas.GetLength(1) - 1) Console.Write(" |");
                    }
                    else if (cas[i, j] == casillas.libre) Console.Write("  ");
                    else if (cas[i, j] == casillas.fruta)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("■■");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }

            //array de coordenadas para dibujar a la serpiente
            Coor[] coorSerp = serpiente.Coordenadas();

            //recorre todas las casillas en las que está la serpiente y las va dibujando
            for (int i = 0; i < coorSerp.Length; i++)
            {
                Console.SetCursorPosition(2*coorSerp[i].col, coorSerp[i].fil);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("██");
            }

            Console.ResetColor();
        }

        //Método que establece una dirección en función de la input de teclado
        public void EstableceDir(char t)
        { 

        }

    }
}
