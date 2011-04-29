using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Service;
using BusinessLayer.Domain;
using BusinessLayer.Util;

namespace Jakeism.Admin
{
    public partial class ManageEntry : System.Web.UI.Page
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
                Entry entry = null;
                if (Request.QueryString["id"] != null)
                {
                    long id = Int64.Parse(Request.QueryString["id"]);
                    entry = service.FindById<Entry>(id);
                }
                if (entry == null)
                {
                    title.Text = "Jakeism Not Found";
                    entryBody.Visible = false;
                    submit.Visible = false;
                }
                else
                {
                    Id = entry.Id;
                    title.Text = "<h2>Jakeism #" + entry.Id + "</h2>";
                    if (!IsPostBack)
                    {
                        entryBody.Text = entry.EntryBody;
                    }
                }
            }
        }

        protected void Modify_Entry(object sender, EventArgs e)
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
            using (var service = new HibernateService())
            {
                Entry entry = (Entry)service.FindById(Id, typeof(Entry));
                entry.EntryBody = entryBody.Text.Trim();
                service.SaveOrUpdate(entry);
                entryBody.Text = entry.EntryBody;
            }

            
        }

    }
}