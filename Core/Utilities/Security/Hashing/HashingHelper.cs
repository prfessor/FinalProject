using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  //encoding sınıfı verilen stringin byte değerlerini kullanmamızı sağlar.
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) //sonradan sisteme girildiğinde yapılacak işlem (string password
                                                                                                         //burada kullanıcının sonradan girdiği parola
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //sonradan girilen parolanın hashini oluşturur. 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!= passwordHash[i]) //sonradan girilen parolanın hashi ile kayıtlı parolanın hashini karşılaştırır
                    {
                        return false;
                    }
                }
                return true;
            }
            
        }
    
    
    }
}
