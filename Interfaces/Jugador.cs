using System;

namespace Proyecto_Duarte.Interfaces;

public class Jugador
{
    string nombre { get; }
    List<JCarta> mano { get; }
    void recibircarta(JCarta carta)
    {
        if (carta != null)
        {
            mano.Add(carta);
        }
    }
}
