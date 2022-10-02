using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ApiSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiSiteController : ControllerBase
    {

        string mensagem;



        [HttpGet]
        //[Route("adm")]
        public IEnumerable<Usuario> Get()
        {
            SqlComandosUsuario comandos = new SqlComandosUsuario();

            return comandos.SqlComandoLeituras();
        }


        [HttpGet("{id}")]
        public IEnumerable<Usuario> Get(int id)
        {
            SqlComandosUsuario comandos = new SqlComandosUsuario();

            return comandos.SqlComandoLeitura(id);
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] object cadastro)
        {
            SqlComandosUsuario comandos = new SqlComandosUsuario();

            string pessoa = cadastro.ToString();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(pessoa);


            try
            {
                comandos.SqlComandoCadastar(usuario);
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

            SqlComandosUsuario comandos = new SqlComandosUsuario();

            string pessoa = novosDados.ToString();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(pessoa);

            try
            {
                comandos.SqlComandoAtualizar(id, usuario);

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

            SqlComandosUsuario comandos = new SqlComandosUsuario();

            try
            {
                comandos.SqlComandoDeletar(id);

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
