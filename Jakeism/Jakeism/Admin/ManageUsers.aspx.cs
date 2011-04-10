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
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (User.Identity.IsAuthenticated)
            {
                string username = User.Identity.Name;
                using (var service = new HibernateService())
                {
                    User user = service.FindUserByUserName(username);
                    if (user.IsAdmin)
                    {
                        loginPanel.Visible = false;
                        adminPanel.Visible = true;
                        if (!IsPostBack)
                            PopulateUsers();
                    }
                }
            }
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            users.EditIndex = e.NewEditIndex;
            PopulateUsers();
        }

        protected void GridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            users.EditIndex = -1;
            PopulateUsers();
        }

        protected void GridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
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
                        Response.Redirect(Request.Url.AbsoluteUri);
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

        protected void Create_User(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username.Text.Trim()) || String.IsNullOrEmpty(password.Text.Trim()) || String.IsNullOrEmpty(email.Text.Trim()))
                return;
            string name = username.Text.Trim();
            string pass = password.Text.Trim();
            string salt = Util.CreateSalt(Constants.SALT_SIZE);
            string emailAddress = email.Text.Trim();
            bool isAdm = isAdmin.Checked;
            using (var service = new HibernateService())
            {
                User user = new User();
                user.UserName = name;
                user.Password = Util.CreatePasswordHash(pass, salt);
                user.Email = emailAddress;
                user.IsAdmin = isAdm;
                service.Save(user);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Delete_Users(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                foreach (GridViewRow row in users.Rows)
                {
                    long id = long.Parse(row.Cells[1].Text);
                    CheckBox checkBx = row.FindControl("check") as CheckBox;
                    if (checkBx.Checked)
                        service.Delete(id, typeof(User));
                }
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Update_Users(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                foreach (GridViewRow row in users.Rows)
                {
                    long id = long.Parse(row.Cells[1].Text);
                    CheckBox checkBx = row.FindControl("check") as CheckBox;
                    TextBox passBx = row.FindControl("password") as TextBox;
                    if (checkBx.Checked)
                    {
                        User user = service.FindById<User>(id);
                        string password = passBx.Text.Trim();
                        string salt = Util.CreateSalt(Constants.SALT_SIZE);
                        user.Password = Util.CreatePasswordHash(password, salt);
                        service.SaveOrUpdate(user);
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        private void PopulateUsers()
        {
            using (var service = new HibernateService())
            {
                users.DataSource = service.GetAllRecords(typeof(User));
                users.DataBind();
            }
        }
    }
}