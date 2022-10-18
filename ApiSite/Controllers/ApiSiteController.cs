using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using ApiSite.Repositorio.Interface;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace ApiSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiSiteController : ControllerBase
    {

        private readonly ISqlComandos RepositioDeUsuario;


        public ApiSiteController(ISqlComandos repositorio)
        {
            RepositioDeUsuario = repositorio;
        }


        [HttpGet]
        //[Route("adm")]
        public IEnumerable<Usuario> Get()
        {
             
            
            return this.RepositioDeUsuario.SqlComandoLeituras();
        }


        [HttpGet("{id}")]
        public IEnumerable<Usuario> Get(int id)
        {
            

            return this.RepositioDeUsuario.SqlComandoLeitura(id);
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] Usuario cadastro)
        {

            var jsonPessoa = JsonConvert.SerializeObject(cadastro);
            

            Usuario pessoaCadastrando = JsonConvert.DeserializeObject<Usuario>(jsonPessoa);


            try
            {
                this.RepositioDeUsuario.SqlComandoCadastar(pessoaCadastrando);
                Mensagem.RegistrarMensagem("Registrado com sucesso!");
            }
            catch (Exception ex)
            {

                Mensagem.RegistrarMensagem(ex.Message);
            }



            return Mensagem.mensagem;



        }




        [HttpPatch("{id}")]
        public ActionResult<string> Patch(int id, [FromBody] Usuario novosDados) {


            string jsonPessoa = JsonConvert.SerializeObject(novosDados);

      
            
            Usuario pessoaAtualizando = JsonConvert.DeserializeObject<Usuario>(jsonPessoa);

            try
            {
                this.RepositioDeUsuario.SqlComandoAtualizar(id, pessoaAtualizando);

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
                this.RepositioDeUsuario.SqlComandoDeletar(id);

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
