using System;
using System.Security.Cryptography;
using System.Text;

namespace Web.Security
{
    public class ReferenceGenerator
    {
        static readonly RNGCryptoServiceProvider Provider = new RNGCryptoServiceProvider();
        private static readonly HashAlgorithm PasswordHasher = HashAlgorithm.Create("SHA1");

        /// <summary>
        /// Creates the random reference, using strong random provider
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public virtual string CreateReference(int length)
        {
            var buffer = new Byte[length];
            Provider.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
    }
}