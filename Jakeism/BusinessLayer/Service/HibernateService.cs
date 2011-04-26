using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.DataAccess;
using BusinessLayer.Domain;

namespace BusinessLayer.Service
{
    public class HibernateService : IHibernateService
    {
        private IHibernateDAO HibernateDAO;

        public HibernateService()
        {
            Open();
        }

        public void Dispose()
        {
            Close();
            GC.SuppressFinalize(this);
        }

        private void Open()
        {
            HibernateDAO = new HibernateDAO();
        }

        private void Close()
        {
            HibernateDAO.Commit();
        }

        #region Persistence

        public void Save(DomainBase entity)
        {
            HibernateDAO.Save(entity);
        }

        public void SaveOrUpdate(DomainBase entity)
        {
            HibernateDAO.SaveOrUpdate(entity);
        }

        public void Delete(DomainBase entity)
        {
            HibernateDAO.Delete(entity);
        }

        public void Delete(long id, Type type)
        {
            HibernateDAO.Delete(id, type);
        }

        #endregion

        #region Searching

        public DomainBase FindById(long id, Type type)
        {
            return HibernateDAO.FindById(id, type);
        }

        public T FindById<T>(long id) where T : DomainBase
        {
            return HibernateDAO.FindById<T>(id);
        }

        public User FindUserByUserName(string username)
        {
            return HibernateDAO.FindUserByUserName(username);
        }

        public IList<T> Search<T>(string query) where T : DomainBase
        {
            return HibernateDAO.Search<T>(query);
        }

        #endregion

        #region Relationships

        public IList<Entry> GetEntriesByUser(User user)
        {
            return HibernateDAO.GetEntriesByUser(user);
        }

        public IList<Comment> GetCommentsByUser(User user)
        {
            return HibernateDAO.GetCommentsByUser(user);
        }

        public IList<Comment> GetCommentsByEntry(Entry entry)
        {
            return HibernateDAO.GetCommentsByEntry(entry);
        }

        public int CountVotesReceived(User user)
        {
            return HibernateDAO.CountVotesReceived(user);
        }

        public int CountFavoritesReceived(User user)
        {
            return HibernateDAO.CountFavoritesReceived(user);
        }

        #endregion

        public IList<DomainBase> GetAllRecords(Type type)
        {
            return HibernateDAO.GetAllRecords(type);
        }

        public IList<T> GetAllRecords<T>() where T : DomainBase
        {
            return HibernateDAO.GetAllRecords<T>();
        }

    }
}
