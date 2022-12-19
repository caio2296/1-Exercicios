using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonToC
{
    class ClasseB
    {

        [JsonProperty("nome")]
        public string nome { get; set; }

        [JsonProperty("idade")]
        public int idade { get; set; }


    }
}
