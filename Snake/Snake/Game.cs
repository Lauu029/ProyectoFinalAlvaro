using System;
namespace Snake
{
    class Game
    {
        public Tablero tab = new Tablero("Nivel1.txt");
        public void Resettablero()
        {
            Console.ResetColor();
           
        }
    }
}
