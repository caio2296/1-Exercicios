using ApiSite.Modulos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Service.Interface
{
    public interface ITokenService
    {

        public  string GenerateToken(UsuarioVerificacaoDto usuario);

    }
}
