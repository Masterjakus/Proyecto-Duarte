using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

public class Mazo : JMazo
{
    protected List<JCarta> cartas = new();
    private readonly Random random = new();

    public virtual void barajar() => cartas = cartas.OrderBy(c => random.Next()).ToList();

    public virtual JCarta robar()
    {
        if (cartas.Count == 0)
        {
            return null;
        }
        var carta = cartas[0];
        cartas.RemoveAt(0);
        return carta;
    }

    public int cartasrestantes => cartas.Count;
}
