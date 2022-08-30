using System;
using System.Collections.Generic;
using System.Text;

namespace CalculadoraHora
{
    class Trabalhador
    {
        public static string Nome { set; protected get; }
        public static bool EMensalista { set;  get; }

        public  float GanhoHora { protected set;  get; }

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
            Program.LeituraConsole(Mensagem);
            
        }

    }
}


    

