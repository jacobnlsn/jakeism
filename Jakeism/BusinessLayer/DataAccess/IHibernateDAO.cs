using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Domain;

namespace BusinessLayer.DataAccess
{
    public interface IHibernateDAO
    {
        void Commit();

        #region Persistence

        void Save(DomainBase entity);

        void SaveOrUpdate(DomainBase entity);

        void Delete(DomainBase entity);

        #endregion

        #region Searching

        DomainBase FindById(long id, Type type);

        T FindById<T>(long id) where T : DomainBase;

        User FindUserByUserName(string username);

        #endregion

        #region Relationships

        IList<Entry> GetEntriesByUser(User user);

        IList<Comment> GetCommentsByUser(User user);

        IList<Comment> GetCommentsByEntry(Entry entry);

        #endregion

        IList<DomainBase> GetAllRecords(Type type);

    }
}
