using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Horista : Trabalhador, ITrabalhador
    {

        //horista


        // quanto recebe por hora (entrada)

        




        public Horista()
        {
            SetSalario();
        }

        public float SetSalario()
        {
            bool respostaValida = true;
            while (respostaValida)
            {
                SetConsole("Quanto por hora você recebe?");


                if (float.TryParse(Console.ReadLine().Replace(".", ","), out float hora))
                {
                    GanhoHora = hora;

                    SetConsole($"Você recebe por hora {Math.Round(hora, 2)}");
                    respostaValida = false;

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
