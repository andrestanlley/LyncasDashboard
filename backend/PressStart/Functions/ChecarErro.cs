using PressStart.Constants;

namespace PressStart.Functions
{
    public class ChecarErro
    {
        public static string HResult(int HResult, string ExMessage)
        {
            string Message = ExMessage;
            switch(HResult){
                case -2146233088:
                    Message = Aviso.INVALID_MAIL;
                    break;
                default:
                    return ExMessage;
            }
            return Message;
        }
    }
}
