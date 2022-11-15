using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Modulos
{
    public class UsuarioDto
    {



        [Required]
        public string nome { get; set; }


        [Required]
        [Range(0, 130)]
        public int idade { get; set; }

        [Required]
        public string endereco { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        [Range(100000, 9999999999)]
        public int senha { get; set; }




    }
}
