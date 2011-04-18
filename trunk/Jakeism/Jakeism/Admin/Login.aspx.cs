using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Domain;
using BusinessLayer.Service;
using BusinessLayer.Util;

namespace Jakeism.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Admin_Login(object sender, EventArgs e)
        {
            string username = usernameField.Text.Trim();
            string password = passwordField.Text.Trim();
            using (var service = new HibernateService())
            {
                User exists = service.FindUserByUserName(username);
                if (exists != null)
                {
                    string dbPassword = exists.Password;
                    string salt = dbPassword.Substring(dbPassword.Length - Constants.SALT_SIZE);
                    string hashedPassword = Util.CreatePasswordHash(password, salt);
                    if (hashedPassword.Equals(exists.Password) && exists.IsAdmin)
                    {
                        FormsAuthenticationService.SignIn(username, false);
                        Response.Redirect("Default.aspx");
                    }
                    else
                        fail.Text = "Unauthorized account";
                    fail.Visible = true;
                }
                else
                {
                    fail.Visible = true;
                }
            }
        }
    }
}