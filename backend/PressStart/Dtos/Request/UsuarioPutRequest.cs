using System.ComponentModel.DataAnnotations;
using PressStart.Constants;


namespace PressStart.Dtos.Request{
    public class UsuarioPutRequest{
        [MaxLength(100, ErrorMessage = Aviso.MAX_LENGTH)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Nome { get; set; }
        [MaxLength(100, ErrorMessage = Aviso.MAX_LENGTH)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Sobrenome { get; set; }
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        [EmailAddress(ErrorMessage = Aviso.INVALID_MAIL)]
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Email { get; set; }
        [Phone(ErrorMessage = Aviso.INVALID_LABEL)]
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        [StringLength(15, ErrorMessage = Aviso.MIN_LENGTH)]
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        [RegularExpression(@"^(?=.*)(?=.*[\d])(?=.*).{6,30}$", ErrorMessage = Aviso.INVALID_PASS)]
        public string? Senha { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public bool Estado { get; set; }
    }
}