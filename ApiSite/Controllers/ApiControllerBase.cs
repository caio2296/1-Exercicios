using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSite.Repositorio.Interface;
using ApiSite.Modulos;

namespace ApiSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {

        private readonly ISqlRepositorio _RepositorioDeUsuario;

        

        public ApiControllerBase(ISqlRepositorio repositorioDeUsuario )
        {
            _RepositorioDeUsuario = repositorioDeUsuario;
            

        }


        protected ActionResult<T> ResponseGet<T>(T resultado)
        {
            if (resultado == null)
            {
                return NotFound();
            }

            return Ok(resultado);

        }

        protected ActionResult<Usuario> ResponsePost(Usuario result)
        {
           

            if (ModelState.IsValid)
            {
                if (result == null)
                    return NoContent();


                this._RepositorioDeUsuario.SqlComandoCadastar(result);
                return Created("http://localhost:56894", result);
            }


            return BadRequest();
        }



        protected ActionResult ResponsePutPatch(int id, UsuarioDto novoUsuario)
        {
           

            IEnumerable<UsuarioDto> usuarioAntigosDados = new List<UsuarioDto>();
            usuarioAntigosDados = _RepositorioDeUsuario.SqlComandoLeitura(id);

            if (Verificacao.VerificarAtualizacaoUsuario(novoUsuario, usuarioAntigosDados))
            {
                this._RepositorioDeUsuario.SqlComandoAtualizar(id, novoUsuario);
                return NoContent();
            }
            

            return BadRequest(new ValidationProblemDetails());

        }



        protected ActionResult<Usuario> ResponseDelete(int id)
        {
           var itemUsuario = this._RepositorioDeUsuario.SqlComandoLeitura(id);
            if (id > 0)
            {
                if (itemUsuario == null)
                    //
                    return NoContent();
                
                this._RepositorioDeUsuario.SqlComandoDeletar(id);
                return Ok(itemUsuario);
            }

           

            return BadRequest(new ValidationProblemDetails());
        }

    }





}

