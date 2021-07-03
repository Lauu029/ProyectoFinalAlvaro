using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Tablero tab = new Tablero("Nivel1.txt");
            tab.Dibuja();
            Console.SetCursorPosition(0, 100);
        }
    }
}
