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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            badName.Visible = false;
            badEmail.Visible = false;
            badPassword.Visible = false;
        }

        protected void Register_User(object sender, EventArgs e)
        {
            var username = usernameField.Text.Trim();
            if (String.IsNullOrEmpty(username))
            {
                badName.Text = "User name may not be empty";
                badName.Visible = true;
                return;
            }
            var email = emailField.Text.Trim();
            if (!Util.IsEmail(email))
            {
                badEmail.Visible = true;
                return;
            }
            var password = passwordField.Text.Trim();
            if (password.Length == 0)
            {
                badPassword.Text = "Password may not be empty";
                badPassword.Visible = true;
                return;
            }
            if (!password.Equals(confirmPassword.Text.Trim()))
            {
                badPassword.Visible = true;
                return;
            }
            using (var service = new HibernateService())
            {
                var exists = service.FindUserByUserName(username);
                if (exists != null)
                {
                    badName.Text = "User name is taken";
                    badName.Visible = true;
                    return;
                }
                var user = new User {UserName = username, Email = email};
                var salt = Util.CreateSalt(Constants.SALT_SIZE);
                user.Password = Util.CreatePasswordHash(password, salt);
                service.Save(user);
                FormsAuthenticationService.SignIn(username, true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}