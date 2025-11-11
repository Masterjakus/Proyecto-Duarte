using System;

namespace Proyecto_Duarte.blackjack;

public class JuegoBlackJack
{
     public class MazoBlackjack : Mazo
    {
        public MazoBlackjack()
        {
            string[] palos = { "Corazones", "Picas", "Tréboles", "Diamantes" };
            string[] valores = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            foreach (var palo in palos)
                foreach (var valor in valores)
                    cartas.Add(new Carta(valor, palo));

            Barajar();
        }
    }

    public class JuegoBlackjack : JuegoDeCartasBase
    {
        public JuegoBlackjack(int jugadores)
        {
            Mazo = new MazoBlackjack();
            for (int i = 1; i <= jugadores; i++)
                Jugadores.Add(new Jugador($"Jugador {i}"));
        }

        public override void IniciarJuego()
        {
            Console.WriteLine("♠️ Iniciando Blackjack...");
            foreach (var j in Jugadores)
            {
                j.RecibirCarta(Mazo.Robar());
                j.RecibirCarta(Mazo.Robar());
            }
        }

        private int ValorCarta(ICarta c)
        {
            if (int.TryParse(c.Valor, out int n)) return n;
            if (c.Valor == "A") return 11;
            return 10;
        }

        private int CalcularPuntaje(IJugador j)
        {
            int total = j.Mano.Sum(ValorCarta);
            int ases = j.Mano.Count(c => c.Valor == "A");
            while (total > 21 && ases-- > 0) total -= 10;
            return total;
        }

        public override void JugarRonda()
        {
            foreach (var j in Jugadores)
            {
                int puntaje = CalcularPuntaje(j);
                Console.WriteLine($"{j.Nombre}: {string.Join(", ", j.Mano)} (Total: {puntaje})");

                while (puntaje < 17)
                {
                    var carta = Mazo.Robar();
                    j.RecibirCarta(carta);
                    puntaje = CalcularPuntaje(j);
                    Console.WriteLine($"{j.Nombre} roba {carta} (Total: {puntaje})");
                }

                if (puntaje > 21)
                    Console.WriteLine($"{j.Nombre} se pasa de 21!");
            }
        }

        public override void MostrarGanador()
        {
            var mejor = Jugadores
                .Select(j => new { j.Nombre, P = CalcularPuntaje(j) })
                .Where(x => x.P <= 21)
                .OrderByDescending(x => x.P)
                .FirstOrDefault();

            Console.WriteLine(mejor != null
                ? $"El ganador es {mejor.Nombre} con {mejor.P} puntos!"
                : "Nadie ganó esta vez.");
        }
    }
}
