using ApiSite.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Repositorio.Interface
{
    public interface ISqlRepositorio
    {
        public IEnumerable<UsuarioDto> SqlComandoLeituras();

        public List<UsuarioDto> SqlComandoLeitura(int id);

        public void SqlComandoCadastar(UsuarioVerificacaoDto cadastro);

        public void SqlComandoAtualizar(int id, UsuarioDto usuarioNovosDados);

        public void SqlComandoDeletar(int id);


        public UsuarioVerificacaoDto SqlComandoVerificarUsuario(UsuarioVerificacaoDto usuario);
        



    }
}
