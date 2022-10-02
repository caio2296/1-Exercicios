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



       

        [HttpGet]
        //[Route("adm")]
        public IEnumerable<Usuario> Get()
        {
            SqlComandos comandos = new SqlComandos();

            return comandos.SqlComandoLerUsuarios();
        }


        [HttpGet("{id}")]
        public IEnumerable<Usuario> Get(int id)
        {
            SqlComandos comandos = new SqlComandos();

            return comandos.SqlComandoLerUsuario(id);
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] object cadastro)
        {
            SqlComandos comandos = new SqlComandos();

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

            SqlComandos comandos = new SqlComandos();

            string pessoa = novosDados.ToString();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(pessoa);

            try
            {
                comandos.SqlComandoAtualizarUsuario(id, usuario);

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

            SqlComandos comandos = new SqlComandos();

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
