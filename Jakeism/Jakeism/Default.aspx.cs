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
        private User CurrentUser
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            using (var service = new HibernateService())
            {
                entries.DataSource = service.GetAllRecords(typeof(Entry)).Reverse();
                entries.DataBind();

                foreach (ListViewDataItem currentItem in entries.Items)
                {
                    ((ImageButton)currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-unclicked-" + ((HiddenField)currentItem.FindControl("HiddenTier")).Value + ".gif";
                    ((ImageButton)currentItem.FindControl("star")).ImageUrl = "images/favorite-unclicked.png";
                }

                if (User.Identity.IsAuthenticated)
                {
                    CurrentUser = service.FindUserByUserName(User.Identity.Name);
                    foreach (ListViewDataItem currentItem in entries.Items)
                    {
                        if(CurrentUser.Votes.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                        {
                            ((ImageButton)currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-clicked-" + ((HiddenField)currentItem.FindControl("HiddenTier")).Value + ".gif";
                        }
                        if (CurrentUser.Favorites.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                        {
                            ((ImageButton)currentItem.FindControl("star")).ImageUrl = "images/favorite-clicked.png";
                        }
                    }
                }
            }
        }

        protected void Cast_Vote(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                ImageButton button = (ImageButton)sender;
                using (var service = new HibernateService())
                {
                    Entry theEntry = (Entry)service.FindById(Int64.Parse(button.CommandArgument), typeof(Entry));
                    User theUser = service.FindUserByUserName(User.Identity.Name);
                    if (theEntry.Votes.Contains(theUser))
                    {
                        theEntry.RemoveVote(theUser);
                    }
                    else
                    {
                        theEntry.AddVote(theUser);
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void Cast_Favorite(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                ImageButton button = (ImageButton)sender;
                using (var service = new HibernateService())
                {
                    Entry theEntry = (Entry)service.FindById(Int64.Parse(button.CommandArgument), typeof(Entry));
                    User theUser = service.FindUserByUserName(User.Identity.Name);
                    if (theEntry.Favorites.Contains(theUser))
                    {
                        theEntry.RemoveFavorite(theUser);
                    }
                    else
                    {
                        theEntry.AddFavorite(theUser);
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
            Response.Redirect(Request.Url.AbsoluteUri);
        }

    }
}