using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ApiSite
{
    public class Usuario
    {
        
        public int id { get; set; }

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
        [Range(100000,9999999999)]
        public int senha { get; set; }


        public int adm { get; set; }


    }
}




