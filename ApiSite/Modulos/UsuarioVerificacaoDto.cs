using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiSite.Modulos
{
    public class UsuarioVerificacaoDto
    {
        public int id { get; set; }

        [Required]
        public string nome { get; set; }


        

        

        

        [Required]
        [Range(100000, 9999999999)]
        public int senha { get; set; }

        public int adm { get; set; }


    }
}
