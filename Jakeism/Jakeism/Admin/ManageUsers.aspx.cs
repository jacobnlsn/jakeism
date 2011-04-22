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
            ((Admin)this.Master).checkIfAdmin(Page);

            if (!IsPostBack)
            {
                PopulateUsers();
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
                    TextBox userBx = row.FindControl("username") as TextBox;
                    TextBox emailBx = row.FindControl("email") as TextBox;
                    CheckBox adminBx = row.FindControl("IsAdmin") as CheckBox;
                    TextBox passBx = row.FindControl("password") as TextBox;
                    if (checkBx.Checked)
                    {
                        User user = service.FindById<User>(id);
                        user.UserName = userBx.Text.Trim();
                        user.Email = emailBx.Text.Trim();
                        user.IsAdmin = adminBx.Checked;
                        string password = passBx.Text.Trim();
                        if (!String.IsNullOrEmpty(password))
                        {
                            string salt = Util.CreateSalt(Constants.SALT_SIZE);
                            user.Password = Util.CreatePasswordHash(password, salt);
                        }
                        service.SaveOrUpdate(user);
                    }
                }
                Response.Redirect(Request.Url.AbsoluteUri);
            }
        }

        protected void View_Comments(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            Response.Redirect("ManageComments.aspx?type=user&id=" + button.CommandArgument);
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