using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer.Domain;
using BusinessLayer.Service;
using BusinessLayer.Util;

namespace Jakeism
{
    public partial class EntryList : System.Web.UI.UserControl
    {
        protected bool IsSearch
        {
            get;
            set;
        }

        protected string Query
        {
            get;
            set;
        }

        protected Constants.SORT_ORDER SortOrder
        {
            get;
            set;
        }

        protected User CurrentUser
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
            IsSearch = false;
            BindData();
            foreach (var currentItem in entries.Items)
            {
                ((ImageButton)currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-unclicked.png";
                ((ImageButton)currentItem.FindControl("thumb")).ToolTip = "Vote Up";
                ((ImageButton)currentItem.FindControl("star")).ImageUrl = "images/favorite-unclicked.png";
                ((ImageButton)currentItem.FindControl("star")).ToolTip = "Add to Favorites";
            }
            if (!Parent.Page.User.Identity.IsAuthenticated) return;
            using (var service = new HibernateService())
            {
                CurrentUser = service.FindUserByUserName(Parent.Page.User.Identity.Name);
                foreach (var currentItem in entries.Items)
                {
                    if (CurrentUser.Votes.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                    {
                        ((ImageButton)currentItem.FindControl("thumb")).ImageUrl = "images/thumbsup-clicked.png";
                        ((ImageButton)currentItem.FindControl("thumb")).ToolTip = "Remove Vote";
                    }
                    if (CurrentUser.Favorites.Contains(service.FindById(Int64.Parse(((HiddenField)currentItem.FindControl("HiddenId")).Value), typeof(Entry))))
                    {
                        ((ImageButton)currentItem.FindControl("star")).ImageUrl = "images/favorite-clicked.png";
                        ((ImageButton)currentItem.FindControl("star")).ToolTip = "Remove from Favorites";
                    }
                }
            }
        }

        protected void BindData()
        {
            using (var service = new HibernateService())
            {
                if (!String.IsNullOrEmpty(Request.QueryString["query"]))
                {
                    IsSearch = true;
                    Query = Request.QueryString["query"];
                    entries.DataSource = service.Search<Entry>(Query).OrderByDescending(n => n.Date);
                    entries.DataBind();
                    return;
                }
                if (!String.IsNullOrEmpty(Request.QueryString["sort"]))
                {
                    string order = Request.QueryString["sort"];
                    if (order.Equals("votes", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.VOTES;
                    else if (order.Equals("favorites", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.FAVORITES;
                    else if (order.Equals("comments", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.COMMENTS;
                    else
                        SortOrder = Constants.SORT_ORDER.DATE;
                    switch (SortOrder)
                    {
                        case Constants.SORT_ORDER.VOTES:
                            entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Votes.Count);
                            break;
                        case Constants.SORT_ORDER.FAVORITES:
                            entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Favorites.Count);
                            break;
                        case Constants.SORT_ORDER.COMMENTS:
                            entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Comments.Count);
                            break;
                        case Constants.SORT_ORDER.DATE:
                            entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Date);
                            break;
                    }
                    entries.DataBind();
                    return;
                }
                else if (Request.Url.AbsolutePath.Contains("TopEntries.aspx"))
                {
                    entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Votes.Count);
                    entries.DataBind();
                    return;
                }
                else
                {
                    entries.DataSource = service.GetAllRecords<Entry>().OrderByDescending(n => n.Date);
                    entries.DataBind();
                    return;
                }
            }
        }

        protected void Cast_Vote(object sender, EventArgs e)
        {
            if (Parent.Page.User.Identity.IsAuthenticated)
            {
                ImageButton button = (ImageButton)sender;
                using (var service = new HibernateService())
                {
                    User theUser = service.FindUserByUserName(Parent.Page.User.Identity.Name);
                    Entry theEntry = (Entry)service.FindById(Int64.Parse(button.CommandArgument), typeof(Entry));
                    if (theEntry.Votes.Contains(theUser))
                    {
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ImageUrl = "images/thumbsup-unclicked.png";
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ToolTip = "Vote Up";
                        theEntry.RemoveVote(theUser);
                        ((Label)entries.Items[int.Parse(button.CommandName)].FindControl("votes")).Text = theEntry.Votes.Count.ToString();
                    }
                    else
                    {
                        theEntry.AddVote(theUser);
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ImageUrl = "images/thumbsup-clicked.png";
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("thumb")).ToolTip = "Remove Vote";
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
            if (Parent.Page.User.Identity.IsAuthenticated)
            {
                ImageButton button = (ImageButton)sender;
                using (var service = new HibernateService())
                {
                    Entry theEntry = (Entry)service.FindById(Int64.Parse(button.CommandArgument), typeof(Entry));
                    User theUser = service.FindUserByUserName(Parent.Page.User.Identity.Name);
                    if (theEntry.Favorites.Contains(theUser))
                    {
                        theEntry.RemoveFavorite(theUser);
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ImageUrl = "images/favorite-unclicked.png";
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ToolTip = "Add to Favorites";
                    }
                    else
                    {
                        theEntry.AddFavorite(theUser);
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ImageUrl = "images/favorite-clicked.png";
                        ((ImageButton)entries.Items[int.Parse(button.CommandName)].FindControl("star")).ToolTip = "Remove from Favorites";
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