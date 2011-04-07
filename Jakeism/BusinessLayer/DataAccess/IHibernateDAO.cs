﻿using System;
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

        IList<DomainBase> GetAllRecords(Type type);

    }
}
