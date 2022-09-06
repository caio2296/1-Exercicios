using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Calculadora
    {


        public static double CalcularHoras(float horasTrabalhador, Produto produto)
        {
            

            produto.Valor = produto.Valor / horasTrabalhador;
            return Math.Round(produto.Valor, 2);
        }

        public static string ComprarBaseHora(ICalcularGanho trabalhador, Produto produto)
        {


            return
                $"As horas nescessarias para comprar {produto.NomeP}" +
                $" e de: {CalcularHoras(Trabalhador.GanhoPorHora,produto)} ";
        }







    }
}
