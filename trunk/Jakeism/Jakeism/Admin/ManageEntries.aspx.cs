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
            // TODO
        }

        protected void Update_Entries(object sender, EventArgs e)
        {
            // TODO
        }

        protected void Modify_Entry(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Response.Redirect("ManageEntry.aspx?id=" + button.CommandArgument);
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