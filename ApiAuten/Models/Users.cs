using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAuten.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int Password { get; set; }

        public string Role { get; set; }

    }
}
