using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Domain
{
    public abstract class DomainBase
    {
        private long id;

        public virtual long Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
