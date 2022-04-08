namespace PressStart.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public virtual Autenticacao Autenticacao { get; set; }
    }
}
