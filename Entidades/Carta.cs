using System;
using Proyecto_Duarte.Interfaces;

namespace Proyecto_Duarte.Entidades;

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
