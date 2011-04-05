using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.Web.Security;
using BusinessLayer.Domain;

namespace BusinessLayer.Util
{
    public class Util
    {
        public static IEnumerable<Type> GetAllTypes()
        {
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && !t.IsAbstract && t.Namespace == "BusinessLayer.Domain"
                    select t;
            return q.AsEnumerable<Type>();
        }

        public static Type GetTypeByName(string name)
        {
            foreach (Type t in GetAllTypes())
            {
                if (name.ToLower().Equals(t.Name.ToLower()))
                    return t;
            }
            return null;
        }

        public static string CreateSalt(int size)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff).Substring(0, size);
        }

        public static string CreatePasswordHash(string pwd, string salt)
        {
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "SHA1");
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }
    }
}
