using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite
{
    public class Verificacao
    {
        //depois criar uma classe para esse metodo
        public static int ContarDigitosIdadeESenha(int numero)
        {

            int contador = 0;
            while (numero != 0)
            {
                numero = numero / 10;
                contador++;

            }

            return contador;
        }


        public static bool VerificarCadastro(Usuario cadastro)
        {
            return cadastro.nome != null
                                    && cadastro.nome != ""
                                     && cadastro.idade != 0
                                      && cadastro.idade >= 18
                                       && Verificacao.ContarDigitosIdadeESenha(cadastro.idade) >= 2
                                        && Verificacao.ContarDigitosIdadeESenha(cadastro.idade) <= 3
                                         && cadastro.endereco != null
                                          && cadastro.endereco != ""
                                           && cadastro.email != null
                                            && cadastro.email != ""
                                             && cadastro.senha >= 0
                                              && cadastro.senha != 0
                                               && Verificacao.ContarDigitosIdadeESenha(cadastro.senha) >= 6;
        }


        public static bool VerificarAtualizacaoUsuario(Usuario usuarioNovosDados, List<Usuario> usuarioAntigosDados)
        {
            return (usuarioNovosDados.idade != 0)
                                     && usuarioNovosDados.idade != int.Parse(usuarioAntigosDados[2].ToString())
                                      && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.idade) >= 2
                                       && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.idade) <= 3
                                        && usuarioNovosDados.endereco != null
                                         && usuarioNovosDados.endereco != ""
                                          && usuarioNovosDados.endereco.ToString() != usuarioAntigosDados[3].ToString()
                                           && usuarioNovosDados.senha != 0
                                            && usuarioNovosDados.senha != int.Parse(usuarioAntigosDados[5].ToString())
                                             && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.senha) >= 6;
        }



    }
}
