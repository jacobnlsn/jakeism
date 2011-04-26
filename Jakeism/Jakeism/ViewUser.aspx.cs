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
    public partial class ViewUser : System.Web.UI.Page
    {
        protected User DomainUser
        {
            get;
            set;
        }

        protected string MemberFor
        {
            get
            {
                var span = DateTime.Now.Subtract(Registered);
                var years = span.GetYears();
                var months = span.GetMonths(years);
                var days = (int) ((span.Days - (years * Constants.YEAR_IN_DAYS)) - (months * Constants.MONTH_IN_DAYS));
                if (days == 0)
                    days = 1;
                var ret = "";
                if (years > 0)
                    ret += years == 1 ? years + " year " : years + " years ";
                if (months > 0)
                    ret += months == 1 ? months + " month " : months + " months ";
                ret += days == 1 ? days + " day " : days + " days";
                return ret;
            }
        }

        protected DateTime Registered
        {
            get;
            set;
        }

        protected int JakeismsSubmitted
        {
            get;
            set;
        }

        protected int CommentsMade
        {
            get;
            set;
        }

        protected int VotesCasted
        {
            get;
            set;
        }

        protected int FavoritesAdded
        {
            get;
            set;
        }

        protected int VotesReceived
        {
            get;
            set;
        }

        protected int FavoritesReceived
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
                    var id = Int64.Parse(Request.QueryString["id"]);
                    DomainUser = service.FindById<User>(id);
                }
                else if (Request.QueryString["user"] != null)
                {
                    var username = Request.QueryString["user"];
                    DomainUser = service.FindUserByUserName(username);
                }
                if (DomainUser == null)
                {
                    userTitle.Text = "User Not Found";
                    userPanel.Visible = false;
                }
                else
                {
                    Registered = DomainUser.DateRegistered;
                    JakeismsSubmitted = DomainUser.Entries.Count;
                    CommentsMade = DomainUser.Comments.Count;
                    VotesCasted = DomainUser.Votes.Count;
                    FavoritesAdded = DomainUser.Favorites.Count;
                    VotesReceived = service.CountVotesReceived(DomainUser);
                    FavoritesReceived = service.CountFavoritesReceived(DomainUser);
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