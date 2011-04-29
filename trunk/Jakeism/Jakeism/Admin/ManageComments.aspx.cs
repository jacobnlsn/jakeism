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
    public partial class ManageComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Admin)this.Master).checkIfAdmin(Page);
            if (!IsPostBack)
            {
                PopulateComments(Request.QueryString["type"], Request.QueryString["id"]);
            }
        }

        private void PopulateComments(string type, string tempId)
        {
            List<Comment> allComments = null;
            List<Comment> returnComments = new List<Comment>();
            using (var service = new HibernateService())
            {

                long id = 0;
                if (tempId != null)
                {
                    id = Int64.Parse(tempId);
                }

                allComments = (List<Comment>)service.GetAllRecords<Comment>();

                if (type == "entry")
                {
                    foreach (Comment currentComment in allComments)
                    {
                        if (currentComment.Entry.Id == id)
                        {
                            returnComments.Add(currentComment);
                        }
                    }
                }
                if (type == "user")
                {
                    foreach (Comment currentComment in allComments)
                    {
                        if (currentComment.User.Id == id)
                        {
                            returnComments.Add(currentComment);
                        }
                    }
                }
                comments.DataSource = returnComments;
                comments.DataBind();
            }
        }

        protected void Delete_Comments(object sender, EventArgs e)
        {
            List<ListViewDataItem> theComments = (List<ListViewDataItem>)comments.Items;
            foreach (ListViewDataItem currentEntry in theComments)
            {
                CheckBox box = (CheckBox)currentEntry.FindControl("check");
                Button button = (Button)currentEntry.FindControl("ModifyButton");
                string id = button.CommandArgument;
                if (box.Checked)
                {
                    using (var service = new HibernateService())
                    {
                        Comment toDelete = (Comment)service.FindById(Int64.Parse(id), typeof(Comment));
                        service.Delete(toDelete);
                    }
                }
            }
            PopulateComments(Request.QueryString["type"], Request.QueryString["id"]);
        }

        protected void Modify_Comment(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("ManageComment.aspx?id=" + button.CommandArgument);
        }
    }
}