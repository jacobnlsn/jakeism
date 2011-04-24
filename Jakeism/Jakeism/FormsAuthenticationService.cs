using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Jakeism
{
    public class FormsAuthenticationService
    {
        public static void SignIn(string userName, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            HttpCookie cookie = HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now.Add(new TimeSpan(30, 0, 0, 0));
        }

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}