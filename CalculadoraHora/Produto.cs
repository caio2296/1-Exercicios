using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Produto
    {
        public static string NomeP;
        public static float Valor;

        private static bool validoP = true;

        

        public static double CalcularHoras(float horasTrabalhador)
        {
            Valor = Valor / horasTrabalhador;
            return Math.Round(Valor,2);
        }

        public static string ComprarBaseHora(Trabalhador pessoa)
        {



            while (validoP)
            {

                Console.WriteLine("Valor do Produto:");

                if (float.TryParse(Console.ReadLine(), out float valor))
                {
                    Produto.Valor = valor;

                  
                    validoP = false;

                    return CalcularGanhoTValorP(pessoa);
                }
                else
                {
                   
                    validoP = true;

                    return "Insira o valor do produto valido!";
                }
            }
            return null;
        }

        private static string CalcularGanhoTValorP(Trabalhador pessoa)
        {
            return
                $"As horas nescessarias para comprar {Produto.NomeP}" +
                $" e de: {Produto.CalcularHoras(pessoa.GanhoPorHora)} ";
        }
    }
}
