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
            return SqlGets();

        }

        private static IEnumerable<string> SqlGets()
        {
            
            using (var conexao = new SqlConnection())
            {
               
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlCommand comando =
                    new SqlCommand(@"select nome , idade from pessoa", conexao))
                {

                    List<string> Pessoa = new List<string>();
                    conexao.Open();
                    var leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        Pessoa.Add(leitor[0].ToString());

                        Pessoa.Add(leitor[1].ToString());
                        
                        
                    }


                    return Pessoa;


                }

            }
        }


        private static int SlqGetsId()
        {
            int ids=0;
            using (var conexao = new SqlConnection())
            {

                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlCommand comando =
                    new SqlCommand(@"select * from pessoa", conexao))
                {

                   
                    conexao.Open();
                    var leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        ids = int.Parse(leitor[0].ToString());
                    }
                    
                    return ids;
                    


                }

            }



        }

        [HttpGet("{id_pessoa}")]
        public ActionResult<string> Get(int id_pessoa)
        {
            return SqlGet(id_pessoa);

        }

        private static ActionResult<string> SqlGet(int id_pessoa)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlCommand comando =
                    new SqlCommand(@$"select nome, idade from pessoa where id_pessoa ={id_pessoa}", conexao))
                {

                    string Pessoa = "";
                    conexao.Open();
                    var leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        Pessoa = (leitor[0].ToString()) + " " + (leitor[1].ToString());


                    }


                    return Pessoa;


                }

            }
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

                SqlPost(myDeserializedClass);

                

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

        private static void SqlPost(Root myDeserializedClass)
        {

            int ids = SlqGetsId();

            IEnumerable<string> enumerable = SqlGets();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                if(myDeserializedClass == null)
                {
                    throw new NullReferenceException("Referencia nula");

                }


                using (SqlCommand comando =
                    new SqlCommand(
                        @$"INSERT INTO pessoa (id_pessoa,nome,idade) values ({ids+1},'{myDeserializedClass.pessoa.nome}', {myDeserializedClass.pessoa.idade})", conexao))
                {


                    conexao.Open();
                    comando.ExecuteNonQuery();






                }

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

            SqlPut(id_pessoa, myDeserializedClass);

        }

        private static void SqlPut(int id_pessoa, Root myDeserializedClass)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";




                using (SqlCommand comando =
                    new SqlCommand(
                        @$"UPDATE pessoa SET nome = '{myDeserializedClass.pessoa.nome}', idade = {myDeserializedClass.pessoa.idade} WHERE id_pessoa = {id_pessoa} ", conexao))
                {


                    conexao.Open();
                    comando.ExecuteNonQuery();






                }

            }
        }


        //Delete

        [HttpDelete("{id_pessoa}")]
        public void Delete(int id_pessoa)
        {
            //DELETE FROM pessoa WHERE id_pessoa=4;

            SqlDelete(id_pessoa);

        }

        private static void SqlDelete(int id_pessoa)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


                using (SqlCommand comando =
                    new SqlCommand(@$"DELETE FROM pessoa WHERE id_pessoa={id_pessoa}", conexao))
                {

                    string Pessoa = "";
                    conexao.Open();
                    comando.ExecuteNonQuery();


                }

            }
        }
    }
}


