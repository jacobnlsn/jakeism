﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Domain;

namespace BusinessLayer.Service
{
    public interface IHibernateService : IDisposable
    {
        #region Persistence

        void Save(DomainBase entity);

        void SaveOrUpdate(DomainBase entity);

        void Delete(DomainBase entity);

        void Delete(long id, Type type);

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

        IList<T> Search<T>(string query) where T : DomainBase;

        #endregion

        IList<DomainBase> GetAllRecords(Type type);

        IList<T> GetAllRecords<T>() where T : DomainBase;

    }
}
