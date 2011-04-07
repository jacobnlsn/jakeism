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

        #endregion

        public IList<DomainBase> GetAllRecords(Type type)
        {
            return HibernateDAO.GetAllRecords(type);
        }

    }
}
