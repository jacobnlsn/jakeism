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

        protected int Index
        {
            get;
            set;
        }

        private int TotalCount
        {
            get;
            set;
        }

        private int PageCount
        {
            get;
            set;
        }

        private string Order
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Count = 0;
            IsSearch = false;
            Index = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                int i;
                if (int.TryParse(Request.QueryString["page"], out i))
                {
                    if (i > 0)
                        Index = (i - 1) * Constants.PAGE_SIZE;
                }
            }
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
                List<Entry> data = null;
                if (!String.IsNullOrEmpty(Request.QueryString["query"]))
                {
                    IsSearch = true;
                    Query = Request.QueryString["query"];
                    data = service.Search<Entry>(Query).OrderByDescending(n => n.Date).ToList();
                }
                else if (!String.IsNullOrEmpty(Request.QueryString["sort"]))
                {
                    Order = Request.QueryString["sort"];
                    if (Order.Equals("votes", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.VOTES;
                    else if (Order.Equals("favorites", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.FAVORITES;
                    else if (Order.Equals("comments", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.COMMENTS;
                    else if (Order.Equals("user", StringComparison.OrdinalIgnoreCase))
                        SortOrder = Constants.SORT_ORDER.USER;
                    else
                        SortOrder = Constants.SORT_ORDER.DATE;
                    switch (SortOrder)
                    {
                        case Constants.SORT_ORDER.VOTES:
                            data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Votes.Count).ToList();
                            break;
                        case Constants.SORT_ORDER.FAVORITES:
                            data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Favorites.Count).ToList();
                            break;
                        case Constants.SORT_ORDER.COMMENTS:
                            data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Comments.Count).ToList();
                            break;
                        case Constants.SORT_ORDER.DATE:
                            data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Date).ToList();
                            break;
                        case Constants.SORT_ORDER.USER:
                            data = service.GetAllRecords<Entry>().OrderBy(n => n.User.UserName).ToList();
                            break;
                    }
                }
                else if (Request.Url.AbsolutePath.Contains("TopEntries.aspx"))
                {
                    data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Votes.Count).ToList();
                    var top = data.Take(Constants.PAGE_SIZE);
                    PageCount = top.Count();
                    entries.DataSource = top;
                    entries.DataBind();
                    return;
                }
                else
                {
                    data = service.GetAllRecords<Entry>().OrderByDescending(n => n.Date).ToList();
                }
                TotalCount = data.Count;
                var selection = data.Skip(Index).Take(Constants.PAGE_SIZE);
                PageCount = selection.Count();
                entries.DataSource = selection;
                entries.DataBind();
                return;
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

        // TODO
        protected void PrintPagination()
        {
            if (PageCount == 0 || TotalCount <= Constants.PAGE_SIZE) return;
            var pageCount = (TotalCount + Constants.PAGE_SIZE - 1) / Constants.PAGE_SIZE;
            if (pageCount <= Constants.PAGINATION_SIZE)
            {
                for (var i = 0; i < pageCount; i++)
                    PrintPaginationIndex(i);
            }
            else
            {
                const int halfRange = Constants.PAGINATION_SIZE / 2;
                var idx = Index / Constants.PAGE_SIZE;
                if (idx <= halfRange)
                {
                    for (var i = 0; i < Constants.PAGINATION_SIZE; i++)
                        PrintPaginationIndex(i);
                    if (pageCount > Constants.PAGINATION_SIZE)
                    {
                        PrintPaginationSkip(Constants.PAGINATION_SIZE);
                        PrintPaginationToEnd(pageCount);
                    }
                }
                else if (idx + 1 + halfRange >= pageCount)
                {
                    if (idx - halfRange - 1 >= 0)
                        PrintPaginationToStart();
                    if (idx - halfRange - 1 > 0)
                        PrintPaginationSkip(idx - halfRange - 1);
                    for (var i = idx - halfRange; i < pageCount; i++)
                        PrintPaginationIndex(i);
                    
                }
                else
                {
                    if (idx - halfRange - 1 >= 0)
                        PrintPaginationToStart();
                    if (idx - halfRange - 1 > 0)
                        PrintPaginationSkip(idx - halfRange - 1);
                    for (var i = idx - halfRange; i < idx + halfRange + 1; i++)
                        PrintPaginationIndex(i);
                    if (idx + halfRange < pageCount)
                        PrintPaginationSkip(idx + halfRange + 1);
                    if (idx + halfRange <= pageCount)
                        PrintPaginationToEnd(pageCount);
                }
            }
        }

        private void PrintPaginationIndex(int i)
        {
            if (IsSearch)
            {
                Response.Write(i == Index / Constants.PAGE_SIZE
                                   ? string.Format("<a class='selected' href='{0}?query={1}&page={2}'>{3}</a>",
                                                   Request.Url.AbsolutePath, Query, i + 1, i + 1)
                                   : string.Format("<a href='{0}?query={1}&page={2}'>{3}</a>",
                                                   Request.Url.AbsolutePath, Query, i + 1, i + 1));
            }
            else if (Request.Url.AbsolutePath.Contains("Archive.aspx"))
            {
                if (string.IsNullOrEmpty(Order))
                    Order = "Date";
                Response.Write(i == Index / Constants.PAGE_SIZE
                                   ? string.Format("<a class='selected' href='{0}?sort={1}&page={2}'>{3}</a>",
                                                   Request.Url.AbsolutePath, Order, i + 1, i + 1)
                                   : string.Format("<a href='{0}?sort={1}&page={2}'>{3}</a>",
                                                   Request.Url.AbsolutePath, Order, i + 1, i + 1));
            }
            else
            {
                Response.Write(i == Index / Constants.PAGE_SIZE
                                   ? string.Format("<a class='selected' href='{0}?page={1}'>{2}</a>",
                                                   Request.Url.AbsolutePath, i + 1,
                                                   i + 1)
                                   : string.Format("<a href='{0}?page={1}'>{2}</a>", Request.Url.AbsolutePath,
                                                   i + 1,
                                                   i + 1));
            }
        }

        private void PrintPaginationSkip(int i)
        {
            if (IsSearch)
            {
                Response.Write(string.Format("<a href='{0}?query={1}&page={2}'>...</a>", Request.Url.AbsolutePath, Query, i + 1));
            }
            else if (Request.Url.AbsolutePath.Contains("Archive.aspx"))
            {
                if (string.IsNullOrEmpty(Order))
                    Order = "Date";
                Response.Write(string.Format("<a href='{0}?sort={1}&page={2}'>...</a>", Request.Url.AbsolutePath, Order, i + 1));
            }
            else
            {
                Response.Write(string.Format("<a href='{0}?page={1}'>...</a>", Request.Url.AbsolutePath, i + 1));
            }
        }

        private void PrintPaginationToStart()
        {
            if (IsSearch)
            {
                Response.Write(string.Format("<a href='{0}?query={1}&page={2}'><<</a>", Request.Url.AbsolutePath, Query, 1));
            }
            else if (Request.Url.AbsolutePath.Contains("Archive.aspx"))
            {
                if (string.IsNullOrEmpty(Order))
                    Order = "Date";
                Response.Write(string.Format("<a href='{0}?sort={1}&page={2}'><<</a>", Request.Url.AbsolutePath, Order, 1));
            }
            else
            {
                Response.Write(string.Format("<a href='{0}?page={1}'><<</a>", Request.Url.AbsolutePath, 1));
            }
        }

        private void PrintPaginationToEnd(int pageCount)
        {
            if (IsSearch)
            {
                Response.Write(string.Format("<a href='{0}?query={1}&page={2}'>>></a>", Request.Url.AbsolutePath, Query, pageCount));
            }
            else if (Request.Url.AbsolutePath.Contains("Archive.aspx"))
            {
                if (string.IsNullOrEmpty(Order))
                    Order = "Date";
                Response.Write(string.Format("<a href='{0}?sort={1}&page={2}'>>></a>", Request.Url.AbsolutePath, Order, pageCount));
            }
            else
            {
                Response.Write(string.Format("<a href='{0}?page={1}'>>></a>", Request.Url.AbsolutePath, pageCount));
            }
        }
    }
}