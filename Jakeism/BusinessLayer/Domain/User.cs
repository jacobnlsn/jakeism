using System;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;

namespace BusinessLayer.Domain
{
    public class User : DomainBase
    {
        private string userName;

        private string password;

        private string emailAddress;

        private bool isAdmin;

        private DateTime dateRegistered;

        private ISet<Entry> entries;

        private ISet<Comment> comments;

        private ISet<Entry> votes;

        private ISet<Entry> favorites;

        public User()
        {
            dateRegistered = DateTime.Now;
            this.entries = new HashedSet<Entry>();
            this.votes = new HashedSet<Entry>();
        }

        public virtual string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        public virtual string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public virtual string Email
        {
            get { return this.emailAddress; }
            set { this.emailAddress = value; }
        }

        public virtual Boolean IsAdmin
        {
            get { return this.isAdmin; }
            set { this.isAdmin = value; }
        }

        public virtual DateTime DateRegistered
        {
            get { return this.dateRegistered; }
            set { this.dateRegistered = value; }
        }

        public virtual ISet<Entry> Entries
        {
            get { return this.entries; }
            set { this.entries = value; }
        }

        public virtual ISet<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ISet<Entry> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ISet<Entry> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
    }
}
