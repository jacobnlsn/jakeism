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
    public partial class CreateEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (User.Identity.IsAuthenticated)
            {
                loggedOut.Visible = false;
                createPanel.Visible = true;
            }
        }

        protected void Create_Entry(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(entryBody.Text.Trim()))
            {
                fail.Text = "Entry field may not be empty";
                fail.Visible = true;
                return;
            }
            if (entryBody.Text.Trim().Length > 255)
            {
                fail.Text = "Entry may not exceed 255 characters";
                fail.Visible = true;
                return;
            }
            long id;
            using (var service = new HibernateService())
            {
                Entry entry = new Entry();
                User user = service.FindUserByUserName(User.Identity.Name);
                if (user != null)
                {
                    entry.EntryBody = entryBody.Text.Trim();
                    entry.User = user;
                    user.Entries.Add(entry);
                }
                service.Save(entry);
                id = entry.Id;
            }
            Response.Redirect("~/Entries/ViewEntry.aspx?id=" + id);
        }
    }
}