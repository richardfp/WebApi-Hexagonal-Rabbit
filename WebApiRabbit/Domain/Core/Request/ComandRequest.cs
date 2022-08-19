namespace WebApiRabbit.Domain.Core.Request
{
    public class ComandRequest
    {
        public string nome { get; set; }
        public string id { get; set; }
        public string dataAtual { get; set; }

        public ComandRequest(MyRequest req)
        {


            this.nome = req.nome + " " + new Random().Next().ToString();
            this.id = Guid.NewGuid().ToString();
            this.dataAtual = DateTime.Now.ToString();

        }
    }
}
