using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite
{
    public  class Mensagem
    {

      public static string mensagem {  get; private set; }

        public static string RegistrarMensagem(string texto)
        {
            mensagem = texto;
            return mensagem;
        }
    }
}
