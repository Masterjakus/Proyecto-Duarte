using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

public class Mazo
    {
        private List<Carta> cartas;
        private static readonly string[] Palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
        private static readonly string[] Valores = 
        { 
            "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" 
        };

        public Mazo()
        {
            cartas = new List<Carta>();
            InicializarMazo();
            Barajar();
        }

        private void InicializarMazo()
        {
            cartas.Clear();
            foreach (string palo in Palos)
            {
                foreach (string valor in Valores)
                {
                    cartas.Add(new Carta(valor, palo));
                }
            }
        }

        public void Barajar()
        {
            Random random = new Random();
            for (int i = cartas.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Carta temp = cartas[i];
                cartas[i] = cartas[j];
                cartas[j] = temp;
            }
        }

        public Carta RepartirCarta()
        {
            if (cartas.Count == 0)
            {
                InicializarMazo();
                Barajar();
            }

            Carta carta = cartas[0];
            cartas.RemoveAt(0);
            return carta;
        }
    }

