using System;

namespace Proyecto_Duarte;

public class InicioDeJuego
{
    static void Main()
        {
            Console.WriteLine("Que queres jugar?");
            Console.WriteLine("1. UNO");
            Console.WriteLine("2. Blackjack");
            Console.Write("👉 Opción: ");
            if (!int.TryParse(Console.ReadLine(), out int opcion))
                return;

            JJuegoDeCartas juego = opcion switch
            {
                1 => new JuegoUNO.JuegoUNO(3),
                2 => new JuegoBlackjack.JuegoBlackjack(3),
                _ => throw new InvalidOperationException("Juego no válido")
            };

            juego.IniciarJuego();
            juego.JugarRonda();
            juego.MostrarGanador();
        }
    }
}
