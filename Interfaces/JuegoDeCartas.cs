using System;

namespace Proyecto_Duarte.Interfaces;

public interface JuegoDeCartas
{
    List<Jugador> jugadores { get; }
    JMazo mazo { get; }
    void iniciarjuego();
    void jugarronda();
    void mostrarganador();
}
