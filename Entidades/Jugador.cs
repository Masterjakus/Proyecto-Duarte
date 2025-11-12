using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

public class Jugador : Jjugador
{
    public string nombre { get; }
    public List<JCarta> mano { get; } = new();
    public Jugador(string nombre) => nombre = nombre;

    public void recibircarta(JCarta carta)
    {
        if (carta != null)
        {
            mano.Add(carta);
        }
    }

    public override string ToString() => $"{nombre} ({mano.Count} cartas)";
}
