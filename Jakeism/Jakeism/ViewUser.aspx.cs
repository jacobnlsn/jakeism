using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Domain;
using BusinessLayer.Service;

namespace Jakeism.Users
{
    public partial class ViewUser : System.Web.UI.Page
    {
        protected User DomainUser
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                if (Request.QueryString["id"] != null)
                {
                    long id = Int64.Parse(Request.QueryString["id"]);
                    DomainUser = service.FindById<User>(id);
                }
                else if (Request.QueryString["user"] != null)
                {
                    string username = Request.QueryString["user"];
                    DomainUser = service.FindUserByUserName(username);
                }
                if (DomainUser == null)
                {
                    userTitle.Text = "User Not Found";
                    entrieslbl.Visible = false;
                    entries.Visible = false;
                    commentslbl.Visible = false;
                    comments.Visible = false;
                    favoriteslbl.Visible = false;
                    favorites.Visible = false;
                }
                else
                {
                    userTitle.Text = DomainUser.UserName;
                    entries.DataSource = service.GetEntriesByUser(DomainUser).OrderByDescending(n => n.Date);
                    entries.DataBind();
                    comments.DataSource = service.GetCommentsByUser(DomainUser).OrderByDescending(n => n.Date);
                    comments.DataBind();
                    favorites.DataSource = DomainUser.Favorites.OrderByDescending(n => n.Date);
                    favorites.DataBind();
                }
            }
        }
    }
}