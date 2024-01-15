using System.Security.Cryptography;
using System.Text;

namespace Lockley.BL.Tools
{
    public class GeneralTools
    {
		public static string URLAdjuster(string text)
		{
			return text.ToLower().Replace(" ", "-").Replace("ı", "i").Replace("ü", "u").Replace("ö", "o").Replace("ç", "c").Replace("ğ", "g").Replace("ş", "s");
		}

		public static string GetMD5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public static string OrderNumberGenerator()
        {
            Random randomNum = new Random();

            string generatedOrderNumber = (DateTime.Now.Millisecond % 10).ToString() + (DateTime.Now.Second % 10).ToString() + (DateTime.Now.Minute % 10).ToString() + (DateTime.Now.Hour % 10).ToString() + randomNum.Next(0, 10).ToString() + randomNum.Next(0, 10).ToString() + randomNum.Next(0, 10).ToString() + randomNum.Next(0, 10).ToString() + (DateTime.Now.Year % 100).ToString();

            return generatedOrderNumber;
		}
    }
}
