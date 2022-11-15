using ApiSite.Modulos;
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
            //SqlComandosUsuario usuarioAntigos = new SqlComandosUsuario();

            //IEnumerable<Usuario> usuariosAntigosDados = usuarioAntigos.SqlComandoLeituras();

            //foreach (var item in usuariosAntigosDados)
            //{



            //}


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


        public static bool VerificarAtualizacaoUsuario(UsuarioDto usuarioNovosDados, IEnumerable<UsuarioDto> usuarioAntigosDados)
        {
            string idadeAntiga = usuarioAntigosDados.Select(dado => dado.idade).ToArray<int>().GetValue(0).ToString();
            string enderecoAntigo = usuarioAntigosDados.Select(dado => dado.endereco).ToArray<string>().GetValue(0).ToString();
            string senhaAntiga = usuarioAntigosDados.Select(dado => dado.senha).ToArray<int>().GetValue(0).ToString();

              return (usuarioNovosDados.idade != 0)
                                     && usuarioNovosDados.idade != int.Parse(idadeAntiga)
                                      && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.idade) >= 2
                                       && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.idade) <= 3
                                        && usuarioNovosDados.endereco != null
                                         && usuarioNovosDados.endereco != ""
                                          && usuarioNovosDados.endereco.ToString() != enderecoAntigo
                                           && usuarioNovosDados.senha != 0
                                            && usuarioNovosDados.senha != int.Parse(senhaAntiga)
                                             && Verificacao.ContarDigitosIdadeESenha(usuarioNovosDados.senha) >= 6;
        }



    }
}
