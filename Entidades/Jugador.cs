using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

public class Jugador
    {
        public string Nombre { get; set; }
        public List<Carta> Mano { get; set; }
        public int Puntos { get; set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Mano = new List<Carta>();
            Puntos = 0;
        }

        public void RecibirCarta(Carta carta)
        {
            Mano.Add(carta);
        }

        public void LimpiarMano()
        {
            Mano.Clear();
        }

        public override string ToString()
        {
            return $"{Nombre} - Puntos: {Puntos}";
        }
    }

