using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Domain;
using BusinessLayer.Service;
using BusinessLayer.Util;

namespace Jakeism.Users
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            fail.Visible = false;
        }

        protected void User_Login(object sender, EventArgs e)
        {
            var username = usernameField.Text.Trim();
            var password = passwordField.Text.Trim();
            using (var service = new HibernateService())
            {
                var exists = service.FindUserByUserName(username);
                if (exists != null)
                {
                    var dbPassword = exists.Password;
                    var salt = dbPassword.Substring(dbPassword.Length - Constants.SALT_SIZE);
                    var hashedPassword = Util.CreatePasswordHash(password, salt);
                    if (hashedPassword.Equals(exists.Password))
                    {
                        FormsAuthenticationService.SignIn(username, remember.Checked);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        fail.Text = "Incorrect password";
                        fail.Visible = true;
                    }
                }
                else
                {
                    fail.Text = "Account not found";
                    fail.Visible = true;
                }
            }
        }
    }
}