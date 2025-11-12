using System;
using System.Buffers;

namespace Proyecto_Duarte;

public class InicioDeJuego
{
   public class InicioDeJuego
    {
        public static void Main()
        {
            Console.WriteLine("Una apuestita? ¿En qué quieres perder tu dinero?");
            Console.WriteLine("1. UNO");
            Console.WriteLine("2. BlackJack");
            Console.Write("Selecciona uno (1 o 2): ");

            string opcion = Console.ReadLine();
            JJuegoDeCartas juego = null;

            if (opcion == "1")
            {
                juego = new juego_uno.JuegoUno(3);
            }
            else if (opcion == "2")
            {
                juego = new Juego_BlackJack.JuegoBlackJack(3);
            }
            else
            {
                Console.WriteLine("Eso no es válido pana, ¿miedo?");
                return;
            }

            Console.Clear();
            Console.WriteLine("Bueno... ¡que comience el juego!");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Ronda {i}");
                juego.JugarRonda();
                Console.WriteLine(new string('-', 40));
            }

            Console.WriteLine("Bueno, el resultado es...");
            juego.MostrarGanador();

            Console.WriteLine("Fin del juego");
        }
    }
}
