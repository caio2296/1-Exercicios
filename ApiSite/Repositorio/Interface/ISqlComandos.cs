using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Repositorio.Interface
{
    public interface ISqlComandos
    {
        public IEnumerable<Usuario> SqlComandoLeituras();

        public List<Usuario> SqlComandoLeitura(int id);

        public void SqlComandoCadastar(Usuario cadastro);

        public void SqlComandoAtualizar(int id, Usuario usuarioNovosDados);

        public void SqlComandoDeletar(int id);

    }
}
