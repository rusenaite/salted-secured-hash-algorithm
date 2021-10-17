using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SaltedSecuredHashAlgorithm
{
    public class Hash
    {
        public const int LENGTH = 16;

        /// <summary>
        /// Method generates salt string which will be added to the user password.
        /// </summary>
        /// <returns> If generating went well, returns a string, otherwise - 
        /// an empty string. </returns>
        public static string GenerateSaltString()
        {
            char[] characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!#$%&'()*+,-./:;<=>?@[]^_`{|}~".ToCharArray();
            
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();

            byte[] data = new byte[LENGTH];

            crypto.GetNonZeroBytes(data);

            StringBuilder result = new(LENGTH);
            foreach (byte b in data)
            {
                result.Append(characters[b % (characters.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Method concatenates passed log in password with generated salt string.
        /// </summary>
        /// <param name="logIn"></param>
        /// <returns> If concatenation went well, returns concatenated string,
        /// otherwise - an empty string. </returns>
        public static string SaltPassword(LogInfo logIn)
        {
            string salt = GenerateSaltString();
            string saltedPass = string.Concat(logIn.Password, salt);
            return saltedPass;
        }

        /// <summary>
        /// Method generates hash string for a passed algorithm (in this case
        /// for an MD5 algorithm).
        /// 
        /// How it works:
        /// Computes hash from pass(word) parameter; gets hash value in array of bytes;
        /// returns a hex string.
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="pass"></param>
        /// <returns> If generating went well, returns hash string, otherwise - 
        /// an empty string. </returns>
        public static string GenerateHashString(MD5CryptoServiceProvider algorithm, string pass)
        {
            algorithm.ComputeHash(Encoding.UTF8.GetBytes(pass));

            var result = algorithm.Hash;

            return string.Join(string.Empty, result.Select(x => x.ToString("x2")));
        }

        /// <summary>
        /// Method hashes passed salted password with MD5 hash value
        /// by using cryptographic service provider.       
        /// </summary>
        /// <param name="saltedPass"></param>
        /// <returns> If hashing went well, returns hashed string, otherwise - 
        /// an emty string. </returns>
        public static string HashedSaltedPass(string saltedPass)
        {
            string result = default;

            using (var algorithm = new MD5CryptoServiceProvider())
            {
                result = GenerateHashString(algorithm, saltedPass);
            }

            return result;
        }

        /// <summary>
        /// Method hashes a list of passwords with a salt string.
        /// </summary>
        /// <param name="list"></param>
        /// <returns> If hashing went well, returns hashed data list,
        /// otherwise - an empty list. </returns>
        public static List<LogInfo> HashData(List<LogInfo> list)
        {
            List<LogInfo> hashedList = new();

            list.ToList().ForEach(x =>
            {
                string salted = SaltPassword(x);
                LogInfo log = new LogInfo(x.UserName, HashedSaltedPass(salted));
                hashedList.Add(log);
            });

            return hashedList;
        }
    }
}
