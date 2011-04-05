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

        private User usr;

        private DateTime date;

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

    }
}
