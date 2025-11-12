using System;
using Proyecto_Duarte.Entidades;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.uno;

public class JuegoUno
{
    public class JuegoUno : JuegoBase
    {
        public override void JugarRonda()
        {
            Console.WriteLine("¡Comienza una ronda de UNO!");

            foreach (var jugador in jugadores)
            {
                jugador.LimpiarMano();
                jugador.RecibirCarta(mazo.RepartirCarta());
                jugador.RecibirCarta(mazo.RepartirCarta());

                int puntos = CalcularPuntos(jugador);
                jugador.Puntos += puntos;

                Console.WriteLine($"{jugador.Nombre} tiene {puntos} puntos esta ronda.");
            }
        }

        private int CalcularPuntos(Jugador jugador)
        {
            Random random = new Random();
            return random.Next(1, 11);
        }

        public override void MostrarGanador()
        {
            var ganador = jugadores.OrderByDescending(j => j.Puntos).First();
            Console.WriteLine($"El ganador del UNO es: {ganador.Nombre} con {ganador.Puntos} puntos!");
        }
    }
}
