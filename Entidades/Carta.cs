using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

public class Carta : JCarta
{
    public string valor { get; }
    public string palo { get; }
    public Carta(string valor, string palo)
    {
        valor = valor;
        palo = palo;
    }

    public override string ToString() => $"{valor} de {palo}";
}
