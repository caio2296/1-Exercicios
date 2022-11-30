using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ApiSite.Repositorio.Interface;
using ApiSite.Modulos;

namespace ApiSite
{
    public class SqlRepositorioUsuario : ISqlRepositorio
    {
        //criar uma interface com esses metodos 



        public IEnumerable<UsuarioDto> SqlComandoLeituras()
        {


            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand("select id ,nome, idade, endereco, email, senha, adm from Usuario", conexao))
                {

                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {
                            UsuarioDto usuario = new UsuarioDto();


                            usuario.nome = leitor["nome"].ToString();
                            usuario.idade = int.Parse(leitor["idade"].ToString());
                            usuario.endereco = leitor["endereco"].ToString();
                            usuario.email = leitor["email"].ToString();
                            usuario.senha = int.Parse(leitor["senha"].ToString());
                            usuario.adm = int.Parse(leitor["adm"].ToString());




                            usuarios.Add(usuario);

                        }

                    }

                    //teste
                    return usuarios.Select(x => new UsuarioDto { nome = x.nome, email = x.email });
                }


            }


        }


        public List<UsuarioDto> SqlComandoLeitura(int id)
        {
            UsuarioDto usuario = new UsuarioDto();

            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand($" select nome, idade, endereco, email, senha, adm from Usuario  where id ={id}", conexao))
                {

                    List<UsuarioDto> usuarios = new List<UsuarioDto>();
                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {

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


        public void SqlComandoCadastar(UsuarioVerificacaoDto cadastro)
        {


            string connectionString =
              @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {
                // consertar a tabela para não aceitar valores nulos 
                using (var comando = new SqlCommand(

                    $"insert into Usuario(nome,   senha)" +
                    $" values('{cadastro.nome}',{cadastro.senha})", conexao))
                {

                    conexao.Open();


                    comando.ExecuteNonQuery();



                }
            }
        }


        public void SqlComandoAtualizar(int id, UsuarioDto usuarioNovosDados)
        {


            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";



            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand(
                    $"update Usuario set idade = {usuarioNovosDados.idade} ," +
                     $" endereco = '{usuarioNovosDados.endereco}' ,senha = {usuarioNovosDados.senha}" +
                      $" where id ={id}", conexao))
                {



                    comando.ExecuteNonQuery();



                }
            }
        }


        public void SqlComandoDeletar(int id)
        {
            string connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand(
                    $"delete from Usuario where id = {id} ", conexao))
                {


                    comando.ExecuteNonQuery();



                }

            }

        }

        public UsuarioVerificacaoDto SqlComandoVerificarUsuario(UsuarioVerificacaoDto model)
        {

            UsuarioVerificacaoDto usuario = new UsuarioVerificacaoDto();

            string connectionString =
               @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RegistroUsuario;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (var conexao = new SqlConnection(
               connectionString))
            {

                using (var comando = new SqlCommand($" select nome, email, senha, adm from Usuario  where nome ='{model.nome}' and senha ={model.senha}", conexao))
                {


                    conexao.Open();


                    using (SqlDataReader leitor = comando.ExecuteReader())
                    {
                        while (leitor.Read())
                        {

                            usuario.nome = leitor["nome"].ToString();
                           
                            usuario.senha = int.Parse(leitor["senha"].ToString());
                            usuario.adm = int.Parse(leitor["adm"].ToString());





                        }

                    }

                    return usuario;


                }
            }
        }
    }
}
