using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ApiSite.Repositorio.Interface;

namespace ApiSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiSiteController : ControllerBase
    {

        private readonly ISqlComandos usuario;


        public ApiSiteController(ISqlComandos repositorio)
        {
            usuario = repositorio;
        }


        [HttpGet]
        //[Route("adm")]
        public IEnumerable<Usuario> Get()
        {
             

            return this.usuario.SqlComandoLeituras();
        }


        [HttpGet("{id}")]
        public IEnumerable<Usuario> Get(int id)
        {
            

            return this.usuario.SqlComandoLeitura(id);
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] object cadastro)
        {
            

            string pessoa = cadastro.ToString();

            Usuario pessoaCadastrando = JsonConvert.DeserializeObject<Usuario>(pessoa);


            try
            {
                this.usuario.SqlComandoCadastar(pessoaCadastrando);
                Mensagem.RegistrarMensagem("Registrado com sucesso!");
            }
            catch (Exception ex)
            {

                Mensagem.RegistrarMensagem(ex.Message);
            }



            return Mensagem.mensagem;



        }




        [HttpPatch("{id}")]
        public ActionResult<string> Patch(int id, [FromBody] object novosDados) {

           

            string pessoa = novosDados.ToString();

            Usuario pessoaAtualizando = JsonConvert.DeserializeObject<Usuario>(pessoa);

            try
            {
                this.usuario.SqlComandoAtualizar(id, pessoaAtualizando);

                Mensagem.RegistrarMensagem("Registrado com sucesso!");
            }
            catch (Exception ex)
            {

                Mensagem.RegistrarMensagem(ex.Message);
            }

            return Mensagem.mensagem;

        }


        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {

            

            try
            {
                this.usuario.SqlComandoDeletar(id);

                Mensagem.RegistrarMensagem("Usuario deletado com sucesso!");
            }
            catch (Exception ex)
            {

                Mensagem.RegistrarMensagem(ex.Message);
            }


            return Mensagem.mensagem;

        }


    }
}
