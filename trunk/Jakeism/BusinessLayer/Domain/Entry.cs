using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class Entry : DomainBase
    {
        private string entryBody;

        private User usr;

        private DateTime date;

        private ISet<User> votes;

        public Entry()
        {
            this.votes = new HashedSet<User>();
        }

        public virtual string EntryBody
        {
            get { return this.entryBody; }

            set { this.entryBody = value; }
        }

        public virtual User Usr
        {
            get { return this.usr; }

            set { this.usr = value; }
        }

        public virtual DateTime Date
        {
            get { return this.date; }

            set { this.date = value; }
        }

        public virtual ISet<User> Votess
        {
            get { return this.votes; }

            set { this.votes = value; }
        }

        public virtual void AddVote(User vote)
        {
            this.votes.Add(vote);
        }
    }
}
