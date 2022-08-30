using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Produto
    {
        public static string NomeP;
        public static float Valor;

        public static double CalcularHoras(float horasTrabalhador)
        {
            Valor = Valor / horasTrabalhador;
            return Math.Round(Valor,2);
        }



    }
}
