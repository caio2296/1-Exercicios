using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTestCaio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        const string connectionString = @"aaaa";

        [HttpGet]
        public IEnumerable<string> Get()
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlCommand comando =
                    new SqlCommand(@"select nome, idade from pessoa", conexao))
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


        [HttpGet("{id_pessoa}")]
        public ActionResult<string> Get(int id_pessoa)
        {
            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                using (SqlCommand comando =
                    new SqlCommand(@$"select nome, idade from pessoa where id_pessoa ={id_pessoa}", conexao))
                {

                    string Pessoa="";
                    conexao.Open();
                    var leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {

                        Pessoa=(leitor[0].ToString()) + " " + (leitor[1].ToString());
                        

                    }


                    return Pessoa;


                }

            }

        }



        [HttpPost]
        public void Post([FromBody] int id_pessoa, string nome, int idade)
        {
            //INSERT INTO pessoa (id_pessoa,nome,idade) values (4,'Renato', 15);

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                    //            {
                    //                "pessoa": {
                    //                    "id_pessoa": "5",
                    // "nome" : "Caio",
                    // "idade": "10"
                    


                    //}
                    //            }


                using (SqlCommand comando =
                    new SqlCommand(@$"INSERT INTO pessoa (id_pessoa,nome,idade) values ({id_pessoa},'{nome}', {idade})", conexao))
                {

                    string Pessoa = "";
                    conexao.Open();
                     comando.ExecuteNonQuery();






                }

            }
        }
        [HttpPut("{id_pessoa}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        [HttpDelete("{id_pessoa}")]
        public void Delete(int id_pessoa)
        {
            //DELETE FROM pessoa WHERE id_pessoa=4;

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
