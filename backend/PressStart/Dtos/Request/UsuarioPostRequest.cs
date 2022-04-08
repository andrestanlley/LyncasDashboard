using System.ComponentModel.DataAnnotations;
using PressStart.Constants;


namespace PressStart.Dtos.Request
{
    public class UsuarioPostRequest
    {
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        [MaxLength(100, ErrorMessage = Aviso.MAX_LENGTH)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        [MaxLength(100, ErrorMessage = Aviso.MAX_LENGTH)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        [EmailAddress(ErrorMessage = Aviso.INVALID_MAIL)]
        public string Email { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        [MinLength(2, ErrorMessage = Aviso.MIN_LENGTH)]
        [Phone(ErrorMessage = Aviso.INVALID_LABEL)]
        [StringLength(15, ErrorMessage = Aviso.MIN_LENGTH)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public DateTime DataNasc { get; set; }
        [RegularExpression(@"^(?=.*)(?=.*[\d])(?=.*).{6,30}$", ErrorMessage = Aviso.INVALID_PASS)]
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Senha { get; set; }
        [Required(ErrorMessage = Aviso.NO_STATUS)]
        public bool Estado { get; set; }
    }
}