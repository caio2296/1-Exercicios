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
        [Route("adm")]
        public IEnumerable<string> Get()
        {

            return SqlComandos.SqlComandoLerUsuarios();
        }


        [HttpGet("{id}")]
        public IEnumerable<string> Get(int id)
        {

            return SqlComandos.SqlComandoLerUsuario(id);
        }



        [HttpPost]
        public ActionResult<string> Post([FromBody] object cadastro)
        {


            string pessoa = cadastro.ToString();

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(pessoa);


            try
            {
                SqlComandos.SqlComandoCadastar(usuario);
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

            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(pessoa);

            try
            {
                SqlComandos.SqlComandoAtualizarUsuario(id, usuario);

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
                SqlComandos.SqlComandoDeletar(id);

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
