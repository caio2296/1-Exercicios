using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ApiSite.Repositorio.Interface;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Routing;
using ApiSite.Modulos;
using Microsoft.AspNetCore.Authorization;
using ApiSite.Service.Interface;

namespace ApiSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiSiteController : ApiControllerBase
    {


        
        private readonly ITokenService _TokenService;


        private readonly ISqlRepositorio _RepositioDeUsuario;
        

        public ApiSiteController(ISqlRepositorio repositorio, ITokenService tokenService) :base(repositorio)
        {
            _RepositioDeUsuario = repositorio;

            _TokenService = tokenService;
        }


        [HttpGet]
        [Route("/adm")]
        [Authorize(Roles ="1")]
        public ActionResult<IEnumerable<UsuarioDto>> Get()
        {

           
            return ResponseGet(this._RepositioDeUsuario.SqlComandoLeituras());
            
        }


        [HttpGet("{id}")]
        public ActionResult<List<UsuarioDto>> Get(int id)
        {

            return ResponseGet(this._RepositioDeUsuario.SqlComandoLeitura(id));
        }



        [HttpPost]
        public ActionResult<UsuarioVerificacaoDto> Post([FromBody] UsuarioVerificacaoDto cadastro)
        {

            var jsonPessoa = JsonConvert.SerializeObject(cadastro);
            

            UsuarioVerificacaoDto pessoaCadastrando = JsonConvert.DeserializeObject<UsuarioVerificacaoDto>(jsonPessoa);


             return ResponsePost(pessoaCadastrando);
        }




        [HttpPatch("{id}")]
        public ActionResult<string> Patch(int id, [FromBody] UsuarioDto novosDados) {


            string jsonPessoa = JsonConvert.SerializeObject(novosDados);



            UsuarioDto pessoaAtualizando = JsonConvert.DeserializeObject<UsuarioDto>(jsonPessoa);


            return ResponsePutPatch(id, pessoaAtualizando);

           
            

        }


        [HttpDelete("{id}")]
        public ActionResult<UsuarioVerificacaoDto> Delete(int id)
        {

            return ResponseDelete(id);


        }




        [HttpPost]
        [Route("/login")]
        [AllowAnonymous]
        public ActionResult<string> Autenticar([FromBody] UsuarioVerificacaoDto model)
        {

            var a = model;

            if (ModelState.IsValid)
            {
                var usuario = _RepositioDeUsuario.SqlComandoVerificarUsuario(model);


                if (usuario == null)
                {
                    NotFound(new { message = "usuario ou senha invalidos!" });
                }
                //concertar aqui 
                var token = _TokenService.GenerateToken(usuario);
                model.senha = 0;

                return new
                {
                    usuario = usuario,
                    token = token
                }.ToString();
            }

            return BadRequest(new { message = "usuario ou senha invalidos!" });
        }




    }
}
