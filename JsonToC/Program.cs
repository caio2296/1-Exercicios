using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using Newtonsoft.Json;



namespace JsonToC
{
    class Program
    {
        static void Main(string[] args)
        {

            var classeA = new ClasseA()
            {
                idade = 10,
                nome = "Lucas"
            };


            string jsonConvert = @"{
                     'nome': 'caio',
                        'idade': '15'

}
            ";




            ClasseB classeBJson = Newtonsoft.Json.JsonConvert.DeserializeObject<ClasseB>(jsonConvert);

            string jsonString = System.Text.Json.JsonSerializer.Serialize(classeA);


            Console.WriteLine(classeBJson.nome);
            Console.WriteLine(classeBJson.idade);
            Console.WriteLine(jsonString);
            Console.ReadKey();



        }
    }
}
