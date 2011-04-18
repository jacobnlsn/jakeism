using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Service;
using BusinessLayer.Util;
using BusinessLayer.Domain;

namespace Jakeism.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        public void checkIfAdmin(Page page)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();


            if (page.User.Identity.IsAuthenticated)
            {
                string username = page.User.Identity.Name;
                using (var service = new HibernateService())
                {
                    User user = service.FindUserByUserName(username);
                    if (!user.IsAdmin)
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}