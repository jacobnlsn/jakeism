using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Entry : DomainBase
    {
        private string entryBody;

        private User user;

        private DateTime date;

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

        public virtual ISet<User> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual void AddVote(User vote)
        {
            this.votes.Add(vote);
        }

        public virtual string ToString()
        {
            return this.entryBody;
        }
    }
}
