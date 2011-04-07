using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using BusinessLayer.Domain;
using BusinessLayer.Util;

namespace BusinessLayer.DataAccess
{
    public class HibernateDAO : IHibernateDAO
    {
        ISession Session;

        public HibernateDAO()
        {
            // TODO: exception handling
            Session = HibernateUtil.GetSessionFactory().OpenSession();
        }

        public void Commit()
        {
            Session.Flush();
            Session.Close();
        }

        #region Persistence

        public void Save(DomainBase entity)
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Save(entity);
                tx.Commit();
            }
        }

        public void SaveOrUpdate(DomainBase entity)
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                tx.Commit();
            }
        }

        public void Delete(DomainBase entity)
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Delete(entity);
                tx.Commit();
            }
        }

        #endregion

        public IList<DomainBase> GetAllRecords(Type type)
        {
            string query = "from " + type.Name;
            return Session.CreateQuery(query).List<DomainBase>();
        }
    }
}
