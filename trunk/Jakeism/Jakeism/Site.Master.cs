using System;
using System.Web;

namespace Jakeism
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Search(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(searchbox.Text.Trim()) || searchbox.Text.Equals("Search for a Jakeism..."))
                return;
            var query = searchbox.Text.Trim();
            Response.Redirect("Search.aspx?query=" + query);
        }
    }
}
