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
    public partial class EditProfile : System.Web.UI.Page
    {
        private User CurrentUser
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                loggedOut.Visible = false;
                editPanel.Visible = true;
                using (var service = new HibernateService())
                {
                    CurrentUser = service.FindUserByUserName(User.Identity.Name);
                }
                if (CurrentUser != null && !Page.IsPostBack)
                    emailField.Text = CurrentUser.Email;
            }
        }

        protected void Edit_User(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                CurrentUser.Email = emailField.Text.Trim();
                if (!String.IsNullOrEmpty(passwordField.Text.Trim()) && passwordField.Text.Trim().Equals(confirmPassword.Text.Trim()))
                {
                    string salt = Util.CreateSalt(Constants.SALT_SIZE);
                    CurrentUser.Password = Util.CreatePasswordHash(passwordField.Text.Trim(), salt);
                }
                else if (!String.IsNullOrEmpty(passwordField.Text.Trim()) && !passwordField.Text.Trim().Equals(confirmPassword.Text.Trim()))
                {
                    matchfail.Visible = true;
                    return;
                }
                service.SaveOrUpdate(CurrentUser);
                Response.Redirect("ViewUser.aspx?id=" + CurrentUser.Id);
            }
        }
    }
}