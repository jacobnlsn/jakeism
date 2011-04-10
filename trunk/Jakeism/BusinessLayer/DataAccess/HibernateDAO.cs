using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Loader;
using BusinessLayer.Domain;
using BusinessLayer.Util;
using NHibernate.Mapping;

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

        public void Delete(long id, Type type)
        {
            using (ITransaction tx = Session.BeginTransaction())
            {
                Session.Delete(string.Format("from {0} where id = {1}", type, id));
                tx.Commit();
            }
        }

        #endregion

        #region Searching

        public DomainBase FindById(long id, Type type)
        {
            return Session.CreateCriteria(type)
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<DomainBase>();
        }

        public T FindById<T>(long id) where T : DomainBase
        {
            return Session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<T>();
        }

        public User FindUserByUserName(string username)
        {
            return Session.CreateCriteria<User>()
                .Add(Restrictions.Eq("UserName", username))
                .UniqueResult<User>();
        }

        #endregion

        #region Relationships

        public IList<Entry> GetEntriesByUser(User user)
        {
            return Session.CreateCriteria<Entry>()
                .Add(Restrictions.Eq("User", user))
                .List<Entry>();
        }

        public IList<Comment> GetCommentsByUser(User user)
        {
            return Session.CreateCriteria<Comment>()
                .Add(Restrictions.Eq("User", user))
                .List<Comment>();
        }

        public IList<Comment> GetCommentsByEntry(Entry entry)
        {
            return Session.CreateCriteria<Comment>()
                .Add(Restrictions.Eq("Entry", entry))
                .List<Comment>();
        }

        #endregion

        public IList<DomainBase> GetAllRecords(Type type)
        {
            string query = "from " + type.Name;
            return Session.CreateQuery(query).List<DomainBase>();
        }

        public IList<T> GetAllRecords<T>() where T : DomainBase
        {
            ICriteria criteria = Session.CreateCriteria<T>();
            return criteria.List<T>();
        }
    }
}
