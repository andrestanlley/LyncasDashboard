using System.Security.Cryptography;
using System.Text;

namespace PressStart.Functions
{
    public class CriptografarSenha
    {
        public static string SHA1(string Senha)
        {
            UnicodeEncoding UE = new UnicodeEncoding();

            byte[] HashValue, MessageBytes = UE.GetBytes(Senha);

            SHA1Managed SHhash = new SHA1Managed();

            string strHex = "";

            HashValue = SHhash.ComputeHash(MessageBytes);

            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }

            return strHex;
        }
    }
}