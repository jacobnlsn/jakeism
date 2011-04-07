using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Service;
using BusinessLayer.Domain;

namespace Jakeism
{
    public partial class _Default : System.Web.UI.Page
    {

        HibernateService service = new HibernateService();

        protected void Page_Load(object sender, EventArgs e)
        {
            ListOfEntries.DataSource = service.GetAllRecords(typeof(Entry));
            ListOfEntries.DataBind();
        }

        protected void SubmitEntry_Click(object sender, EventArgs e)
        {
            Entry newEntry = new Entry();
            newEntry.Date = DateTime.Now;
            newEntry.EntryBody = JakeismEntry.Text;
            newEntry.User = null;
            service.Save(newEntry);
        }
    }
}
