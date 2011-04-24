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

        }

        protected void Register_User(object sender, EventArgs e)
        {
            string username = usernameField.Text.Trim();
            string email = emailField.Text.Trim();
            string password = passwordField.Text.Trim();
            if (password.Length == 0)
            {
                Response.Write("Password may not be empty");
                return;
            }
            if (!password.Equals(confirmPassword.Text.Trim()))
            {
                Response.Write("Passwords do not match!");
                return;
            }
            using (var service = new HibernateService())
            {
                User exists = service.FindUserByUserName(username);
                if (exists != null)
                {
                    Response.Write("User already registered!");
                    return;
                }
                User user = new User();
                user.UserName = username;
                user.Email = email;
                string salt = Util.CreateSalt(Constants.SALT_SIZE);
                user.Password = Util.CreatePasswordHash(password, salt);
                service.Save(user);
                FormsAuthenticationService.SignIn(username, true);
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}