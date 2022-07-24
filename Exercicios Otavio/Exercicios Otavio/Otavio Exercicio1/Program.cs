using System;
using Exercicios_Otavio.Otavio_Exercicio1;

namespace Exercicios_Otavio
{
    class Program
    {

        

        static void Main(string[] args)
        {

            //Console.WriteLine("Hello World!");
            ////1)
            //Media();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////2)
            //Ano();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////3)
            //Emprestimo();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////4)
            //Reajustar();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////5)
            //Par();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////6)
            //Quadrado();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////7)
            //Numerar();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////8)
            //Maior();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            ////9)
            //Inverter();

            //Console.WriteLine("#PRÓXIMO EXERCICIO.");
            //10)
            //Maior2();

            Console.WriteLine("#PRÓXIMO EXERCICIO.");

            //11)
            ListaRandom listaNumeros = new ListaRandom();

            int [] numeros =listaNumeros.GetNumeros();

            Console.WriteLine("Lista de números inteiros aleatórios!");

            for (int index = 0; index < numeros.Length; index++)
            {
                Console.WriteLine($"Número da lista {index + 1} recebeu : {numeros[index]}");
            }



            //imprimir em crescente e decrescente.

            //crescente
            Array.Sort(numeros);
            Console.WriteLine("Lista em Ordem crescente:");
            for (int index = 0; index < numeros.Length; index++)
            {
                Console.WriteLine($"Número {index + 1}: {numeros[index]}");
            }

            //decrescente

            Array.Reverse(numeros);

            Console.WriteLine("Lista em ordem decrescente: ");

            for (int index = 0; index < numeros.Length; index++)
            {
                Console.WriteLine($"Número {index + 1}: {numeros[index]}");
            }


            Console.WriteLine("Presione qualquer tecla para finalizar...");
            Console.ReadKey();
        }
        //Fazer um programa que imprima a média aritmética dos números
        //8,9 e 7 A media dos números 4, 5 e 6. A soma das duas médias A//
        //media das medias //

        public static void  Media()
        {
            int media1 = (8+9+7)/3 ;

            int media2 = (4 + 5 + 6) / 3;

            Console.WriteLine($"A média entre 8,9,7 e: {media1}");

            

            Console.WriteLine($"A média entre 4, 5, 6 e : {media2}");

            

            Console.WriteLine($"A soma das 2 médias é: {media1+media2}");

        }

            //        Ler um ano de nascimento e ano atual.Imprimir a idade da
            //pessoa. Se a idade for maior ou igual a 18 leia o nome da pessoa e
            //imprima o nome digitado e uma mensagem informando que sua
            //entrada é permitida. (Ex: Fulano, sua entrada foi permitida.)
            

        public static void Ano()
        {
            string nomePessoa;
           


            Console.WriteLine("Insira o seu nome:");

            nomePessoa = Console.ReadLine();

            Console.WriteLine("Insira o seu ano de nascimento(4 digitos): ");

            

            int.TryParse(Console.ReadLine(), out int ano);

            if (ano != 0 && ano >= 999)
            {
                if (DateTime.Now.Year - ano >= 18)
                {
                    Console.WriteLine($"{nomePessoa},sua entrada foi permitida.");
                }
                else
                {
                    Console.WriteLine($"{nomePessoa},sua entrada foi negada.");

                }
            }
            else
            {
                Console.WriteLine($"{nomePessoa},sua entrada foi negada.");
            }


           



        }


            //03) Solicitar salario, perstaçao. Se prestação for maior que 20% do
            //salario, imprimir : Empréstimo não pode ser concedido.Senão
            //imprimir Empréstimo pode ser concedido.


        public static void Emprestimo()
        {
            
            

            Console.WriteLine("Inserir o seu Salario:");

            int.TryParse(Console.ReadLine(), out int salario);

            //dividir o total por 20
            Console.WriteLine("Inserir o sua Prestação:");

            int.TryParse(Console.ReadLine(), out int prestacao);

            if (prestacao != 0 && salario !=0)
            {
                int porcentagem = salario / 20;

                if (porcentagem < prestacao)
                {
                    Console.WriteLine("Empréstimo não pode ser concedido");
                }
                else
                {
                    Console.WriteLine("Empréstimo pode ser concedido.");
                }
            }
            else
            {

                Console.WriteLine("Emprestimo invalido!");
            }



        }


        //04) Informar um saldo e imprimir o saldo com reajuste de 1%.

        public static void Reajustar()
        {

            Console.WriteLine("Inserir o seu Saldo:");
            int.TryParse(Console.ReadLine(), out int saldo);

            if (saldo !=0)
            {
                Console.WriteLine($"Reajuste de 1%:{saldo += saldo / 100}");
            }
            else
            {
                Console.WriteLine("Saldo invalido!");
            }
            
        }

