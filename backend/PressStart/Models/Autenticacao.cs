namespace PressStart.Models
{
    public class Autenticacao
    {
        public virtual Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public int Id { get; set; }
        public string Senha { get; set;}
        public bool Estado { get; set; }
    }
}