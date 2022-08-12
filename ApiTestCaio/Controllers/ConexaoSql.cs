using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace ApiTestCaio.Controllers
{
    public class ConexaoSql
    {

        //GETS: Pega todos os valores menos o Id
        public static IEnumerable<string> SqlGets()
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


        //GET: PEGA O ULTIMO Id para o auto incremento do Post
        public static int SlqGetsId()
        {
            int ids = 0;
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

        //Get: Pega um registro
        public static ActionResult<string> SqlGet(int id_pessoa)
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


        //Post: Fazer o registro
        public static void SqlPost(Root myDeserializedClass)
        {

            int ids = SlqGetsId();

            IEnumerable<string> enumerable = SqlGets();

            using (var conexao = new SqlConnection())
            {
                conexao.ConnectionString =
@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Pessoa;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                if (myDeserializedClass == null)
                {
                    throw new NullReferenceException("Referencia nula");

                }


                using (SqlCommand comando =
                    new SqlCommand(
                        @$"INSERT INTO pessoa (id_pessoa,nome,idade) values ({ids + 1},'{myDeserializedClass.pessoa.nome}', {myDeserializedClass.pessoa.idade})", conexao))
                {


                    conexao.Open();
                    comando.ExecuteNonQuery();






                }

            }
        }

        //Put: faz a atualização
        public static void SqlPut(int id_pessoa, Root myDeserializedClass)
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


        //Delete: deleta o registro
        public static void SqlDelete(int id_pessoa)
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
