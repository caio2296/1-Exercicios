using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Mensalista : Trabalhador, ITrabalhador
    {

        //mensalista
        // quanto por mes recebe( entrada)(interfaceA)
        //qual sua jornada semanal (entrada)(interfaceA)
        //quanto recebe por hora (saida) 

   

        


        public Mensalista()
        {

            SetSalario();
        }

        public float SetSalario()
        {

            
            bool respostaValida = true;
            while (respostaValida)
            {
                SetConsole("Quanto por mes você recebe?");

                if (float.TryParse(Console.ReadLine().Replace(".", ","), out float mes))
                { 
                    SetConsole("quantas horas você trabalha por semana?");


                    if (float.TryParse(Console.ReadLine().Replace(".", ","), out float hsemana) && hsemana <= 44)
                    {
                        GanhoHora = (mes / 5) / hsemana;
                        SetConsole($"Você recebe por hora {Math.Round(GanhoHora, 2)}");
                        respostaValida = false;
                        
                    }
                    else {

                        SetConsole("Insira uma jornada semanal válida! (limite ate 44 horas semanais) ");
                        respostaValida = true;
                    }

                }
                else
                {
                    SetConsole("Insira um salario válido! ");
                    respostaValida = true;
                }

            }


            return GanhoHora;
        }








    }
}
