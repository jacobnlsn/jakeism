using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
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
            string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, Constants.HASH);
            hashedPwd = String.Concat(hashedPwd, salt);
            return hashedPwd;
        }

        public static bool IsEmail(string inputEmail)
        {
            const string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            var re = new Regex(strRegex);
            return re.IsMatch(inputEmail);
        }

        public static void SendEmail(string subject, string message, string toEmail)
        {
            var mail = new MailMessage {From = new MailAddress(Constants.CREDENTIALS_USERNAME)};
            mail.To.Add(toEmail);
            mail.Subject = subject;
            mail.Body = message;
            var smtp = new SmtpClient(Constants.SMTP_SERVER);
            var credentials = new NetworkCredential(Constants.CREDENTIALS_USERNAME, Constants.CREDENTIALS_PASSWORD);
            smtp.Credentials = credentials;
            smtp.Send(mail); 
        }
    }
}
