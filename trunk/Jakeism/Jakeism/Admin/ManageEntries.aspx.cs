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
    public partial class ManageEntries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Admin)this.Master).checkIfAdmin(Page);
            if (!IsPostBack)
            {
                PopulateEntries();
            }
        }

        protected void Delete_Entries(object sender, EventArgs e)
        {
            List<ListViewDataItem> theEntries = (List<ListViewDataItem>)entries.Items;
            foreach (ListViewDataItem currentEntry in theEntries)
            {
                CheckBox box = (CheckBox)currentEntry.FindControl("check");
                Button button = (Button)currentEntry.FindControl("ModifyButton");
                string id = button.CommandArgument;
                if (box.Checked)
                {
                    using (var service = new HibernateService())
                    {
                        Entry toDelete = (Entry)service.FindById(Int64.Parse(id), typeof(Entry));
                        service.Delete(toDelete);
                    }
                }
            }
            PopulateEntries();
        }

        protected void Modify_Entry(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("ManageEntry.aspx?id=" + button.CommandArgument);
        }

        protected void View_Comments(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("ManageComments.aspx?type=entry&id=" + button.CommandArgument);
        }

        private void PopulateEntries()
        {
            using (var service = new HibernateService())
            {
                entries.DataSource = service.GetAllRecords(typeof(Entry));
                entries.DataBind();
            }
        }
    }
}