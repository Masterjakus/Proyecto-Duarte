using System;
using System.Collections.Generic;

namespace JuegosCartas
{
    // Clase Carta base
    public class Carta
    {
        public string Valor { get; set; }
        public string Palo { get; set; }

        public Carta(string valor, string palo)
        {
            Valor = valor;
            Palo = palo;
        }

        public override string ToString()
        {
            return $"{Valor} de {Palo}";
        }
    }

    // Clase Baraja genérica
    public class Baraja
    {
        protected List<Carta> cartas;
        protected Random random = new Random();

        public Baraja()
        {
            cartas = new List<Carta>();
        }

        public void Barajar()
        {
            for (int i = 0; i < cartas.Count; i++)
            {
                int j = random.Next(cartas.Count);
                var temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public Carta Robar()
        {
            if (cartas.Count == 0) return null;
            Carta c = cartas[0];
            cartas.RemoveAt(0);
            return c;
        }
    }

    // Clase Jugador base
    public class Jugador
    {
        public string Nombre { get; set; }
        public List<Carta> Mano { get; private set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Mano = new List<Carta>();
        }

        public void TomarCarta(Carta c)
        {
            if (c != null) Mano.Add(c);
        }

        public void MostrarMano()
        {
            Console.WriteLine($"{Nombre} tiene:");
            foreach (var c in Mano)
                Console.WriteLine($" - {c}");
        }

        public void LimpiarMano() => Mano.Clear();
    }
}
