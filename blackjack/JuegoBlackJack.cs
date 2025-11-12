using System;
using Proyecto_Duarte.Entidades;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.blackjack;

public class JuegoBlackJack : JuegoBase
    {
        public JuegoBlackJack(int cantidadJugadores) : base(cantidadJugadores)
        {
        }

        public override void JugarRonda()
        {
            Console.WriteLine("¡Comienza una ronda de BlackJack!");

            foreach (var jugador in jugadores)
            {
                jugador.LimpiarMano();
                jugador.RecibirCarta(mazo.RepartirCarta());
                jugador.RecibirCarta(mazo.RepartirCarta());

                int puntos = CalcularPuntaje(jugador);
                jugador.Puntos += puntos;

                Console.WriteLine($"{jugador.Nombre} tiene {puntos} puntos esta ronda.");
            }
        }

        private int CalcularPuntaje(Jugador jugador)
        {
            int total = 0;

            Random random = new Random();
            foreach (var _ in jugador.Mano)
            {
                total += random.Next(1, 12);
            }

            return total;
        }

        public override void MostrarGanador()
        {
            var ganador = Jugadores
            Console.WriteLine($"El ganador del BlackJack es: {ganador.Nombre} con {ganador.Puntos} puntos!");
        }
    }

