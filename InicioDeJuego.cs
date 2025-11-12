using System;
using System.Buffers;

namespace Proyecto_Duarte;

public class InicioDeJuego
{
    static void Main()
    {
        Console.WriteLine("Una apuestita?, en que quieres perder tu dinero?");
        Console.WriteLine("1. UNO");
        Console.WriteLine("2. BlackJack");
        Console.WriteLine("Seleccciona uno (1 0 2):");

        string opcion = Console.ReadLine();

        JJuegoDeCartas juego = null;

        if (opcion == "1")
        {
            juego = new Juego_Uno.juegoUno(3);
        }
        else if (opcion == "2")
        {
            juego = new Juego_BlackJack.JuegoBlackJack(3);
        }
        else
        {
            Console.WriteLine("eso no es valido pana, miedo?");
            return;
        }

        Console.Clear();
        Console.WriteLine("Bueno. que comience el juego!");

        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"ronda {i}");
            juego.JugarRonda();
            Console.WriteLine(new string('-', 40));
        }

        Console.WriteLine("Bueno, el resultado es....");
        juego.mostrarganador();
    }
}
