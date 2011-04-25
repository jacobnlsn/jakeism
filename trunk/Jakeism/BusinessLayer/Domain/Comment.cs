using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Domain
{
    public class Comment : DomainBase
    {
        private Entry entry;

        private string commentBody;

        private User user;

        private DateTime date;

        public Comment()
        {
            date = DateTime.Now;
        }

        public virtual Entry Entry
        {
            get { return this.entry; }
            set { this.entry = value; }
        }

        public virtual string CommentBody
        {
            get { return this.commentBody; }
            set { this.commentBody = value; }
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
            get { return this.date.ToString("h:mm tt"); }
        }

    }
}
