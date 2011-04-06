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

        private bool isAdmin;

        private DateTime dateRegistered;

        private ISet<Entry> votes;

        public User()
        {
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

        public virtual ISet<Entry> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }
    }
}
