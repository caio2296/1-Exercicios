using ApiAuten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuten.Repositorios
{
    public class UsersRepository
    {

        public static Users Get(string nome, int passowrd)
        {
            var users = new List<Users>();

            users.Add(new Users() {Id = 1 ,Nome = "Caio", Password= 123456, Role = "gerente"});
            users.Add(new Users() { Id = 1, Nome = "Ronaldo", Password = 123456, Role = "funcionario" });

            return users.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower() && x.Password == passowrd );

        }

    }
}
