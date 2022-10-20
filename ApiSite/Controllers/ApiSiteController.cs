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

namespace ApiSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiSiteController : ApiControllerBase
    {

        private readonly ISqlComandos RepositioDeUsuario;
        

        public ApiSiteController(ISqlComandos repositorio):base(repositorio)
        {
            RepositioDeUsuario = repositorio;
        }


        [HttpGet]
        //[Route("adm")]
        public ActionResult<IEnumerable<Usuario>> Get()
        {

           
            return ResponseGet(this.RepositioDeUsuario.SqlComandoLeituras());
            
        }


        [HttpGet("{id}")]
        public ActionResult<List<Usuario>> Get(int id)
        {

            return ResponseGet(this.RepositioDeUsuario.SqlComandoLeitura(id));
        }



        [HttpPost]
        public ActionResult<Usuario> Post([FromBody] Usuario cadastro)
        {

            var jsonPessoa = JsonConvert.SerializeObject(cadastro);
            

            Usuario pessoaCadastrando = JsonConvert.DeserializeObject<Usuario>(jsonPessoa);


             return ResponsePost(pessoaCadastrando);
        }




        [HttpPatch("{id}")]
        public ActionResult<string> Patch(int id, [FromBody] Usuario novosDados) {


            string jsonPessoa = JsonConvert.SerializeObject(novosDados);

      
            
            Usuario pessoaAtualizando = JsonConvert.DeserializeObject<Usuario>(jsonPessoa);


            return ResponsePutPatch(id, pessoaAtualizando);

           
            

        }


        [HttpDelete("{id}")]
        public ActionResult<Usuario> Delete(int id)
        {

            return ResponseDelete(id);


        }


    }
}
