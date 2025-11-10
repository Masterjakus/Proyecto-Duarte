using System;
using System.Collections.Generic;
using JuegosCartas;

namespace JuegoBlackjack
{
    public class BarajaBlackjack : Baraja
    {
        public BarajaBlackjack()
        {
            string[] palos = { "Corazones", "Picas", "Diamantes", "Tréboles" };
            string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

            foreach (var palo in palos)
                foreach (var valor in valores)
                    cartas.Add(new Carta(valor, palo));

            Barajar();
        }

        public static int ValorCarta(Carta c)
        {
            if (int.TryParse(c.Valor, out int n)) return n;
            if (c.Valor == "A") return 11;
            return 10;
        }
    }

    public class JuegoBlackjack
    {
        private List<Jugador> jugadores;
        private BarajaBlackjack baraja;

        public JuegoBlackjack(int cantidadJugadores)
        {
            jugadores = new List<Jugador>();
            baraja = new BarajaBlackjack();

            for (int i = 1; i <= cantidadJugadores; i++)
                jugadores.Add(new Jugador($"Jugador {i}"));
        }

        public void Jugar()
        {
            Console.WriteLine("=== Comienza Blackjack ===\n");
            // repartir 2 cartas a cada jugador
            foreach (var j in jugadores)
            {
                j.TomarCarta(baraja.Robar());
                j.TomarCarta(baraja.Robar());
            }

            foreach (var j in jugadores)
            {
                j.MostrarMano();
                int valor = CalcularValor(j);
                Console.WriteLine($"Valor total: {valor}\n");
            }

            // determinar ganador
            Jugador ganador = null;
            int mejorPuntaje = 0;

            foreach (var j in jugadores)
            {
                int valor = CalcularValor(j);
                if (valor > mejorPuntaje && valor <= 21)
                {
                    mejorPuntaje = valor;
                    ganador = j;
                }
            }

            if (ganador != null)
                Console.WriteLine($"Ganador: {ganador.Nombre} con {mejorPuntaje} puntos!");
            else
                Console.WriteLine("Nadie ganó, todos se pasaron de 21!");
        }

        private int CalcularValor(Jugador j)
        {
            int total = 0;
            int ases = 0;
            foreach (var c in j.Mano)
            {
                int val = BarajaBlackjack.ValorCarta(c);
                total += val;
                if (c.Valor == "A") ases++;
            }
            while (total > 21 && ases > 0)
            {
                total -= 10; // A cuenta como 1
                ases--;
            }
            return total;
        }
    }

    class Program
    {
        static void Main()
        {
            JuegoBlackjack juego = new JuegoBlackjack(3);
            juego.Jugar();
        }
    }
}

