using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ApiSite.Repositorio.Interface;


namespace ApiSite
{
    public class SqlComandosUsuario: ISqlComandos
    {
        //criar uma interface com esses metodos 



        public  IEnumerable<Usuario> SqlComandoLeituras()
        {
            

            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand("select id ,nome, idade, endereco, email, senha, adm from Usuario", conexao))
                {

                    List<Usuario> usuarios = new List<Usuario>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            Usuario usuario = new Usuario(); 

                            usuario.id = int.Parse(leitor["id"].ToString());
                            usuario.nome = leitor["nome"].ToString();
                            usuario.idade = int.Parse(leitor["idade"].ToString());
                            usuario.endereco = leitor["endereco"].ToString();
                            usuario.email = leitor["email"].ToString();
                            usuario.senha = int.Parse(leitor["senha"].ToString());
                            usuario.adm = int.Parse(leitor["adm"].ToString());

                            

                            usuarios.Add(usuario);

                        }
                     
                    }

                    return usuarios;
                }


            }


        }


        public  IEnumerable<Usuario> SqlComandoLeitura(int id)
        {
            Usuario usuario = new Usuario();

            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand($"select select nome, idade, endereco, email, adm from Usuario; from Usuario where id ={id}", conexao))
                {

                    List<Usuario> usuarios = new List<Usuario>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            usuario.id = int.Parse(leitor["id"].ToString());
                            usuario.nome = leitor["nome"].ToString();
                            usuario.idade = int.Parse(leitor["idade"].ToString());
                            usuario.endereco = leitor["endereco"].ToString();
                            usuario.email = leitor["email"].ToString();
                            usuario.senha = int.Parse(leitor["senha"].ToString());
                            usuario.adm =int.Parse(leitor["adm"].ToString());



                            usuarios.Add(usuario);

                        }

                    }

                    return usuarios;
                }


            }

        }


        public  void SqlComandoCadastar(Usuario cadastro)
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

        
        public  void SqlComandoAtualizar(int id, Usuario usuarioNovosDados)
        {
            SqlComandosUsuario comandos = new SqlComandosUsuario();

            string connectionString = 
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            List<Usuario> usuarioAntigosDados = new List<Usuario>();

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand(
                    $"update Usuario set idade = {usuarioNovosDados.idade} ," +
                     $" endereco = '{usuarioNovosDados.endereco}' ,senha = {usuarioNovosDados.senha}" +
                      $" where id ={id}",conexao))
                {


                    usuarioAntigosDados = comandos.SqlComandoLeitura(id).ToList();

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

       
        public  void SqlComandoDeletar(int id)
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
