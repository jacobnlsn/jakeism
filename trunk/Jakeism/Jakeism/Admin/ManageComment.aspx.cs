using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Service;
using BusinessLayer.Domain;

namespace Jakeism.Admin
{
    public partial class ManageComment : System.Web.UI.Page
    {

        protected long Id
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ((Admin)this.Master).checkIfAdmin(Page);

            using (var service = new HibernateService())
            {
                Comment comment = null;
                if (Request.QueryString["id"] != null)
                {
                    long id = Int64.Parse(Request.QueryString["id"]);
                    comment = service.FindById<Comment>(id);
                }
                if (comment == null)
                {
                    title.Text = "Jakeism Not Found";
                    commentBody.Visible = false;
                    submit.Visible = false;
                }
                else
                {
                    Id = comment.Id;
                    title.Text = "<h2>Jakeism #" + comment.Id + "</h2>";
                    if (!IsPostBack)
                    {
                        commentBody.Text = comment.CommentBody;
                    }
                }
            }
        }

        protected void Modify_Comment(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(commentBody.Text.Trim()))
            {
                fail.Text = "Entry field may not be empty";
                fail.Visible = true;
                return;
            }
            if (commentBody.Text.Trim().Length > 255)
            {
                fail.Text = "Entry may not exceed 255 characters";
                fail.Visible = true;
                return;
            }
            using (var service = new HibernateService())
            {
                Comment comment = (Comment)service.FindById(Id, typeof(Comment));
                comment.CommentBody = commentBody.Text.Trim();
                service.SaveOrUpdate(comment);
                commentBody.Text = comment.CommentBody;
            }


        }
    }
}