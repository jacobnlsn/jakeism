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

        public override string ToString()
        {
            return this.entryBody;
        }
    }
}
