using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace ApiTestCaio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaioApiController : ControllerBase
    {

         
        //Get

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ConexaoSql.SqlGets();

        }




        [HttpGet("{id_pessoa}")]
        public ActionResult<string> Get(int id_pessoa)
        {
            return ConexaoSql.SqlGet(id_pessoa);

        }




        //Post

        [HttpPost]
        public ActionResult<string> Post([FromBody] object value)
        {
            string mensagem = "";

            //INSERT INTO pessoa (id_pessoa,nome,idade) values (4,'Renato', 15);

            //            {
            //                "pessoa": {
            //                    "id_pessoa": "5",
            // "nome" : "Caio",
            // "idade": "10"



            //}
            //            }

            
            try
            {


                string pessoa = value.ToString();

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(pessoa);

                ConexaoSql.SqlPost(myDeserializedClass);

                

                return mensagem = "Dados inseridos com sucesso!";

                

            }
            catch (NullReferenceException ex)
            {

                return mensagem= ex.Message;
                throw;
            }
            catch (Exception)
            {
                return mensagem = "Ocorreu um erro!";
                throw;
            }

            

           



        }



        //Put

        [HttpPut("{id_pessoa}")]
        public void Put(int id_pessoa, [FromBody] object value)
        {

            //UPDATE pessoa SET nome = 'Caio Cesar', idade = 21
            //WHERE id_pessoa = 1

            string pessoa = value.ToString();

            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(pessoa);

            ConexaoSql.SqlPut(id_pessoa, myDeserializedClass);

        }

       


        //Delete

        [HttpDelete("{id_pessoa}")]
        public void Delete(int id_pessoa)
        {
            //DELETE FROM pessoa WHERE id_pessoa=4;

           ConexaoSql.SqlDelete(id_pessoa);

        }

    }




}


