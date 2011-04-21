using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                Entry entry = null;
                if (Request.QueryString["id"] != null)
                {
                    long id = Int64.Parse(Request.QueryString["id"]);
                    entry = service.FindById<Entry>(id);
                }
                if (entry == null)
                {
                    title.Text = "Jakeism Not Found";
                    body.Visible = false;
                    postedBy.Visible = false;
                    commentslbl.Visible = false;
                    commentsList.Visible = false;
                    commentPanel.Visible = false;
                }
                else
                {
                    Id = entry.Id;
                    title.Text = "<h2>Jakeism #" + entry.Id + "</h2>";
                    body.Text = entry.EntryBody;
                    postedBy.Text = "<i>Posted by <a href='../Users/ViewUser.aspx?id=" + entry.User.Id + "'>" + entry.User.UserName + "</a> on " + entry.Date + "</i>";
                    IList<Comment> data = service.GetCommentsByEntry(entry);
                    commentsList.DataSource = data;
                    commentsList.DataBind();
                    if (data.Count > 0)
                        commentslbl.Text += " (" + data.Count + ")";
                }
                if (User.Identity.IsAuthenticated && entry != null)
                    commentPanel.Visible = true;
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
                Comment comment = new Comment();
                comment.CommentBody = commentBox.Text.Trim();
                Entry entry = service.FindById<Entry>(Id);
                comment.Entry = entry;
                User user = service.FindUserByUserName(User.Identity.Name);
                comment.User = user;
                entry.Comments.Add(comment);
                service.Save(comment);
                IList<Comment> data = service.GetCommentsByEntry(entry);
                commentsList.DataSource = data;
                commentsList.DataBind();
                if (data.Count > 0)
                    commentslbl.Text += " (" + data.Count + ")";
                Response.Redirect(Request.Url.AbsoluteUri, false);
            }
        }
    }
}