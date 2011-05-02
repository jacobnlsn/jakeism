using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jakeism
{
    public partial class Archive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sort_Changing(object sender, EventArgs e)
        {
            string order = sortList.SelectedValue;
            Response.Redirect("Archive.aspx?sort=" + order);
        }
    }
}