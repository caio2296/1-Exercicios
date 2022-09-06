using CalculadoraHora.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Trabalhador: ICalcularGanho
    {
        public  string Nome { set; protected get; }
        public  bool EMensalista { set;  get; }

        public static float GanhoPorHora { protected set;  get; }

        protected bool valorValido;

     public static string Mensagem;

        // perfil do trabalhador  mensalista ou horista (entrada)
        //trabalhador nome
        //tipo de contratação



        protected static string  GetNome()
        {
            string nome;

            Trabalhador trabalhador = new Trabalhador();

            nome = trabalhador.Nome;

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


    