        //05) Informar um número e imprimir se é par ou ímpar.

        public static void Par()
        {

            Console.WriteLine("Inserir um número:");


            int.TryParse(Console.ReadLine(), out int numero);

            if (numero != 0)
            {
                if (numero % 2 == 0)
                {
                    Console.WriteLine("Esse número é par");


                }
                else
                {

                    Console.WriteLine("Esse número é ímpar");


                }
            }
            else
            {
                Console.WriteLine("Número invalido!");
            }


        }


        //        06) Ler 1 número.Se positivo, imprimir raiz quadrada senão o
        //quadrado do número.

        public static void Quadrado()
        {
            Console.WriteLine("Inserir um número:");


            int.TryParse(Console.ReadLine(), out int valor);

            if (valor != 0)
            {
                if (valor > 0)
                {
                    Console.WriteLine($"Raiz quadrada do {valor} é:{ Math.Sqrt(valor)}");
                }
                else
                {
                    Console.WriteLine($"O quadrado do numero {valor} é: {Math.Pow(valor, 2)}");

                }
            }
            else
            {
                Console.WriteLine("Número invalido!");
            }



        }

        //        07) Ler um número e imprimir igual a 20, menor que 20, maior que
        //20.

        public static void Numerar()
        {
            Console.WriteLine("Inserir um número:");


            int.TryParse(Console.ReadLine(), out int numero);

            if (numero != 0)
            {
                if (numero > 20)
                {
                    Console.WriteLine("O número inserido é maior que 20!");
                }
                else if (numero < 20)
                {
                    Console.WriteLine("O número inserido é menor que 20!");
                }
                else
                {
                    Console.WriteLine("O número inserido é maior que 20!");
                }
            }
            else
            {
                Console.WriteLine("Numero invalido!");
            }

 



        }

        //        08) Crie um algoritmo que receba 3 números e informe qual o maior
        //entre eles.

        public static void Maior()
        {
            Console.WriteLine("Insira 3 números:");

            Console.WriteLine("Primeiro número:");
            int.TryParse(Console.ReadLine(), out int num1);

            Console.WriteLine("Segundo número:");
            int.TryParse(Console.ReadLine(), out int num2);

            Console.WriteLine("Terceiro número:");
            int.TryParse(Console.ReadLine(), out int num3);


            if (num1 != 0 && num2 != 0 && num3 != 0)
            {

                int max3 = Math.Max(num1, Math.Max(num2, num3));

                Console.WriteLine($"O maior numero entre os três é: {max3}");
            }
            else
            {
                Console.WriteLine("Um dos numeros são invalidos!");
            }


        }


        //        09) Faça um algoritmo que leia dois números nas variáveis NumA e
        //NumB, nessa ordem, e imprima em ordem inversa, isto é, se os
        //dados lidos forem NumA = 5 e NumB = 9, por exemplo, devem ser
        //impressos na ordem NumA = 9 e NumB = 5

        public static void Inverter()
        {

            Console.WriteLine("Insira 2 números:");

            Console.WriteLine("Primeiro número(numA):");
            int.TryParse(Console.ReadLine(), out int numA);

            Console.WriteLine("Segundo número(numB):");
            int.TryParse(Console.ReadLine(), out int numB);


            if (numA != 0 && numB != 0)
            {
                numA += numB;

                numB = numA - numB;

                numA -= numB;

                Console.WriteLine($"Resultado do numA é:{numA}");

                Console.WriteLine($"Resultado do numB é:{numB}");

            }
            else
            {
                Console.WriteLine("Um dos numeros são invalidos!");
            }


        }


        //        10) Faça um algoritmo que leia dois números e indique se são iguais
        //ou se são diferentes.Mostre o maior e o menor (nesta sequência).

        public static void Maior2()
        {
            Console.WriteLine("Primeiro número:");
            int.TryParse(Console.ReadLine(), out int num1);

            Console.WriteLine("Segundo número:");
            int.TryParse(Console.ReadLine(), out int num2);


            if (num1 != 0 && num2 != 0)
            {
                if (num1 == num2)
                {
                    Console.WriteLine("Os 2 números são iguais!");
                }
                else
                {
                    Console.WriteLine("Os 2 números são diferentes!");

                    int max = Math.Max(num1, num2);

                    int min = Math.Min(num1, num2);

                    Console.WriteLine($"O maior numero é: {max}");

                    Console.WriteLine($"O menor numero é: {min}");


                }
            }
            else
            {
                Console.WriteLine("Um dos numeros são invalidos!");
            }



        }



    }

   
}
