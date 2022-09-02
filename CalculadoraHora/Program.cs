using CalculadoraHora.Interface;
using System;

namespace CalculadoraHora
{
    class Program
    {

        //        Criar um programa que calcula quantas horas de trabalho custa o que quero comprar

          

            
            


        //nome e valor do produto (entrada)

        // calcular quantas horas para pagar aquele produto (saida)


        static void Main(string[] args)
        {
            RegistrarPerfilTrabalhador();

            ICalcularGanho pessoa = EscolherCalculoGanho();

            LerConsole(RegistrarPerfilProduto(pessoa));


            Console.ReadKey();


        }

        public static void CalcularGanhoTValorP()
        {
            Console.WriteLine(
                $"As horas nescessarias para comprar {Produto.NomeP}" +
                $" e de: {Produto.CalcularHoras(Trabalhador.GanhoPorHora)} ");
        }

        private static string RegistrarPerfilProduto(ICalcularGanho pessoa)
        {
            Console.WriteLine("Nome do Produto:");

            Produto.NomeP = Console.ReadLine();

            return Produto.ComprarBaseHora(pessoa);
        }

        private static ICalcularGanho EscolherCalculoGanho()
        {
            ICalcularGanho pessoa = new Trabalhador();

            if (Trabalhador.EMensalista)
            {
                pessoa = new Mensalista();

            }
            else
            {
                pessoa = new Horista();
            }

            pessoa.SetGanhoPorHora();

           


            return pessoa;
        }


        private static void RegistrarPerfilTrabalhador()
        {
            Console.WriteLine("Insira o nome do Trabalhador:");

            Trabalhador.Nome = Console.ReadLine();


            string respostaDoUsuario;
            bool respostaValida = true;

            while (respostaValida)
            {
                Console.WriteLine("O Trabalhador e mensalista? ");
                Console.WriteLine("Insira a opção: ");

                Console.WriteLine("1. Mensalista ");

                Console.WriteLine("2. Horista ");
                respostaDoUsuario = Console.ReadLine();

                if (respostaDoUsuario != null && int.TryParse(respostaDoUsuario, out int numero))
                {
                    if (numero < 2 && numero > 0) //1 é mensalista
                    {
                        Trabalhador.EMensalista = true;
                        respostaValida = false;
                    }
                    else if (numero == 2) //0 é horista
                    {
                        Trabalhador.EMensalista = false;
                        respostaValida = false;
                    }
                    else
                    {
                        Console.WriteLine("Insira a opção correta! ");

                        respostaValida = true;
                    }
                }
                else
                {
                    Console.WriteLine("Insira a opção correta! ");
                    respostaValida = true;
                }
            }
        }

        public static void LerConsole(string mensagem)
        {

            Console.WriteLine(mensagem);
        }


    }
}
