using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using BusinessLayer.Util;

namespace BusinessLayer.Domain
{
    public class Entry : DomainBase
    {
        private string entryBody;

        private User user;

        private DateTime date;

        private ISet<Comment> comments;

        private ISet<User> votes;

        private ISet<User> favorites;

        public Entry()
        {
            this.votes = new HashedSet<User>();
            date = DateTime.Now;
        }

        public virtual string EntryBody
        {
            get { return this.entryBody; }
            set { this.entryBody = value; }
        }

        public virtual User User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        public virtual DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public virtual string FormattedDate
        {
            get { return this.date.ToString("M/d/yyyy"); }
        }

        public virtual string FormattedTime
        {
            get { return this.date.AddHours(Constants.HOUR_OFFSET).ToString("h:mm tt"); }
        }

        public virtual ISet<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ISet<User> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ISet<User> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }

        public virtual string Tier
        {
            get
            {
                if (Votes.Count >= Constants.TIER_TWO)
                    return "dark";
                if (Votes.Count < Constants.TIER_TWO && Votes.Count >= Constants.TIER_ONE)
                    return "med";
                return "light";
            }
        }

        public virtual void AddVote(User vote)
        {
            this.votes.Add(vote);
        }

        public virtual void RemoveVote(User vote)
        {
            this.votes.Remove(vote);
        }

        public virtual void AddFavorite(User favorite)
        {
            this.favorites.Add(favorite);
        }

        public virtual void RemoveFavorite(User favorite)
        {
            this.favorites.Remove(favorite);
        }

        public override string ToString()
        {
            return this.entryBody;
        }
    }
}
