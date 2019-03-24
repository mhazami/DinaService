using System.Security.Cryptography;
using System.Text;

namespace DAL.Utility
{
    public static class StringUtils
    {
        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return password;
            }

            return System.Convert.ToBase64String(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(password)));
        }
    }
}
