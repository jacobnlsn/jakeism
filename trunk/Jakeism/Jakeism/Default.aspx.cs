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

        protected int Count
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Count = 0;
            using (var service = new HibernateService())
            {
                entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Date);
                entries.DataBind();

                foreach (var currentItem in entries.Items)
                {
                    ((ImageButton)currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-unclicked.png";
                    ((ImageButton)currentItem.FindControl("thumb")).ToolTip = "Vote Up";
                    ((ImageButton)currentItem.FindControl("star")).ImageUrl = "images/favorite-unclicked.png";
                    ((ImageButton)currentItem.FindControl("star")).ToolTip = "Add to Favorites";
                }

                if (!User.Identity.IsAuthenticated) return;
                CurrentUser = service.FindUserByUserName(User.Identity.Name);
                foreach (var currentItem in entries.Items)
                {
                    if (CurrentUser.Votes.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                    {
                        ((ImageButton) currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-clicked.png";
                        ((ImageButton) currentItem.FindControl("thumb")).ToolTip = "Remove Vote";
                    }
                    if (CurrentUser.Favorites.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                    {
                        ((ImageButton) currentItem.FindControl("star")).ImageUrl = "images/favorite-clicked.png";
                        ((ImageButton)currentItem.FindControl("star")).ToolTip = "Remove from Favorites";
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
                    User theUser = service.FindUserByUserName(User.Identity.Name);
                    Entry theEntry = (Entry)service.FindById(Int64.Parse(button.CommandArgument), typeof(Entry));
                    if (theEntry.Votes.Contains(theUser))
                    {
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ImageUrl = "images/thumbsup-unclicked.png";
                        theEntry.RemoveVote(theUser);
                        ((Label)entries.Items[int.Parse(button.CommandName)].FindControl("votes")).Text = theEntry.Votes.Count.ToString();
                    }
                    else
                    {
                        theEntry.AddVote(theUser);
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ImageUrl = "images/thumbsup-clicked.png";
                        ((Label)entries.Items[int.Parse(button.CommandName)].FindControl("votes")).Text = theEntry.Votes.Count.ToString();
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
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
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ImageUrl = "images/favorite-unclicked.png";
                    }
                    else
                    {
                        theEntry.AddFavorite(theUser);
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ImageUrl = "images/favorite-clicked.png";
                    }
                    service.SaveOrUpdate(theEntry);
                }
            }
            else
            {
                Response.Redirect("Register.aspx");
            }
        }
    }
}