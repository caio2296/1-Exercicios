
//// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Pessoa
{
    public int id_pessoa { get; set; }
    public string nome { get; set; }
    public int idade { get; set; }
}
public class Root
{
    public Pessoa pessoa { get; set; }
}