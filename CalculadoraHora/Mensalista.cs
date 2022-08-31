using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Mensalista : Trabalhador, ICalcularGanho
    {

        //mensalista
        // quanto por mes recebe( entrada)(interfaceA)
        //qual sua jornada semanal (entrada)(interfaceA)
        //quanto recebe por hora (saida) 

   

        


        public Mensalista()
        {

            SetGanhoPorHora();
        }

        public float SetGanhoPorHora()
        {
            
            
             valorValido = true;
            while (valorValido)
            {
                SetConsole("Quanto por mes você recebe?");

                if (float.TryParse(Console.ReadLine().Replace(".", ","), out float mes))
                { 
                    SetConsole("quantas horas você trabalha por semana?");


                    if (float.TryParse(Console.ReadLine().Replace(".", ","), out float hsemana) && hsemana <= 44)
                    {
                        GanhoPorHora = (mes / 4) / hsemana;
                        SetConsole($"Você recebe por hora {Math.Round(GanhoPorHora, 2)}");
                        valorValido = false;
                        
                    }
                    else {

                        SetConsole("Insira uma jornada semanal válida! (limite ate 44 horas semanais) ");
                        valorValido = true;
                    }

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
