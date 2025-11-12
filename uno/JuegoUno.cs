using System;
using Proyecto_Duarte.Entidades;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.uno;

public class JuegoUno
{
    public class CartaUNO : Carta
    {
        public string Color { get; }
        public CartaUNO(string valor, string color) : base(valor, color) => Color = color;
        public override string ToString() => $"{valor} ({Color})";
    }

    public class MazoUNO : Mazo
    {
        public MazoUNO()
        {
            string[] colores = { "Rojo", "Verde", "Azul", "Amarillo" };
            string[] valores = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Salta", "Reversa", "Roba2" };

            foreach (var color in colores)
                foreach (var valor in valores)
                    cartas.Add(new CartaUNO(valor, color));

            barajar();
        }
    }

    public class JuegoUNO : JuegoDeCartasBase
    {
        private CartaUNO cartaEnMesa;

        public JuegoUNO(int jugadores)
        {
            Mazo = new MazoUNO();
            for (int i = 1; i <= jugadores; i++)
                Jugadores.Add(new Jugador($"Jugador {i}"));
        }

        public override void IniciarJuego()
        {
            Console.WriteLine("🎮 Iniciando UNO...");
            foreach (var j in Jugadores)
                for (int i = 0; i < 7; i++) j.RecibirCarta(Mazo.Robar());

            cartaEnMesa = (CartaUNO)Mazo.Robar();
            Console.WriteLine($"Carta inicial: {cartaEnMesa}");
        }

        public override void JugarRonda()
        {
            foreach (var j in Jugadores)
            {
                var jugable = j.Mano.FirstOrDefault(c =>
                    c is CartaUNO cu && (cu.Color == cartaEnMesa.Color || cu.Valor == cartaEnMesa.Valor));

                if (jugable != null)
                {
                    j.Mano.Remove(jugable);
                    cartaEnMesa = (CartaUNO)jugable;
                    Console.WriteLine($"{j.Nombre} juega {jugable}");
                }
                else
                {
                    var nueva = Mazo.Robar();
                    j.RecibirCarta(nueva);
                    Console.WriteLine($"{j.Nombre} roba una carta.");
                }

                if (j.Mano.Count == 0)
                {
                    Console.WriteLine($"{j.Nombre} gana el juego!");
                    Environment.Exit(0);
                }
            }
        }

        public override void MostrarGanador()
        {
            var ganador = Jugadores.OrderBy(j => j.Mano.Count).First();
            Console.WriteLine($"Ganador provisional: {ganador.Nombre}");
        }
    }
}
