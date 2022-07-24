using System;

using System.Collections.Generic;
using System.Text;

namespace Exercicios_Otavio.Otavio_Exercicio1
{
    class ListaRandom
    {

        //11) crie uma lista de numeros inteiro (até 10 numeros) de forma aleatório e imprima-os...
        //Depois imprima a mesma lista em forma crescente e decrescente.

        private int[] listaNumeros = new int[10];

        public ListaRandom()
        {
            
            Random rnd = new Random();

            for (int index = 0; index < 10; index++)
            {
                listaNumeros[index] = rnd.Next(20);

               
            }
        }
        public int[] GetNumeros()
        {
            return listaNumeros;
        } 

    }
}
