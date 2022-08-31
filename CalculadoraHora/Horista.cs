using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Horista : Trabalhador, ICalcularGanho
    {

        //horista


        // quanto recebe por hora (entrada)

        




        public Horista()
        {
            SetGanhoPorHora();
        }

        public float SetGanhoPorHora()
        {
             valorValido = true;
            while (valorValido)
            {
                SetConsole("Quanto por hora você recebe?");


                if (float.TryParse(Console.ReadLine().Replace(".", ","), out float hora))
                {
                    GanhoPorHora = hora;

                    SetConsole($"Você recebe por hora {Math.Round(hora, 2)}");
                    valorValido = false;

                }
                else
                {
                    SetConsole("Insira um salario válido! ");
                    valorValido = true;
                }

            }


            return GanhoPorHora;
        }
    }
}
