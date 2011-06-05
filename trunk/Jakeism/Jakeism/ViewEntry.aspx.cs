using System;
using System.Collections.Generic;
using BusinessLayer.Domain;
using BusinessLayer.Service;

namespace Jakeism.Entries
{
    public partial class ViewEntry : System.Web.UI.Page
    {

        protected long Id
        {
            get;
            set;
        }

        protected string Tier
        {
            get;
            set;
        }

        protected int Votes
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                Entry entry = null;
                if (Request.QueryString["id"] != null)
                {
                    long id;
                    if (Int64.TryParse(Request.QueryString["id"], out id))
                        entry = service.FindById<Entry>(id);
                }
                if (entry == null)
                {
                    notFound.Visible = true;
                    notFoundMsg.Visible = true;
                    entryPanel.Visible = false;
                }
                else
                {
                    Id = entry.Id;
                    Tier = entry.Tier;
                    Votes = entry.Votes.Count;
                    title.Text = "Jakeism #" + entry.Id;
                    body.Text = entry.EntryBody;
                    votes.Text = Votes.ToString();
                    postedBy.Text = "posted by <a title='View User' href='ViewUser.aspx?id=" + entry.User.Id + "'>" + entry.User.UserName + "</a> on " + entry.FormattedDate + " at " + entry.FormattedTime;
                    thumb.ImageUrl = "images/thumbsup-unclicked.png";
                    thumb.ToolTip = "Vote Up";
                    star.ImageUrl = "images/favorite-unclicked.png";
                    star.ToolTip = "Add to Favorites";
                    var data = service.GetCommentsByEntry(entry);
                    commentsList.DataSource = data;
                    commentsList.DataBind();
                    if (data.Count > 0)
                        commentslbl.Text = "Comments (" + data.Count + ")";
                }
                if (!User.Identity.IsAuthenticated || entry == null) return;
                var user = service.FindUserByUserName(User.Identity.Name);
                if (user.Votes.Contains(entry))
                {
                    thumb.ImageUrl = "images/thumbsup-clicked.png";
                    thumb.ToolTip = "Remove Vote";
                }
                if (user.Favorites.Contains(entry))
                {
                    star.ImageUrl = "images/favorite-clicked.png";
                    star.ToolTip = "Remove from Favorites";
                }
                commentPanel.Visible = true;
            }
        }

        protected void Cast_Vote(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var service = new HibernateService())
                {
                    User theUser = service.FindUserByUserName(User.Identity.Name);
                    Entry theEntry = (Entry)service.FindById(Id, typeof(Entry));
                    if (theEntry.Votes.Contains(theUser))
                    {
                        thumb.ImageUrl = "images/thumbsup-unclicked.png";
                        thumb.ToolTip = "Vote Up";
                        theEntry.RemoveVote(theUser);
                        votes.Text = theEntry.Votes.Count.ToString();
                    }
                    else
                    {
                        theEntry.AddVote(theUser);
                        thumb.ImageUrl = "images/thumbsup-clicked.png";
                        thumb.ToolTip = "Remove Vote";
                        votes.Text = theEntry.Votes.Count.ToString();
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void Cast_Favorite(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                using (var service = new HibernateService())
                {
                    Entry theEntry = (Entry)service.FindById(Id, typeof(Entry));
                    User theUser = service.FindUserByUserName(User.Identity.Name);
                    if (theEntry.Favorites.Contains(theUser))
                    {
                        theEntry.RemoveFavorite(theUser);
                        star.ImageUrl = "images/favorite-unclicked.png";
                        star.ToolTip = "Add to Favorites";
                    }
                    else
                    {
                        theEntry.AddFavorite(theUser);
                        star.ImageUrl = "images/favorite-clicked.png";
                        star.ToolTip = "Remove from Favorites";
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }

        protected void Submit_Comment(Object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(commentBox.Text.Trim()))
            {
                fail.Text = "Comment may not be empty";
                fail.Visible = true;
                return;
            }
            if (commentBox.Text.Trim().Length > 255)
            {
                fail.Text = "Comment may not exceed 255 characters";
                fail.Visible = true;
                return;
            }
            using (var service = new HibernateService())
            {
                var comment = new Comment {CommentBody = commentBox.Text.Trim()};
                var entry = service.FindById<Entry>(Id);
                comment.Entry = entry;
                var user = service.FindUserByUserName(User.Identity.Name);
                comment.User = user;
                entry.Comments.Add(comment);
                service.Save(comment);
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}