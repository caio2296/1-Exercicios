using System;
using System.Collections.Generic;
using System.Text;

namespace Exercicios_Otavio.Otavio_Exercicio1
{
    class ListaRandom
    {

        //11) crie uma lista de numeros inteiro (até 10 numeros) de forma aleatório e imprima-os...
        //Depois imprima a mesma lista em forma crescente e decrescente.

        public static void NumerosRandomizados()
        {
            //inicializar a list
            int[] listaNumeros = new int[10];
            Random rnd = new Random();

            //for 10x e imprimi-los

            Console.WriteLine("Lista de números inteiros aleatórios!");

            for (int index = 0; index < 10; index++)
            {
                listaNumeros[index] = rnd.Next(20);

                Console.WriteLine($"Número da lista {index+1} recebeu : {listaNumeros[index]}");
            }

            //imprimir em crescente e decrescente.

            //crescente
            Array.Sort(listaNumeros);
            Console.WriteLine("Lista em Ordem crescente:");
            for (int index = 0; index < listaNumeros.Length; index++)
            {
                Console.WriteLine($"Número {index + 1}: {listaNumeros[index]}");
            }


            //decrescente

            Array.Reverse(listaNumeros);

            Console.WriteLine("Lista em ordem decrescente: ");

            for (int index = 0; index < listaNumeros.Length; index++)
            {
                Console.WriteLine($"Número {index + 1}: {listaNumeros[index]}");
            }

        }

    }
}
