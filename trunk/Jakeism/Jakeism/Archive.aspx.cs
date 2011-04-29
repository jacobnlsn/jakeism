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
            if (!string.IsNullOrEmpty(Request.QueryString["sort"]))
            {
                string order = Request.QueryString["sort"];
                if (order.Equals("Comments", StringComparison.OrdinalIgnoreCase))
                    sortList.SelectedIndex = 3;
                else if (order.Equals("Votes", StringComparison.OrdinalIgnoreCase))
                    sortList.SelectedIndex = 1;
                else if (order.Equals("Favorites", StringComparison.OrdinalIgnoreCase))
                    sortList.SelectedIndex = 2;
                else if (order.Equals("User", StringComparison.OrdinalIgnoreCase))
                    sortList.SelectedIndex = 4;
                else
                    sortList.SelectedIndex = 0;
            }
        }

        protected void Sort_Changing(object sender, EventArgs e)
        {
            string order = sortList.SelectedValue;
            Response.Redirect(Request.Url.AbsolutePath + "?sort=" + order);
        }
    }
}