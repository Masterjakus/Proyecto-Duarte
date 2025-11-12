using System;
using Proyecto_Duarte.Entidades;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.juegoDeCartasBase;

public class JuegoBase
{
    public abstract class JuegoBase : JJuegoDeCartas
    {
        protected List<Jugador> jugadores;
        protected Mazo mazo;

        public JuegoBase(int cantidadJugadores)
        {
            jugadores = new List<Jugador>();
            mazo = new Mazo();
            InicializarJugadores(cantidadJugadores);
        }

        protected void InicializarJugadores(int cantidad)
        {
            for (int i = 1; i <= cantidad; i++)
            {
                jugadores.Add(new Jugador($"Jugador {i}"));
            }
        }

        public abstract void JugarRonda();
        public abstract void MostrarGanador();
    }
}
