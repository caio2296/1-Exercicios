using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Trabalhador: ICalcularGanho
    {
        public static string Nome { set; protected get; }
        public static bool EMensalista { set;  get; }

        public static float GanhoPorHora { protected set;  get; }

        protected bool valorValido;

     public static string Mensagem;

        // perfil do trabalhador  mensalista ou horista (entrada)
        //trabalhador nome
        //tipo de contratação



        protected static string  GetNome()
        {
            string nome;

            nome = Nome;

            return nome;
        }
            
        

        protected static void SetConsole(string mensagem)
        {
            Mensagem = mensagem;
            Program.LerConsole(Mensagem);
            
        }

        public float SetGanhoPorHora()
        {
            throw new NotImplementedException();
        }
    }
}


    

