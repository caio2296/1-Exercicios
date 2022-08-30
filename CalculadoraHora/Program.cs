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
            Inicializando();

            Trabalhador pessoa = new Trabalhador();

            if (Trabalhador.EMensalista)
            {
                 pessoa = new Mensalista();

                

                
            }
            else
            {
                 pessoa = new Horista();
            }


            Console.WriteLine($"Quanto por hora a pessoa ganha: {pessoa.GanhoHora}");

            Console.WriteLine("Nome do Produto:");

            Produto.NomeP = Console.ReadLine();
            bool validoP = true;

            while (validoP)
            {

                Console.WriteLine("Valor do Produto:");

                if (float.TryParse(Console.ReadLine(), out float valor))
                {
                    Produto.Valor = valor;



                    Console.WriteLine(
                        $"As horas nescessarias para comprar {Produto.NomeP}" +
                        $" e de: {Produto.CalcularHoras(pessoa.GanhoHora)} ");
                    validoP = false;
                }
                else
                {
                    Console.WriteLine("Insira o valor do produto valido!");
                    validoP = true;
                }
            }

            
            

            Console.ReadKey();


        }

        private static void Inicializando()
        {
            Console.WriteLine("Insira o nome do Trabalhador:");

            Trabalhador.Nome = Console.ReadLine();


            string resposta;
            bool ModuloValido = true;

            while (ModuloValido)
            {
                Console.WriteLine("O Trabalhador e mensalista? ");
                Console.WriteLine("Insira a opção: ");

                Console.WriteLine("1. Mensalista ");

                Console.WriteLine("2. Horista ");
                resposta = Console.ReadLine();

                if (resposta != null && int.TryParse(resposta, out int numero))
                {
                    if (numero < 2 && numero > 0) //1 é mensalista
                    {
                        Trabalhador.EMensalista = true;
                        ModuloValido = false;
                    }
                    else if (numero == 2) //0 é horista
                    {
                        Trabalhador.EMensalista = false;
                        ModuloValido = false;
                    }
                    else
                    {
                        Console.WriteLine("Insira a opção correta! ");

                        ModuloValido = true;
                    }
                }
                else
                {
                    Console.WriteLine("Insira a opção correta! ");
                    ModuloValido = true;
                }
            }
        }

        public static void LeituraConsole(string mensagem)
        {

            Console.WriteLine(mensagem);
        }


    }
}
