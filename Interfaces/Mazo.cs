using System;

namespace Proyecto_Duarte.Interfaces;

public interface JMazo
{
    void barajar();
    JCarta robar();
    int cartasrestantes{ get; }
}
