namespace PressStart.Dtos.Response
{
    public class ExcecaoResponse
    {
        public ExcecaoResponse(int errorRef, string message, int statusCode = 500)
        {
            this.errorRef = errorRef;
            this.message = message;
            this.statusCode = statusCode;
        }

        public int errorRef { get; private set; }
        public string message { get; private set; }
        public int statusCode { get; private set; }
    }
}