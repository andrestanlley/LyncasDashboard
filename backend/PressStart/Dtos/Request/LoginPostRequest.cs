using System.ComponentModel.DataAnnotations;
using PressStart.Constants;


namespace PressStart.Dtos.Request
{
    public class LoginPostRequest
    {
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Email { get; set; }
        [Required(ErrorMessage = Aviso.NULL_LABEL)]
        public string Senha { get; set; }
    }
}