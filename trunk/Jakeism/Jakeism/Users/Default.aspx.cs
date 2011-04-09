using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Domain;
using BusinessLayer.Service;

namespace Jakeism.Users
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                users.DataSource = service.GetAllRecords(typeof(User));
                users.DataBind();
            }
        }
    }
}