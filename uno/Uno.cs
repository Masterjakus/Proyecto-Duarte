using System;
using System.Collections.Generic;
using JuegosCartas;

namespace JuegoUno
{
    public class CartaUno : Carta
    {
        public string Color { get; set; }

        public CartaUno(string valor, string color) : base(valor, color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return $"{Valor} {Color}";
        }
    }

    public class BarajaUno : Baraja
    {
        public BarajaUno()
        {
            string[] colores = { "Rojo", "Verde", "Azul", "Amarillo" };
            string[] valores = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Salta", "Reversa", "+2" };

            foreach (var color in colores)
                foreach (var valor in valores)
                    cartas.Add(new CartaUno(valor, color));

            Barajar();
        }
    }

    public class JuegoUno
    {
        private List<Jugador> jugadores;
        private BarajaUno baraja;
        private CartaUno cartaActual;

        public JuegoUno(int cantidadJugadores)
        {
            jugadores = new List<Jugador>();
            baraja = new BarajaUno();

            for (int i = 1; i <= cantidadJugadores; i++)
                jugadores.Add(new Jugador($"Jugador {i}"));
        }

        public void Jugar()
        {
            Console.WriteLine("=== Comienza UNO ===\n");

            // Repartir 5 cartas a cada jugador
            foreach (var j in jugadores)
                for (int i = 0; i < 5; i++)
                    j.TomarCarta(baraja.Robar());

            cartaActual = (CartaUno)baraja.Robar();
            Console.WriteLine($"Carta inicial: {cartaActual}\n");

            int turno = 0;
            bool terminado = false;
            int direccion = 1;

            while (!terminado)
            {
                var jugador = jugadores[turno];
                Console.WriteLine($"\nTurno de {jugador.Nombre}");
                bool jugo = false;

                foreach (var c in jugador.Mano)
                {
                    var cu = c as CartaUno;
                    if (cu.Color == cartaActual.Color || cu.Valor == cartaActual.Valor)
                    {
                        Console.WriteLine($"{jugador.Nombre} juega {cu}");
                        cartaActual = cu;
                        jugador.Mano.Remove(cu);
                        jugo = true;
                        break;
                    }
                }

                if (!jugo)
                {
                    jugador.TomarCarta(baraja.Robar());
                    Console.WriteLine($"{jugador.Nombre} roba carta.");
                }

                if (jugador.Mano.Count == 0)
                {
                    Console.WriteLine($"\n{jugador.Nombre} gana la partida!");
                    terminado = true;
                    break;
                }

                // Efectos simples
                if (cartaActual.Valor == "Reversa") direccion *= -1;
                if (cartaActual.Valor == "Salta") turno = (turno + direccion + jugadores.Count) % jugadores.Count;

                turno = (turno + direccion + jugadores.Count) % jugadores.Count;
            }
        }
    }

    class Program
    {
        static void Main()
        {
            JuegoUno juego = new JuegoUno(4);
            juego.Jugar();
        }
    }
}
