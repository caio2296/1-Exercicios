using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace ApiSite
{
    public class SqlComandos
    {

        public static IEnumerable<string> SqlComandoLerUsuarios()
        {
            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand("select * from Usuario ", conexao))
                {

                    List<string> usuario = new List<string>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            usuario.Add(leitor[0].ToString());
                            usuario.Add(leitor[1].ToString());
                            usuario.Add(leitor[2].ToString());
                            usuario.Add(leitor[3].ToString());
                            usuario.Add(leitor[4].ToString());
                            usuario.Add(leitor[5].ToString());
                            usuario.Add(leitor[6].ToString());

                        }

                    }

                    return usuario;
                }


            }


        }


        public static IEnumerable<string> SqlComandoLerUsuario(int id)
        {

            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand($"select * from Usuario where id ={id}", conexao))
                {

                    List<string> usuario = new List<string>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            usuario.Add(leitor[0].ToString());
                            usuario.Add(leitor[1].ToString());
                            usuario.Add(leitor[2].ToString());
                            usuario.Add(leitor[3].ToString());
                            usuario.Add(leitor[4].ToString());
                            usuario.Add(leitor[5].ToString());
                            usuario.Add(leitor[6].ToString());

                        }

                    }

                    return usuario;
                }


            }

        }


        public static void SqlComandoCadastar(Usuario cadastro)
        {
            string connectionString =
              @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {
                // consertar a tabela para não aceitar valores nulos 
                using (var comando = new SqlCommand(

                    $"insert into Usuario(nome, idade, endereco, email, senha)" +
                    $" values('{cadastro.nome}',{cadastro.idade},'{cadastro.endereco}','{cadastro.email}',{cadastro.senha})", conexao))
                {

                    conexao.Open();

                    if (Verificacao.VerificarCadastro(cadastro))
                    {
                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Falha ao registrar!");
                    }
                }
            }
        }

        
        public static void SqlComandoAtualizarUsuario(int id, Usuario usuarioNovosDados)
        {
            string connectionString = 
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            List<string> usuarioAntigosDados = new List<string>();

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand(
                    $"update Usuario set idade = {usuarioNovosDados.idade} ," +
                     $" endereco = '{usuarioNovosDados.endereco}' ,senha = {usuarioNovosDados.senha}" +
                      $" where id ={id}",conexao))
                {


                    usuarioAntigosDados = SqlComandos.SqlComandoLerUsuario(id).ToList();

                    if (Verificacao.VerificarAtualizacaoUsuario(usuarioNovosDados, usuarioAntigosDados))
                    {
                        comando.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Falha ao registrar!");
                    }
                }
            }
        }

       
        public static void SqlComandoDeletar(int id)
        {
            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand(
                    $"delete from Usuario where id = {id} ",conexao))
                {

                    try
                    {
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw new Exception("Falha ao deletar!");
                    }

                }

            }

        }


       

    }
}
