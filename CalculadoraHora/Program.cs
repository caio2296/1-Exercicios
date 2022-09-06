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

            Trabalhador trabalhador = new Trabalhador();

            trabalhador.Nome =  ObterTrabalhador();

            RegistrarTrabalhador(trabalhador);

            EscolherCalculoGanho(trabalhador);

            Produto produto = new Produto();

            produto.NomeP = ObterProduto();

            RegistrarPerfilProduto(produto);


            LerConsole(Calculadora.ComprarBaseHora(trabalhador, produto));


            Console.ReadKey();


        }



        private static void RegistrarPerfilProduto(Produto produto)
        {
            while (produto.validoP)
            {
                Console.WriteLine("Valor do Produto:");

                if (float.TryParse(Console.ReadLine(), out float valor))
                {
                    produto.Valor = valor;


                    produto.validoP = false;

                    
                }
                else
                {

                    produto.validoP = true;

                   LerConsole("Insira o valor do produto valido!");
                }
            }

            

            
        }

        private static string ObterProduto()
        {
            Console.WriteLine("Nome do Produto:");


           return Console.ReadLine();
        }

        private static void EscolherCalculoGanho(Trabalhador trabalhador)
        {
            ICalcularGanho tipoGanho = trabalhador;

            if (trabalhador.EMensalista)
            {
                tipoGanho = new Mensalista();

            }
            else
            {
                tipoGanho = new Horista();
            }

            tipoGanho.SetGanhoPorHora();

           


            
        }


        private static string ObterTrabalhador()
        {

            Console.WriteLine("Insira o nome do Trabalhador:");

            return  Console.ReadLine();

            

        }


        private static void RegistrarTrabalhador(Trabalhador trabalhador)
        {
            

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
                        trabalhador.EMensalista = true;
                        respostaValida = false;
                    }
                    else if (numero == 2) //0 é horista
                    {
                        trabalhador.EMensalista = false;
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
